using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInvisible : MonoBehaviour
{
    public GameObject MainCamC;
    public GameObject This_object;
    public bool active = true;//от первого лица
    // Start is called before the first frame update
    void Start()
    {
        MainCamC = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (active)//от первого лица
        {
            Component test = MainCamC.GetComponent("ARPGcameraC");
            if (MainCamC.GetComponent<ARPGcameraC>().useFirstPerson)//от первого лица
            {
                This_object.SetActive(false);//отключить отрисовку
                active = false;
            }
        }

    }
}
