using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameTime))]
public class LightInGame : MonoBehaviour {
    public float ambient_minus;
    public float ambient_plus;
    public float reflection_minus;
    public float reflection_plus;

    [SerializeField] GameTime gameTime;

    void Reset()
    {
        gameTime = GetComponent<GameTime>();
    }

	// Update is called once per frame
	void Update () {
        if (Temp.current_screen == Temp.screen_name.screen_game) {
            if (gameTime.TimeInHours > gameTime.timeOfDayTransitions[0].startHour ||
                gameTime.TimeInHours < gameTime.timeOfDayTransitions[1].startHour - 0.5f)
            {//ночь
                if (RenderSettings.reflectionIntensity > reflection_minus)
                    RenderSettings.reflectionIntensity -= Time.deltaTime / 4;
                if (RenderSettings.reflectionIntensity < reflection_minus)
                    RenderSettings.reflectionIntensity = reflection_minus;

                if (RenderSettings.ambientIntensity > ambient_minus)
                    RenderSettings.ambientIntensity -= Time.deltaTime / 4;
                if (RenderSettings.ambientIntensity < ambient_minus)
                    RenderSettings.ambientIntensity = ambient_minus;
                if (RenderSettings.reflectionIntensity == reflection_minus && RenderSettings.ambientIntensity == ambient_minus)
                {
                    RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
                    RenderSettings.ambientLight = RenderSettings.ambientGroundColor;
                }
            }
            if (gameTime.TimeInHours > gameTime.timeOfDayTransitions[1].startHour - 0.3f &&
                gameTime.TimeInHours < gameTime.timeOfDayTransitions[3].startHour + 0.5f)
            {//день
                if (RenderSettings.reflectionIntensity < reflection_plus)
                    RenderSettings.reflectionIntensity += Time.deltaTime / 4;
                if (RenderSettings.reflectionIntensity > reflection_plus)
                    RenderSettings.reflectionIntensity = reflection_plus;

                if (RenderSettings.ambientIntensity < ambient_plus)
                    RenderSettings.ambientIntensity += Time.deltaTime / 4;
                if (RenderSettings.ambientIntensity > ambient_plus)
                    RenderSettings.ambientIntensity = ambient_plus;
                if (RenderSettings.reflectionIntensity == reflection_plus && RenderSettings.ambientIntensity == ambient_plus)
                {
                    RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
                    RenderSettings.ambientLight = RenderSettings.ambientSkyColor;
                }
            }
        }
    }
}
