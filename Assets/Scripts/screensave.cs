using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class screensave : MonoBehaviour
{

    public Camera mainCam;
    public bool showText = true;
    string path;
    public string directoryName = "Screenshots";
    string mainPath = "";
    string cName;
    int i = 0;

    void Start()
    {

        path = Application.dataPath + "/";
        mainPath = path + directoryName + "/";


        if (!Directory.Exists(mainPath))
        {
            Directory.CreateDirectory(mainPath);
        }


    }

    IEnumerator SaveScreenshot(string name)
    {


        int sw = (int)Screen.width;
        int sh = (int)Screen.height;

        RenderTexture rt = new RenderTexture(sw, sh, 0);
        mainCam.targetTexture = rt;
        Texture2D sc = new Texture2D(sw, sh, TextureFormat.RGB24, false);
        mainCam.Render();

        yield return new WaitForSeconds(0.3f);
        showText = true;


        RenderTexture.active = rt;
        sc.ReadPixels(new Rect(0, 0, sw, sh), 0, 0);
        mainCam.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        byte[] bytes = sc.EncodeToPNG();
        string finalPath = mainPath + name + ".png";
        File.WriteAllBytes(finalPath, bytes);

        yield return new WaitForSeconds(2.3f);
        showText = false;


    }

    void OnGUI()
    {

        if (showText)
        {

            GUI.Label(new Rect(100, 200, 200, 50), "Saving screen!!");

        }

    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.B) )
        {
            i++;
            cName = "Screen_" + i;
            StartCoroutine(SaveScreenshot(cName));

        }

    }


}
