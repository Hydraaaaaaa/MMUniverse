﻿using UnityEngine;
using System;

public class Hud : MonoBehaviour {
	float deltaTime = 0.0f;

	void Start () {
	}

	void Update () {
		deltaTime += (UnityEngine.Time.deltaTime - deltaTime) * 0.1f;
	}

	void OnGUI() {
		int w = Screen.width, h = Screen.height;
		
		GUIStyle style = new GUIStyle();

		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color (0.0f, 0.0f, 0.5f, 1.0f);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(new Rect(0, 0, w, h * 2 / 100), text, style);

		/*Globals globals = Globals.Get ();
		GUI.Label (new Rect (w - 150, 0, 150, 50), ((DateTime)globals ["time"]).ToShortTimeString (), style);*/
	}
}