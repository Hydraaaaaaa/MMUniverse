using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Menu_Game : MonoBehaviour {

public GUISkin ButtonSkin_Empty;
    public int win_id;

public bool paused = false; //объявляем булевую переменную паузы
public bool menu_open = false; //объявляем булевую переменную для открытого меню

public Texture aTexture;
    public Texture win1_tex;
    public Texture Chest_tex;
public Texture2D nullTexture;
    public Texture2D[] slider = new Texture2D[11];
    public int[] music_coord = new int[11];
    public Color fadeColor;
    public AudioClip Harp;
    public AudioSource Audio;
    public GameObject Music;

    void Start () {
	    nullTexture = new Texture2D(1,1) as Texture2D;
	    nullTexture.SetPixel(0,0, Color.black);
	    nullTexture.Apply();
	    fadeColor =  Color.black;
        win_id = 0;

        Cursor.visible = false;
        Screen.lockCursor = true;
    }
    public void Game_pause() 
    {
	    Time.timeScale=0;
        GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        GameObject.Find("FPSController").GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Music").GetComponent<AudioSource>().mute = true;

        Cursor.visible = true;
        Screen.lockCursor = false;
    }
    public void Game_active()
    {
        Time.timeScale = 1;
        GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = true;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        GameObject.Find("FPSController").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("FPSController").GetComponent<AudioSource>().Stop();
        GameObject.Find("Music").GetComponent<AudioSource>().mute = false;

        Cursor.visible = false;
        Screen.lockCursor = true;
    }
    public bool TestWindow()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Temp.current_screen == Temp.screen_name.screen_chest 
            || Input.GetKeyDown(KeyCode.Escape) && Temp.current_screen == Temp.screen_name.screen_game_menu
            || Temp.current_screen == Temp.screen_name.screen_game_menu
            || Input.GetKeyDown(KeyCode.Escape) && Temp.current_screen == Temp.screen_name.screen_game 
            || Input.GetKeyDown(KeyCode.Escape) && Temp.current_screen == Temp.screen_name.screen_house)
        {
            return true;
        }
        return false;
    }
    public bool TestFlags()
    {
        if (!GameObject.Find("MouseSelect").GetComponent<MouseSelect>().chest_flag  
                && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().weaponsmith_door_flag
                && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().armor_door_flag
		    && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().tavern_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home1_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home2_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home3_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home4_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home5_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().training_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().LordMarhem_door_flag     
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().doctor_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().spirit_door_flag     
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().air_door_flag            
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().mage_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().fire_door_flag       
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().alchimist_door_flag      
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().body_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().dragon_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().moon_door_flag
            && !GameObject.Find("MouseSelect").GetComponent<MouseSelect>().boat_door_flag
            && Temp.current_screen == Temp.screen_name.screen_game || menu_open)
        {
            return true;
        }
        return false;
    }
    public void GoToGameWindow()
    {
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().chest_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().weaponsmith_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().armor_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().tavern_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home1_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home2_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home3_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home4_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home5_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().training_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().LordMarhem_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().doctor_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().spirit_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().air_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().mage_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().fire_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().alchimist_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().body_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().dragon_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().boat_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().moon_door_flag = false;
        GameObject.Find("MouseSelect").GetComponent<MouseSelect>().Dangeon_door_flag = false;
        Temp.current_screen = Temp.screen_name.screen_game;
                GameObject.Find("Player0").GetComponent<Inventory>().Inventory_open_flag = false;
                GameObject.Find("Player1").GetComponent<Inventory>().Inventory_open_flag = false;
                GameObject.Find("Player2").GetComponent<Inventory>().Inventory_open_flag = false;
                GameObject.Find("Player3").GetComponent<Inventory>().Inventory_open_flag = false;
			    Time.timeScale=1;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = true;
                Game_active();
                menu_open = false;
    }
    public void Update ()
    {//При нажатии ескепи
        if (TestWindow())
        {					//Экран свободен от других окон
            if (TestFlags())
            {
			    if(!paused){
                    Game_pause(); 
				    paused = true;
                    GameObject.Find("MouseSelect").GetComponent<MouseSelect>().menu_flag = true;
                    menu_open = false;
			    }
			    else if(paused){
                    Game_active();
				    paused = false;
                    GameObject.Find("MouseSelect").GetComponent<MouseSelect>().menu_flag = false;
                    menu_open = false;
			    }
		    }
		    else
                GoToGameWindow();//имеются другие окна
	    }
    }
    public bool TestHouseWindows()
    {
        if (Temp.current_screen == Temp.screen_name.screen_house) {
            if(GameObject.Find("MouseSelect").GetComponent<MouseSelect>().weaponsmith_door_flag)
            {           //оружейник
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 1;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().doctor_door_flag)
            {           //лекарь
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 5;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().armor_door_flag)
            {               //бронник
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 2;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().tavern_door_flag)
            {               //таверна
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 3;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home1_door_flag)
            {               //дом1
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 4;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home2_door_flag)
            {               //дом2
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 18;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home3_door_flag)
            {               //дом3
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 19;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home4_door_flag)
            {               //дом4
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 20;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().home5_door_flag)
            {               //дом1
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 6;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().LordMarhem_door_flag)
            {               //дом1
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 7;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().training_door_flag)
            {               //дом1
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 8;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().spirit_door_flag)
            {               //дом1
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 9;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().air_door_flag)
            {               //дом1
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 10;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().mage_door_flag)
            {               //дом1
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 11;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().fire_door_flag)
            {               //дом1
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 12;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().alchimist_door_flag)
            {               //алхимик
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 13;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().boat_door_flag)
            {               //корабль
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 17;
            }
            else if (GameObject.Find("MouseSelect").GetComponent<MouseSelect>().body_door_flag)
            {               //гильдия тела
                Time.timeScale = 0;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("for_events").GetComponent<Video_Player>().video_number = 14;
            }
            return true;
        }
        return false;
    }
    void OnGUI()
    {
        if (GameObject.Find("for_events").GetComponent<Video_Player>().video_number == 0)
        {
            if (!TestHouseWindows() && paused == true)
            {//меню игры
                Game_pause(); 
                menu_open = false;
                GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = false;

                fadeColor.a = 0.8f;
                GUI.color = fadeColor;
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), nullTexture, ScaleMode.StretchToFill, true);
                GUI.skin = ButtonSkin_Empty;
                GUI.color = Color.white;
                if (win_id == 0)
                {
                    GUI.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 172, 460, 344), aTexture);
                    //GUILayout.BeginArea(new Rect((Screen.width / 2) - 20, (Screen.height / 2) - 23, 210, 344));

                    if (GUI.Button(new Rect((Screen.width / 2) - 216, (Screen.height / 2) - 23, 210, 40), ""))//New Game
                    {
                        Application.LoadLevel(5);
                    }
                    if (GUI.Button(new Rect((Screen.width / 2) - 216, (Screen.height / 2) + 30, 210, 40), ""))//
                    {
                        //Application.LoadLevel(0);		
                    }
                    if (GUI.Button(new Rect((Screen.width / 2) - 216, (Screen.height / 2) + 85, 210, 40), ""))//
                    {
                        //Application.LoadLevel(0);		
                    }

                    GUILayout.BeginArea(new Rect((Screen.width / 2) + 5, (Screen.height / 2) - 23, 210, 344));

                    if (GUILayout.Button("Options", GUILayout.Width(300), GUILayout.Height(35)))
                    {
                        win_id = 1;
                    }
                    if (GUILayout.Button("Exit", GUILayout.Width(300), GUILayout.Height(35)))
                    {
                        Application.LoadLevel("GameSelect");
                    }
                    if (GUILayout.Button("Continue", GUILayout.Width(300), GUILayout.Height(35)))
                    {
                        Time.timeScale = 1;
                        paused = false;
                        GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = true;
                        Game_active();
                        menu_open = false;
                    }
                    GUILayout.EndArea();
                }
                else if (win_id == 1)
                {
                    GUI.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 172, 460, 344), aTexture);
                    GUI.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 48, 460, 220), win1_tex);
                    if (GUI.Button(new Rect((Screen.width / 2) + 6, (Screen.height / 2) + 125, 210, 35), ""))//вернуться в игру
                    {
                        win_id = 0;
                        Time.timeScale = 1;
                        paused = false;
                        GameObject.Find("FPSController").GetComponent<MovePlayer>().enabled = true;
                        Game_active();
                        menu_open = false;
                    }
                    Music.GetComponent<AudioSource>().volume = Temp.Music_volume;
                    //громкость общая
                    if (GUI.Button(new Rect((Screen.width / 2) + 6, (Screen.height / 2)-20, 18, 18), ""))//уменьшить громкость музыки
                    {
                    }
                    if (GUI.Button(new Rect((Screen.width / 2) + 198, (Screen.height / 2) - 20, 18, 18), ""))//увеличить громкость музыки
                    {
                    }
                    //громкость музыки
                    if (GUI.Button(new Rect((Screen.width / 2) + 6, (Screen.height / 2)+36, 18, 18), ""))//уменьшить громкость музыки
                    {
                        Temp.Music_volume = Temp.Music_volume - 0.1f;
                        if (Temp.Music_volume < 0.0f)
                            Temp.Music_volume = 0.0f;
                        GetComponent<AudioSource>().volume = Temp.Music_volume;
                        GetComponent<AudioSource>().PlayOneShot(Harp);
                    }
                    if (GUI.Button(new Rect((Screen.width / 2) + 198, (Screen.height / 2)+36, 18, 18), ""))//увеличить громкость музыки
                    {
                        Temp.Music_volume = Temp.Music_volume + 0.1f;
                        if (Temp.Music_volume >= 1.0f)
                            Temp.Music_volume = 0.9f;
                        GetComponent<AudioSource>().volume = Temp.Music_volume;
                        GetComponent<AudioSource>().PlayOneShot(Harp);
                    }
                    int curent_volume = (int)(Temp.Music_volume * 10);
                    Debug.Log(curent_volume);
                    GUI.DrawTexture(new Rect((Screen.width / 2) + music_coord[curent_volume], (Screen.height / 2) + 36, 18, 18), slider[curent_volume]);
                }
            }
        }
    }
}
