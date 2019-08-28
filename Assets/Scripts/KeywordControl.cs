using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class KeywordControl : MonoBehaviour
    {
        public bool Control_flag;
		public bool Alt_flag;
		public bool Info_flag;
		public bool Rain_flag;
		public bool Snow_flag;
		public bool Fog_flag;

		//public GameObject Bow;
		public GameObject Info_window;
		public GameObject FX_Rain;
		public GameObject FX_Spit;
		public GameObject FX_Snow;
		public GameObject Fog;
        // Use this for initialization
        void Start()
        {
            Control_flag = false;
			Alt_flag = false;
			Info_flag = false;
			//Bow.active = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C) && Temp.current_screen == Temp.screen_name.screen_game)
            {

                if (Control_flag == true)
                {
                    GetComponent<MovePlayer>().enabled = true;
                    GetComponent<FirstPersonController>().enabled = false;
                    Control_flag = false;
                    Cursor.visible = true;
                    Screen.lockCursor = false;
                }
                else
                {
                    GetComponent<MovePlayer>().enabled = false;
                    GetComponent<FirstPersonController>().enabled = true;
                    Control_flag = true;
                    Cursor.visible = false;
                    Screen.lockCursor = true;
                }
            }
			/*else if (Input.GetKeyDown(KeyCode.LeftAlt) && Temp.current_screen == Temp.screen_name.screen_game)
			{
				if (Alt_flag == true)
				{
					Bow.active = false;
					Alt_flag = false;
				}
				else
				{
					Bow.active = true;
					Alt_flag = true;
				}
			}*/
			else if (Input.GetKeyDown(KeyCode.F1) && Temp.current_screen == Temp.screen_name.screen_game)
			{
				if (Info_flag == true)
				{
					Info_window.active = false;
					Info_flag = false;
					GameObject.Find("FPSController").GetComponent<Menu_Game>().Game_active();
				}
				else
				{
					Info_window.active = true;
					Info_flag = true;
					GameObject.Find("FPSController").GetComponent<Menu_Game>().Game_pause();
				}
			}
			else if (Input.GetKeyDown(KeyCode.Alpha5) && Temp.current_screen == Temp.screen_name.screen_game)
			{
				if (Rain_flag == true)
				{
					FX_Rain.active = false;
					FX_Spit.active = false;
					Rain_flag = false;
				}
				else
				{
					FX_Rain.active = true;
					FX_Spit.active = true;
					Rain_flag = true;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Alpha6) && Temp.current_screen == Temp.screen_name.screen_game)
			{
				if (Snow_flag == true)
				{
					FX_Snow.active = false;
					Snow_flag = false;
				}
				else
				{
					FX_Snow.active = true;
					Snow_flag = true;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Alpha7) && Temp.current_screen == Temp.screen_name.screen_game)
			{
				if (Fog_flag == true)
				{
					Fog.GetComponent<Fog>().fog = false;
					Fog_flag = false;
				}
				else
				{
					Fog.GetComponent<Fog>().fog = true;
					Fog_flag = true;
				}
			}
        }
    }
}