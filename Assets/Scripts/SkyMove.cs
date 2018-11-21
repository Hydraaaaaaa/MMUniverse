using UnityEngine;
using System.Collections;

public class SkyMove : MonoBehaviour {
    public float rotationSpeed = 0.14f;
    public float rot = 0;


    void Update()
    {

        
        rot += rotationSpeed * Time.deltaTime;
        rot %= 360;
        RenderSettings.skybox.SetFloat("_Rotation", rot);
        /*if (tSkybox) tSkybox.rotation = gSkybox.rotation;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Transition(SkyboxType.DAY, Color.white, 3.0f);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Transition(SkyboxType.DAY, new Color(0.75f, 0.15f, 0.0f, 1.0f), 3.0f);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Transition(SkyboxType.NIGHT, new Color(0.75f, 0.75f, 1.0f, 1.0f), 3.0f);
        }*/
    }
}
