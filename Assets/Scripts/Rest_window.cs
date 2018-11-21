using UnityEngine;
using System.Collections;

public class Rest_window : MonoBehaviour {
    public GUISkin skin;
    public Texture2D rest_tex;
    public Texture2D rest_tex2;
    public Texture2D[] clock_tex = new Texture2D[120];
    public float clock_timer = 0f;
    public int ClockAnim_id;
    public GameTime gameTime;
    private int hour;
    public int minute;
    public string minute_str;
    public float num;
    public float ost;
    public string day_dec;

    void OnGUI()
    {
        if (Temp.current_screen == Temp.screen_name.screen_rest)
        {
            Menu_Game gameMenu = GameObject.Find("GameMenu").GetComponent<Menu_Game>();

            GUI.skin = skin;
            gameMenu.Game_pause();
            GUI.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 172, 460, 344), rest_tex);
            GUI.DrawTexture(new Rect((Screen.width / 2) - 222, (Screen.height / 2) - 154, 444, 108), rest_tex2);

            //arrows
            clock_timer += 0.8f;//Time.deltaTime * 16.0f;
            if (clock_timer > 119.0f)
                clock_timer = 0.0f;
            ClockAnim_id = (int)clock_timer;

            GUI.DrawTexture(new Rect((Screen.width / 2)+30, (Screen.height / 2) - 25, 72, 114), clock_tex[ClockAnim_id]);

            if (GUI.Button(new Rect((Screen.width / 2) + 43, (Screen.height / 2) + 117, 151, 35), "Остановить отдых"))//Quit
            {
                Temp.current_screen = Temp.screen_name.screen_game;
                gameMenu.Game_active();
            }
            hour = (int)GameTime.TimeInHours;
            num = GameTime.TimeInHours;
            ost = num - (int)num;
            minute = (int)((ost*100)/1.6f);
            if (minute < 10)
                minute_str = "0" + minute;
            else
                minute_str = minute.ToString();

            if (hour >= 4 && hour < 12)
                day_dec = "утра";
            else if (hour >= 12 && hour < 18)
                day_dec = "дня";
            else if (hour >= 18 && hour < 21)
                day_dec = "вечера";
            else 
                day_dec = "ночи";

            GUI.skin.box.alignment = TextAnchor.MiddleCenter;
            GUI.Box(new Rect(Screen.width/2+110, Screen.height/2-22, 96, 22), "" + hour +":"+ minute_str + " "+day_dec);//время
            GUI.skin.box.alignment = TextAnchor.MiddleLeft;
            GUI.Box(new Rect(Screen.width / 2 + 110, (Screen.height / 2)+6, 96, 22), "День:" );//день
            GUI.skin.box.alignment = TextAnchor.MiddleRight;
            GUI.Box(new Rect(Screen.width / 2 + 110, (Screen.height / 2) + 6, 96, 22), ""+ GameTime.CurrentDay);//день
            GUI.skin.box.alignment = TextAnchor.MiddleLeft;
            GUI.Box(new Rect(Screen.width / 2 + 110, Screen.height / 2 + 34, 96, 22), "Месяц:" );//месяц
            GUI.skin.box.alignment = TextAnchor.MiddleRight;
            GUI.Box(new Rect(Screen.width / 2 + 110, Screen.height / 2 + 34, 96, 22), ""+ GameTime.CurrentMonth);//месяц
            GUI.skin.box.alignment = TextAnchor.MiddleLeft;
            GUI.Box(new Rect(Screen.width / 2 + 110, Screen.height / 2 + 62, 96, 22), "Год: ");//год
            GUI.skin.box.alignment = TextAnchor.MiddleRight;
            GUI.Box(new Rect(Screen.width / 2 + 110, Screen.height / 2 + 62, 96, 22), "" + (GameTime.CurrentYear));//год
        }
    }
}
