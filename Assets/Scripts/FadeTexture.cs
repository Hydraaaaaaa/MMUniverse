using UnityEngine;
using System.Collections;

public class FadeTexture : MonoBehaviour {
    public Texture2D nullTexture;
    public Color fadeColor;
    // Use this for initialization
    void Start () {
        nullTexture = new Texture2D(1, 1) as Texture2D;
        nullTexture.SetPixel(0, 0, Color.black);
        nullTexture.Apply();
        fadeColor = Color.black;
    }
	
	// Update is called once per frame
	void Update () {

    }
    void OnGUI() {
        if (GameObject.Find("Crate").GetComponent<Chest>().Chest_open_flag)
        {
            fadeColor.a = 0.8f;
            GUI.color = fadeColor;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), nullTexture, ScaleMode.StretchToFill, true);
        }
    }
}
