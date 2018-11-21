using UnityEngine;
using System.Collections;

public class monster_walk : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
	 anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.A)){
            anim.SetBool("monster_walk1", true);
            //GetComponent<Actors>().uAIState = Actors.AIState.Pursuing;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("monster_walk1", false);
           // GetComponent<Actors>().uAIState = Actors.AIState.Standing;
        }
	}
}
