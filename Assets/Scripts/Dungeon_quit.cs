using UnityEngine;
using System.Collections;

public class Dungeon_quit : MonoBehaviour
{
    public string NextMapName;
    public GameObject character;
    public GameObject mouse_select;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MouseUp();
    }
    void MouseUp()
    {

        //Проверка попадания луча от мыши
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {

            //проверка куда попал луч
            if (hit.collider.tag == "Dungeon_quit" )
            {
                if (Input.GetMouseButtonUp(0))
                {
                    Temp.current_screen = Temp.screen_name.screen_house;
                    if (Application.loadedLevelName == "dragon_cave")
                    {
                        Time.timeScale = 0;
                        character.GetComponent<MovePlayer>().enabled = false;
                        mouse_select.GetComponent<MouseSelect>().Dangeon_door_flag = true;
                        Temp.current_house_tag = "Dungeon_quit";
                        //Temp.transition_flag = true;
                        Temp.CurrentMapName = "dragon_cave";
                        Temp.NextMapName = "emerald_01";
                        Temp.NextLevelID = 3;
                        //Application.LoadLevel("Load");
                        //Application.LoadLevel("emerald_01");
                    }
                    if (Application.loadedLevelName == "Tample_of_moon")
                    {
                        Time.timeScale = 0;
                        character.GetComponent<MovePlayer>().enabled = false;
                        mouse_select.GetComponent<MouseSelect>().Dangeon_door_flag = true;
                        Temp.current_house_tag = "Dungeon_quit";
                        //Temp.transition_flag = true;
                        Temp.CurrentMapName = "Tample_of_moon";
                        Temp.NextMapName = "emerald_01";
                        Temp.NextLevelID = 3;
                        //Application.LoadLevel("Load");
                        //Application.LoadLevel("emerald_01");
                    }
                }
            }
        }
    }

}
