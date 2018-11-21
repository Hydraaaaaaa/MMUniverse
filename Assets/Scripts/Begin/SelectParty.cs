using UnityEngine;
using System.Collections;

public class SelectParty : MonoBehaviour {
    public GameObject MainMenu;
    private bool drawFlag;
	// Use this for initialization
	void Start () {
        drawFlag = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (MainMenu.GetComponent<MM7_MainMenu>().window == 1)
        {
            drawFlag = true;
           GetComponent<Party>().CreateDefaultParty();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!GetComponent<Party>().HintWindow)
                {
                    GetComponent<Party>().create_flag = false;
                    GetComponent<Party>().PosActiveItem_flag = false;
                    MainMenu.GetComponent<MM7_MainMenu>().window = 0;
                    MainMenu.GetComponent<AudioSource>().Play();
                    //Debug.Log("Escape");		
                }
                else if (GetComponent<Party>().HintWindow)
                {
                    GetComponent<Party>().HintWindow = false;
                }
            }
        }
        else
            drawFlag = false;

    }
    void OnGUI() {
        if (drawFlag)
        {
            GetComponent<Party>().PlayerCreationUI_Draw();
        }
    }
}
