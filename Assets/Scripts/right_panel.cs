using UnityEngine;
using UnityEngine.UI;

public class right_panel : MonoBehaviour {
    public GameObject menu;
    public GameObject character;
    public GameObject Quests;
    public GameObject VideoPlayer;
    public GameObject MouseSelect;
    public AudioClip Exit_sound;
    public GUISkin skin;
    public GUISkin NPC_skin;
    public GUISkin skin_menu_btn;
    public GUISkin skin_quick_info_btn;
    public GUISkin skin_rest_btn;
    public GUISkin skin_spell_book_btn;
    public GUISkin skin_history_btn;
    public GUISkin skin_calendar_btn;
    public GUISkin skin_mapbook_btn;
    public GUISkin skin_autonotes_btn;
    public GUISkin skin_quests_btn;
    public GUISkin skin_dungeon_btn_OK;
    public GUISkin skin_dungeon_btn_CANCEL;
    //public Sprite sprite1;
    public bool panel1_texture_flag;
    public Texture2D panel1_texture;
    //public Sprite sprite2;
    public bool panel2_texture_flag;
    public Texture2D panel2_texture;
    //public Sprite sprite3;
    public Texture2D Body1;
    public Texture2D Body1_1;
    public Texture2D Body1_2;
    public Texture2D Body1_3;
    public Texture2D Body1_4;
    public Texture2D Body1_5;
    public Texture2D Body2;
    public Texture2D Body2_1;
    public Texture2D Body2_2;
    public Texture2D Body2_3;
    public Texture2D Body2_4;
    public Texture2D Body2_5;
    public Texture2D Body3;
    public Texture2D Body3_1;
    public Texture2D Body3_2;
    public Texture2D Body3_3;
    public Texture2D Body3_4;
    public Texture2D Body3_5;
    public Texture2D Body4;
    public Texture2D Body4_1;
    public Texture2D Body4_2;
    public Texture2D Body4_3;
    public Texture2D Body4_4;
    public Texture2D Body4_5;
    public Texture2D Body5;
    public Texture2D Body5_1;
    public Texture2D Body5_2;
    public Texture2D Body5_3;
    public Texture2D Body5_4;
    public Texture2D Body5_5;
    public Texture2D Body6;
    public Texture2D Body6_1;
    public Texture2D Body6_2;
    public Texture2D Body6_3;
    public Texture2D Body6_4;
    public Texture2D Body6_5;
    public Texture2D Body7;
    public Texture2D Body7_1;
    public Texture2D Body7_2;
    public Texture2D Body7_3;
    public Texture2D Body7_4;
    public Texture2D Body7_5;
    public Texture2D Body8;
    public Texture2D Body8_1;
    public Texture2D Body8_2;
    public Texture2D Body8_3;
    public Texture2D Body8_4;
    public Texture2D Body8_5;
    public Texture2D Body9;
    public Texture2D Body9_1;
    public Texture2D Body9_2;
    public Texture2D Body9_3;
    public Texture2D Body9_4;
    public Texture2D Body9_5;
    public Texture2D Body10;
    public Texture2D Body10_1;
    public Texture2D Body10_2;
    public Texture2D Body10_3;
    public Texture2D Body10_4;
    public Texture2D Body10_5;
    public Texture2D Body11;
    public Texture2D Body11_1;
    public Texture2D Body11_2;
    public Texture2D Body11_3;
    public Texture2D Body11_4;
    public Texture2D Body11_5;
    public Texture2D Body12;
    public Texture2D Body12_1;
    public Texture2D Body12_2;
    public Texture2D Body12_3;
    public Texture2D Body12_4;
    public Texture2D Body12_5;
    public Texture2D Body13;
    public Texture2D Body13_1;
    public Texture2D Body13_2;
    public Texture2D Body13_3;
    public Texture2D Body13_4;
    public Texture2D Body13_5;
    public Texture2D Body13_6;
    public Texture2D Body14;
    public Texture2D Body14_1;
    public Texture2D Body14_2;
    public Texture2D Body14_3;
    public Texture2D Body14_4;
    public Texture2D Body14_5;
    public Texture2D Body14_6;
    public Texture2D Body15;
    public Texture2D Body15_1;
    public Texture2D Body15_2;
    public Texture2D Body15_3;
    public Texture2D Body15_4;
    public Texture2D Body15_5;
    public Texture2D Body16;
    public Texture2D Body16_1;
    public Texture2D Body16_2;
    public Texture2D Body16_3;
    public Texture2D Body16_4;
    public Texture2D Body16_5;
    public Texture2D Body17;
    public Texture2D Body17_1;
    public Texture2D Body17_2;
    public Texture2D Body17_3;
    public Texture2D Body17_4;
    public Texture2D Body17_5;
    public Texture2D Body18;
    public Texture2D Body18_1;
    public Texture2D Body18_2;
    public Texture2D Body18_3;
    public Texture2D Body18_4;
    public Texture2D Body18_5;
    public Texture2D Body19;
    public Texture2D Body19_1;
    public Texture2D Body19_2;
    public Texture2D Body19_3;
    public Texture2D Body19_4;
    public Texture2D Body19_5;
    public Texture2D Body20;
    public Texture2D Body20_1;
    public Texture2D Body20_2;
    public Texture2D Body20_3;
    public Texture2D Body20_4;
    public Texture2D Body20_5;
    public Texture2D Body21;
    public Texture2D Body21_1;
    public Texture2D Body21_2;
    public Texture2D Body21_3;
    public Texture2D Body21_4;
    public Texture2D Body21_5;
    public Texture2D Body22;
    public Texture2D Body22_1;
    public Texture2D Body22_2;
    public Texture2D Body22_3;
    public Texture2D Body22_4;
    public Texture2D Body22_5;
    public Texture2D Body23;
    public Texture2D Body23_1;
    public Texture2D Body23_2;
    public Texture2D Body23_3;
    public Texture2D Body23_4;
    public Texture2D Body23_5;
    public Texture2D Body23_6;
    public Texture2D Body23_7;
    public Texture2D Body23_8;
    public Texture2D Body23_9;
    public Texture2D Body23_10;
    public Texture2D Body23_11;
    public Texture2D Body23_12;
    public Texture2D Body23_13;
    public Texture2D Body23_14;
    public Texture2D Body23_15;
    public Texture2D Body23_16;
    public Texture2D Body23_17;
    public Texture2D Body23_18;
    public Texture2D Body23_19;
    public Texture2D Body23_20;
    public Texture2D Body23_21;
    public Texture2D Body23_22;
    public Texture2D Body23_23;
    public Texture2D Body24;
    public Texture2D Body24_1;
    public Texture2D Body24_2;
    public Texture2D Body24_3;
    public Texture2D Body24_4;
    public Texture2D Body24_5;
    public Texture2D Body25;
    public Texture2D Body25_1;
    public Texture2D Body25_2;
    public Texture2D Body25_3;
    public Texture2D Body25_4;
    public Texture2D Body25_5;
    public Texture2D pd_background;
    public Texture2D background_hw;
    public Texture2D character_body;
    public Texture2D character_hand;
    public Texture2D character_hand2;
    public Texture2D character_fast;
    public Texture2D character_fast_left;
    public Texture2D character_fast_left2;
    public GameObject r_panel;
    public Texture2D btn_quit;
    public Texture2D btn_OK;
    public Texture2D btn_CANCEL;
    private int next_page;
    public GameObject party;
    public GameObject Player;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    private ItemDatebase database;
    Texture2D null_tex = null;
    Texture2D cloak = null;
    Texture2D cloak_collar = null;
    Texture2D bow = null;
    Texture2D armor = null;
    Texture2D armor_shoulders = null;
    Texture2D helm = null;
    Texture2D boot = null;
    Texture2D belt = null;
    Texture2D shield = null;
    Texture2D weapon1 = null;
    int cloak_x = 0;
    int cloak_y = 0;
    int bow_x = 0;
    int bow_y = 0;
    int armor_x = 0;
    int armor_y = 0;
    int helm_x = 0;
    int helm_y = 0;
    int boot_x = 0;
    int boot_y = 0;
    int belt_x = 0;
    int belt_y = 0;
    int shield_x = 0;
    int shield_y = 0;
    int weapon1_x = 0;
    int weapon1_y = 0;
    private Texture2D NPC_portrate;
    public Texture2D HNPC1;
    public Texture2D[] Paperdoll_Cloak1_items = new Texture2D[4];
    public Texture2D[] Paperdoll_Cloak2_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Cloak3_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Cloak4_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Cloak5_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Cloak6_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Cloak7_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Cloak8_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Cloak9_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Cloak10_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Bow_items = new Texture2D[10];
    public Texture2D[] Paperdoll_Armor1_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Armor2_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Armor3_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Armor4_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor5_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor6_items = new Texture2D[5];
    public Texture2D[] Paperdoll_Armor7_items = new Texture2D[8];
    public Texture2D[] Paperdoll_Armor8_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor9_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor10_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor11_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor12_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor13_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor14_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor15_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Armor16_items = new Texture2D[12];
    public Texture2D[] Paperdoll_Helm1_items = new Texture2D[2];
    public Texture2D[] Paperdoll_Boot1_items = new Texture2D[4];
    public Texture2D[] Paperdoll_Belt1_items = new Texture2D[2];
    public Texture2D[] Paperdoll_Shields_items = new Texture2D[10];
    public Texture2D[] Paperdoll_Weapons_items = new Texture2D[57];
    public int groups = 0;
    public bool chest_window_flag = false;
    public GameObject DungeonWindow;
    //public Image img;
    //public Image img_body;

    // Use this for initialization
    void Start () {
        /*r_panel = GameObject.Find("right_panel");
        img = r_panel.GetComponent<Image>() as Image;*/
        next_page = 0;
        panel1_texture_flag = false;
        panel2_texture_flag = false;
        database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Temp.current_screen == Temp.screen_name.screen_game)
        {
            panel1_texture_flag = true;
            panel2_texture_flag = false;
        }
        else if (Temp.current_screen == Temp.screen_name.screen_inventory && !chest_window_flag || Temp.current_screen == Temp.screen_name.screen_house)
        {
            panel1_texture_flag = false;
            panel2_texture_flag = true;

        }
	}
        void OnGUI (){
        GUI.skin = skin;
        if (panel1_texture_flag)
        {
            GUI.DrawTexture(new Rect(Screen.width - panel1_texture.width, Screen.height - panel1_texture.height, panel1_texture.width, panel1_texture.height), panel1_texture);
        }
        else if (panel2_texture_flag)
        {
            GUI.DrawTexture(new Rect(Screen.width - panel2_texture.width, Screen.height - panel2_texture.height, panel2_texture.width, panel2_texture.height), panel2_texture);
        }
        if (Temp.current_screen == Temp.screen_name.screen_inventory && !chest_window_flag)
            {
                int race_id = 0;
                int sex_id = 0;
                int face_id = 0;
                switch (Temp.ActiveCharacter) { 
                    case 1:
                        face_id = GameObject.Find("Player0").GetComponent<PlayerStats>().CurrentFace;
                        SelectBodyTexture(face_id + 1);
                    Player = Player1;
                        sex_id = GetHandsCoord(GameObject.Find("Player0").GetComponent<PlayerStats>().CurrentFace);
                        if (face_id <= 7)
                            race_id = 0;
                        else if (face_id <= 11)
                            race_id = 1;
                        else if (face_id <= 15)
                            race_id = 3;
                        else if (face_id <= 19)
                            race_id = 2;
                        break;
                    case 2:
                    if (party.GetComponent<Party>().players_Count > 1)
                    {
                        face_id = GameObject.Find("Player1").GetComponent<PlayerStats>().CurrentFace;
                        Player = Player2;
                        sex_id = GetHandsCoord(GameObject.Find("Player1").GetComponent<PlayerStats>().CurrentFace);
                        SelectBodyTexture(face_id + 1);
                        if (face_id <= 7)
                            race_id = 0;
                        else if (face_id <= 11)
                            race_id = 1;
                        else if (face_id <= 15)
                            race_id = 3;
                        else if (face_id <= 19)
                            race_id = 2;
                    }
                        break;
                    case 3:
                    if (party.GetComponent<Party>().players_Count > 2)
                    {
                        sex_id = GetHandsCoord(GameObject.Find("Player2").GetComponent<PlayerStats>().CurrentFace);
                        face_id = GameObject.Find("Player2").GetComponent<PlayerStats>().CurrentFace;
                        Player = Player3;
                        SelectBodyTexture(face_id + 1);
                        if (face_id <= 7)
                            race_id = 0;
                        else if (face_id <= 11)
                            race_id = 1;
                        else if (face_id <= 15)
                            race_id = 3;
                        else if (face_id <= 19)
                            race_id = 2;
                    }
                        break;
                    case 4:
                    if (party.GetComponent<Party>().players_Count > 3)
                    {
                        face_id = GameObject.Find("Player3").GetComponent<PlayerStats>().CurrentFace;
                        sex_id = GetHandsCoord(GameObject.Find("Player3").GetComponent<PlayerStats>().CurrentFace);
                        Player = Player4;
                        SelectBodyTexture(face_id + 1);

                        if (face_id <= 7)
                            race_id = 0;
                        else if (face_id <= 11)
                            race_id = 1;
                        else if (face_id <= 15)
                            race_id = 3;
                        else if (face_id <= 19)
                            race_id = 2;
                    }
                        break;
                }
            //подложка фон
            GUI.DrawTexture(new Rect(Screen.width - pd_background.width+10, Screen.height - (pd_background.height+120), pd_background.width-20, pd_background.height-8), pd_background);
            //лук
            bow = null;
            if (Player.GetComponent<PlayerStats>().current_bow > 0 || database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_BOW)
            {
                if (Player.GetComponent<PlayerStats>().current_bow > 0)
                {//имеется лук
                    select_bow();
                    //if (Player.GetComponent<PlayerStats>().current_cloak > 0)
                    //{
                       //GUI.DrawTexture(new Rect(Screen.width - pPaperdoll_BodyX + bow_x, Screen.height - (pPaperdoll_BodyY + bow_y), bow.width, bow.height), bow);
                    //}
                    //else {
                        if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + bow_x, Screen.height - (pPaperdoll_BodyY + bow_y), 55, 55), null_tex))
                        {//нажали на плащ на кукле

                            if (party.GetComponent<Party>().TakenItemID > 0)//есть вещь на мышке
                            {
                                if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_BOW)
                                {
                                    uint temp = party.GetComponent<Party>().TakenItemID;
                                    //поменять текстуру на мыши
                                    party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_bow - 1].itemTexture;
                                    //поменять вещь на мыши
                                    party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_bow;
                                    //поменять вещь на кукле
                                    Player.GetComponent<PlayerStats>().current_bow = (int)temp;
                                }
                            }
                            else// нет вещи на мышке
                            {
                                //поменять текстуру на мыши
                                party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_bow - 1].itemTexture;
                                //поменять вещь на мыши
                                party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_bow;
                                //обнулить на кукле
                                Player.GetComponent<PlayerStats>().current_bow = 0;
                                bow = null;
                            }
                        }
                    if (bow != null) { 
                        GUI.DrawTexture(new Rect(Screen.width - pPaperdoll_BodyX + bow_x, Screen.height - (pPaperdoll_BodyY + bow_y), bow.width, bow.height), bow);
                    }
                }
                else//нет лука на кукле
                {//пустая кнопка
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + 108, Screen.height - (pPaperdoll_BodyY + 78), 55, 55), bow))
                    {
                        if (party.GetComponent<Party>().TakenItemID > 0)//имеется вещь на мыши
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_BOW)
                            {
                                Player.GetComponent<PlayerStats>().current_bow = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemID = 0;
                                party.GetComponent<Party>().TakenItemTexture = null;
                            }
                        }
                    }

                }
            }
            //плащ
            cloak = null;
            cloak_collar = null;
            if (Player.GetComponent<PlayerStats>().current_cloak > 0 || database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_CLOAK)
            {
                if (Player.GetComponent<PlayerStats>().current_cloak > 0)
                {//имеется плащ
                    select_cloak();
                    //Texture2D pTexture = database.items[Player.GetComponent<PlayerStats>().current_cloak].itemTexture;
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + cloak_x, Screen.height - (pPaperdoll_BodyY + cloak_y-120), 70, 55), null_tex))
                    {//нажали на плащ на кукле
                        if (party.GetComponent<Party>().TakenItemID > 0)//есть вещь на мышке
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_CLOAK)
                            {
                                uint temp = party.GetComponent<Party>().TakenItemID;
                                //поменять текстуру на мыши
                                party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_cloak - 1].itemTexture;
                                //поменять вещь на мыши
                                party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_cloak;
                                //поменять вещь на кукле
                                Player.GetComponent<PlayerStats>().current_cloak = (int)temp;
                                cloak_collar = null;
                            }
                        }
                        else// нет вещи на мышке
                        {
                            //поменять текстуру на мыши
                            party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_cloak - 1].itemTexture;
                            //поменять вещь на мыши
                            party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_cloak;
                            //обнулить на кукле
                            Player.GetComponent<PlayerStats>().current_cloak = 0;
                            cloak = null;
                            cloak_collar = null;
                        }
                    }
                    if (cloak != null)
                    {
                        GUI.DrawTexture(new Rect(Screen.width - pPaperdoll_BodyX + cloak_x, Screen.height - (pPaperdoll_BodyY + cloak_y), cloak.width, cloak.height), cloak);
                    }
                }
                else//нет плаща на кукле
                {//пустая кнопка
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + 28, Screen.height - (pPaperdoll_BodyY + 28), 155, 237), cloak))
                    {
                        if (party.GetComponent<Party>().TakenItemID > 0)//имеется вещь на мыши
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_CLOAK)
                            {
                                Player.GetComponent<PlayerStats>().current_cloak = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemID = 0;
                                party.GetComponent<Party>().TakenItemTexture = null;
                            }
                        }
                    }

                }
            }
            //кукла
            GUI.DrawTexture(new Rect(Screen.width - pPaperdoll_BodyX + 10, Screen.height - (pPaperdoll_BodyY + 128), character_body.width, character_body.height), character_body);
            //броня
            armor = null;
            if (Player.GetComponent<PlayerStats>().current_armor > 0 || database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_ARMOUR)
            {
                if (Player.GetComponent<PlayerStats>().current_armor > 0)
                {//имеется броня
                    select_armor();
                        if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + armor_x, Screen.height - (pPaperdoll_BodyY + armor_y), 50, 80), null_tex))
                        {//нажали на плащ на кукле
                            if (party.GetComponent<Party>().TakenItemID > 0)//есть вещь на мышке
                            {
                                if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_ARMOUR)
                                {
                                    uint temp = party.GetComponent<Party>().TakenItemID;
                                    //поменять текстуру на мыши
                                    party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_armor - 1].itemTexture;
                                    //поменять вещь на мыши
                                    party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_armor;
                                    //поменять вещь на кукле
                                    Player.GetComponent<PlayerStats>().current_armor = (int)temp;
                                    armor_shoulders = null;
                                }
                            }
                            else// нет вещи на мышке
                            {
                                //поменять текстуру на мыши
                                party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_armor - 1].itemTexture;
                                //поменять вещь на мыши
                                party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_armor;
                                //обнулить на кукле
                                Player.GetComponent<PlayerStats>().current_armor = 0;
                                armor = null;
                                armor_shoulders = null;
                            }
                        }
                    if (armor != null)
                    {
                        GUI.DrawTexture(new Rect(Screen.width - pPaperdoll_BodyX + armor_x, Screen.height - (pPaperdoll_BodyY + armor_y), armor.width, armor.height), armor);
                    }
                }
                else//нет брони на кукле
                {//пустая кнопка
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + 28, Screen.height - (pPaperdoll_BodyY + 28), 155, 237), armor))
                    {
                        if (party.GetComponent<Party>().TakenItemID > 0)//имеется вещь на мыши
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_ARMOUR)
                            {
                                Player.GetComponent<PlayerStats>().current_armor = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemID = 0;
                                party.GetComponent<Party>().TakenItemTexture = null;
                            }
                        }
                    }

                }
            }

            //шлем
            helm = null;
            if (Player.GetComponent<PlayerStats>().current_helm > 0 || database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_HELMET)
            {
                if (Player.GetComponent<PlayerStats>().current_helm > 0)
                {//имеется шлем
                    select_helm();
                    //Texture2D pTexture = database.items[Player.GetComponent<PlayerStats>().current_cloak].itemTexture;
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + helm_x, Screen.height - (pPaperdoll_BodyY + helm_y), helm.width, helm.height), helm))
                    {//нажали на шлем на кукле
                        if (party.GetComponent<Party>().TakenItemID > 0)//есть вещь на мышке
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_HELMET)
                            {
                                uint temp = party.GetComponent<Party>().TakenItemID;
                                //поменять текстуру на мыши
                                party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_helm - 1].itemTexture;
                                //поменять вещь на мыши
                                party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_helm;
                                //поменять вещь на кукле
                                Player.GetComponent<PlayerStats>().current_helm = (int)temp;
                            }
                        }
                        else// нет вещи на мышке
                        {
                            //поменять текстуру на мыши
                            party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_helm - 1].itemTexture;
                            //поменять вещь на мыши
                            party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_helm;
                            //обнулить на кукле
                            Player.GetComponent<PlayerStats>().current_helm = 0;
                            helm = null;
                        }
                    }
                }
                else//нет шлема на кукле
                {//пустая кнопка
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + 68, Screen.height - (pPaperdoll_BodyY + 103), 46, 53), helm))
                    {
                        if (party.GetComponent<Party>().TakenItemID > 0)//имеется вещь на мыши
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_HELMET)
                            {
                                Player.GetComponent<PlayerStats>().current_helm = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemID = 0;
                                party.GetComponent<Party>().TakenItemTexture = null;
                            }
                        }
                    }

                }
            }
            //обувь
            boot = null;
            if (Player.GetComponent<PlayerStats>().current_boot > 0 || database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_BOOTS)
            {
                if (Player.GetComponent<PlayerStats>().current_boot > 0)
                {//имеется обувь
                    select_boot();
                    //Texture2D pTexture = database.items[Player.GetComponent<PlayerStats>().current_cloak].itemTexture;
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + boot_x, Screen.height - pPaperdoll_BodyY + boot_y, boot.width, boot.height), boot))
                    {//нажали на шлем на кукле
                        if (party.GetComponent<Party>().TakenItemID > 0)//есть вещь на мышке
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_BOOTS)
                            {
                                uint temp = party.GetComponent<Party>().TakenItemID;
                                //поменять текстуру на мыши
                                party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_boot - 1].itemTexture;
                                //поменять вещь на мыши
                                party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_boot;
                                //поменять вещь на кукле
                                Player.GetComponent<PlayerStats>().current_boot = (int)temp;
                            }
                        }
                        else// нет вещи на мышке
                        {
                            //поменять текстуру на мыши
                            party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_boot - 1].itemTexture;
                            //поменять вещь на мыши
                            party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_boot;
                            //обнулить на кукле
                            Player.GetComponent<PlayerStats>().current_boot = 0;
                            boot = null;
                        }
                    }
                }
                else//нет обуви на кукле
                {//пустая кнопка
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + 20, Screen.height - pPaperdoll_BodyY + 165, 154, 58), boot))
                    {
                        if (party.GetComponent<Party>().TakenItemID > 0)//имеется вещь на мыши
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_BOOTS)
                            {
                                Player.GetComponent<PlayerStats>().current_boot = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemID = 0;
                                party.GetComponent<Party>().TakenItemTexture = null;
                            }
                        }
                    }

                }
            }
            //пояс
            belt = null;
            if (Player.GetComponent<PlayerStats>().current_belt > 0 || database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_BELT)
            {
                if (Player.GetComponent<PlayerStats>().current_belt > 0)
                {//имеется пояс
                    select_belt();
                    //Texture2D pTexture = database.items[Player.GetComponent<PlayerStats>().current_cloak].itemTexture;
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + belt_x, Screen.height - pPaperdoll_BodyY + belt_y, 45, 25), null_tex))
                    {//нажали на шлем на кукле
                        if (party.GetComponent<Party>().TakenItemID > 0)//есть вещь на мышке
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_BELT)
                            {
                                uint temp = party.GetComponent<Party>().TakenItemID;
                                //поменять текстуру на мыши
                                party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_belt - 1].itemTexture;
                                //поменять вещь на мыши
                                party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_belt;
                                //поменять вещь на кукле
                                Player.GetComponent<PlayerStats>().current_belt = (int)temp;
                            }
                        }
                        else// нет вещи на мышке
                        {
                            //поменять текстуру на мыши
                            party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_belt - 1].itemTexture;
                            //поменять вещь на мыши
                            party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_belt;
                            //обнулить на кукле
                            Player.GetComponent<PlayerStats>().current_belt = 0;
                            belt = null;
                        }
                    }
                    if (belt != null)
                    {
                        GUI.DrawTexture(new Rect(Screen.width - pPaperdoll_BodyX + belt_x, Screen.height - pPaperdoll_BodyY + belt_y, belt.width, belt.height), belt);
                    }
                    
                }
                else//нет пояса на кукле
                {//пустая кнопка
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + 70, Screen.height - pPaperdoll_BodyY + 50, 54, 25), belt))
                    {
                        if (party.GetComponent<Party>().TakenItemID > 0)//имеется вещь на мыши
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_BELT)
                            {
                                Player.GetComponent<PlayerStats>().current_belt = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemID = 0;
                                party.GetComponent<Party>().TakenItemTexture = null;
                            }
                        }
                    }

                }
            }

            //рука
            GUI.DrawTexture(new Rect(Screen.width - (pPaperdollLeftEmptyHand[race_id][0] + 14), Screen.height - (pPaperdollLeftEmptyHand[race_id][1] + 258), character_hand.width, character_hand.height), character_hand);
            //плечи брони
            if (Player.GetComponent<PlayerStats>().current_armor > 0)
            {
                if (armor_shoulders != null)
                {
                    GUI.DrawTexture(new Rect(Screen.width - pPaperdoll_BodyX + 113, Screen.height - (pPaperdoll_BodyY + 25), armor_shoulders.width, armor_shoulders.height), armor_shoulders);
                }
            }
            //воротник 
            if (Player.GetComponent<PlayerStats>().current_cloak > 0)
            {
                if (cloak_collar != null)
                {
                    GUI.DrawTexture(new Rect(Screen.width - pPaperdoll_BodyX + 60, Screen.height - (pPaperdoll_BodyY + 25), cloak_collar.width, cloak_collar.height), cloak_collar);
                }
            }
            //оружие
            weapon1 = null;
            if (Player.GetComponent<PlayerStats>().current_weapon1 > 0 || database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED)
            {
                if (Player.GetComponent<PlayerStats>().current_weapon1 > 0)
                {//имеется щит
                    select_weapon1();
                    //Texture2D pTexture = database.items[Player.GetComponent<PlayerStats>().current_cloak].itemTexture;
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + weapon1_x, Screen.height - (pPaperdoll_BodyY + weapon1_y), weapon1.width, weapon1.height), weapon1))
                    {//нажали на шлем на кукле
                        if (party.GetComponent<Party>().TakenItemID > 0)//есть вещь на мышке
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED)
                            {
                                uint temp = party.GetComponent<Party>().TakenItemID;
                                //поменять текстуру на мыши
                                party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_weapon1 - 1].itemTexture;
                                //поменять вещь на мыши
                                party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_weapon1;
                                //поменять вещь на кукле
                                Player.GetComponent<PlayerStats>().current_weapon1 = (int)temp;
                            }
                        }
                        else// нет вещи на мышке
                        {
                            //поменять текстуру на мыши
                            party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_weapon1 - 1].itemTexture;
                            //поменять вещь на мыши
                            party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_weapon1;
                            //обнулить на кукле
                            Player.GetComponent<PlayerStats>().current_weapon1 = 0;
                            weapon1 = null;
                        }
                    }
                }
                else//нет щита на кукле
                {//пустая кнопка
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + 30, Screen.height - (pPaperdoll_BodyY+101), 34, 156), weapon1))
                    {
                        if (party.GetComponent<Party>().TakenItemID > 0)//имеется вещь на мыши
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED)
                            {
                                Player.GetComponent<PlayerStats>().current_weapon1 = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemID = 0;
                                party.GetComponent<Party>().TakenItemTexture = null;
                            }
                        }
                    }

                }
            }
            //оружие во второй руке
            if (Player.GetComponent<PlayerStats>().current_weapon2 > 0)
            {
                database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();
                Texture2D pTexture = database.items[Player.GetComponent<PlayerStats>().current_weapon2].itemTexture;
                GUI.DrawTexture(new Rect(Screen.width - pPaperdoll_BodyX + 10, Screen.height - (pPaperdoll_BodyY + 128), pTexture.width, pTexture.height), pTexture);
            }
            //кулак
            GUI.DrawTexture(new Rect(Screen.width - (pPaperdoll_RightHand[sex_id][0] + 115), Screen.height - (pPaperdoll_RightHand[sex_id][1] + 313), character_fast.width, character_fast.height), character_fast);
            //щит
            shield = null;
            if (Player.GetComponent<PlayerStats>().current_shield > 0 || database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_SHIELD)
            {
                if (Player.GetComponent<PlayerStats>().current_shield > 0)
                {//имеется щит
                    select_shield();
                    //Texture2D pTexture = database.items[Player.GetComponent<PlayerStats>().current_cloak].itemTexture;
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + shield_x, Screen.height - pPaperdoll_BodyY + shield_y, shield.width, shield.height), shield))
                    {//нажали на шлем на кукле
                        if (party.GetComponent<Party>().TakenItemID > 0)//есть вещь на мышке
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_SHIELD)
                            {
                                uint temp = party.GetComponent<Party>().TakenItemID;
                                //поменять текстуру на мыши
                                party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_shield - 1].itemTexture;
                                //поменять вещь на мыши
                                party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_shield;
                                //поменять вещь на кукле
                                Player.GetComponent<PlayerStats>().current_shield = (int)temp;
                            }
                        }
                        else// нет вещи на мышке
                        {
                            //поменять текстуру на мыши
                            party.GetComponent<Party>().TakenItemTexture = database.items[Player.GetComponent<PlayerStats>().current_shield - 1].itemTexture;
                            //поменять вещь на мыши
                            party.GetComponent<Party>().TakenItemID = (uint)Player.GetComponent<PlayerStats>().current_shield;
                            //обнулить на кукле
                            Player.GetComponent<PlayerStats>().current_shield = 0;
                            shield = null;
                        }
                    }
                }
                else//нет щита на кукле
                {//пустая кнопка
                    if (GUI.Button(new Rect(Screen.width - pPaperdoll_BodyX + 82, Screen.height - pPaperdoll_BodyY , 83, 141), shield))
                    {
                        if (party.GetComponent<Party>().TakenItemID > 0)//имеется вещь на мыши
                        {
                            if (database.items[(int)party.GetComponent<Party>().TakenItemID].uEquipType == Items.ITEM_EQUIP_TYPE.EQUIP_SHIELD)
                            {
                                Player.GetComponent<PlayerStats>().current_shield = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemID = 0;
                                party.GetComponent<Party>().TakenItemTexture = null;
                            }
                        }
                    }

                }
            }

            GUI.skin = skin;
                GUI.skin.box.alignment = TextAnchor.MiddleRight;
                GUI.Box(new Rect(Screen.width - 85, Screen.height - 102, 52, 22), "" + character.GetComponent<Party>().NumGold);
                //GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                GUI.Box(new Rect(Screen.width - 135, Screen.height - 102, 45, 22), "" + character.GetComponent<Party>().uNumFoodRations);

        }
        else if (Temp.current_screen == Temp.screen_name.screen_chest)
        {
            GUI.skin = skin;
            GUI.skin.box.alignment = TextAnchor.MiddleRight;
            GUI.Box(new Rect(Screen.width - 85, Screen.height - 162, 52, 22), "" + character.GetComponent<Party>().NumGold);
            //GUI.skin.box.alignment = TextAnchor.MiddleLeft;
            GUI.Box(new Rect(Screen.width - 135, Screen.height - 162, 45, 22), "" + character.GetComponent<Party>().uNumFoodRations);
        }
        else if (Temp.current_screen == Temp.screen_name.screen_game)
        {
                GUI.skin = skin;
                GUI.DrawTexture(new Rect(Screen.width - 152, Screen.height - 328, 63, 73), HNPC1);//партрет первого НПС
                GUI.skin.box.alignment = TextAnchor.MiddleRight;
                GUI.Box(new Rect(Screen.width - 85, Screen.height - 162, 52, 22), "" + character.GetComponent<Party>().NumGold);
                //GUI.skin.box.alignment = TextAnchor.MiddleLeft;
                GUI.Box(new Rect(Screen.width - 135, Screen.height - 162, 45, 22), "" + character.GetComponent<Party>().uNumFoodRations);
                GUI.skin = skin_menu_btn;
                if (GUI.Button(new Rect(Screen.width - 40, Screen.height - 32, 35, 28), ""))//menu
                {
                    Temp.current_screen = Temp.screen_name.screen_game_menu;
                    menu.GetComponent<Menu_Game>().menu_open = true;
                }
                GUI.skin = skin_quick_info_btn;
                if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 32, 35, 28), ""))//info
                {
                    Temp.current_screen = Temp.screen_name.screen_quick_info;
                }
                GUI.skin = skin_rest_btn;
                if (GUI.Button(new Rect(Screen.width - 122, Screen.height - 32, 35, 28), ""))//rest
                {
                    Temp.current_screen = Temp.screen_name.screen_rest;
                }
                GUI.skin = skin_spell_book_btn;
                if (GUI.Button(new Rect(Screen.width - 164, Screen.height - 32, 35, 28), ""))//spells
                {
                    Temp.current_screen = Temp.screen_name.screen_spell_book;
                }
                GUI.skin = skin_quests_btn;
                if (GUI.Button(new Rect(Screen.width - 148, Screen.height - 125, 36, 60), ""))//quests book
                {
                    Temp.current_screen = Temp.screen_name.screen_quests_book;
                }
                GUI.skin = skin_autonotes_btn;
                if (GUI.Button(new Rect(Screen.width - 112, Screen.height - 128, 19, 62), ""))//autonotes book
                {

                }
                GUI.skin = skin_mapbook_btn;
                if (GUI.Button(new Rect(Screen.width - 93, Screen.height - 127, 23, 63), ""))//mapbook
                {

                }
                GUI.skin = skin_calendar_btn;
                if (GUI.Button(new Rect(Screen.width - 70, Screen.height - 126, 30, 89), ""))//calendar book
                {

                }
                GUI.skin = skin_history_btn;
                if (GUI.Button(new Rect(Screen.width - 40, Screen.height - 120, 20, 82), ""))//history book
                {

                }
            }
            if (Temp.current_screen == Temp.screen_name.screen_house)
            {
                menu.GetComponent<Menu_Game>().Game_pause();

                GUI.DrawTexture(new Rect(Screen.width - 162, Screen.height - 473, 152, 345), background_hw);//подложка
            GameObject house = GameObject.FindGameObjectWithTag(Temp.current_house_tag);
            GUI.skin = NPC_skin;
            GUI.skin.box.alignment = TextAnchor.MiddleCenter;
            GUI.Box(new Rect(Screen.width - 160, Screen.height - 472, 150, 40), "" + house.GetComponent<house_data>().house_name);
            if (!MouseSelect.GetComponent<MouseSelect>().Dangeon_door_flag)
            {
                NPC_portrate = house.GetComponent<house_data>().portrate1;
                Texture2D NPC_portrate2 = house.GetComponent<house_data>().portrate2;
                if (house.GetComponent<house_data>().descriptions != "")//текстовое приветствие
                {
                    Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest1_1 - 1].QuestDescription = house.GetComponent<house_data>().descriptions;
                    Quests.GetComponent<Quests_data>().quest_id = house.GetComponent<house_data>().quest1_1;
                    Quests.GetComponent<Quests_data>().gui_hint = true;
                }
                if (NPC_portrate != null && NPC_portrate2 != null && next_page == 0)//два и более НПС в доме
                {
                    GUI.DrawTexture(new Rect(Screen.width - 115, Screen.height - 430, 63, 73), NPC_portrate);//портрет1
                    if (house.GetComponent<house_data>().quest1_1 > 0)
                    {
                        if (GUI.Button(new Rect(Screen.width - 115, Screen.height - 430, 63, 73), ""))
                        {
                            //Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest1_1 - 1].QuestState = Quest.Quest_state.Quest_performed;
                            next_page = 1;
                        }//кнопка портрета 1

                    }
                    GUI.Label(new Rect(Screen.width - 160, Screen.height - 358, 150, 22), "" + house.GetComponent<house_data>().Name1 + " " + house.GetComponent<house_data>().profession1);

                    GUI.DrawTexture(new Rect(Screen.width - 115, Screen.height - 320, 63, 73), NPC_portrate2);//портрет1
                    if (house.GetComponent<house_data>().quest2_1 > 0)
                    {
                        if (GUI.Button(new Rect(Screen.width - 115, Screen.height - 320, 63, 73), ""))
                        {
                            //Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest1_1 - 1].QuestState = Quest.Quest_state.Quest_performed;
                            next_page = 2;
                        }//кнопка портрета 2
                    }
                    GUI.Label(new Rect(Screen.width - 160, Screen.height - 248, 150, 22), "" + house.GetComponent<house_data>().Name2 + " " + house.GetComponent<house_data>().profession2);
                    if (GUI.Button(new Rect(Screen.width - 173, Screen.height - 37, 173, 37), btn_quit))
                    {           //При нажатии на ескепи
                        if (next_page > 0)
                        {
                            next_page = 0;
                            Quests.GetComponent<Quests_data>().gui_hint = false;
                            Quests.GetComponent<Quests_data>().gui_hint_not_done = false;
                        }
                        else
                        {
                            Temp.current_screen = Temp.screen_name.screen_game;
                            menu.GetComponent<Menu_Game>().Game_active();
                            MouseSelect.GetComponent<MouseSelect>().MS_reset();
                            VideoPlayer.GetComponent<Video_Player>().video_reset = true;
                            GetComponent<AudioSource>().PlayOneShot(Exit_sound);
                            Quests.GetComponent<Quests_data>().gui_hint = false;
                            Quests.GetComponent<Quests_data>().gui_hint_not_done = false;
                        }
                    }
                }
                else if (NPC_portrate != null && next_page == 0 || next_page == 1)// страница первая и первого НПС
                {
                    GUI.DrawTexture(new Rect(Screen.width - 115, Screen.height - 430, 63, 73), NPC_portrate);//портрет
                                                                                                             //GUI.color = new Color(0x33, 0x66, 0xCC);
                    GUI.Label(new Rect(Screen.width - 160, Screen.height - 358, 150, 22), "" + house.GetComponent<house_data>().Name1 + " " + house.GetComponent<house_data>().profession1);
                    //GUI.color = Color.white;
                    //GUI.skin.font.lineHeight
                    if (house.GetComponent<house_data>().quest1_1 > 0)
                    {
                        if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 338, 150, 55), "" + Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest1_1 - 1].QuestTopic))
                            Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest1_1 - 1].QuestState = Quest.Quest_state.Quest_performed;
                    }
                    if (house.GetComponent<house_data>().quest1_2 > 0)
                    {
                        if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 280, 150, 60), "" + Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest1_2 - 1].QuestTopic))
                            Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest1_2 - 1].QuestState = Quest.Quest_state.Quest_performed;
                    }
                    if (house.GetComponent<house_data>().quest1_3 > 0)
                    {
                        if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 212, 150, 55), "" + Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest1_3 - 1].QuestTopic))
                            Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest1_3 - 1].QuestState = Quest.Quest_state.Quest_performed;
                    }
                    if (GUI.Button(new Rect(Screen.width - 173, Screen.height - 37, 173, 37), btn_quit))
                    {           //При нажатии на ескепи
                        if (next_page > 0)
                        {
                            next_page = 0;
                            Quests.GetComponent<Quests_data>().gui_hint = false;
                            Quests.GetComponent<Quests_data>().gui_hint_not_done = false;
                        }
                        else
                        {
                            Temp.current_screen = Temp.screen_name.screen_game;
                            menu.GetComponent<Menu_Game>().Game_active();
                            MouseSelect.GetComponent<MouseSelect>().MS_reset();
                            VideoPlayer.GetComponent<Video_Player>().video_reset = true;
                            GetComponent<AudioSource>().PlayOneShot(Exit_sound);
                            Quests.GetComponent<Quests_data>().gui_hint = false;
                            Quests.GetComponent<Quests_data>().gui_hint_not_done = false;
                        }
                    }
                }
                else if (NPC_portrate2 != null && next_page == 2)//страница второго НПС
                {
                    GUI.DrawTexture(new Rect(Screen.width - 115, Screen.height - 450, 63, 73), NPC_portrate2);//портрет
                                                                                                              //GUI.color = new Color(0x33, 0x66, 0xCC);
                    GUI.Label(new Rect(Screen.width - 160, Screen.height - 378, 150, 22), "" + house.GetComponent<house_data>().Name2 + " " + house.GetComponent<house_data>().profession2);
                    //GUI.color = Color.white;
                    //GUI.skin.font.lineHeight
                    if (house.GetComponent<house_data>().quest2_1 > 0)
                    {
                        if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 338, 150, 50), "" + Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest2_1 - 1].QuestTopic))
                            Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest2_1 - 1].QuestState = Quest.Quest_state.Quest_performed;
                    }
                    if (house.GetComponent<house_data>().quest2_2 > 0)
                    {
                        if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 280, 150, 50), "" + Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest2_2 - 1].QuestTopic))
                            Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest2_2 - 1].QuestState = Quest.Quest_state.Quest_performed;
                    }
                    if (house.GetComponent<house_data>().quest2_3 > 0)
                    {
                        if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 212, 150, 50), "" + Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest2_3 - 1].QuestTopic))
                            Quests.GetComponent<Quests_data>().Quests[house.GetComponent<house_data>().quest2_3 - 1].QuestState = Quest.Quest_state.Quest_performed;
                    }
                    if (GUI.Button(new Rect(Screen.width - 173, Screen.height - 37, 173, 37), btn_quit))
                    {           //При нажатии на выход
                        if (next_page > 0)
                        {
                            next_page = 0;
                            Quests.GetComponent<Quests_data>().gui_hint = false;
                            Quests.GetComponent<Quests_data>().gui_hint_not_done = false;
                        }
                        else
                        {
                            Temp.current_screen = Temp.screen_name.screen_game;
                            menu.GetComponent<Menu_Game>().Game_active();
                            MouseSelect.GetComponent<MouseSelect>().MS_reset();
                            VideoPlayer.GetComponent<Video_Player>().video_reset = true;
                            GetComponent<AudioSource>().PlayOneShot(Exit_sound);
                            Quests.GetComponent<Quests_data>().gui_hint = false;
                            Quests.GetComponent<Quests_data>().gui_hint_not_done = false;
                            Quests.GetComponent<Quests_data>().gui_hint_done = false;
                        }
                    }
                }
            }
            else
            {
                NPC_portrate = house.GetComponent<house_data>().portrate1;
                GUI.DrawTexture(new Rect(Screen.width - 115, Screen.height - 430, 63, 73), NPC_portrate);//портрет1
                GUI.Label(new Rect(Screen.width - 160, Screen.height - 338, 150, 210), "" + house.GetComponent<house_data>().descriptions);
                GUI.skin = skin_dungeon_btn_OK;
                if (GUI.Button(new Rect(Screen.width - 162, Screen.height - 37, 75, 26), null_tex))
                {
                    Temp.current_screen = Temp.screen_name.screen_game;
                    menu.GetComponent<Menu_Game>().Game_active();
                    MouseSelect.GetComponent<MouseSelect>().MS_reset();
                    MouseSelect.GetComponent<MouseSelect>().Dangeon_door_flag = false;
                    VideoPlayer.GetComponent<Video_Player>().video_reset = true;
                    Quests.GetComponent<Quests_data>().gui_hint = false;
                    Quests.GetComponent<Quests_data>().gui_hint_not_done = false;
                    character.GetComponent<Save>().AutoSave();
                    Application.LoadLevel("Load");
                }
                GUI.skin = skin_dungeon_btn_CANCEL;
                if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 37, 75, 26), null_tex))
                {
                    Temp.current_screen = Temp.screen_name.screen_game;
                    menu.GetComponent<Menu_Game>().Game_active();
                    MouseSelect.GetComponent<MouseSelect>().MS_reset();
                    VideoPlayer.GetComponent<Video_Player>().video_reset = true;
                    MouseSelect.GetComponent<MouseSelect>().Dangeon_door_flag = false;
                    Quests.GetComponent<Quests_data>().gui_hint = false;
                    Quests.GetComponent<Quests_data>().gui_hint_not_done = false;
                }
            }
            GUI.skin = skin;
            GUI.skin.box.alignment = TextAnchor.MiddleRight;
            GUI.Box(new Rect(Screen.width - 85, Screen.height - 102, 52, 22), "" + character.GetComponent<Party>().NumGold);
            GUI.Box(new Rect(Screen.width - 135, Screen.height - 102, 45, 22), "" + character.GetComponent<Party>().uNumFoodRations);

            }

        }

        public int GetHandsCoord(int id)
        {
            switch (id)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 8:
                case 9:
                case 16:
                case 17:
                case 20:
                case 23:
                    return 0;
                case 4:
                case 5:
                case 6:
                case 7:
                case 10:
                case 11:
                case 18:
                case 19:
                case 21:
                case 24:
                    return 1;

                case 12:
                case 13:
                    return 2;
                case 14:
                case 15:
                    return 3;
            }
            return 0;
        }
    public void select_cloak()
    {
        switch (Player.GetComponent<PlayerStats>().current_cloak)
        {
            case 105:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                        cloak = Paperdoll_Cloak1_items[0];
                    else
                        cloak = Paperdoll_Cloak1_items[1];
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                        cloak = Paperdoll_Cloak1_items[2];
                    else
                        cloak = Paperdoll_Cloak1_items[3];
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
            case 106:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak2_items[0];
                        cloak_collar = Paperdoll_Cloak2_items[1];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak2_items[2];
                        cloak_collar = Paperdoll_Cloak2_items[3];

                    }
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak2_items[4];
                        cloak_collar = Paperdoll_Cloak2_items[5];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak2_items[6];
                        cloak_collar = Paperdoll_Cloak2_items[7];

                    }
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
            case 107:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak3_items[0];
                        cloak_collar = Paperdoll_Cloak3_items[1];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak3_items[2];
                        cloak_collar = Paperdoll_Cloak3_items[3];

                    }
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak3_items[4];
                        cloak_collar = Paperdoll_Cloak3_items[5];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak3_items[6];
                        cloak_collar = Paperdoll_Cloak3_items[7];

                    }
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
            case 108:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak4_items[0];
                        cloak_collar = Paperdoll_Cloak4_items[1];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak4_items[2];
                        cloak_collar = Paperdoll_Cloak4_items[3];

                    }
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak4_items[4];
                        cloak_collar = Paperdoll_Cloak4_items[5];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak4_items[6];
                        cloak_collar = Paperdoll_Cloak4_items[7];

                    }
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
            case 109:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak5_items[0];
                        cloak_collar = Paperdoll_Cloak5_items[1];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak5_items[2];
                        cloak_collar = Paperdoll_Cloak5_items[3];

                    }
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak5_items[4];
                        cloak_collar = Paperdoll_Cloak5_items[5];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak5_items[6];
                        cloak_collar = Paperdoll_Cloak5_items[7];

                    }
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
            case 325:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak6_items[0];
                        cloak_collar = Paperdoll_Cloak6_items[1];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak6_items[2];
                        cloak_collar = Paperdoll_Cloak6_items[3];

                    }
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak6_items[4];
                        cloak_collar = Paperdoll_Cloak6_items[5];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak6_items[6];
                        cloak_collar = Paperdoll_Cloak6_items[7];

                    }
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
            case 330:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak7_items[0];
                        cloak_collar = Paperdoll_Cloak7_items[1];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak7_items[2];
                        cloak_collar = Paperdoll_Cloak7_items[3];

                    }
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak7_items[4];
                        cloak_collar = Paperdoll_Cloak7_items[5];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak7_items[6];
                        cloak_collar = Paperdoll_Cloak7_items[7];

                    }
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
            case 347:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak8_items[0];
                        cloak_collar = Paperdoll_Cloak8_items[1];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak8_items[2];
                        cloak_collar = Paperdoll_Cloak8_items[3];

                    }
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak8_items[4];
                        cloak_collar = Paperdoll_Cloak8_items[5];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak8_items[6];
                        cloak_collar = Paperdoll_Cloak8_items[7];

                    }
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
            case 348:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak9_items[0];
                        cloak_collar = Paperdoll_Cloak9_items[1];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak9_items[2];
                        cloak_collar = Paperdoll_Cloak9_items[3];

                    }
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak9_items[4];
                        cloak_collar = Paperdoll_Cloak9_items[5];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak9_items[6];
                        cloak_collar = Paperdoll_Cloak9_items[7];

                    }
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
            case 350:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak10_items[0];
                        cloak_collar = Paperdoll_Cloak10_items[1];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak10_items[2];
                        cloak_collar = Paperdoll_Cloak10_items[3];

                    }
                    cloak_x = 28;
                    cloak_y = 28;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        cloak = Paperdoll_Cloak10_items[4];
                        cloak_collar = Paperdoll_Cloak10_items[5];
                    }
                    else
                    {
                        cloak = Paperdoll_Cloak10_items[6];
                        cloak_collar = Paperdoll_Cloak10_items[7];

                    }
                    cloak_x = 28;
                    cloak_y = 8;
                }
                break;
        }

    }
    public void select_bow()
    {
        switch (Player.GetComponent<PlayerStats>().current_bow)
        {
            case 42:
                    bow = Paperdoll_Bow_items[0];
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    bow_x = 100;
                    bow_y = 78;
                }
                else {
                    bow_x = 100;
                    bow_y = 48;
                }
                break;
        }
    }
    public void select_armor()
    {
        switch (Player.GetComponent<PlayerStats>().current_armor)
        {
            case 66:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor1_items[0];
                        armor_shoulders = Paperdoll_Armor1_items[1];
                    }
                    else {
                        armor = Paperdoll_Armor1_items[2];
                        armor_shoulders = Paperdoll_Armor1_items[3];
                    }
                    armor_x = 56;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor1_items[4];
                        armor_shoulders = Paperdoll_Armor1_items[5];
                    }
                    else {
                        armor = Paperdoll_Armor1_items[6];
                        armor_shoulders = Paperdoll_Armor1_items[7];
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 67:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor2_items[0];
                        armor_shoulders = Paperdoll_Armor2_items[1];
                    }
                    else {
                        armor = Paperdoll_Armor2_items[2];
                        armor_shoulders = Paperdoll_Armor2_items[3];
                    }
                    armor_x = 56;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor2_items[4];
                        armor_shoulders = Paperdoll_Armor2_items[5];
                    }
                    else {
                        armor = Paperdoll_Armor2_items[6];
                        armor_shoulders = Paperdoll_Armor2_items[7];
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 68:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor3_items[0];
                        armor_shoulders = Paperdoll_Armor3_items[1];
                    }
                    else {
                        armor = Paperdoll_Armor3_items[2];
                        armor_shoulders = Paperdoll_Armor3_items[3];
                    }
                    armor_x = 56;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor3_items[4];
                        armor_shoulders = Paperdoll_Armor3_items[5];
                    }
                    else {
                        armor = Paperdoll_Armor3_items[6];
                        armor_shoulders = Paperdoll_Armor3_items[7];
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 69:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor4_items[0];
                        armor_shoulders = Paperdoll_Armor4_items[1];
                        //дуручие
                    }
                    else {
                        armor = Paperdoll_Armor4_items[3];
                        armor_shoulders = Paperdoll_Armor4_items[4];
                        //5
                    }
                    armor_x = 56;
                    armor_y = 26;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor4_items[6];
                        armor_shoulders = Paperdoll_Armor4_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor4_items[9];
                        armor_shoulders = Paperdoll_Armor4_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 70:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor5_items[0];
                        armor_shoulders = Paperdoll_Armor5_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor5_items[3];
                        armor_shoulders = Paperdoll_Armor5_items[4];
                        //5
                    }
                    armor_x = 28;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor5_items[6];
                        armor_shoulders = Paperdoll_Armor5_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor5_items[9];
                        armor_shoulders = Paperdoll_Armor5_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 71:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor6_items[0];
                        armor_shoulders = Paperdoll_Armor6_items[1];
                    }
                    else {
                        armor = Paperdoll_Armor6_items[2];
                        armor_shoulders = Paperdoll_Armor6_items[1];
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor6_items[3];
                        armor_shoulders = Paperdoll_Armor6_items[1];
                    }
                    else {
                        armor = Paperdoll_Armor6_items[4];
                        armor_shoulders = Paperdoll_Armor6_items[1];
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 72:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor7_items[0];
                        armor_shoulders = Paperdoll_Armor7_items[1];
                    }
                    else {
                        armor = Paperdoll_Armor7_items[2];
                        armor_shoulders = Paperdoll_Armor7_items[3];
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor7_items[4];
                        armor_shoulders = Paperdoll_Armor7_items[5];
                    }
                    else {
                        armor = Paperdoll_Armor7_items[6];
                        armor_shoulders = Paperdoll_Armor7_items[7];
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 73:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor8_items[0];
                        armor_shoulders = Paperdoll_Armor8_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor8_items[3];
                        armor_shoulders = Paperdoll_Armor8_items[4];
                        //5
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor8_items[6];
                        armor_shoulders = Paperdoll_Armor8_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor8_items[9];
                        armor_shoulders = Paperdoll_Armor8_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 74:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor9_items[0];
                        armor_shoulders = Paperdoll_Armor9_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor9_items[3];
                        armor_shoulders = Paperdoll_Armor9_items[4];
                        //5
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor9_items[6];
                        armor_shoulders = Paperdoll_Armor9_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor9_items[9];
                        armor_shoulders = Paperdoll_Armor9_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 75:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor10_items[0];
                        armor_shoulders = Paperdoll_Armor10_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor10_items[3];
                        armor_shoulders = Paperdoll_Armor10_items[4];
                        //5
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor10_items[6];
                        armor_shoulders = Paperdoll_Armor10_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor10_items[9];
                        armor_shoulders = Paperdoll_Armor10_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 76:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor11_items[0];
                        armor_shoulders = Paperdoll_Armor11_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor11_items[3];
                        armor_shoulders = Paperdoll_Armor11_items[4];
                        //5
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor11_items[6];
                        armor_shoulders = Paperdoll_Armor11_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor11_items[9];
                        armor_shoulders = Paperdoll_Armor11_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 77:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor12_items[0];
                        armor_shoulders = Paperdoll_Armor12_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor12_items[3];
                        armor_shoulders = Paperdoll_Armor12_items[4];
                        //5
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor12_items[6];
                        armor_shoulders = Paperdoll_Armor12_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor12_items[9];
                        armor_shoulders = Paperdoll_Armor12_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 78:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor13_items[0];
                        armor_shoulders = Paperdoll_Armor13_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor13_items[3];
                        armor_shoulders = Paperdoll_Armor13_items[4];
                        //5
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor13_items[6];
                        armor_shoulders = Paperdoll_Armor13_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor13_items[9];
                        armor_shoulders = Paperdoll_Armor13_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 234:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor14_items[0];
                        armor_shoulders = Paperdoll_Armor14_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor14_items[3];
                        armor_shoulders = Paperdoll_Armor14_items[4];
                        //5
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor14_items[6];
                        armor_shoulders = Paperdoll_Armor14_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor14_items[9];
                        armor_shoulders = Paperdoll_Armor14_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 235:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor15_items[0];
                        armor_shoulders = Paperdoll_Armor15_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor15_items[3];
                        armor_shoulders = Paperdoll_Armor15_items[4];
                        //5
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor15_items[6];
                        armor_shoulders = Paperdoll_Armor15_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor15_items[9];
                        armor_shoulders = Paperdoll_Armor15_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
            case 236:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor16_items[0];
                        armor_shoulders = Paperdoll_Armor16_items[1];
                        //2
                    }
                    else {
                        armor = Paperdoll_Armor16_items[3];
                        armor_shoulders = Paperdoll_Armor16_items[4];
                        //5
                    }
                    armor_x = 46;
                    armor_y = 25;
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        armor = Paperdoll_Armor16_items[6];
                        armor_shoulders = Paperdoll_Armor16_items[7];
                        //8
                    }
                    else {
                        armor = Paperdoll_Armor16_items[9];
                        armor_shoulders = Paperdoll_Armor16_items[10];
                        //11
                    }
                    armor_x = 28;
                    armor_y = 8;
                }
                break;
        }
    }
    public void select_helm()
    {
        switch (Player.GetComponent<PlayerStats>().current_helm)
        {
            case 89:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        helm_x = 70;
                        helm_y = 103;
                        helm = Paperdoll_Helm1_items[0];
                    }
                    else
                    {
                        helm_x = 70;
                        helm_y = 103;
                        helm = Paperdoll_Helm1_items[1];
                    }
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        helm_x = 70;
                        helm_y = 68;
                        helm = Paperdoll_Helm1_items[0];
                    }
                    else
                    {
                        helm_x = 70;
                        helm_y = 68;
                        helm = Paperdoll_Helm1_items[1];
                    }
                }
                break;
        }
    }
    public void select_boot()
    {
        switch (Player.GetComponent<PlayerStats>().current_boot)
        {
            case 115:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        boot_x = 27;
                        boot_y = 158;
                        boot = Paperdoll_Boot1_items[0];
                    }
                    else
                    {
                        boot_x = 68;
                        boot_y = 103;
                        boot = Paperdoll_Boot1_items[1];
                    }
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        boot_x = 70;
                        boot_y = 68;
                        boot = Paperdoll_Boot1_items[2];
                    }
                    else
                    {
                        boot_x = 70;
                        boot_y = 68;
                        boot = Paperdoll_Boot1_items[3];
                    }
                }
                break;
        }
    }
    public void select_belt()
    {
        switch (Player.GetComponent<PlayerStats>().current_belt)
        {
            case 100:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        belt_x = 70;
                        belt_y = 50;
                        belt = Paperdoll_Belt1_items[0];
                    }
                    else
                    {
                        belt_x = 68;
                        belt_y = 103;
                        belt = Paperdoll_Belt1_items[1];
                    }
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        belt_x = 70;
                        belt_y = 68;
                        belt = Paperdoll_Belt1_items[0];
                    }
                    else
                    {
                        belt_x = 70;
                        belt_y = 68;
                        belt = Paperdoll_Belt1_items[1];
                    }
                }
                break;
        }
    }
    public void select_shield()
    {
        switch (Player.GetComponent<PlayerStats>().current_shield)
        {
            case 79:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        shield_x = 82;
                        shield_y = 0;
                        shield = Paperdoll_Shields_items[0];
                    }
                    else
                    {
                        shield_x = 68;
                        shield_y = 103;
                        shield = Paperdoll_Shields_items[0];
                    }
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        shield_x = 70;
                        shield_y = 68;
                        shield = Paperdoll_Shields_items[0];
                    }
                    else
                    {
                        shield_x = 70;
                        shield_y = 68;
                        shield = Paperdoll_Shields_items[0];
                    }
                }
                break;
        }
    }
    public void select_weapon1()
    {
        switch (Player.GetComponent<PlayerStats>().current_weapon1)
        {
            case 1:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        weapon1_x = 30;
                        weapon1_y = 101;
                        weapon1 = Paperdoll_Weapons_items[0];
                    }
                    else
                    {
                        weapon1_x = 68;
                        weapon1_y = 103;
                        weapon1 = Paperdoll_Weapons_items[0];
                    }
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        weapon1_x = 70;
                        weapon1_y = 68;
                        weapon1 = Paperdoll_Weapons_items[0];
                    }
                    else
                    {
                        weapon1_x = 70;
                        weapon1_y = 68;
                        weapon1 = Paperdoll_Weapons_items[0];
                    }
                }
                break;
            case 2:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        weapon1_x = 30;
                        weapon1_y = 110;
                        weapon1 = Paperdoll_Weapons_items[1];
                    }
                    else
                    {
                        weapon1_x = 68;
                        weapon1_y = 103;
                        weapon1 = Paperdoll_Weapons_items[1];
                    }
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        weapon1_x = 70;
                        weapon1_y = 68;
                        weapon1 = Paperdoll_Weapons_items[1];
                    }
                    else
                    {
                        weapon1_x = 70;
                        weapon1_y = 68;
                        weapon1 = Paperdoll_Weapons_items[1];
                    }
                }
                break;
            case 3:
                if (GetRace(Player.GetComponent<PlayerStats>().CurrentFace) != (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF)
                {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        weapon1_x = 30;
                        weapon1_y = 101;
                        weapon1 = Paperdoll_Weapons_items[2];
                    }
                    else
                    {
                        weapon1_x = 68;
                        weapon1_y = 103;
                        weapon1 = Paperdoll_Weapons_items[2];
                    }
                }
                else {
                    if (Player.GetComponent<PlayerStats>().Sex == PlayerStats.PlayerSex.Male)
                    {
                        weapon1_x = 70;
                        weapon1_y = 68;
                        weapon1 = Paperdoll_Weapons_items[2];
                    }
                    else
                    {
                        weapon1_x = 70;
                        weapon1_y = 68;
                        weapon1 = Paperdoll_Weapons_items[2];
                    }
                }
                break;
        }
    }
    public void SelectBodyTexture(int id){
        switch (id)
        {
            case 1:
                character_body = Body1;
                character_hand = Body1_1;
                character_fast = Body1_5;
                break;
            case 2:
                character_body = Body2;
                character_hand = Body2_1;
                character_fast = Body2_5;
                break;
            case 3:
                character_body = Body3;
                character_hand = Body3_1;
                character_fast = Body3_5;
                break;
            case 4:
                character_body = Body4;
                character_hand = Body4_1;
                character_fast = Body4_5;
                break;
            case 5:
                character_body = Body5;
                character_hand = Body5_1;
                character_fast = Body5_5;
                break;
            case 6:
                character_body = Body6;
                character_hand = Body6_1;
                character_fast = Body6_5;
                break;
            case 7:
                character_body = Body7;
                character_hand = Body7_1;
                character_fast = Body7_5;
                break;
            case 8:
                character_body = Body8;
                character_hand = Body8_1;
                character_fast = Body8_5;
                break;
            case 9:
                character_body = Body9;
                character_hand = Body9_1;
                character_fast = Body9_5;
                break;
            case 10:
                character_body = Body10;
                character_hand = Body10_1;
                character_fast = Body10_5;
                break;
            case 11:
                character_body = Body11;
                character_hand = Body11_1;
                character_fast = Body11_5;
                break;
            case 12:
                character_body = Body12;
                character_hand = Body12_1;
                character_fast = Body12_5;
                break;
            case 13:
                character_body = Body13;
                character_hand = Body13_1;
                character_fast = Body13_5;
                break;
            case 14:
                character_body = Body14;
                character_hand = Body14_1;
                character_fast = Body14_5;
                break;
            case 15:
                character_body = Body15;
                character_hand = Body15_1;
                character_fast = Body15_5;
                break;
            case 16:
                character_body = Body16;
                character_hand = Body16_1;
                character_fast = Body16_5;
                break;
            case 17:
                character_body = Body17;
                character_hand = Body17_1;
                character_fast = Body17_5;
                break;
            case 18:
                character_body = Body18;
                character_hand = Body18_1;
                character_fast = Body18_5;
                break;
            case 19:
                character_body = Body19;
                character_hand = Body19_1;
                character_fast = Body19_5;
                break;
            case 20:
                character_body = Body20;
                character_hand = Body20_1;
                character_fast = Body20_5;
                break;
            case 21:
                character_body = Body21;
                character_hand = Body21_1;
                character_fast = Body21_5;
                break;
            case 22:
                character_body = Body22;
                character_hand = Body22_1;
                character_fast = Body22_5;
                break;
            case 23:
                character_body = Body23;
                character_hand = Body23_1;
                character_fast = Body23_5;
                break;
            case 24:
                character_body = Body24;
                character_hand = Body24_1;
                character_fast = Body24_5;
                break;
            case 25:
                character_body = Body25;
                character_hand = Body25_1;
                character_fast = Body25_5;
                break;
        }
    }
    public int GetRace(int cur_face_id)
    {
        if (cur_face_id <= 7)
        {
            return 0;
        }
        else if (cur_face_id <= 11)
        {
            return 1;
        }
        else if (cur_face_id <= 15)
        {
            return 3;
        }
        else if (cur_face_id <= 19)
        {
            return 2;
        }
        else {
            return 0;
        }
    }
    public int[] pPaperdoll_Beards = new int[4]{52, 130, 56, 136};
    public int[][] pPaperdoll_LeftHand = new int[][]{
        new int[]{0x67, 0x6A},
        new int[]{0x65, 0x6C},
        new int[]{0x74, 0x8D},
        new int[]{0x74, 0x93}};
    public int[][] pPaperdoll_SecondLeftHand = new int[][]{
        new int[]{0x1A, 0x6B},
        new int[]{0x28, 0x6D},
        new int[]{0x19, 0x8D},
        new int[]{0x20, 0x92}};
    public int[][] pPaperdoll_RightHand = new int[4][]{
        new int[2]{19, 23},//human_Male
        new int[2]{20, 15},//human_Female
        new int[2]{22, -20},//dwarf_Male
        new int[2]{22, -20}};//dwarf_Female
    public int[][] pPaperdollLeftEmptyHand = new int[4][]{
        new int[2]{47, 120},//human
        new int[2]{47, 118},//elf
        new int[2]{47, 120},//goblin
        new int[2]{37, 75}};//dwarf

    public int pPaperdoll_BodyX = 173; // 004E4C28
    public int pPaperdoll_BodyY = 353;   // 004E4C2C
}
