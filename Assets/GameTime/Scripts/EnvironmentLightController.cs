using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class EnvironmentLightController : MonoBehaviour
{
    public static EnvironmentLightController Instance { get; private set; }
    public float NightLightIntensity
    {
        get
        {
            return nightLightIntensity.Evaluate(m_SunIntensity);
        }
    }

    [SerializeField] Light sunLight;
    [SerializeField] Gradient sunlightGradient;
    [SerializeField] AnimationCurve sunlightIntensity;

    [Space]

    [SerializeField] AnimationCurve ambientLightIntensity;
    [SerializeField] Gradient ambientLightGradient;
    [SerializeField] Gradient skyboxColor;

    [Space]

    [SerializeField] AnimationCurve nightLightIntensity;

    [SerializeField] float dayStartHour;
    [SerializeField] float dayEndHour;

    float m_SunIntensity;

    void Reset()
    {
        sunLight = GetComponent<Light>();
        sunLight.type = LightType.Directional;
        sunLight.shadows = LightShadows.Soft;
    }
    
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        float dayPercentage = Mathf.Clamp01((GameTime.TimeInHours - dayStartHour) / (dayEndHour - dayStartHour));

        transform.eulerAngles = new Vector3
        (
            dayPercentage * 180,
            0,
            0
        );

        m_SunIntensity = Mathf.Clamp01(Vector3.Dot(transform.forward, Vector3.down));

        sunLight.color = sunlightGradient.Evaluate(m_SunIntensity);
        sunLight.intensity = sunlightIntensity.Evaluate(m_SunIntensity);

        RenderSettings.skybox.SetColor("_Tint", skyboxColor.Evaluate(m_SunIntensity));

        RenderSettings.ambientLight = ambientLightGradient.Evaluate(m_SunIntensity);
        RenderSettings.ambientIntensity = ambientLightIntensity.Evaluate(m_SunIntensity);
        RenderSettings.reflectionIntensity = ambientLightIntensity.Evaluate(m_SunIntensity);
    }
}
