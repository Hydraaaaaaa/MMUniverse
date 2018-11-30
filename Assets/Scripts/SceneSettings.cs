using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Scene Settings", fileName = "SceneSettings")]
public class SceneSettings : ScriptableObject
{
    [System.Serializable]
    public struct Settings
    {
        public float timeScale;
    }

    [System.Serializable]
    struct Scene
    {
        public string sceneName;
        public Settings settings;
    }

    [SerializeField] Settings defaultSettings;

    [SerializeField] Scene[] scenes;

    public Settings GetCurrentSettings()
    {
        UnityEngine.SceneManagement.Scene activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        if (scenes.Any((scene) => scene.sceneName == activeScene.name))
        {
            return scenes.First((scenes) => scenes.sceneName == activeScene.name).settings;
        }

        return defaultSettings;
    }
}
