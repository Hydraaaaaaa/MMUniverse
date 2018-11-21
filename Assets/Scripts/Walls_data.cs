using UnityEngine;
using System.Collections;

public class Walls_data : MonoBehaviour {
    public GameObject character;
    public Wall_event[] walls;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < walls.Length; i++)
        {
            if (walls[i].wall_state == Wall_event.Wall_state.Wall_taken  || walls[i].wall_state == Wall_event.Wall_state.Wall_performed)
            {
                CheckWall(walls[i]);
            }
        }
    }
    public void CheckWall(Wall_event wall)
    {
        if (wall.gold_prize > 0)
        {
            character.GetComponent<Party>().NumGold += wall.gold_prize;
            wall.wall_state = Wall_event.Wall_state.Wall_done;
        }
        if (wall.SP_prize > 0 && wall.Taken_count > 0)
        {
            if (character.GetComponent<Party>().Players[Temp.ActiveCharacter-1].sMana < character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxMana)
            {
                character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sMana += wall.SP_prize;
                if (character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sMana > character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxMana)
                    character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sMana = character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxMana;
                wall.Taken_count--;
            }
            wall.wall_state = Wall_event.Wall_state.Wall_done;
            character.GetComponent<MouseSelect>().wall_flag = false;
        }
        if (wall.HP_prize > 0 && wall.Taken_count > 0)
        {
            if (character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sHealth < character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxHealth)
            {
                character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sHealth += wall.HP_prize;
                if (character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sHealth > character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxHealth)
                    character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sHealth = character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxHealth;
                wall.Taken_count--;
            }
            wall.wall_state = Wall_event.Wall_state.Wall_done;
            character.GetComponent<MouseSelect>().wall_flag = false;
        }
        GetComponent<AudioSource>().clip = wall.sound_prize;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().volume = 0.8f;
    }
}
