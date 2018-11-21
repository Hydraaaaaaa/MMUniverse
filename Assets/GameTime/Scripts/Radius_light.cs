using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class Radius_light : MonoBehaviour
{
    [SerializeField] float light_minus;
    [SerializeField] float light_plus;
    [SerializeField] GameTime gameTime;
    [SerializeField] Light light;

    void Reset()
    {
        light = GetComponent<Light>();
    }

	void Update ()
    {
        if (gameTime.TimeInHours > gameTime.timeOfDayTransitions[0].startHour ||
            gameTime.TimeInHours < gameTime.timeOfDayTransitions[1].startHour - 0.5f)
        {
            if (light.intensity < light_plus)
                light.intensity += Time.deltaTime / 4;
            if (light.intensity > light_plus)
                light.intensity = light_plus;
        }
        if (gameTime.TimeInHours > gameTime.timeOfDayTransitions[1].startHour - 0.3f &&
            gameTime.TimeInHours < gameTime.timeOfDayTransitions[3].startHour + 0.5f)
        {
            if (light.intensity > light_minus)
                light.intensity -= Time.deltaTime / 4;
            if (light.intensity < light_minus)
                light.intensity = light_minus;
        }
    }
}
