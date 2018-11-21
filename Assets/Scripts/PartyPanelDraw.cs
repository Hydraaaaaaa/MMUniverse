using UnityEngine;
using System.Collections;
using Engine;

public class PartyPanelDraw : MonoBehaviour {
	public SpriteAtlas sprites;
	public Sprite sprite0;
	// Use this for initialization
	void Start () {
		sprites = SpriteAtlas.FromResources("Faces/PC01");
		sprite0 = sprites[0];
		for (int x = -10; x < 10; x++) {
			for (int y = -10; y < 10; y++) {
				GameObject obj = new GameObject();
				obj.transform.position = new Vector3(x, y, 0);
				obj.AddComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 2)];
			}
		}
	}
}