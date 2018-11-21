using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

    public int QuestID;
    public enum Quest_state
    {
        Quest_no_taken = 0,     //квест не взят
        Quest_taken = 1,        //квест взят
        Quest_performed = 2,    //квест выполняется
        Quest_done = 3,         //квест выполнен
        Quest_periodical = 4,   //квест периодический
    };
    public Quest_state QuestState;
    public string QuestTopic;
    public string QuestDescription;
    public string QuestText;
    public string QuestPostText;
    public int Quest_gold_exchange;
    public int Quest_food_exchange;
    public int Quest_findItem1ID;
    public string Quest_findItem1Name;
    public bool Quest_findItem1ID_done;
    public int Quest_findItem2ID;
    public string Quest_findItem2Name;
    public bool Quest_findItem2ID_done;
    public int Quest_findItem3ID;
    public string Quest_findItem3Name;
    public bool Quest_findItem3ID_done;
    public int Quest_findItem4ID;
    public string Quest_findItem4Name;
    public bool Quest_findItem4ID_done;
    public int Quest_findItem5ID;
    public string Quest_findItem5Name;
    public bool Quest_findItem5ID_done;
    public int Quest_findItem6ID;
    public string Quest_findItem6Name;
    public bool Quest_findItem6ID_done;
    public int Quest_findActorID;
    public int Quest_KillMonsterID;
}
