using UnityEngine;
using System.Collections;

public class Copyright : MonoBehaviour {
	public Texture2D loadingtex1;
	public Texture GUITextureBackground;
	public Texture2D tex_horizontal_top;
	public Texture2D tex_horizontal_btm;
	public Texture2D tex_vertical_left;
	public Texture2D tex_vertical_right;
	public Texture2D tex_left_up;
	public Texture2D tex_right_up;
	public Texture2D tex_left_bottom;
	public Texture2D tex_right_bottom;
	public GUISkin skin;

	// Use this for initialization
	void Start () {
	
	}
	private void OnGUI(){
		GUI.DrawTexture(new Rect((Screen.width/2)-320, (Screen.height/2)-240,640, 480), loadingtex1);
		Temp.GUITextureBackground = GUITextureBackground;
		Temp.tex_horizontal_top = tex_horizontal_top;
		Temp.tex_horizontal_btm = tex_horizontal_btm;
		Temp.tex_vertical_left = tex_vertical_left;
		Temp.tex_vertical_right = tex_vertical_right;
		Temp.tex_left_up = tex_left_up;
		Temp.tex_right_up = tex_right_up;
		Temp.tex_left_bottom = tex_left_bottom;
		Temp.tex_right_bottom = tex_right_bottom;
		Temp.skin = skin;

		Temp.OnGUI (315,-65, Temp.GlobalText[157]);
		System.Threading.Thread.Sleep (300);//пауза на каждом кадре
		Application.LoadLevel("MM7_MainMenu");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
