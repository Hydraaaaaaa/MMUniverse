using UnityEngine;
using System.Collections;

public class Fog : MonoBehaviour {

    public float fogDensity = 0.05f;
    public bool fog = false;
    public bool current_fog = false;

	// Update is called once per frame
	void Update () {
        if (current_fog != fog)
        {
            if (fog)
            {
                //RenderSettings.fogColor = new Color(128,128,128,255);
                RenderSettings.fogDensity = fogDensity;
                //RenderSettings.fogMode = FogMode.Linear;
                RenderSettings.fogStartDistance = 30;
                RenderSettings.fogEndDistance = 100;
                RenderSettings.fog = true;
                current_fog = true;

            }
            else
            {
                RenderSettings.fog = false;
                current_fog = false;
            }
        }
	}
}
