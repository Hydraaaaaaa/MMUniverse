using UnityEngine;
using System.Collections;

public class Info_window : MonoBehaviour {
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
		GUI.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 172, 460, 344), quick_info_tex);
		GUI.skin = skin;
		GUI.Box (new Rect ((Screen.width / 2) - 70, (Screen.height / 2) - 160, 230, 26), "Active Buttons");
		GUI.Box (new Rect ((Screen.width / 2) - 220, (Screen.height / 2) - 130, 230, 26), "F1-Key Info(enable/disable)");
		GUI.Box (new Rect ((Screen.width / 2) - 220, (Screen.height / 2) - 100, 230, 26), "leftCtrl or right mouse-Change control(original/mouse)");
		//GUI.Box (new Rect ((Screen.width / 2) - 220, (Screen.height / 2) - 70, 230, 26), "LeftAlt-Bow(enable/disable)");
		GUI.Box (new Rect ((Screen.width / 2) - 220, (Screen.height / 2) - 40, 230, 26), "Q-Shoot(if bow enable)");
		GUI.Box (new Rect ((Screen.width / 2) - 220, (Screen.height / 2) - 10, 230, 26), "5-Rain(enable/disable)");
		GUI.Box (new Rect ((Screen.width / 2) - 220, (Screen.height / 2) + 20, 230, 26), "6-Snow(enable/disable)");
		GUI.Box (new Rect ((Screen.width / 2) - 220, (Screen.height / 2) + 50, 230, 26), "7-Fog(enable/disable)");
		/*if (Temp.current_screen == Temp.screen_name.screen_quick_info)
		{
			GameObject.Find("FPSController").GetComponent<Menu_Game>().Game_pause();
			GUI.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 172, 460, 344), quick_info_tex);
			if (GUI.Button(new Rect((Screen.width / 2) + 162, (Screen.height / 2) + 135, 50, 35), ""))//Quit
			{
				Temp.current_screen = Temp.screen_name.screen_game;
				GameObject.Find("FPSController").GetComponent<Menu_Game>().Game_active();
			}
		}*/
	}
}
