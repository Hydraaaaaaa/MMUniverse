/*       INFINITY CODE 2013         */
/*   http://www.infinity-code.com   */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

// ReSharper disable UnusedMember.Global
public class MeshToTerrain : EditorWindow
// ReSharper restore UnusedMember.Global
{
    public static MeshToTerrainPhase phase;

    private static int activeIndex;
    private static float progress;
    private static List<MeshToTerrainObject> terrainObjects;

    private List<Texture2D> checkedTexures;
    private Color[] colors;
    private GameObject container;
    private float[,] heightmap;
    private int lastX;
    private Material material;
    private Vector3 maxBounds = Vector3.zero;
    private Vector3 minBounds = Vector3.zero;
    private MeshToTerrainPrefs prefs = new MeshToTerrainPrefs();
    private string resultFolder;
    private List<MeshCollider> tempColliders;
    private Mesh mesh;

    private void AddTempCollider(GameObject go, bool recursive)
    {
        if (go.GetComponent<Collider>() == null) tempColliders.Add(go.AddComponent<MeshCollider>());
        if (recursive) for (int i = 0; i < go.transform.childCount; i++) AddTempCollider(go.transform.GetChild(i).gameObject, true);
    }

    private void CancelConvert()
    {
        phase = MeshToTerrainPhase.idle;
        if (container != null) DestroyImmediate(container);
        Dispose();
    }

    private bool CheckBounds(bool isFirstTime = true)
    {
        if (prefs.terrainType == MeshToTerrainSelectTerrainType.newTerrains &&
            prefs.boundsType == MeshToTerrainBounds.fromGameobject)
        {
            if (!CheckBoundsFromGameObject()) return false;
        }
        else
        {
            FindBounds();
        }

        if ((minBounds == Vector3.zero && maxBounds == Vector3.zero) || (maxBounds- minBounds).magnitude < 10)
        {
            if (isFirstTime && prefs.meshes.Count == 1)
            {
                bool result = EditorUtility.DisplayDialog("Warning", "Can not define the boundaries of the models.\nScale up GameObject in 1000 times?", "Scale up", "Cancel");
                if (result)
                {
                    prefs.meshes[0].transform.localScale *= 1000;
                    return CheckBounds(false);
                }
                return false;
            }

            DisplayDialog("Can not define the boundaries of the models.\nTry manual scale up GameObjects in 1000 times.");
            return false;
        }
        return true;
    }

    private bool CheckBoundsFromGameObject()
    {
        if (prefs.boundsGameObject == null)
        {
            DisplayDialog("Boundaries GameObject are not set.\nSelect a GameObject in the scene, which will be the boundaries to generated Terrains.");
            return false;
        }
        Renderer r = prefs.boundsGameObject.GetComponent<Renderer>();
        if (r == null)
        {
            DisplayDialog("Boundaries GameObject does not contain the Renderer component.\nSelect another GameObject.");
            return false;
        }
        minBounds = r.bounds.min;
        maxBounds = r.bounds.max;
        return true;
    }

    private bool CheckOnlySceneObjects()
    {
        GameObject[] sceneGameObjects = (GameObject[])FindSceneObjectsOfType(typeof(GameObject));

        if (prefs.meshes.Any(mesh => !sceneGameObjects.Contains(mesh)))
        {
            DisplayDialog("Added GameObjects, not contained in the scene.\nPlease add all convertibles GameObjects into the scene.");
            return false;
        }
        return true;
    }

    private void CheckReadWriteEnabled(Texture2D texture)
    {
        if (checkedTexures.Contains(texture)) return;

        string assetPath = AssetDatabase.GetAssetPath(texture);
        TextureImporter textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
        if (textureImporter != null && !textureImporter.isReadable)
        {
            textureImporter.isReadable = true;
            AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
        }

        checkedTexures.Add(texture);
    }

    private bool CheckValues()
    {
        if (prefs.meshFindType == MeshToTerrainFindType.gameObjects)
        {
            if (prefs.meshes.Count == 0)
            {
                DisplayDialog("No meshes added.");
                return false;
            }

            if (!CheckOnlySceneObjects()) return false;

            prefs.meshLayer = FindFreeLayer();
            if (prefs.meshLayer == -1)
            {
                prefs.meshLayer = 31;
                DisplayDialog("Can not find the free layer.");
                return false;
            }
        }
        else if (prefs.meshFindType == MeshToTerrainFindType.layers)
        {
            if (prefs.meshLayer == 0)
            {
                DisplayDialog("Cannot use dafault layer.\nPlace the models for conversion to another layer.");
                return false;
            }

            prefs.meshes = FindGameObjectsWithLayer(prefs.meshLayer).ToList();
        }

        if (!CheckBounds()) return false;

        if (prefs.terrainType == MeshToTerrainSelectTerrainType.newTerrains) CreateTerrainContainer();
        else if (prefs.terrains.Count == 0)
        {
            DisplayDialog("No terrains added.");
            return false;
        }
        return true;
    }

    private void CreateTerrain(int terrainIndex)
    {
        int x = terrainIndex % prefs.newTerrainCountX;
        int y = terrainIndex / prefs.newTerrainCountX;

        float w = maxBounds.x - minBounds.x;
        float h = maxBounds.z - minBounds.z;

        int sW = Mathf.RoundToInt(w / prefs.newTerrainCountX);
        int sH = Mathf.RoundToInt(h / prefs.newTerrainCountY);
        int sY = Mathf.RoundToInt((maxBounds.y - minBounds.y) * 1.5f);
        float offX = (w - sW * prefs.newTerrainCountX) / 2;
        float offY = (h - sH * prefs.newTerrainCountY) / 2;

        string terrainName = string.Format("Terrain {0}x{1}", x, y);
        GameObject terrainGO = CreateTerrainGameObject(sW, sY, sH, terrainName);

        terrainGO.name = terrainName;
        terrainGO.transform.parent = container.transform;
        terrainGO.transform.localPosition = new Vector3(x * sW + offX, 0, y * sH + offY);
        prefs.terrains.Add(terrainGO.GetComponent<Terrain>());

        activeIndex++;
        progress = activeIndex / (float)(prefs.newTerrainCountX * prefs.newTerrainCountY);
        if (activeIndex >= prefs.newTerrainCountX * prefs.newTerrainCountY)
        {
            if (prefs.terrains.Count > 1) for (int i = 0; i < prefs.terrains.Count; i++) SetTerrainNeighbors(i);

            activeIndex = 0;
            progress = 0;
            phase = MeshToTerrainPhase.generateHeightmaps;
        }
    }

    private void CreateTerrainContainer()
    {
        const string containerName = "Generated terrains";

        prefs.terrains = new List<Terrain>();

        string cName = containerName;
        int index = 1;
        while (GameObject.Find(cName) != null) cName = containerName + " " + index++;

        container = new GameObject(cName);
        container.transform.position = new Vector3(minBounds.x, minBounds.y - 5, minBounds.z);
    }

    private GameObject CreateTerrainGameObject(int sW, int sY, int sH, string terrainName)
    {
        TerrainData tdata = new TerrainData();
        tdata.SetDetailResolution(prefs.detailResolution, prefs.resolutionPerPatch);
        tdata.baseMapResolution = prefs.baseMapResolution;
        tdata.heightmapResolution = prefs.heightmapResolution;
        tdata.size = new Vector3(sW, sY, sH);
        string filename = Path.Combine(resultFolder, terrainName + ".asset");

        AssetDatabase.CreateAsset(tdata, filename);
        GameObject terrainGO = Terrain.CreateTerrainGameObject(tdata);
        return terrainGO;
    }

    private void DisplayDialog(string msg)
    {
        EditorUtility.DisplayDialog("Error", msg, "OK");
    }

    private void Dispose()
    {
        checkedTexures = null;
        colors = null;
        heightmap = null;
        lastX = 0;

        EditorUtility.UnloadUnusedAssets();
        GC.Collect();
    }

    private void FindBounds()
    {
        minBounds = Vector3.zero;
        maxBounds = Vector3.zero;

        Renderer[] renderers = prefs.meshes.SelectMany(m => m.GetComponentsInChildren<Renderer>()).ToArray();
        if (renderers.Length == 0) return;
        
        minBounds.x = renderers.Min(r => r.bounds.min.x);
        minBounds.y = renderers.Min(r => r.bounds.min.y);
        minBounds.z = renderers.Min(r => r.bounds.min.z);
        maxBounds.x = renderers.Max(r => r.bounds.max.x);
        maxBounds.y = renderers.Max(r => r.bounds.max.y);
        maxBounds.z = renderers.Max(r => r.bounds.max.z);
    }

    private int FindFreeLayer()
    {
        bool[] ls = new bool[32];

        for (int i = 0; i < 32; i++) ls[i] = true;
        foreach (GameObject go in (GameObject[])FindObjectsOfType(typeof(GameObject))) ls[go.layer] = false;

        for (int i = 31; i > 0; i--) if (ls[i]) return i;
        return -1;
    }

    private IEnumerable<GameObject> FindGameObjectsWithLayer(int layer)
    {
        return ((MeshFilter[])FindObjectsOfType(typeof(MeshFilter))).Select(m => m.gameObject).Where(go => go.layer == layer);
    }

    private void Finish()
    {
        RemoveTempColliders();
        if (prefs.meshFindType == MeshToTerrainFindType.gameObjects)
            foreach (MeshToTerrainObject m in terrainObjects) m.gameobject.layer = m.layer;

        if (prefs.terrainType == MeshToTerrainSelectTerrainType.newTerrains) EditorGUIUtility.PingObject(container);
        else foreach (Terrain t in prefs.terrains) EditorGUIUtility.PingObject(t.gameObject);

        phase = MeshToTerrainPhase.idle;
    }

    private Color GetColor(Vector3 curPoint, float raycastDistance, Vector3 raycastDirection, int mLayer,
                          ref Renderer lastRenderer, ref int[] triangles, ref Vector3[] verticles,
                          ref Vector2[] uv)
    {

        RaycastHit hit;
        if (Physics.Raycast(curPoint, raycastDirection, out hit, raycastDistance, mLayer))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer != null && renderer.sharedMaterial != null)
            {
                if (lastRenderer != renderer)
                {
                    lastRenderer = renderer;
                    material = renderer.sharedMaterial;
                    if (material.mainTexture != null)CheckReadWriteEnabled((Texture2D)material.mainTexture);
                    mesh = renderer.GetComponent<MeshFilter>().sharedMesh;
                    triangles = mesh.triangles;
                    verticles = mesh.vertices;
                    uv = mesh.uv;
                }

                int triangleIndex = hit.triangleIndex;

                if (mesh.subMeshCount > 1) 
                {
                    triangles = mesh.triangles;
                    int t1 = triangles[triangleIndex * 3];
                    int t2 = triangles[triangleIndex * 3 + 1];
                    int t3 = triangles[triangleIndex * 3 + 2];

                    bool finded = false;

                    for (int i = 0; i < mesh.subMeshCount; i++)
                    {
                        triangles = mesh.GetTriangles(i);
                        for (int j = 0; j < triangles.Length; j += 3)
                        {
                            if (triangles[j] == t1 && triangles[j + 1] == t2 && triangles[j + 2] == t3)
                            {
                                finded = true;
                                material = renderer.sharedMaterials[i];
                                triangleIndex = j / 3; 
                                break;
                            }
                        }
                        if (finded) break;
                    }
                }

                return material.mainTexture != null ? GetTextureColor(material, renderer, hit, verticles, triangles, triangleIndex, uv) : material.color;
            }
        }
        return prefs.textureEmptyColor;
    }

    private float GetValue(int X, int Y)
    {
        X = Mathf.Clamp(X, 0, prefs.heightmapResolution);
        Y = Mathf.Clamp(Y, 0, prefs.heightmapResolution);
        return heightmap[X, Y];
    }

    private double GetValuesAround(int x, int y, int offset, float scale)
    {
        double val = GetValue(x - offset, y - offset) * scale;
        val += GetValue(x, y - offset) * scale;
        val += GetValue(x + offset, y - offset) * scale;
        val += GetValue(x + offset, y) * scale;
        val += GetValue(x + offset, y + offset) * scale;
        val += GetValue(x, y + offset) * scale;
        val += GetValue(x - offset, y + offset) * scale;
        val += GetValue(x - offset, y) * scale;
        return val;
    }

    private SplatPrototype[] GetSplatPrototype(Terrain t)
    {
        Texture2D texture = new Texture2D(prefs.textureWidth, prefs.textureHeight);
        texture.SetPixels(colors);
        texture.Apply();

        string textureFilename = Path.Combine(resultFolder, t.name + ".png");
        File.WriteAllBytes(textureFilename, texture.EncodeToPNG());
        AssetDatabase.Refresh();
        TextureImporter importer = AssetImporter.GetAtPath(textureFilename) as TextureImporter;
        if (importer != null)
        {
            importer.maxTextureSize = Mathf.Max(prefs.textureWidth, prefs.textureHeight);
            AssetDatabase.ImportAsset(textureFilename, ImportAssetOptions.ForceUpdate);
        }

        texture = (Texture2D)AssetDatabase.LoadAssetAtPath(textureFilename, typeof(Texture2D));

        float tsx = prefs.textureWidth - 4;
        float tsy = prefs.textureHeight - 4;

        Vector2 tileSize = new Vector2(t.terrainData.size.x + t.terrainData.size.x / tsx * 4,
            t.terrainData.size.z + t.terrainData.size.z / tsy * 4);

        Vector2 tileOffset = new Vector2(t.terrainData.size.x / prefs.textureWidth / 2, t.terrainData.size.z / prefs.textureHeight / 2);

        SplatPrototype sp = new SplatPrototype
        {
            tileSize = tileSize,
            tileOffset = tileOffset,
            texture = texture
        };
        return new []{sp};
    }

    private void GetResultFolder()
    {
        const string baseResultFolder = "Assets/MTT_Results";
        string baseResultFullPath = Path.Combine(Application.dataPath, "MTT_Results");
        if (!Directory.Exists(baseResultFullPath)) Directory.CreateDirectory(baseResultFullPath);
        string dateStr = DateTime.Now.ToString("yyyy-MM-dd HH-mm");

        int index = 0;
        bool appendIndex = false;
        while (true)
        {
            resultFolder = baseResultFolder + "/" + dateStr;
            string resultFullPath = Path.Combine(baseResultFullPath, dateStr);

            if (appendIndex)
            {
                resultFolder += " " + index;
                resultFullPath += " " + index;
            }

            if (!Directory.Exists(resultFullPath))
            {
                Directory.CreateDirectory(resultFullPath);
                break;
            }

            appendIndex = true;
            index++;
        }
    }

    private Color GetTextureColor(Material mat, Renderer renderer, RaycastHit hit, Vector3[] verticles,
                                        int[] triangles, int triangleIndex, Vector2[] uv)
    {
        Texture2D mainTexture = (Texture2D)mat.mainTexture;
        Vector3 localPoint = renderer.transform.InverseTransformPoint(hit.point);
        int triangle = triangleIndex * 3;
        Vector3 v1 = verticles[triangles[triangle]];
        Vector3 v2 = verticles[triangles[triangle + 1]];
        Vector3 v3 = verticles[triangles[triangle + 2]];
        Vector3 f1 = v1 - localPoint;
        Vector3 f2 = v2 - localPoint;
        Vector3 f3 = v3 - localPoint;
        float a = Vector3.Cross(v1 - v2, v1 - v3).magnitude;
        float a1 = Vector3.Cross(f2, f3).magnitude / a;
        float a2 = Vector3.Cross(f3, f1).magnitude / a;
        float a3 = Vector3.Cross(f1, f2).magnitude / a;
        Vector2 textureCoord = uv[triangles[triangle]] * a1 + uv[triangles[triangle + 1]] * a2 +
                               uv[triangles[triangle + 2]] * a3;

        return mainTexture.GetPixelBilinear(textureCoord.x, textureCoord.y);
    }

    private void OnConvertGUI()
    {
        string phaseTitle = "";
        if (phase == MeshToTerrainPhase.prepare) phaseTitle = "Preparing.";
        else if (phase == MeshToTerrainPhase.createTerrains) phaseTitle = "Create terrains.";
        else if (phase == MeshToTerrainPhase.generateHeightmaps) phaseTitle = "Generate heightmaps.";
        else if (phase == MeshToTerrainPhase.generateTextures) phaseTitle = "Generate textures.";
        else if (phase == MeshToTerrainPhase.finish) phaseTitle = "Finishing.";

        GUILayout.Label(phaseTitle);

        Rect r = EditorGUILayout.BeginVertical();
        if (phase == MeshToTerrainPhase.generateHeightmaps || phase == MeshToTerrainPhase.generateTextures || phase == MeshToTerrainPhase.createTerrains)
        {
            int iProgress = Mathf.FloorToInt(progress*100);
            EditorGUI.ProgressBar(r, progress, iProgress + "%");
            GUILayout.Space(16);
        }
        else
        {
            GUILayout.Space(38);
        }

        if (GUILayout.Button("Cancel")) CancelConvert();

        EditorGUILayout.EndVertical();
    }

// ReSharper disable once UnusedMember.Local
    private void OnDestroy()
    {
        if (prefs != null) prefs.Save();
    }

// ReSharper disable once UnusedMember.Local
    private void OnDisable()
    {
        if (prefs != null) prefs.Save();
    }

// ReSharper disable once UnusedMember.Local
    private void OnEnable()
    {
        prefs = new MeshToTerrainPrefs();
        Repaint();
    }

// ReSharper disable once UnusedMember.Local
    private void OnGUI()
    {
        if (phase == MeshToTerrainPhase.idle) prefs.OnGUI();
        else OnConvertGUI();
    }

    [MenuItem("Window/Infinity Code/Mesh to Terrain", false, 2)]
// ReSharper disable once UnusedMember.Local
    private static void OpenWindow()
    {
        GetWindow<MeshToTerrain>(false, "Mesh to Terrain");
    }

    private void Prepare()
    {
        activeIndex = 0;
        checkedTexures = new List<Texture2D>();
        colors = null;
        heightmap = null;
        progress = 0;
        tempColliders = new List<MeshCollider>();
        terrainObjects = new List<MeshToTerrainObject>();

        GetResultFolder();

        if (!CheckValues())
        {
            phase = MeshToTerrainPhase.idle;
            return;
        }

        PrepareMeshes(terrainObjects);

        phase = prefs.terrainType == MeshToTerrainSelectTerrainType.newTerrains ? MeshToTerrainPhase.createTerrains : MeshToTerrainPhase.generateHeightmaps;
    }

    private void PrepareMeshes(List<MeshToTerrainObject> objs)
    {
        if (prefs.meshFindType == MeshToTerrainFindType.gameObjects)
        {
            IEnumerable<GameObject> gos = prefs.meshes.SelectMany(m => m.GetComponentsInChildren<MeshFilter>()).Select(mf => mf.gameObject);
            foreach (GameObject go in gos)
            {
                objs.Add(new MeshToTerrainObject(go));
                AddTempCollider(go, false);
                go.layer = prefs.meshLayer;
            }
        }
        else if (prefs.meshFindType == MeshToTerrainFindType.layers)
        {
            foreach (GameObject go in FindGameObjectsWithLayer(prefs.meshLayer)) AddTempCollider(go, false);
        }
    }

    private void RemoveTempColliders()
    {
        foreach (MeshCollider mc in tempColliders) DestroyImmediate(mc);
    }

    private void SetTerrainNeighbors(int i)
    {
        int leftIndex = (i % prefs.newTerrainCountX != 0) ? i - 1 : -1;
        int rightIndex = (i % prefs.newTerrainCountX != prefs.newTerrainCountX - 1) ? i + 1 : -1;
        int topIndex = i - prefs.newTerrainCountX;
        int bottomIndex = i + prefs.newTerrainCountX;
        Terrain left = (prefs.newTerrainCountX > 1 && leftIndex != -1) ? prefs.terrains[leftIndex] : null;
        Terrain right = (prefs.newTerrainCountX > 1 && rightIndex != -1) ? prefs.terrains[rightIndex] : null;
        Terrain top = (prefs.newTerrainCountY > 1 && topIndex >= 0) ? prefs.terrains[topIndex] : null;
        Terrain bottom = (prefs.newTerrainCountY > 1 && bottomIndex < prefs.terrains.Count) ? prefs.terrains[bottomIndex] : null;
        prefs.terrains[i].SetNeighbors(left, bottom, right, top);
    }

    private void SmoothHeightmap()
    {
        int h = heightmap.GetLength(0);
        float[,] smoothedHeightmap = new float[h, h];
        int sf = prefs.smoothingFactor;
        int sfStep = 1;
        if (sf > 8)
        {
            sfStep = sf / 8;
            sf = 8;
        }

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < h; j++)
            {
                float curV = 0.5f;
                double totalV = curV;
                float origVal = GetValue(i, j);
                double val = origVal * curV;

                if (i == 0 || i == h - 1 || j == 0 || j == h - 1)
                {
                    smoothedHeightmap[i, j] = origVal;
                    continue;
                }

                curV = 0.3f;
                
                for (int v = 1; v <= sf; v++)
                {
                    int v1 = v * sfStep;
                    val += GetValuesAround(i, j, v1, curV);
                    totalV += curV * 8;
                }

                smoothedHeightmap[i, j] = (float)(val / totalV);
            }
        }

        if (sfStep > 1)
        {
            heightmap = smoothedHeightmap;
            smoothedHeightmap = new float[h, h];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    float curV = 0.7f;
                    double totalV = curV;
                    double val = GetValue(i, j) * curV;

                    curV = 0.3f;
                    val += GetValuesAround(i, j, 1, curV);
                    totalV += curV * 8;
                    
                    smoothedHeightmap[i, j] = (float) (val / totalV);
                }
            }
        }

        heightmap = smoothedHeightmap;
    }

// ReSharper disable once UnusedMember.Local
    private void Update()
    {
        if (phase == MeshToTerrainPhase.idle) return;

        if (phase == MeshToTerrainPhase.prepare) Prepare();
        else if (phase == MeshToTerrainPhase.createTerrains) CreateTerrain(activeIndex);
        else if (phase == MeshToTerrainPhase.generateHeightmaps) UpdateTerrain(prefs.terrains[activeIndex]);
        else if (phase == MeshToTerrainPhase.generateTextures) UpdateTexture(prefs.terrains[activeIndex]);
        else if (phase == MeshToTerrainPhase.finish) Finish();

        Repaint();
    }

    private void UpdateTerrain(Terrain t)
    {
        int mLayer = 1 << prefs.meshLayer;
        float raycastDistance = maxBounds.y - minBounds.y + 10;

        Vector3 vScale = t.terrainData.heightmapScale;
        Vector3 beginPoint = t.transform.position;
        Vector3 raycastDirection = -Vector3.up;
        if (prefs.direction == MeshToTerrainDirection.normal) beginPoint.y += raycastDistance;
        else
        {
            beginPoint.y = maxBounds.y - raycastDistance;
            raycastDirection = Vector3.up;
        }

        if (heightmap == null)
        {
            heightmap = new float[t.terrainData.heightmapWidth, t.terrainData.heightmapHeight];
            lastX = 0;
        }

        long startTicks = DateTime.Now.Ticks;

        for (int i = lastX; i < t.terrainData.heightmapWidth; i++)
        {
            for (int j = 0; j < t.terrainData.heightmapHeight; j++)
            {
                Vector3 curPoint = beginPoint + new Vector3(i * vScale.x, 0, j * vScale.z);
                RaycastHit hit;
                if (Physics.Raycast(curPoint, raycastDirection, out hit, raycastDistance, mLayer))
                {
                    if (prefs.direction == MeshToTerrainDirection.normal) heightmap[j, i] = (raycastDistance - hit.distance) / vScale.y;
                    else heightmap[j, i] = hit.distance / vScale.y;
                }
                else heightmap[j, i] = 0;
            }

            if (new TimeSpan(DateTime.Now.Ticks - startTicks).TotalSeconds >= 1)
            {
                lastX = i;
                progress = (activeIndex + lastX / (float)t.terrainData.heightmapWidth) / prefs.terrains.Count;
                return;
            }
        }

        lastX = 0;

        if (prefs.useHeightmapSmoothing) SmoothHeightmap();

        t.terrainData.SetHeights(0, 0, heightmap);
        t.Flush();

        heightmap = null;

        activeIndex++;
        progress = activeIndex / (float)prefs.terrains.Count;
        if (activeIndex >= prefs.terrains.Count)
        {
            activeIndex = 0;
            progress = 0;
            phase = prefs.textureType == MeshToTerrainTextureType.bakeMainTextures ? MeshToTerrainPhase.generateTextures : MeshToTerrainPhase.finish;
        }
    }

    private void UpdateTexture(Terrain t)
    {
        int mLayer = 1 << prefs.meshLayer;
        float raycastDistance = maxBounds.y - minBounds.y + 10;

        Vector3 vScale = t.terrainData.size;
        Vector3 beginPoint = t.transform.position;
        Vector3 raycastDirection = -Vector3.up;
        if (prefs.direction == MeshToTerrainDirection.normal) beginPoint.y += raycastDistance;
        else
        {
            beginPoint.y = maxBounds.y - raycastDistance;
            raycastDirection = Vector3.up;
        }

        float tsx = prefs.textureWidth - 4;
        float tsy = prefs.textureHeight - 4;

        vScale.x = vScale.x / tsx;
        vScale.z = vScale.z / tsy;

        Renderer lastRenderer = null;
        Vector2[] uv = null;
        int[] triangles = null;
        Vector3[] verticles = null;

        if (colors == null)
        {
            colors = new Color[prefs.textureWidth * prefs.textureHeight];
            lastX = 0;
        }

        long startTicks = DateTime.Now.Ticks;

        //Vector3 offset = new Vector3(vScale.x * 1.5f, 0, vScale.z * 1.5f);

        for (int i = lastX; i < prefs.textureWidth; i++)
        {
            for (int j = 0; j < prefs.textureHeight; j++)
            {
                int cPos = j * prefs.textureWidth + i;
                Vector3 curPoint = beginPoint + new Vector3(i * vScale.x, 0, j * vScale.z);
                colors[cPos] = GetColor(curPoint, raycastDistance, raycastDirection, mLayer, ref lastRenderer, ref triangles, ref verticles, ref uv);
            }

            if (new TimeSpan(DateTime.Now.Ticks - startTicks).TotalSeconds >= 1)
            {
                lastX = i;
                progress = (activeIndex + lastX / (float)prefs.textureWidth) / prefs.terrains.Count;
                return;
            }
        }

        lastX = 0;
        t.terrainData.splatPrototypes = GetSplatPrototype(t);

        colors = null;
        EditorUtility.UnloadUnusedAssets();
        GC.Collect();

        activeIndex++;
        progress = activeIndex / (float)prefs.terrains.Count;
        if (activeIndex >= prefs.terrains.Count)
        {
            activeIndex = 0;
            phase = MeshToTerrainPhase.finish;
        }
    }
}

public class MeshToTerrainObject
{
    public readonly GameObject gameobject;
    public readonly int layer;

    public MeshToTerrainObject(GameObject gameObject)
    {
        gameobject = gameObject;
        layer = gameObject.layer;
    }
}

public enum MeshToTerrainBounds
{
    autoDetect,
    fromGameobject
}

public enum MeshToTerrainFindType
{
    gameObjects,
    layers
}

public enum MeshToTerrainPhase
{
    idle,
    prepare,
    createTerrains,
    generateHeightmaps,
    generateTextures,
    finish
}

public enum MeshToTerrainSelectTerrainType
{
    existTerrains,
    newTerrains
}

public enum MeshToTerrainTextureType
{
    noTexture,
    bakeMainTextures
}