using UnityEngine;
using System.Collections;

public class GameSelect : MonoBehaviour {
	public Texture2D Background;

	public GUISkin Button_Enroth;
	public GUISkin Button_Jadame;
	public GUISkin Button_Eraphia;

	public GUISkin Button_Quit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){

		if (Screen.width >= 1024) {
			GUI.DrawTexture (new Rect ((Screen.width / 2) - 512, (Screen.height / 2) - 347, 1024, 695), Background);

			GUI.skin = Button_Enroth;
			if (GUI.Button (new Rect ((Screen.width / 2) - 492, (Screen.height / 2) - 316, 440, 297), "")) {
				//MM6
				Application.LoadLevel ("new_sorpigal");
			}

			GUI.skin = Button_Jadame;
			if (GUI.Button (new Rect ((Screen.width / 2) + 19, (Screen.height / 2) - 323, 332, 256), "")) {
				//MM8
				Application.LoadLevel ("Daggerwound Island");
			}

			GUI.skin = Button_Eraphia;
			if (GUI.Button (new Rect (((Screen.width / 2) + 114), ((Screen.height / 2) - 27), 388, 348), "")) {
				//MM7
				Application.LoadLevel ("MM7_VideoIntro");
			}

			GUI.skin = Button_Quit;
			if (GUI.Button (new Rect ((Screen.width / 2) + 425, (Screen.height / 2) + 314, 85, 31), "Quit")) {
				Application.Quit ();
			}
		} 
		else {
			GUI.DrawTexture (new Rect (((Screen.width / 2) - 320), ((Screen.height / 2) - 240), 640, 480), Background);
			
			GUI.skin = Button_Enroth;
			if (GUI.Button (new Rect ((Screen.width / 2) - 310, (Screen.height / 2) - 220, 280, 208), "")) {
				//MM6
				Application.LoadLevel ("new_sorpigal");
			}
			
			GUI.skin = Button_Jadame;
			if (GUI.Button (new Rect ((Screen.width / 2) + 10, (Screen.height / 2) - 224, 211, 178), "")) {
				//MM8
				Application.LoadLevel ("Daggerwound Island");
			}
			
			GUI.skin = Button_Eraphia;
			if (GUI.Button (new Rect ((Screen.width / 2) + 68, (Screen.height / 2) - 21, 248, 243), "")) {
				//MM7
				Application.LoadLevel ("MM7_VideoIntro");
			}
			
			GUI.skin = Button_Quit;
			if (GUI.Button (new Rect ((Screen.width / 2) + 260, (Screen.height / 2) + 215, 55, 21), "Quit")) {
				Application.Quit ();
			}
		}
	}
}
