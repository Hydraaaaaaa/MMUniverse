using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbookGUI : MonoBehaviour
{
    public static SpellbookGUI Instance { get; private set; }

    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        Instance = Instantiate(Resources.Load<SpellbookGUI>("SpellbookGUI"));

        DontDestroyOnLoad(Instance);

        Instance.gameObject.SetActive(false);
    }
}
