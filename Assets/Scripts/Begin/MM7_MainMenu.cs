using UnityEngine;
using System.Collections;

public class MM7_MainMenu : MonoBehaviour {

    public GUIStyle welcomeLabel;
    public GUIStyle wolumeLabel;

    public float sider = 0.9f;//горизонтальный ползунок
    public AudioClip Clip;
    public AudioClip otherClip;
    public int credit_flag;

    public GUISkin ButtonSkin1;
    public GUISkin ButtonSkin2;
    public GUISkin ButtonSkin3;
    public GUISkin ButtonSkin4;

    public GUISkin ButtonSkin_Empty;

    public int window = 0;

    public Texture2D aTexture;

    public GameObject creators_Window;

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("MusicVol"))
        {
            sider = 0.9f;
        }
        else
        {
            sider = PlayerPrefs.GetFloat("MusicVol");
        }
        credit_flag = 1;
    }
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetFloat("MusicVol", sider);
        PlayerPrefs.Save();
    }

    void OnGUI()
    {

        //width_c = Screen.width/640.0;
        //height_c = Screen.height/480.0;

        if (window == 0)
        { // теперь главное меню активировано при window = 0

            GUI.DrawTexture(new Rect((Screen.width / 2) - 320, (Screen.height / 2) - 240, 640, 480), aTexture);
            //GUI.Label(new Rect(Screen.width-80, 0, 50, 20),""+width_c+"  "+height_c,welcomeLabel);

            GUI.Label(new Rect((Screen.width / 2) + 26, (Screen.height / 2) + 200, 50, 20), "громкость", wolumeLabel);
            sider = GUI.HorizontalSlider(new Rect((Screen.width / 2) + 26, (Screen.height / 2) + 217, 180, 20), sider, 0.0f, 1.0f);
            GetComponent<AudioSource>().volume = sider;

            GUI.skin = ButtonSkin1;
            if (GUI.Button(new Rect((Screen.width / 2) + 176, (Screen.height / 2) - 67, 82, 30), ""))
            {
                window = 1; // создание персонажей
                GetComponent<AudioSource>().Pause();
            }
            GUI.skin = ButtonSkin2;
            if (GUI.Button(new Rect((Screen.width / 2) + 175, (Screen.height / 2) - 13, 85, 31), ""))
            {
                window = 2; // загрузить
            }
            GUI.skin = ButtonSkin3;
            if (GUI.Button(new Rect((Screen.width / 2) + 175, (Screen.height / 2) + 43, 85, 31), ""))
            {
                window = 3; // создатели
                GetComponent<AudioSource>().Stop();
            }
            GUI.skin = ButtonSkin4;
            if (GUI.Button(new Rect((Screen.width / 2) + 175, (Screen.height / 2) + 97, 85, 31), ""))
            {
                Application.LoadLevel("GameSelect");
            }
        }
        if (window == 3)
        { // создатели

            if (credit_flag == 1)
            {
                GetComponent< AudioSource > ().clip = otherClip;
                GetComponent< AudioSource > ().Play();
                credit_flag = 0;
                creators_Window.GetComponent<Creators>().flag = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                window = 0;
                credit_flag = 1;
                GetComponent< AudioSource > ().Stop();
                GetComponent< AudioSource > ().clip = Clip;
                GetComponent< AudioSource > ().Play();
            }
        }
    }
}
