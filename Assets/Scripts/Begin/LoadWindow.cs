using UnityEngine;
using System.Collections;

public class LoadWindow : MonoBehaviour {
    public GameObject MainMenu;
    private bool drawFlag;
    public GUISkin ButtonSkin_Empty;
    public Texture2D aTexture2;

    // Use this for initialization
    void Start()
    {
        drawFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.GetComponent<MM7_MainMenu>().window == 2 )
        {
            drawFlag = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MainMenu.GetComponent<MM7_MainMenu>().window = 0;
            }
        }
        else
            drawFlag = false;

    }
    void OnGUI()
    {
        if (drawFlag)
        {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 320, (Screen.height / 2) - 240, 640, 480), aTexture2);

            GUI.skin = ButtonSkin_Empty;
            if (GUI.Button(new Rect((Screen.width / 2) + 5, (Screen.height / 2) + 125, 103, 37), ""))
            {
                //Загрузить
            }
            if (GUI.Button(new Rect((Screen.width / 2) + 113, (Screen.height / 2) + 125, 103, 37), ""))
            {
                MainMenu.GetComponent<MM7_MainMenu>().window = 0;//Отмена;
            }
        }
    }
}
