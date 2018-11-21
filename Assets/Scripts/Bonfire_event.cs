using UnityEngine;
using System.Collections;

public class Bonfire_event : MonoBehaviour {

    public int BF_ID;
    public int checked_Might_number;
    public int food_prize;
    public int gold_prize;
    public int HP_prize;
    public int SP_prize;
    public int ItemID_prize;
    public AudioClip sound_prize;
    public int Taken_count;
    public enum BF_STATE
    {
        BF_no_taken = 0,     //костер не взят
        BF_taken = 1,        //костер взят
        BF_performed = 2,    //костер берется
        BF_periodical = 3,   //костер периодический
        BF_done = 4,//колодец исчерпался
    };
    public BF_STATE BF_state;
}
