using UnityEngine;
using System.Collections;

public class Tumbler_one_off : MonoBehaviour {
    public GameObject Object_tumbler;
    public GameObject Object_right;
    public GameObject Object_left;
    private bool tumbler_flag;

    // Use this for initialization
    void Start () {
        tumbler_flag = true;

    }

    // Update is called once per frame
    void Update()
    {
        //Проверка попадания луча от мыши
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {
            //проверка куда попал луч
            if (hit.collider.tag == "Tumbler")
            {
                if (Input.GetMouseButtonUp(0) 
                    && !Object_right.GetComponent<Obj_move_right>().M_Time_right 
                    && !Object_right.GetComponent<Obj_move_right>().M_Time_left
                    && !Object_left.GetComponent<Obj_move_left>().M_Time_right
                    && !Object_left.GetComponent<Obj_move_left>().M_Time_left)
                {

                    //Object_tumbler.GetComponent<MeshRenderer>().enabled = !tumbler_flag;
                    if (tumbler_flag)
                    {
                        Object_tumbler.GetComponent<MeshRenderer>().enabled = false;
                        Object_right.GetComponent<Obj_move_right>().action = true;
                        Object_right.GetComponent<Obj_move_right>().Tumbler_flag = true;
                        Object_left.GetComponent<Obj_move_left>().action = true;
                        Object_left.GetComponent<Obj_move_left>().Tumbler_flag = true;
                        tumbler_flag = false;
                    }
                    else
                    {
                        Object_tumbler.GetComponent<MeshRenderer>().enabled = true;
                        Object_right.GetComponent<Obj_move_right>().action = true;
                        Object_right.GetComponent<Obj_move_right>().Tumbler_flag = false;
                        Object_left.GetComponent<Obj_move_left>().action = true;
                        Object_left.GetComponent<Obj_move_left>().Tumbler_flag = false;
                        tumbler_flag = true;
                    }
                }
            }
        }
    }
}
