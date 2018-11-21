using UnityEngine;
using System.Collections;

public class Obj_move_left : MonoBehaviour {

    private Transform myTransform;
    public float MoveSpeed;
    public bool M_Time_right;
    public bool M_Time_left;
    public bool action;
    private float currentX;
    public bool Tumbler_flag;
    // Use this for initialization
    void Start()
    {
        M_Time_right = false;
        M_Time_left = false;
        currentX = transform.position.x;
        action = false;
    }
    void Awake()
    {
        myTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        //MouseUp();
        if (action)
        {
            if (Tumbler_flag)
            {
                M_Time_left = true;

            }
            if (M_Time_left)//
            {
                Vector3 pos = transform.position;
                pos.x += MoveSpeed * Time.deltaTime;
                if (myTransform.position.x > (currentX + 2.48f))
                {
                    M_Time_left = false;
                    action = false;
                }
                else {
                    myTransform.position = pos;
                }

            }

            if (!Tumbler_flag)
            {
                M_Time_right = true;

            }
            if (M_Time_right)//
            {
                Vector3 pos = transform.position;
                pos.x -= MoveSpeed * Time.deltaTime;
                if (myTransform.position.x < currentX)
                {
                    M_Time_right = false;
                    action = false;
                }
                else {
                    myTransform.position = pos;
                }

            }

        }
    }
}
