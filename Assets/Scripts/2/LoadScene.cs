using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	private AsyncOperation async = null;
	private bool isLoading = false;
	public string levelName;
	public Texture backgroundBar;
	public Texture lineBar;
	public Texture GUITextureBackground;
	public Texture2D loadingtex1;
	public Texture2D loadingtex2;
	public Texture2D loadingtex3;
	public Texture2D loadingtex4;
	public Texture2D loadingtex5;
	private int texID;

    private float pRounded;
    public static int SceneNum;
    public int SceneIndex;
    public GUISkin main;
    public GUISkin Background;

    void Start()
    {
		texID = (Random.Range (1,5));
		switch (texID) {
			case 1:
				GUITextureBackground = loadingtex1;
				break;
			case 2:
				GUITextureBackground = loadingtex2;
				break;
			case 3:
				GUITextureBackground = loadingtex3;
				break;
			case 5:
				GUITextureBackground = loadingtex4;
				break;
			default:
				GUITextureBackground = loadingtex5;
				break;
		}
        StartCoroutine("launchLevel");
        Temp.transition_flag = true;
    }
    IEnumerator launchLevel()
    {
    	levelName = Temp.NextMapName;
        async = Application.LoadLevelAsync(Temp.NextLevelID);
        while( async.isDone == false )
        {
            float p = async.progress * 100f;
            pRounded = Mathf.RoundToInt(p);
            string perc = pRounded.ToString();
            Debug.Log( "Прогресс загрузки: "+perc+"%");
            yield return true;
        }
        
    }

    void OnGUI()
    {
    	//System.Threading.Thread.Sleep (50);//пауза на каждом кадре
	    GUI.DrawTexture(new Rect((Screen.width/2)-320, (Screen.height/2)-240,640, 480), GUITextureBackground);
        GUI.DrawTexture(new Rect( (Screen.width / 2)-152, (Screen.height / 2) + 218, 3.4f*pRounded, 15), lineBar);
    }
}