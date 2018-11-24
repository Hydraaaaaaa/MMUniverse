using UnityEngine;
using System.Collections;

public class PlayPostIntro : MonoBehaviour {
	public MovieTexture Video_PostIntro;
	
	public AudioClip audioClip_PostIntro;

	//public GUISkin skin;
	public Texture2D aTexture;
	public bool flag = false;
	
	// Use this for initialization
	void Start () {
		Cursor.visible=false;
		Video_PostIntro.Play();
		GetComponent<AudioSource>().clip = audioClip_PostIntro;
		GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (Video_PostIntro.isPlaying) {
		}
		else
		{
			flag = true;

		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			flag = true;
		}
	}
	void OnGUI(){
		if (flag){
			Video_PostIntro.Stop();
			GetComponent<AudioSource>().Stop();
			Cursor.visible=true;
			Temp.NextMapName = "emerald_01";
            Temp.NextLevelID = 5;
            Application.LoadLevel("Load");
		}
		if (Event.current.type.Equals (EventType.Repaint)) {
			Graphics.DrawTexture(new Rect((Screen.width/2)-320,(Screen.height/2)-240,640, 480),Video_PostIntro);
		}
	}
}
