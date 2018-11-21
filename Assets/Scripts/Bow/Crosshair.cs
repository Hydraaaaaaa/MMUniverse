using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	public Texture crosshairTexture;
	void OnGUI()
	{
		GUI.DrawTexture(new Rect((Screen.width / 2)-12, (Screen.height / 2)-12, 24,24), crosshairTexture);


    }
}
