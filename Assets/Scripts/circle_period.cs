using UnityEngine;
using System.Collections;

public class circle_period : MonoBehaviour {
    public float cur_intensity;
    public bool plus;
	// Use this for initialization
	void Start () {
        cur_intensity = 0.01f;
        plus = true;
    }
	
	// Update is called once per frame
	void Update () {
        //Material material = new Material(Shader.Find("Self-Illumin/Specular"));
        //material.HasProperty("Illumin(A)").x = 
        //GetComponent<Renderer>().material = material;
        if (Temp.current_screen == Temp.screen_name.screen_game)
        {
            if (plus)
                cur_intensity += 2*Time.deltaTime;
            else
                cur_intensity -= 2*Time.deltaTime;
            if (cur_intensity >= 2.0f)
                plus = false;
            else if (cur_intensity <= 0.3f)
                plus = true;

            GetComponent<Light>().intensity = cur_intensity;
        }
    }
}
