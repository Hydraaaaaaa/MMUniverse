using UnityEngine;
using System.Collections;

public class Quick_info_window : MonoBehaviour {
    public GUISkin skin;
    public Texture2D quick_info_tex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        if (Temp.current_screen == Temp.screen_name.screen_quick_info)
        {
            GameObject.Find("GameMenu").GetComponent<Menu_Game>().Game_pause();
            GUI.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 172, 460, 344), quick_info_tex);
            if (GUI.Button(new Rect((Screen.width / 2) + 162, (Screen.height / 2) + 135, 50, 35), ""))//Quit
            {
                Temp.current_screen = Temp.screen_name.screen_game;
                GameObject.Find("GameMenu").GetComponent<Menu_Game>().Game_active();
            }
        }
    }
}
