using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    public GUISkin skin;
    public bool Inventory_open_flag = false;
    public bool Inventory_change_flag = false;
    public Texture2D fr_stats_tex;
    public Texture2D fr_skill_tex;
    public Texture2D fr_inven_tex;
    public Texture2D fr_award_tex;
    private Texture2D fr_cur_tex;
    public List<Items> inventory = new List<Items>();
    private ItemDatebase database;

    private uint INVETORYSLOTSWIDTH = 14;
    private uint INVETORYSLOTSHEIGHT = 9;

    private AudioSource m_AudioSource;
    public AudioClip[] mix_sounds = new AudioClip[2];

    private int current_character;
    private int name_id;

    private Vector2 MousePos;
    public GameObject right_panel;
    public GameObject party;
    public GameObject Person1;
    public float Person1_coord_x;
    public float Person_coord_y;
    public GameObject Person2;
    public float Person2_coord_x;
    public GameObject Person3;
    public float Person3_coord_x;
    public GameObject Person4;
    public float Person4_coord_x;
    private bool actives = false;
    private bool actives_tumbler = false;
    private bool actives2 = false;
    public GameObject Party_panel;

    // Use this for initialization
    void Start () {
        //database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();
        //party.GetComponent<Party>().TakenItemTexture = null;
        Person1_coord_x = (Screen.width / 2) - 198;
        Person_coord_y = (Screen.height - 91);
        Person2_coord_x = (Screen.width / 2) - 83;
        Person3_coord_x = (Screen.width / 2) + 32;
        Person4_coord_x = (Screen.width / 2) + 147;
        database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Temp.current_screen == Temp.screen_name.screen_inventory)
        {
            // if (timer_btn <= 0)
            OnMouseDrag();
        }
        if (Input.GetKeyUp(KeyCode.I)) {
            Inventory_open_flag = true;
        }
    }
    public int GetCurrentCharacter(string name) {
      
      switch(name){
          case "Player0":
              name_id = 1;
              break;
          case "Player1":
              name_id = 2;
              break;
          case "Player2":
              name_id = 3;
              break;
          case "Player3":
              name_id = 4;
              break;
          default:

              break;
      }
      return name_id;
    }
    void OnGUI () {
        if (Inventory_open_flag)
        {
            GameObject.Find("GameMenu").GetComponent<Menu_Game>().Game_pause();
            if (fr_cur_tex != null)
            {
                int width = Screen.width;
                int height = Screen.height;
                if (width > 640)
                  GUI.DrawTexture(new Rect((Screen.width / 2) - 230, (Screen.height / 2) - 172, 460, 344), fr_cur_tex);
                else
                    GUI.DrawTexture(new Rect(0, 0, 460, 344), fr_cur_tex);

               if (Temp.current_screen == Temp.screen_name.screen_game)
                 current_character = GetCurrentCharacter(this.gameObject.name);
                if (Temp.current_screen == Temp.screen_name.screen_chest)
                {
                    right_panel.GetComponent<right_panel>().chest_window_flag = true;
                }
               string name = "";
               int exp = 0;
                if (Temp.current_inventory_window == 1)//Stats
                {

                   string classType = "";
                   int abs_might = 0;
                   int curent_might = 0;
                   int abs_intellect = 0;
                   int curent_intellect = 0;
                   int abs_willpower = 0;
                   int curent_willpower = 0;
                   int abs_endurance = 0;
                   int curent_endurance = 0;
                   int abs_speed = 0;
                   int curent_speed = 0;
                   int abs_accuracy = 0;
                   int curent_accuracy = 0;
                   int abs_luck = 0;
                   int curent_luck = 0;
                   int health = 0;
                   int max_health = 0;
                   int mana = 0;
                   int max_mana = 0;
                   int AC_cur = 0;
                   int AC_max = 0;
                    string condition = "";
                    string qspell = Temp.GlobalText[153];//Нет
                    uint age = 0;
                    uint age_m = 0;
                    int level = 1;
                    int exper = 0;
                    bool CanTrain = false;
                    int atack = 0;
                    int fire_actual_rest = 0;
                    int fire_base_rest = 0;
                    int Air_actual_rest = 0;
                    int Air_base_rest = 0;
                    int water_actual_rest = 0;
                    int water_base_rest = 0;
                    int earth_actual_rest = 0;
                    int earth_base_rest = 0;
                    int body_actual_rest = 0;
                    int body_base_rest = 0;
                    int mind_actual_rest = 0;
                    int mind_base_rest = 0;


                   Temp.current_screen = Temp.screen_name.screen_inventory;
                   switch(Temp.ActiveCharacter)
                {
                       case 1:
                           name = GameObject.Find("Player0").GetComponent<PlayerStats>().Name;
                           classType = Temp.pClassNames [(int)GameObject.Find("Player0").GetComponent<PlayerStats>().ClassType];
                           exp = Temp.Player1_Skill_Point;
                           abs_might = GameObject.Find("Player0").GetComponent<PlayerStats>().MightBonus;
                           curent_might = GameObject.Find("Player0").GetComponent<PlayerStats>().Might;
                           abs_intellect = GameObject.Find("Player0").GetComponent<PlayerStats>().IntelligenceBonus;
                           curent_intellect = GameObject.Find("Player0").GetComponent<PlayerStats>().Intelligence;
                           abs_willpower = GameObject.Find("Player0").GetComponent<PlayerStats>().WillpowerBonus;
                           curent_willpower = GameObject.Find("Player0").GetComponent<PlayerStats>().Willpower;
                           abs_endurance = GameObject.Find("Player0").GetComponent<PlayerStats>().EnduranceBonus;
                           curent_endurance = GameObject.Find("Player0").GetComponent<PlayerStats>().Endurance;
                           abs_speed = GameObject.Find("Player0").GetComponent<PlayerStats>().SpeedBonus;
                           curent_speed = GameObject.Find("Player0").GetComponent<PlayerStats>().Speed;
                           abs_accuracy = GameObject.Find("Player0").GetComponent<PlayerStats>().AccuracyBonus;
                           curent_accuracy = GameObject.Find("Player0").GetComponent<PlayerStats>().Accuracy;
                           abs_luck = GameObject.Find("Player0").GetComponent<PlayerStats>().LuckBonus;
                           curent_luck = GameObject.Find("Player0").GetComponent<PlayerStats>().Luck;
                           health = GameObject.Find("Player0").GetComponent<PlayerStats>().sHealth;
                           max_health = GameObject.Find("Player0").GetComponent<PlayerStats>().MaxHealth;
                           mana = GameObject.Find("Player0").GetComponent<PlayerStats>().sMana;
                           max_mana = GameObject.Find("Player0").GetComponent<PlayerStats>().MaxMana;
                           AC_cur = GameObject.Find("FPSController").GetComponent<Party>().GetActualAC(0);
                           AC_max = GameObject.Find("FPSController").GetComponent<Party>().GetBaseAC(0);
                           condition = Temp.aCharacterConditionNames[GameObject.Find("FPSController").GetComponent<Party>().GetMajorConditionIdx(0)];
                           if (GameObject.Find("Player0").GetComponent<PlayerStats>().QuickSpell > 0)
                               qspell = GameObject.Find("Player0").GetComponent<PlayerStats>().QuickSpell +"";//pSpellStats->pInfos[GameObject.Find("Player0").GetComponent<PlayerStats>().QuickSpell].pShortName;
                           age = GameObject.Find("FPSController").GetComponent<Party>().GetBaseAge(0);
                           age_m = GameObject.Find("FPSController").GetComponent<Party>().GetActualAge(0);
                           level = GameObject.Find("FPSController").GetComponent<Party>().GetActualLevel(0);
                           exper = GameObject.Find("Player0").GetComponent<PlayerStats>().Experience;
                           CanTrain = GameObject.Find("FPSController").GetComponent<Party>().CanTrainToNextLevel(0);
                           atack = GameObject.Find("FPSController").GetComponent<Party>().GetActualAttack(0, false);
                           fire_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE);
                           fire_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE);
                           Air_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR);
                           Air_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR);
                           water_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER);
                           water_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER);
                           earth_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH);
                           earth_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH);
                           body_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY);
                           body_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY);
                           mind_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND);
                           mind_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(0, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND);

                           break;
                       case 2:
                           name = GameObject.Find("Player1").GetComponent<PlayerStats>().Name;
                           classType = Temp.pClassNames[(int)GameObject.Find("Player1").GetComponent<PlayerStats>().ClassType];
                           exp = Temp.Player2_Skill_Point;
                           abs_might = GameObject.Find("Player1").GetComponent<PlayerStats>().MightBonus;
                           curent_might = GameObject.Find("Player1").GetComponent<PlayerStats>().Might;
                           abs_intellect = GameObject.Find("Player1").GetComponent<PlayerStats>().IntelligenceBonus;
                           curent_intellect = GameObject.Find("Player1").GetComponent<PlayerStats>().Intelligence;
                           abs_willpower = GameObject.Find("Player1").GetComponent<PlayerStats>().WillpowerBonus;
                           curent_willpower = GameObject.Find("Player1").GetComponent<PlayerStats>().Willpower;
                           abs_endurance = GameObject.Find("Player1").GetComponent<PlayerStats>().EnduranceBonus;
                           curent_endurance = GameObject.Find("Player1").GetComponent<PlayerStats>().Endurance;
                           abs_speed = GameObject.Find("Player1").GetComponent<PlayerStats>().SpeedBonus;
                           curent_speed = GameObject.Find("Player1").GetComponent<PlayerStats>().Speed;
                           abs_accuracy = GameObject.Find("Player1").GetComponent<PlayerStats>().AccuracyBonus;
                           curent_accuracy = GameObject.Find("Player1").GetComponent<PlayerStats>().Accuracy;
                           abs_luck = GameObject.Find("Player1").GetComponent<PlayerStats>().LuckBonus;
                           curent_luck = GameObject.Find("Player1").GetComponent<PlayerStats>().Luck;
                           health = GameObject.Find("Player1").GetComponent<PlayerStats>().sHealth;
                           max_health = GameObject.Find("Player1").GetComponent<PlayerStats>().MaxHealth;
                           mana = GameObject.Find("Player1").GetComponent<PlayerStats>().sMana;
                           max_mana = GameObject.Find("Player1").GetComponent<PlayerStats>().MaxMana;
                           AC_cur = GameObject.Find("FPSController").GetComponent<Party>().GetActualAC(1);
                           AC_max = GameObject.Find("FPSController").GetComponent<Party>().GetBaseAC(1);
                           condition = Temp.aCharacterConditionNames[GameObject.Find("FPSController").GetComponent<Party>().GetMajorConditionIdx(1)];
                           if (GameObject.Find("Player1").GetComponent<PlayerStats>().QuickSpell > 0)
                               qspell = GameObject.Find("Player1").GetComponent<PlayerStats>().QuickSpell + "";
                           age = GameObject.Find("FPSController").GetComponent<Party>().GetBaseAge(1);
                           age_m = GameObject.Find("FPSController").GetComponent<Party>().GetActualAge(1);
                           level = GameObject.Find("FPSController").GetComponent<Party>().GetActualLevel(1);
                           exper = GameObject.Find("Player1").GetComponent<PlayerStats>().Experience;
                           CanTrain = GameObject.Find("FPSController").GetComponent<Party>().CanTrainToNextLevel(1);
                           atack = GameObject.Find("FPSController").GetComponent<Party>().GetActualAttack(1, false);
                           fire_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE);
                           fire_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE);
                           Air_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR);
                           Air_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR);
                           water_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER);
                           water_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER);
                           earth_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH);
                           earth_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH);
                           body_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY);
                           body_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY);
                           mind_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND);
                           mind_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(1, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND);
                           break;
                       case 3:
                           name = GameObject.Find("Player2").GetComponent<PlayerStats>().Name;
                           classType = Temp.pClassNames[(int)GameObject.Find("Player2").GetComponent<PlayerStats>().ClassType];
                           exp = Temp.Player3_Skill_Point;
                           abs_might = GameObject.Find("Player2").GetComponent<PlayerStats>().MightBonus;
                           curent_might = GameObject.Find("Player2").GetComponent<PlayerStats>().Might;
                           abs_intellect = GameObject.Find("Player2").GetComponent<PlayerStats>().IntelligenceBonus;
                           curent_intellect = GameObject.Find("Player2").GetComponent<PlayerStats>().Intelligence;
                           abs_willpower = GameObject.Find("Player2").GetComponent<PlayerStats>().WillpowerBonus;
                           curent_willpower = GameObject.Find("Player2").GetComponent<PlayerStats>().Willpower;
                           abs_endurance = GameObject.Find("Player2").GetComponent<PlayerStats>().EnduranceBonus;
                           curent_endurance = GameObject.Find("Player2").GetComponent<PlayerStats>().Endurance;
                           abs_speed = GameObject.Find("Player2").GetComponent<PlayerStats>().SpeedBonus;
                           curent_speed = GameObject.Find("Player2").GetComponent<PlayerStats>().Speed;
                           abs_accuracy = GameObject.Find("Player2").GetComponent<PlayerStats>().AccuracyBonus;
                           curent_accuracy = GameObject.Find("Player2").GetComponent<PlayerStats>().Accuracy;
                           abs_luck = GameObject.Find("Player2").GetComponent<PlayerStats>().LuckBonus;
                           curent_luck = GameObject.Find("Player2").GetComponent<PlayerStats>().Luck;
                           health = GameObject.Find("Player2").GetComponent<PlayerStats>().sHealth;
                           max_health = GameObject.Find("Player2").GetComponent<PlayerStats>().MaxHealth;
                           mana = GameObject.Find("Player2").GetComponent<PlayerStats>().sMana;
                           max_mana = GameObject.Find("Player2").GetComponent<PlayerStats>().MaxMana;
                           AC_cur = GameObject.Find("FPSController").GetComponent<Party>().GetActualAC(2);
                           AC_max = GameObject.Find("FPSController").GetComponent<Party>().GetBaseAC(2);
                           condition = Temp.aCharacterConditionNames[GameObject.Find("FPSController").GetComponent<Party>().GetMajorConditionIdx(2)];
                           if (GameObject.Find("Player2").GetComponent<PlayerStats>().QuickSpell > 0)
                               qspell = GameObject.Find("Player2").GetComponent<PlayerStats>().QuickSpell + "";
                           age = GameObject.Find("FPSController").GetComponent<Party>().GetBaseAge(2);
                           age_m = GameObject.Find("FPSController").GetComponent<Party>().GetActualAge(2);
                           level = GameObject.Find("FPSController").GetComponent<Party>().GetActualLevel(2);
                           exper = GameObject.Find("Player2").GetComponent<PlayerStats>().Experience;
                           CanTrain = GameObject.Find("FPSController").GetComponent<Party>().CanTrainToNextLevel(2);
                           atack = GameObject.Find("FPSController").GetComponent<Party>().GetActualAttack(2, false);
                           fire_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE);
                           fire_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE);
                           Air_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR);
                           Air_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR);
                           water_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER);
                           water_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER);
                           earth_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH);
                           earth_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH);
                           body_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY);
                           body_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY);
                           mind_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND);
                           mind_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(2, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND);
                           break;
                       case 4:
                           name = GameObject.Find("Player3").GetComponent<PlayerStats>().Name;
                           classType = Temp.pClassNames[(int)GameObject.Find("Player3").GetComponent<PlayerStats>().ClassType];
                           exp = Temp.Player4_Skill_Point;
                           abs_might = GameObject.Find("Player3").GetComponent<PlayerStats>().MightBonus;
                           curent_might = GameObject.Find("Player3").GetComponent<PlayerStats>().Might;
                           abs_intellect = GameObject.Find("Player3").GetComponent<PlayerStats>().IntelligenceBonus;
                           curent_intellect = GameObject.Find("Player3").GetComponent<PlayerStats>().Intelligence;
                           abs_willpower = GameObject.Find("Player3").GetComponent<PlayerStats>().WillpowerBonus;
                           curent_willpower = GameObject.Find("Player3").GetComponent<PlayerStats>().Willpower;
                           abs_endurance = GameObject.Find("Player3").GetComponent<PlayerStats>().EnduranceBonus;
                           curent_endurance = GameObject.Find("Player3").GetComponent<PlayerStats>().Endurance;
                           abs_speed = GameObject.Find("Player3").GetComponent<PlayerStats>().SpeedBonus;
                           curent_speed = GameObject.Find("Player3").GetComponent<PlayerStats>().Speed;
                           abs_accuracy = GameObject.Find("Player3").GetComponent<PlayerStats>().AccuracyBonus;
                           curent_accuracy = GameObject.Find("Player3").GetComponent<PlayerStats>().Accuracy;
                           abs_luck = GameObject.Find("Player3").GetComponent<PlayerStats>().LuckBonus;
                           curent_luck = GameObject.Find("Player3").GetComponent<PlayerStats>().Luck;
                           health = GameObject.Find("Player3").GetComponent<PlayerStats>().sHealth;
                           max_health = GameObject.Find("Player3").GetComponent<PlayerStats>().MaxHealth;
                           mana = GameObject.Find("Player3").GetComponent<PlayerStats>().sMana;
                           max_mana = GameObject.Find("Player3").GetComponent<PlayerStats>().MaxMana;
                           AC_cur = GameObject.Find("FPSController").GetComponent<Party>().GetActualAC(3);
                           AC_max = GameObject.Find("FPSController").GetComponent<Party>().GetBaseAC(3);
                           condition = Temp.aCharacterConditionNames[GameObject.Find("FPSController").GetComponent<Party>().GetMajorConditionIdx(3)];
                           if (GameObject.Find("Player3").GetComponent<PlayerStats>().QuickSpell > 0)
                               qspell = GameObject.Find("Player3").GetComponent<PlayerStats>().QuickSpell + "";
                           age = GameObject.Find("FPSController").GetComponent<Party>().GetBaseAge(3);
                           age_m = GameObject.Find("FPSController").GetComponent<Party>().GetActualAge(3);
                           level = GameObject.Find("FPSController").GetComponent<Party>().GetActualLevel(3);
                           exper = GameObject.Find("Player3").GetComponent<PlayerStats>().Experience;
                           CanTrain = GameObject.Find("FPSController").GetComponent<Party>().CanTrainToNextLevel(3);
                           atack = GameObject.Find("FPSController").GetComponent<Party>().GetActualAttack(3, false);
                           fire_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE);
                           fire_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE);
                           Air_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR);
                           Air_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR);
                           water_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER);
                           water_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER);
                           earth_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH);
                           earth_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH);
                           body_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY);
                           body_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY);
                           mind_actual_rest = GameObject.Find("FPSController").GetComponent<Party>().GetActualResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND);
                           mind_base_rest = GameObject.Find("FPSController").GetComponent<Party>().GetBaseResistance(3, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND);
                           break;
                   }
                   abs_might = abs_might + curent_might;
                   abs_intellect = abs_intellect + curent_intellect;
                   abs_willpower = abs_willpower + curent_willpower;
                   abs_endurance = abs_endurance + curent_endurance;
                   abs_speed = abs_speed + curent_speed;
                   abs_accuracy = abs_accuracy + curent_accuracy;
                   abs_luck = abs_luck + curent_luck;
                   max_health = max_health + health;
                   max_mana = max_mana + mana;
                   GUI.skin = skin;
                   GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                   GUI.color = new Color(209, 187, 0/*97*/, 1);
                    if (name != "")
                        GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 162, name.Length * 16 + classType.Length * 16, 20), name+"  "+ classType);
                    else
                        GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 162, 70 + classType.Length * 16, 20), "name  " + classType);
                    GUI.color = Color.white;
                    GUI.skin.box.alignment = TextAnchor.MiddleRight;
                    GUI.Box(new Rect((Screen.width / 2) + 65, (Screen.height / 2) - 162, 150, 20), "Очки навыков: "+exp);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 125, 65, 20), "Сила ");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) - 125, 90, 20), abs_might+"/"+curent_might);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 108, 140, 20), "Интеллект ");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) - 108, 90, 20), abs_intellect + "/" + curent_intellect);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 90, 120, 24), "Сила духа ");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) - 90, 90, 20), abs_willpower + "/" + curent_willpower);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 72, 140, 20), "Выносливость");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) - 72, 90, 20), abs_endurance + "/" + curent_endurance);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 54, 120, 20), "Меткость ");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) - 54, 90, 20), abs_accuracy + "/" + curent_accuracy);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 38, 120, 20), "Скорость ");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) - 38, 90, 20), abs_speed + "/" + curent_speed);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 20, 80, 20), "Удача ");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) - 20, 90, 20), abs_luck + "/" + curent_luck);
                    
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) + 10, 120, 20), "Здоровье");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) + 10, 90, 20), health + "/" + max_health);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) + 28, 110, 20), "Магия");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) + 28, 90, 20), mana + "/" + max_mana);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) + 46, 120, 20), "Кл.брони");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) + 46, 90, 20), AC_cur + "/" +AC_max);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) + 86, 220, 20), "Состояние: "+condition);
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) + 104, 220, 20), "Б.заклинание: " + qspell);

                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 125, 100, 20), "Возраст");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) - 125, 90, 20), age_m + "/" + age);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 108, 85, 20), "Уров.");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) - 108, 90, 20), ""+level);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 90, 85, 20), "Опыт");
                    GUI.skin.box.alignment = TextAnchor.MiddleRight;
                    if (CanTrain)
                        GUI.color = Color.green;
                    GUI.Box(new Rect((Screen.width / 2) + 100, (Screen.height / 2) - 90, 120, 20), ""+exper);

                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.color = Color.white;
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 60, 85, 20), "Атака");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) - 60, 90, 20), "+" + atack);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 42, 85, 20), "Урон");
                    //GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    //GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) - 42, 90, 20), "+" + atack);
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 24, 100, 20), "Стрелять");

                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 6, 85, 20), "Урон");

                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) + 25, 85, 20), "Огонь");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) + 25, 90, 20), fire_actual_rest + "/" + fire_base_rest);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) + 42, 85, 25), "Воздух");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) + 42, 90, 20), Air_actual_rest + "/" + Air_base_rest);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) + 60, 85, 20), "Вода");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) + 60, 90, 20), water_actual_rest + "/" + water_base_rest);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) + 78, 85, 20), "Земля");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) + 78, 90, 20), earth_actual_rest + "/" + earth_base_rest);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) + 97, 85, 20), "Мысль");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) + 97, 90, 20), mind_actual_rest + "/" + mind_base_rest);
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) + 114, 85, 20), "Тело");
                    GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                    GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) + 114, 90, 20), body_actual_rest + "/" + body_base_rest);

                }
                else if (Temp.current_inventory_window == 2)//Skills
                {

                    if (Temp.current_screen == Temp.screen_name.screen_game)
                        current_character = GetCurrentCharacter(this.gameObject.name);
                    if (current_character == 0)
                        current_character = Temp.ActiveCharacter;
                    Temp.current_screen = Temp.screen_name.screen_inventory;
                    GUI.skin = skin;
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;

                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 162, 100, 22), "Навыки для: ");
                    name = "name";
                    string ip = "";
                    switch(current_character){
                       case 1:
                            name = GameObject.Find("Player0").GetComponent<PlayerStats>().Name;
                            exp = Temp.Player1_Skill_Point;
                            ip = "Player0";
                            break;
                       case 2:
                            name = GameObject.Find("Player1").GetComponent<PlayerStats>().Name;
                            exp = Temp.Player2_Skill_Point;
                            ip = "Player1";
                            break;
                       case 3:
                            name = GameObject.Find("Player2").GetComponent<PlayerStats>().Name;
                            exp = Temp.Player3_Skill_Point;
                            ip = "Player2";
                            break;
                       case 4:
                            name = GameObject.Find("Player3").GetComponent<PlayerStats>().Name;
                            exp = Temp.Player4_Skill_Point;
                            ip = "Player3";
                            break;
                    }
                    GUI.color = Color.yellow;
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    if (name != "")
                      GUI.Box(new Rect((Screen.width / 2) - 120, (Screen.height / 2) - 162, 180, 22), ""+name);
                    else
                        GUI.Box(new Rect((Screen.width / 2) - 120, (Screen.height / 2) - 162, 50, 22), "name");
                    GUI.color = Color.white;
                    GUI.skin.box.alignment = TextAnchor.MiddleRight;
                    GUI.Box(new Rect((Screen.width / 2) + 65, (Screen.height / 2) - 162, 150, 20), "Очки навыков: " + exp);
                    GUI.color = Color.yellow;
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 135, 70, 22), "Оружие");
                    GUI.Box(new Rect((Screen.width / 2) - 50, (Screen.height / 2) - 135, 45, 22), "Уров.");
                    int new_x = (Screen.width / 2) - 220;
                    int new_x1 = (Screen.width / 2) - 50;
                    int new_x2 = (Screen.width / 2) - 100;
                    int new_y = (Screen.height / 2) - 120;
                    new_y = CharacterUI_SkillsTab_Draw__DrawSkillTable(ip, new_x, new_x1, new_x2, new_y, pWeaponSkills, 9); // "Weapons"
                    GUI.color = Color.yellow;
                    new_y += 25;
                    GUI.Box(new Rect((Screen.width / 2) - 220, new_y, 70, 22), "Магия");
                    GUI.Box(new Rect((Screen.width / 2) - 50, new_y, 45, 22), "Уров.");
                    new_y += 15;
                    new_y = CharacterUI_SkillsTab_Draw__DrawSkillTable(ip, new_x, new_x1,new_x2, new_y, pMagicSkills, 9); // "Magics"

                    GUI.color = Color.yellow;
                    GUI.Box(new Rect((Screen.width / 2)+ 5, (Screen.height / 2) - 135, 70, 22), "Доспехи");
                    GUI.Box(new Rect((Screen.width / 2) + 175, (Screen.height / 2) - 135, 45, 22), "Уров.");
                    new_x = (Screen.width / 2)+ 5;
                    new_x1 = (Screen.width / 2) + 175;
                    new_x2 = (Screen.width / 2) + 95;
                    new_y = (Screen.height / 2) - 120;
                    new_y = CharacterUI_SkillsTab_Draw__DrawSkillTable(ip, new_x, new_x1, new_x2, new_y, pArmorSkills, 5); // "Armors"

                    GUI.color = Color.yellow;
                    new_y += 25;
                    GUI.Box(new Rect((Screen.width / 2) + 5, new_y, 60, 22), "Разное");
                    GUI.Box(new Rect((Screen.width / 2) + 175, new_y, 45, 22), "Уров.");
                    new_y += 15;
                    new_y = CharacterUI_SkillsTab_Draw__DrawSkillTable(ip, new_x, new_x1, new_x2, new_y, pMiscSkills, 12); // "Others"
                }
                else if (Temp.current_inventory_window == 4)
                {
                    if (Temp.current_screen == Temp.screen_name.screen_game)
                        current_character = GetCurrentCharacter(this.gameObject.name);
                    Temp.current_screen = Temp.screen_name.screen_inventory;
                    GUI.skin = skin;
                    GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                    GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 162, 250, 22), "В разработке");

                }
            }
            //if (fr_inven_flag)
            //{
            //    fr_cur_tex = fr_inven_tex;
            //}
            switch (Temp.current_inventory_window)
            { 
                case 1:
                    fr_cur_tex = fr_stats_tex;
                    //fr_stats_flag = true;
                    break;
                case 2:
                    fr_cur_tex = fr_skill_tex;
                    break;
                case 3:
                    fr_cur_tex = fr_inven_tex;
                    //fr_inven_flag = true;
                    break;
                case 4:
                    fr_cur_tex = fr_award_tex;
                    break;
            }

            if (GUI.Button(new Rect((Screen.width / 2) + 140, (Screen.height / 2) + 133, 80, 35), ""))//Quit
            {
                //fr_inven_flag = true;
                //fr_stats_flag = false;
                Temp.current_screen = Temp.screen_name.screen_game;
                //GetComponent<Inventory>().enabled = false;
                Inventory_open_flag = false;
                GameObject.Find("GameMenu").GetComponent<Menu_Game>().Game_active();
                //right_panel.GetComponent<right_panel>().chest_window_flag = false;
            }
            if (GUI.Button(new Rect((Screen.width / 2) + 50, (Screen.height / 2) + 133, 80, 35), ""))
            {
                //fr_inven_flag = false;
                //fr_stats_flag = false;
                fr_cur_tex = fr_award_tex;
                Temp.current_inventory_window = 4;
            }
            if (GUI.Button(new Rect((Screen.width / 2) - 40, (Screen.height / 2) + 133, 80, 35), ""))
            {
                //fr_inven_flag = true;
                //fr_skill_flag = false;
                //fr_stats_flag = false;
                fr_cur_tex = fr_inven_tex;
                Temp.current_inventory_window = 3;
            }
            if (GUI.Button(new Rect((Screen.width / 2) - 130, (Screen.height / 2) + 133, 80, 35), ""))
            {
                //fr_inven_flag = false;
                //fr_skill_flag = true;
                //fr_stats_flag = false;
                fr_cur_tex = fr_skill_tex;
                Temp.current_inventory_window = 2;
            }
            if (GUI.Button(new Rect((Screen.width / 2) - 220, (Screen.height / 2) + 133, 80, 35), ""))
            {
                //fr_inven_flag = false;
                //fr_skill_flag = false;
                //fr_stats_flag = true;
                fr_cur_tex = fr_stats_tex;
                Temp.current_inventory_window = 1;

            }
            if (GUI.Button(new Rect((Screen.width / 2) - 210, Screen.height - 100, 80, 100), ""))//Character 1
            {

                Temp.ActiveCharacter = 1;
                    current_character = 1;
                Party_panel.GetComponent<Characters_panel>().person_oreol_ID = 1;

            }
            if (GUI.Button(new Rect((Screen.width / 2) - 95, Screen.height - 100, 80, 100), ""))//Character 2
            {

                Temp.ActiveCharacter = 2;
                current_character = 2;
                Party_panel.GetComponent<Characters_panel>().person_oreol_ID = 2;

            }
            if (GUI.Button(new Rect((Screen.width / 2) + 20, Screen.height - 100, 80, 100), ""))//Character 3
            {

                Temp.ActiveCharacter = 3;
                current_character = 3;
                Party_panel.GetComponent<Characters_panel>().person_oreol_ID = 3;

            }
            if (GUI.Button(new Rect((Screen.width / 2) + 135, Screen.height - 100, 80, 100), "") || Input.GetKeyDown(KeyCode.Alpha4))
            {

                Temp.ActiveCharacter = 4;
                current_character = 4;
                Party_panel.GetComponent<Characters_panel>().person_oreol_ID = 4;
            }
        }
    }

    public int[] pArmorSkills = new int[5]
    {
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEATHER,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_CHAIN,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_PLATE,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SHIELD,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DODGE
    };
    public int[] pWeaponSkills = new int[9]
    {
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_AXE,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BOW,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DAGGER,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MACE,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SPEAR,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_STAFF,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SWORD,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_UNARMED,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BLASTER
    };
    public int[] pMiscSkills = new int[12] 
    {
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ALCHEMY, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ARMSMASTER, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BODYBUILDING, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ITEM_ID, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MONSTER_ID, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEARNING, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_TRAP_DISARM, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MEDITATION, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MERCHANT, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_PERCEPTION,
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_REPAIR, 
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_STEALING
    };
    public int[] pMagicSkills = new int[9] 
    {
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_FIRE,    
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_AIR,        
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_WATER,        
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_EARTH,   
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SPIRIT,    
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MIND,     
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BODY,        
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LIGHT,      
        (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DARK
    };

    public int CharacterUI_SkillsTab_Draw__DrawSkillTable(string ip, int new_x, int new_x1, int new_x2, int new_y, int[] skill_list, int skill_list_size)
    {
        int num_skills_drawn = 0;
        for (int i = 0; i < skill_list_size; ++i)
        {
            PlayerStats.PLAYER_SKILL_TYPE skill = (PlayerStats.PLAYER_SKILL_TYPE)skill_list[i];
            int skill_value = GameObject.Find(ip).GetComponent<PlayerStats>().ActiveSkills[(int)skill];
            GUI.color = Color.white;
            if (GameObject.Find(ip).GetComponent<PlayerStats>().SkillPoints > skill_value)
                GUI.color = Color.blue;
            if (skill_value > 0) 
            {
                GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                GUI.Box(new Rect(new_x, new_y, 132, 22), Temp.pSkillNames[(int)skill]);
                  if (GetSkillToMastery(skill_value) == 1)
                  {
                      if (GUI.Button(new Rect(new_x1, new_y, 40, 22), "" + skill_value))
                    {

			        }
                  }
                  else
                  {
                    string skill_level_str = "";

                    switch (GetSkillToMastery(skill_value))
                    {
                      case 4: skill_level_str = Temp.GlobalText[96];  break; // "Grand"
                      case 3: skill_level_str = Temp.GlobalText[432]; break; // Master
                      case 2: skill_level_str = Temp.GlobalText[433]; break; // Expert
                    }

                    GUI.Box(new Rect(new_x2, new_y, 70, 22), "" + skill_level_str);
                    if (GUI.Button(new Rect(new_x1, new_y, 40, 22), "" + skill_value))
                    {

			        }
                  }
                new_y += 15;
                num_skills_drawn++;
            }
        }
        if (num_skills_drawn == 0)
        {
            GUI.color = Color.white;
            GUI.Box(new Rect(new_x, new_y, 40, 22), "Нет");
            new_y += 15;
        }
        return new_y;
    }
    public int GetSkillToMastery(int skill_value)
    {
        switch (skill_value & 0x1C0)
        {
            case 0x100: return 4;     // Grandmaster
            case 0x80: return 3;     // Master
            case 0x40: return 2;     // Expert
            case 0x00: return 1;     // Normal
        }
        //assert(false);
        return 0;
    }


    /*public void OnGUIHint(int x, int y, string text, int curlegth)
    {
        //fadeColor.a = 0.8f;
        //GUI.color = fadeColor;
        //GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), nullTexture, ScaleMode.StretchToFill, true);
        if (text == "")
        {
            //MessageBoxW(nullptr, L"Invalid string passed !", L"E:\\WORK\\MSDEV\\MM7\\MM7\\Code\\Font.cpp:445", 0);
            Debug.Log("Строка пуста");
            return;
        }

        int uInStrLen = text.Length;
        int InStrLen = text.Length;//Узнать длину строки
        if (curlegth == 0)
            curlegth = 70;
        int num_line = uInStrLen / curlegth;

        double ir;
        int line = 0;
        int vline = 0;

        if (uInStrLen < 35)
            line = 8;
        if (num_line > 0)
            vline = 18;
        //получить длину строки
        if (uInStrLen > curlegth)
            uInStrLen = curlegth;
        ir = uInStrLen * 0.78;
        //Debug.Log( ir );
        int w = uInStrLen * 9;
        int z = (num_line * 20) + 32;
        //Debug.Log( z );
        GUI.DrawTexture(new Rect((Screen.width / 2) - x, (Screen.height / 2) - y, w, z), GUITextureBackground);

        GUI.DrawTexture(new Rect(((Screen.width / 2) - x) - 4, ((Screen.height / 2) - y) - 4, 32, 32), tex_left_up);//верхний левый угол
        GUI.DrawTexture(new Rect(((Screen.width / 2) - x) + 28, ((Screen.height / 2) - y) - 4, (w - (int)ir) - line, 8), tex_horizontal_top);//верхняя горизонтальная полоса
        GUI.DrawTexture(new Rect((((Screen.width / 2) - x) + w) - 28, ((Screen.height / 2) - y) - 4, 32, 32), tex_right_up);//верхний правый угол

        GUI.DrawTexture(new Rect(((Screen.width / 2) - x) - 4, ((Screen.height / 2) - y) + 28, 8, (vline * num_line)), tex_vertical_left);//вертикальная левая полоса

        GUI.DrawTexture(new Rect(((Screen.width / 2) - x) - 4, (((Screen.height / 2) - y) + z) - 28, 32, 32), tex_left_bottom);//нижний левый угол
        GUI.DrawTexture(new Rect(((Screen.width / 2) - x) + 28, ((Screen.height / 2) - y) + z - 4, (w - (int)ir) - line, 8), tex_horizontal_btm);//нижняя горизонтальная полоса
        GUI.DrawTexture(new Rect((((Screen.width / 2) - x) + w) - 28, (((Screen.height / 2) - y) + z) - 28, 32, 32), tex_right_bottom);//нижний правый угол

        GUI.DrawTexture(new Rect(((Screen.width / 2) - x) + w - 4, ((Screen.height / 2) - y) + 28, 8, (vline * num_line)), tex_vertical_right);

        GUI.skin = skinTemp;
        GUI.TextArea(new Rect((Screen.width / 2) - x, (Screen.height / 2) - y, w, z), text, InStrLen);
    }*/
    //----- (004927A8) --------------------------------------------------------
    public int AddItem(int ip, int index, uint uItemID)
    {
      if ( index == -1 )
      {
          for (int xcoord = 0; xcoord < INVETORYSLOTSWIDTH; xcoord++)
          {
            for (int ycoord = 0; ycoord < INVETORYSLOTSHEIGHT; ycoord++)
            {
              if ( CanFitItem(ip, (int)(ycoord * INVETORYSLOTSWIDTH + xcoord), (int)uItemID) )
              {
                return CreateItemInInventory(ip, (uint)(ycoord * INVETORYSLOTSWIDTH + xcoord), uItemID);  
              }
            }
          }
        return 0;
      }
      if (!CanFitItem(ip, index, (int)uItemID))
      {
                //pAudioPlayer->PlaySound(SOUND_error, 0, 0, -1, 0, 0, 0, 0);
          Inventory_change_flag = false;
          return 0;
       }
      return CreateItemInInventory(ip, (uint)index, uItemID);
    }
    void OnMouseDrag()
    {
        /*if (Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log("описание предмета");
        }*/
        if (Input.GetMouseButton(0))
        {
            actives2 = actives2 ? false : true;
        }
        //if (Input.GetMouseButton(1))
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //actives = actives ? false : true;
            actives = true;
            //timer_btn = 3f;
            //party.GetComponent<ModalWindow>().flag = true;
            //Debug.Log("actives = true");
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            actives = false;
            party.GetComponent<ModalWindow>().flag = false;
        }
            /*else
            {
                actives = false;
                //party.GetComponent<ModalWindow>().flag = false;
                //Debug.Log("actives = false");
            }  */
        }
    public int mix_items(uint item1_id, int item2_id)
    {
        if (item2_id == 181)
        {
            m_AudioSource.PlayOneShot(mix_sounds[0]);
            switch (item1_id)
            {
                case 140:
                    return 160; 
                    break;
                case 141:
                    return 166;
                    break;
                case 142:
                    return 164;
                    break;
                case 143:
                    return 162;
                    break;
            }

        }
        return 0;
    }
    //----- (00492600) --------------------------------------------------------
    public int CreateItemInInventory(int ip, uint uSlot, uint uItemID)
    {
      int result; // eax@8
      int freeSlot; // [sp+8h] [bp-4h]@4

      string ip_string = "";
      switch (ip)
      {
          case 1:
              ip_string = "Player0";
              break;
          case 2:
              ip_string = "Player1";
              break;
          case 3:
              ip_string = "Player2";
              break;
          case 4:
              ip_string = "Player3";
              break;
      }
      PlayerStats Player = GameObject.Find(ip_string).GetComponent<PlayerStats>();
      freeSlot = FindFreeInventoryListSlot(Player);
      if ( freeSlot == -1 )
      {
        //if ( uActiveCharacter )
          //pPlayers[uActiveCharacter]->PlaySound(SPEECH_NoRoom, 0);
        return 0;
      }
      else
      {
          PutItemArInventoryIndex(Player, (int)uItemID, freeSlot, (int)uSlot);
        result = freeSlot + 1;
            if (uSlot > 0)
                Player.InventoryItemList[uSlot].ItemID = (int)uItemID;
            else
                Player.InventoryItemList[freeSlot].ItemID = (int)uItemID;
      }
      return result;
    }

    //----- (0049298B) --------------------------------------------------------
    public void PutItemArInventoryIndex(PlayerStats Player, int uItemID, int itemListPos, int index)   //originally accepted ItemGen* but needed only its uItemID
    {
      Texture2D item_texture; // esi@1
      uint pInvPos; // esi@4
      uint slot_width; // [sp+Ch] [bp-4h]@1
      uint slot_height; // [sp+18h] [bp+8h]@1

      //item_texture = pIcons_LOD->LoadTexturePtr(pItemsTable->pItems[uItemID].pIconName, TEXTURE_16BIT_PALETTE);
      item_texture = database.items[uItemID].itemTexture;
      slot_width =  GetSizeInInventorySlots((uint)item_texture.width);
      slot_height = GetSizeInInventorySlots((uint)item_texture.height);
      /*if ( !areWeLoadingTexture )
      {
        item_texture->Release();
        pIcons_LOD->SyncLoadedFilesCount();
      }*/
      if ( slot_width > 0 )
      {
          pInvPos = (uint)index;
        for (uint i = 0; i < slot_height; i++)
        {
            for(uint j = 0; j < slot_width; j++)
                Player.InventoryMatrix[pInvPos+j] = -1 -index; 
          pInvPos += INVETORYSLOTSWIDTH;
        }
      }
      if (index > 0)
            Player.InventoryMatrix[index] = index+1;
      else
        Player.InventoryMatrix[index] = itemListPos +1;
    }
    public void DeleteItemArInventoryIndex(PlayerStats Player, int uItemID, int index)   //originally accepted ItemGen* but needed only its uItemID
    {
        Texture2D item_texture; // esi@1
        uint pInvPos; // esi@4
        uint slot_width; // [sp+Ch] [bp-4h]@1
        uint slot_height; // [sp+18h] [bp+8h]@1

        //item_texture = pIcons_LOD->LoadTexturePtr(pItemsTable->pItems[uItemID].pIconName, TEXTURE_16BIT_PALETTE);
        item_texture = database.items[uItemID].itemTexture;
        slot_width = GetSizeInInventorySlots((uint)item_texture.width);
        slot_height = GetSizeInInventorySlots((uint)item_texture.height);
        /*if ( !areWeLoadingTexture )
        {
          item_texture->Release();
          pIcons_LOD->SyncLoadedFilesCount();
        }*/
        if (slot_width > 0)
        {
            pInvPos = (uint)index;
            for (uint i = 0; i < slot_height; i++)
            {
                for (uint j = 0; j < slot_width; j++)
                    Player.InventoryMatrix[pInvPos+j] = 0;
                pInvPos += INVETORYSLOTSWIDTH;
            }
        }
        Player.InventoryMatrix[index] = 0;
    }
    //----- (0041A2C1) --------------------------------------------------------
    public uint GetSizeInInventorySlots(uint uNumPixels)
    {
      if ( (int)uNumPixels < 14 )
        uNumPixels = 14;
      return (uint)((int)(uNumPixels - 14) >> 5) + 1;
    }

    //----- (004925E6) --------------------------------------------------------
    public int FindFreeInventoryListSlot(PlayerStats Player)
    {
      for (int i = 0; i < 126; i++ )
      {
          if (Player.InventoryItemList[i].ItemID == -1)
        {
          return i;
        }
      }
      return -1;
    }

    //----- (00492528) --------------------------------------------------------
    public bool CanFitItem(int ip, int uSlot, int uItemID)
    {
      Texture2D texture; // esi@1
      uint slotWidth; // ebx@1
      uint slotHeight; // [sp+1Ch] [bp+Ch]@1

      string ip_string = "";
      switch (ip)
      {
          case 1:
              ip_string = "Player0";
              break;
          case 2:
              ip_string = "Player1";
              break;
          case 3:
              ip_string = "Player2";
              break;
          case 4:
              ip_string = "Player3";
              break;
      }
      PlayerStats Player = GameObject.Find(ip_string).GetComponent<PlayerStats>();
      database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();
      //texture = pIcons_LOD->LoadTexturePtr(pItemsTable->pItems[uItemID].pIconName, TEXTURE_16BIT_PALETTE);
      texture = database.items[uItemID].itemTexture;
      slotWidth = GetSizeInInventorySlots((uint)texture.width);
      slotHeight = GetSizeInInventorySlots((uint)texture.height);
      /*if ( !areWeLoadingTexture )
      {
        texture->Release();
        pIcons_LOD->SyncLoadedFilesCount();
      }*/
      //Assert(slotHeight > 0 && slotWidth > 0, "Items should have nonzero dimensions");
      if ( (slotWidth + uSlot % INVETORYSLOTSWIDTH) <= INVETORYSLOTSWIDTH && (slotHeight + uSlot / INVETORYSLOTSWIDTH) <= INVETORYSLOTSHEIGHT )
      {
            if (!Inventory_change_flag)
            {
                for (uint x = 0; x < slotWidth; x++)
                {
                    for (uint y = 0; y < slotHeight; y++)
                    {
                        if (Player.InventoryMatrix[y * INVETORYSLOTSWIDTH + x + uSlot] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
        return true;
                
      }
      return false;
    }


}
