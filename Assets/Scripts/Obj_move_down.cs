using UnityEngine;
using System.Collections;

public class Obj_move_down : MonoBehaviour
{
    private Transform myTransform;
    public float DownSpeed;
    private bool M_Time;
    // Use this for initialization
    void Start()
    {
        M_Time = false;
    }
    void Awake()
    {
        myTransform = transform;

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
            if (hit.collider.tag == "Object_move_down")
            {
                if (Input.GetMouseButtonUp(0))
                {
                    M_Time = true;
                }
            }
        }
        if (M_Time)//время проигрывания анимации не закончилось
        {
            Vector3 pos = transform.position;
            pos.y -= DownSpeed * Time.deltaTime;
            myTransform.position = pos;
            if (myTransform.position.y < -10f)
                M_Time = false;
        }
    }
}
