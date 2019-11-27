using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInvisible : MonoBehaviour
{
    //public GameObject MainCamC;
    public GameObject This_object;
    public bool active_flag = false;//проверка активна
    public float timer = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        //MainCamC = GameObject.FindWithTag("MainCamera");
        This_object.SetActive(false);//отключить отрисовку
        active_flag = true;
        timer = 6f;
    }
    public void TimerBegin() {
        timer = 6f;
        active_flag = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (active_flag) {
            if (timer > 0f)
                timer -= Time.deltaTime;
            else
            {
                active_flag = false;
                This_object.SetActive(false);//отключить отрисовку

            }
        }
    }
}
