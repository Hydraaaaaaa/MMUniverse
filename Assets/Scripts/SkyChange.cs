using UnityEngine;
using System.Collections;

public class SkyChange : MonoBehaviour
{
    [System.Serializable]
    struct Skybox
    {
        public Material Material;
        public bool IsFoggy;
        public bool IsRaining;
    }

    [SerializeField] Skybox[] skyboxes; // скабоксы. массив, скайбоксы постепенной смены дня и ночи
    [SerializeField] int currentSkybox = 0;
    [SerializeField] GameTime gameTime;
    [SerializeField] GameObject rain;
    [SerializeField] GameObject spot;
    [SerializeField] Fog fog;

    void Start()
    {
        gameTime.OnDayChanged += OnDayChanged;
    }

    void OnDayChanged()
    {
        currentSkybox = Random.Range(0, skyboxes.Length);
        RenderSettings.skybox = skyboxes[currentSkybox].Material;
        RenderSettings.fog = true;

        if (skyboxes[currentSkybox].IsFoggy)
        {
            RenderSettings.fog = true;
            //fog.fog = true;
        }
        else
        {
            RenderSettings.fog = false;
            //fog.fog = false;
        }

        if (skyboxes[currentSkybox].IsRaining)
        {
            rain.SetActive(true);
            //spot.SetActive(true);
        }
        else
        {
            rain.SetActive(false);
            //spot.SetActive(false);
        }
    }
}
