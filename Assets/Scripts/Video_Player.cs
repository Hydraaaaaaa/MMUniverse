using UnityEngine;
using System.Collections;

public class Video_Player : MonoBehaviour {

	public Texture2D nullTexture;
	public Color fadeColor;
    public bool video_reset;
	//Текущее видео
	public MovieTexture Video;

    public GameObject Quest_data;

	//Перечисление переменных хранящих видео
	public MovieTexture Video_weaponsmith;
	public MovieTexture Video_armor;
    public MovieTexture Video_tavern; 
	public MovieTexture Video_home1;
	public MovieTexture Video_home2;
	public MovieTexture Video_home3;
	public MovieTexture Video_home4;
	public MovieTexture Video_home5;
    public MovieTexture Video_LordMarhem;
    public MovieTexture Video_doctor;
    public MovieTexture Video_training;
    public MovieTexture Video_spirit;
    public MovieTexture Video_water;
    public MovieTexture Video_air;
    public MovieTexture Video_alchimist;
    public MovieTexture Video_body;
    public MovieTexture Video_fire;
    public MovieTexture Video_mage;
    public MovieTexture Video_moon_tample;
    public MovieTexture Video_dragon_cave;
    public MovieTexture Video_boat;

    //Текущее аудио
    public AudioSource Audio;

	//Перечисление переменных хранящих аудио для видео
	public AudioClip audioClip_weaponsmith;
	public AudioClip audioClip_armor;
	public AudioClip audioClip_tavern;
	public AudioClip audioClip_home1;
	public AudioClip audioClip_home2;
	public AudioClip audioClip_home3;
	public AudioClip audioClip_home4;
	public AudioClip audioClip_home5;
    public AudioClip audioClip_LordMarhem;
    public AudioClip audioClip_doctor;
    public AudioClip audioClip_training;
    public AudioClip audioClip_spirit;
    public AudioClip audioClip_water;
    public AudioClip audioClip_air;
    public AudioClip audioClip_alchimist;
    public AudioClip audioClip_body;
    public AudioClip audioClip_fire;
    public AudioClip audioClip_mage;
    public AudioClip audioClip_moon_tample;
    public AudioClip audioClip_dragon_cave;
    public AudioClip audioClip_boat;
    private Rect fade1;
    private Rect fade2;
    private Rect fade3;
    private Rect fade4;

    //номер текущего видео
    public int video_number;
	
	// Выполняется при запуске
	void Start () {
		video_number = 0;
		Audio = GetComponent<AudioSource>();
		nullTexture = new Texture2D(1,1) as Texture2D;
		nullTexture.SetPixel(0,0, Color.black);
		nullTexture.Apply();
		fadeColor =  Color.black;
        video_reset = false;
    }
	
	// Выполняется постоянно
	void Update () {
		switch(video_number){
		case 1:											//для оружейника
			//GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
			Video = Video_weaponsmith;
			Video.Play();
			Video.loop = true;
			Audio.clip = audioClip_weaponsmith;
			if (!Audio.isPlaying)
				Audio.Play();
			Audio.loop = true;
			break;
		case 2:											//для бронника
			//GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
			Video = Video_armor;
			Video.Play();
			Video.loop = true;
			Audio.clip = audioClip_armor;
			if (!Audio.isPlaying)
				Audio.Play();
			Audio.loop = true;
			break;
		case 3:											//для таверны
			//GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
			Video = Video_tavern;
			Video.Play();
			Video.loop = true;
			Audio.clip = audioClip_tavern;
			if (!Audio.isPlaying)
				Audio.Play();
			Audio.loop = true;
			break;
		case 4:											//для дом рядом с таверной
			//GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
			Video = Video_home1;
			Video.Play();
			Video.loop = true;
			Audio.clip = audioClip_home1;
			if (!Audio.isPlaying)
				Audio.Play();
			Audio.loop = true;
			break;
        case 5:											//для лекаря
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_doctor;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_doctor;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
        case 6:											//для дом рядом с пристанью
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_home5;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_home5;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
        case 7:                                         //для дома Лорда Мархема и судьи
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_LordMarhem;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_LordMarhem;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
        case 8:                                         //для тренировочного дома
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_training;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_training;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
        case 9:                                         //для spirit guild
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_spirit;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_spirit;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
        case 10:                                         //для air guild
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_air;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_air;
            if (!Audio.isPlaying)
              Audio.Play();
            Audio.loop = true;
            break;
        case 11:                                         //для mage shop
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_mage;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_mage;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
        case 12:                                         //для fire guild
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_fire;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_fire;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
        case 13:                                         //для alchimist
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_alchimist;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_alchimist;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
        case 14:                                         //для body guild
            //GameObject.Find("Interface").GetComponent<AudioSource>().Pause();
            Video = Video_body;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_body;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
         case 15:                                         //для dragon cave
            Video = Video_dragon_cave;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_dragon_cave;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
          case 16:                                         //для moon tample
            Video = Video_moon_tample;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_moon_tample;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
          case 17:                                         //для boat
            Video = Video_boat;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_boat;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
          case 18:                                         //для дом 2
            Video = Video_home2;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_home2;
            if (!Audio.isPlaying)
                 Audio.Play();
            Audio.loop = true;
            break;
          case 19:                                         //для дом 3
            Video = Video_home3;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_home3;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
          case 20:                                         //для дом 4
            Video = Video_home4;
            Video.Play();
            Video.loop = true;
            Audio.clip = audioClip_home4;
            if (!Audio.isPlaying)
                Audio.Play();
            Audio.loop = true;
            break;
          default:
			break;
		} //else{
				//Cursor.visible=true;
				//Application.LoadLevel(1);
			//}

		if(Input.GetKeyDown(KeyCode.Escape) || video_reset == true){           //При нажатии на ескепи
            if (Video != null)
                Video.Stop();
			Audio.Stop();
			video_number = 0;
			Video = null;
			Audio.clip = null;
			//GameObject.Find("Interface").GetComponent<AudioSource>().Play();
            video_reset = false;
        }
        if (Video != null) {
            //расчет размеров текстур затенения
            int gr1 = Screen.width - 172;
            if (Quest_data.GetComponent<Quests_data>().gui_hint || Quest_data.GetComponent<Quests_data>().gui_hint_not_done)
            {
                fade1 = new Rect(0, 0, gr1, (Screen.height / 2) + 172);
                fade3 = new Rect(0, (Screen.height / 2) + 172, Screen.width / 2 - 234, Screen.height);
                fade4 = new Rect(Screen.width / 2 + 234, (Screen.height / 2) + 172, gr1 - (Screen.width / 2 + 234), Screen.height);
            }
            else {
                fade1 = new Rect(0, 0, gr1, Screen.height - 126);
                fade3 = new Rect(0, Screen.height - 126, Screen.width / 2 - 234, Screen.height);
                fade4 = new Rect(Screen.width / 2 + 234, Screen.height - 126, gr1 - (Screen.width / 2 + 234), Screen.height);
            }
                fade2 = new Rect(Screen.width - 172, 0, Screen.width, Screen.height - 480);
        }
	}

	//Для отрисовки видео картинок
	void OnGUI(){
		if(video_number>0){
            fadeColor.a = 0.8f;
            GUI.color = fadeColor;
            if (Temp.current_screen != Temp.screen_name.screen_house)
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), nullTexture, ScaleMode.StretchToFill, true);
            else {
                GUI.DrawTexture(fade1, nullTexture, ScaleMode.StretchToFill, true);//основная затемняющая текстура
                GUI.DrawTexture(fade2, nullTexture, ScaleMode.StretchToFill, true);//правая затеняющая текстура
                GUI.DrawTexture(fade3, nullTexture, ScaleMode.StretchToFill, true);//левая нижняя затеняющая текстура
                GUI.DrawTexture(fade4, nullTexture, ScaleMode.StretchToFill, true);//правая нижняя затеняющая текстура
            }
            if (Video != null)
            {
                if (Event.current.type.Equals(EventType.Repaint))
                {
                    Graphics.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 172, 460, 344), Video);
                }
			}
		}
	}
}
