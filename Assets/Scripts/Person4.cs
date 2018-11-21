using UnityEngine;
using System.Collections;
using Engine;
using UnityEngine.UI;

public class Person4 : MonoBehaviour {
	public SpriteAtlas sprites;
	public GameObject character4;
	public Image img;
	public float FaceAnimationTimer;
	private int RandTemp;
	private int Id;
	
	// Use this for initialization
	void Start () {
		//Temp.Player1CurentFacePath = true;
		RandTemp = -1;
		FaceAnimationTimer = 2f;
	}
	
	// Update is called once per frame
	void Update () {

			if (!Temp.Player4CurentFacePath) {
				//fileName = "Faces/PC01";
				//Debug.Log (GetComponent<Party>().Players[0].CurrentFace+"");
				if (Temp.Player4fileName == "")
					Temp.Player4fileName = "Faces/PC01";
				//Debug.Log (Temp.Player4fileName);
				sprites = SpriteAtlas.FromResources (Temp.Player4fileName);
				character4 = GameObject.Find ("Character4");
				img = character4.GetComponent<Image> () as Image;
				img.sprite = sprites [0];
				Temp.Player4CurentFacePath = true;
			} else if (Temp.Player4CurentFacePath && Temp.Player4fileName != "" && FaceAnimationTimer <= 0f) {
				int Rand = Random.Range (0, 7);
				if (RandTemp != Rand) {

					if (Rand == 1)
						Id = 12;
					else if (Rand == 2)
						Id = 15;
					else if (Rand == 3)
						Id = 16;
					else if (Rand == 4)
						Id = 18;
					else if (Rand == 5)
						Id = 19;
					else if (Rand == 6)
						Id = 20;
					else if (Rand == 7)
						Id = 21;
					else
						Id = 0;
					img.sprite = sprites [Id];
					RandTemp = Rand;
				} else {
					RandTemp = 0;
					img.sprite = sprites [0];
				}
				FaceAnimationTimer = 10f;
			} else if (Id == 12) {
				RandTemp = 0;
				img.sprite = sprites [0];
			} else if (Id > 12) {
				FaceAnimationTimer = 0.5f;
				Id = 0;
			}
			FaceAnimationTimer -= Time.deltaTime;
			//Debug.Log (FaceAnimationTimer);
	}
}
