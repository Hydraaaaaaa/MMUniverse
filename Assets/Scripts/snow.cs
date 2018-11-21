using UnityEngine;
using System.Collections;

public class snow : MonoBehaviour {
	public  Material[] skyboxes; // скабоксы. массив, скайбоксы постепенной смены дня и ночи
	public int currSky;
    void Update()
    {
		RenderSettings.skybox = skyboxes[currSky];
        var parentGo = GameObject.FindWithTag("MainCamera");
        transform.position = new Vector3(parentGo.transform.position.x, parentGo.transform.position.y + 5.0f, parentGo.transform.position.z);
        GameObject.Find("Directional Light").GetComponent<Light>().enabled = false;
    }
}
