using UnityEngine;
using System.Collections;

public class Dungeon_open : MonoBehaviour
{
    public GameObject mouse_select;

    void OnGUI()
    {
        if (mouse_select.GetComponent<MouseSelect>().Dangeon_door_flag)
        {
            Time.timeScale = 0;
            GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
        }
    }
}
