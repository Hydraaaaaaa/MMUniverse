using UnityEngine;
using System.Collections;

public class Spell_book_window : MonoBehaviour {
    public GUISkin skin;
    public Texture2D spb_tex;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        if (Temp.current_screen == Temp.screen_name.screen_spell_book)
        {
            GUI.skin = skin;
            GameObject.Find("GameMenu").GetComponent<Menu_Game>().Game_pause();
            GUI.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 172, 460, 344), spb_tex);
            if (GUI.Button(new Rect((Screen.width / 2) + 40, (Screen.height / 2) + 120, 150, 35), ""))//Quit
            {
                Temp.current_screen = Temp.screen_name.screen_game;
                GameObject.Find("GameMenu").GetComponent<Menu_Game>().Game_active();
            }
        }
    }
}
