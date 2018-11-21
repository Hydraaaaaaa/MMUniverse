using UnityEngine;
using System.Collections;

public class Bonfires_data : MonoBehaviour {
    public GameObject character;
    public Bonfire_event[] BF_events;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < BF_events.Length; i++)
        {
            if (BF_events[i].BF_state == Bonfire_event.BF_STATE.BF_taken || BF_events[i].BF_state == Bonfire_event.BF_STATE.BF_performed)
            {
                CheckBF(BF_events[i]);
            }
        }
    }
    public void CheckBF(Bonfire_event BF_event)
    {
        if (BF_event.gold_prize > 0)
        {
            character.GetComponent<Party>().NumGold += BF_event.gold_prize;
            BF_event.BF_state = Bonfire_event.BF_STATE.BF_done;
        }
        if (BF_event.SP_prize > 0 && BF_event.Taken_count > 0)
        {
            if (character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sMana < character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxMana)
            {
                character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sMana += BF_event.SP_prize;
                if (character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sMana > character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxMana)
                    character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sMana = character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxMana;
                BF_event.Taken_count--;
            }
            BF_event.BF_state = Bonfire_event.BF_STATE.BF_done;
            character.GetComponent<MouseSelect>().bonfire_flag = false;
        }
        if (BF_event.HP_prize > 0 && BF_event.Taken_count > 0)
        {
            if (character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sHealth < character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxHealth)
            {
                character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sHealth += BF_event.HP_prize;
                if (character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sHealth > character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxHealth)
                    character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].sHealth = character.GetComponent<Party>().Players[Temp.ActiveCharacter - 1].MaxHealth;
                BF_event.Taken_count--;
            }
            BF_event.BF_state = Bonfire_event.BF_STATE.BF_done;
            character.GetComponent<MouseSelect>().bonfire_flag = false;
        }
        if (BF_event.food_prize > 0)
        {
            character.GetComponent<Party>().uNumFoodRations += BF_event.food_prize;
            BF_event.BF_state = Bonfire_event.BF_STATE.BF_done;
        }
        GetComponent<AudioSource>().clip = BF_event.sound_prize;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().volume = 0.8f;
        string text = "Bonfire" + (BF_event.BF_ID-1);
        GameObject go = GameObject.Find(text);
        go.SetActive(false);
    }
}
