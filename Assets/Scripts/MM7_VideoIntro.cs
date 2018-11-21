using UnityEngine;
using System.Collections;

public class MM7_VideoIntro : MonoBehaviour {
	public MovieTexture Video;
	public MovieTexture Video_3DO;
	public MovieTexture Video_NWC;
	public MovieTexture Video_JVC;
	public MovieTexture Video_Intro;

	public AudioClip audioClip_NWC;
	public AudioClip audioClip_JVC;
	public AudioClip audioClip_Intro;

	public int i;
	public int size_x;
	public int size_y;

	// Use this for initialization
	void Start () {
		Video = Video_3DO;
		Cursor.visible=false;
		Video.Play();
		i = 3;
		size_x = 640;
		size_y = 480;
	}
	
	// Update is called once per frame
	void Update () {
		if (Video.isPlaying) {
		
		} else {
			if (i>0){
				if (i==3){
					Video = Video_NWC;
					i--;
					Video.Play();
					GetComponent<AudioSource>().clip = audioClip_NWC;
					GetComponent<AudioSource>().Play();
				}
				else if (i==2){
					Video = Video_JVC;
					i--;
					Video.Play();
					GetComponent<AudioSource>().clip = audioClip_JVC;
					GetComponent<AudioSource>().Play();
				}
				else if (i==1){
					Video = Video_Intro;
					i--;
					Video.Play();
					GetComponent<AudioSource>().clip = audioClip_Intro;
					GetComponent<AudioSource>().Play();
				}
			} else{
				Cursor.visible=true;
				Application.LoadLevel("MM7_MainMenu");
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			Cursor.visible=true;
			Application.LoadLevel("MM7_MainMenu");	
		}
	}
	void OnGUI(){
		if (Event.current.type.Equals (EventType.Repaint)) {
			Graphics.DrawTexture(new Rect((Screen.width/2)-(size_x/2),(Screen.height/2)-(size_y/2),size_x, size_y),Video);
		}
	}
}
