using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class TorchLight : MonoBehaviour
{
    [SerializeField] Light m_Light;

    void Reset()
    {
        m_Light = GetComponent<Light>();
    }

    void Update()
    {
        // TODO: Add some kind of check for torchlight spell
        // TODO: Handle scenes without an environment lighting controller, such as indoors settings
        if (EnvironmentLightController.Instance != null)
        {
            m_Light.intensity = EnvironmentLightController.Instance.NightLightIntensity;
        }
    }
}
