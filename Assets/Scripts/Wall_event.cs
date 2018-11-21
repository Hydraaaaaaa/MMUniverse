using UnityEngine;
using System.Collections;

public class Wall_event : MonoBehaviour {
    public int wallID;
    public int checked_Might_number;
    public int gold_prize;
    public int HP_prize;
    public int SP_prize;
    public AudioClip sound_prize;
    public int Taken_count;
    public enum Wall_state
    {
        Wall_no_taken = 0,     //колодец не взят
        Wall_taken = 1,        //колодец взят
        Wall_performed = 2,    //колодец берется
        Wall_periodical = 3,   //колодец периодический
        Wall_done = 4,//колодец исчерпался
    };
    public Wall_state wall_state;
}
