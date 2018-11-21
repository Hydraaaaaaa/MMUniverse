/// <summary>
/// Player stats.
/// Хранит данные о группе
/// Вешать на игрока
/// </summary>
using UnityEngine;
using System.Collections;

public class Party : MonoBehaviour {
    public int players_Count;
    public Texture2D Plus_text;
    public Texture2D Minus_text;
    private int plus_pos = 180;

    public GUISkin skin;
    public GUISkin skin2;
    public GUISkin skinCenter;
    public GUISkin skinRight;
    public Texture2D NewGame_tex;
    public Texture2D Aframe_tex;
    public Texture2D[] aTexture_Face = new Texture2D[19];
    public Texture2D[] pTextures_PlayerFaces = new Texture2D[224];
    public Texture2D[] pTextures_arrowl = new Texture2D[19];
    public Texture2D[] pTextures_arrowr = new Texture2D[19];
    public int uPlayerCreationUI_ArrowAnim;
    public float arrow_timer;
    public Texture2D[] Texture_Logo = new Texture2D[9];
    public AudioClip[] VoiceList = new AudioClip[20];

    private AudioSource m_AudioSource;
    public AudioClip[] atack_sounds = new AudioClip[2];
    public GameObject oreol;

    public string uRaceName;
    public Event current_name;
    private string playerName;
    public bool create_flag = false;
    public Color fadeColor;
    public Texture2D nullTexture;
    public int PosActiveItemX = 0;
    public int PosActiveItemY = 0;
    public bool PosActiveItem_flag = false;
    public int eAttribute = -1;
    int i;
    //For Temp
    public Texture GUITextureBackground;
    public Texture2D tex_horizontal_top;
    public Texture2D tex_horizontal_btm;
    public Texture2D tex_vertical_left;
    public Texture2D tex_vertical_right;
    public Texture2D tex_left_up;
    public Texture2D tex_right_up;
    public Texture2D tex_left_bottom;
    public Texture2D tex_right_bottom;
    public GUISkin skinTemp;
    //
    public bool HintWindow = false;

    public int PartyHeight;
    public int ActiveCharacter;
    public int NumGold;
    public int NumGoldInBank;
    public int NumDeaths;
    public PlayerStats Char0;
    public PlayerStats Char1;
    public PlayerStats Char2;
    public PlayerStats Char3;
    //public PlayerStats Char; // Объект на котором висят статы
    public PlayerStats[] Players;
    public Texture2D TakenItemTexture;
    public uint TakenItemID;
    public GameObject Shoot;

    public enum PARTY_BUFF_INDEX
    {
        PARTY_BUFF_RESIST_AIR = 0,
        PARTY_BUFF_RESIST_BODY = 1,
        PARTY_BUFF_DAY_OF_GODS = 2,
        PARTY_BUFF_DETECT_LIFE = 3,
        PARTY_BUFF_RESIST_EARTH = 4,
        PARTY_BUFF_FEATHER_FALL = 5,
        PARTY_BUFF_RESIST_FIRE = 6,
        PARTY_BUFF_FLY = 7,
        PARTY_BUFF_HASTE = 8,
        PARTY_BUFF_HEROISM = 9,
        PARTY_BUFF_IMMOLATION = 10,
        PARTY_BUFF_INVISIBILITY = 11,
        PARTY_BUFF_RESIST_MIND = 12,
        PARTY_BUFF_PROTECTION_FROM_MAGIC = 13,
        PARTY_BUFF_SHIELD = 14,
        PARTY_BUFF_STONE_SKIN = 15,
        PARTY_BUFF_TORCHLIGHT = 16,
        PARTY_BUFF_RESIST_WATER = 17,
        PARTY_BUFF_WATER_WALK = 18,
        PARTY_BUFF_WIZARD_EYE = 19,
    };
    enum ITEM_EQUIP_TYPE
    {
      EQUIP_SINGLE_HANDED     = 0,
      EQUIP_TWO_HANDED     = 1,
      EQUIP_BOW            = 2,
      EQUIP_ARMOUR         = 3,
      EQUIP_SHIELD         = 4,
      EQUIP_HELMET         = 5,
      EQUIP_BELT           = 6,
      EQUIP_CLOAK          = 7,
      EQUIP_GAUNTLETS      = 8,
      EQUIP_BOOTS          = 9, 
      EQUIP_RING           = 10,
      EQUIP_AMULET         = 11,
      EQUIP_WAND           = 12,
      EQUIP_REAGENT        = 13,
      EQUIP_POTION         = 14,
      EQUIP_SPELL_SCROLL   = 15,
      EQUIP_BOOK           = 16,
      EQIUP_ANY            = 16,
      EQUIP_MESSAGE_SCROLL = 17,
      EQUIP_GOLD           = 18,
      EQUIP_GEM            = 19,
      EQUIP_NONE           = 20
    };
    private Vector2 MousePos;
    public GameObject Person1;
    public float Person1_coord_x;
    public float Person_coord_y;
    public GameObject Person2;
    public float Person2_coord_x;
    public GameObject Person3;
    public float Person3_coord_x;
    public GameObject Person4;
    public float Person4_coord_x;
    public int uCurrentYear;
	public int uCurrentMonth;
	public int uCurrentMonthWeek;
	public int uDaysPlayed;
	public int uCurrentHour;
	public int uCurrentMinute;
	public int uCurrentTimeSecond;
	public int uNumFoodRations;

    private Transform myTransform;

    public float throwForce;
    private ItemDatebase database;
    public  GameObject item;
    //public char pHireling1Name[100];
    //public char pHireling2Name[100];
    /*public pSpellBuffs[] PartyBuffs;
	public struct pSpellBuffs
	{
		public double ExpireTime;
		public int Power;
		public int Skill;
		public int OverlayID;
		public int Caster;
		public int Flags;
		pSpellBuffs(int a)//0
		{
			ExpireTime = a;
			Power = a;
			Skill = a;
			OverlayID = a;
			Caster = a;
			Flags = a;
		}
	}*/

    /*public Party(int a){
		if(a<5)
			Players = new PlayerStats[a];
	}*/
    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
        players_Count = 1;


        Temp.pSkillNames[0] = Temp.GlobalText[271];
        Temp.pSkillNames[1] = Temp.GlobalText[272];
        Temp.pSkillNames[2] = Temp.GlobalText[273];
        Temp.pSkillNames[3] = Temp.GlobalText[274];
        Temp.pSkillNames[4] = Temp.GlobalText[275];
        Temp.pSkillNames[5] = Temp.GlobalText[276];
        Temp.pSkillNames[6] = Temp.GlobalText[277];
        Temp.pSkillNames[7] = Temp.GlobalText[278];
        Temp.pSkillNames[8] = Temp.GlobalText[279];
        Temp.pSkillNames[9] = Temp.GlobalText[280];
        Temp.pSkillNames[10] = Temp.GlobalText[281];
        Temp.pSkillNames[11] = Temp.GlobalText[282];
        Temp.pSkillNames[12] = Temp.GlobalText[283];
        Temp.pSkillNames[13] = Temp.GlobalText[284];
        Temp.pSkillNames[14] = Temp.GlobalText[285];
        Temp.pSkillNames[15] = Temp.GlobalText[286];
        Temp.pSkillNames[16] = Temp.GlobalText[289];
        Temp.pSkillNames[17] = Temp.GlobalText[290];
        Temp.pSkillNames[18] = Temp.GlobalText[291];
        Temp.pSkillNames[19] = Temp.GlobalText[287];
        Temp.pSkillNames[20] = Temp.GlobalText[288];
        Temp.pSkillNames[21] = Temp.GlobalText[292];
        Temp.pSkillNames[22] = Temp.GlobalText[293];
        Temp.pSkillNames[23] = Temp.GlobalText[294];
        Temp.pSkillNames[24] = Temp.GlobalText[295];
        Temp.pSkillNames[25] = Temp.GlobalText[296];
        Temp.pSkillNames[26] = Temp.GlobalText[297];
        Temp.pSkillNames[27] = Temp.GlobalText[298];
        Temp.pSkillNames[28] = Temp.GlobalText[299];
        Temp.pSkillNames[29] = Temp.GlobalText[300];
        Temp.pSkillNames[30] = Temp.GlobalText[50];
        Temp.pSkillNames[31] = Temp.GlobalText[77];
        Temp.pSkillNames[32] = Temp.GlobalText[88];
        Temp.pSkillNames[33] = Temp.GlobalText[89];
        Temp.pSkillNames[34] = Temp.GlobalText[90];
        Temp.pSkillNames[35] = Temp.GlobalText[95];
        Temp.pSkillNames[36] = Temp.GlobalText[301];
        Temp.pSkillNames[37] = Temp.GlobalText[153];

        Temp.pClassNames[0] = Temp.GlobalText[253];
        Temp.pClassNames[1] = Temp.GlobalText[254];
        Temp.pClassNames[2] = Temp.GlobalText[255];
        Temp.pClassNames[3] = Temp.GlobalText[2];

        Temp.pClassNames[4] = Temp.GlobalText[307];
        Temp.pClassNames[5] = Temp.GlobalText[114];
        Temp.pClassNames[6] = Temp.GlobalText[3];
        Temp.pClassNames[7] = Temp.GlobalText[13];

        Temp.pClassNames[8] = Temp.GlobalText[21];
        Temp.pClassNames[9] = Temp.GlobalText[26];
        Temp.pClassNames[10] = Temp.GlobalText[432];
        Temp.pClassNames[11] = Temp.GlobalText[27];

        Temp.pClassNames[12] = Temp.GlobalText[262];
        Temp.pClassNames[13] = Temp.GlobalText[263];
        Temp.pClassNames[14] = Temp.GlobalText[264];
        Temp.pClassNames[15] = Temp.GlobalText[28];

        Temp.pClassNames[16] = Temp.GlobalText[265];
        Temp.pClassNames[17] = Temp.GlobalText[267];
        Temp.pClassNames[18] = Temp.GlobalText[119];
        Temp.pClassNames[19] = Temp.GlobalText[124];

        Temp.pClassNames[20] = Temp.GlobalText[31];
        Temp.pClassNames[21] = Temp.GlobalText[370];
        Temp.pClassNames[22] = Temp.GlobalText[33];
        Temp.pClassNames[23] = Temp.GlobalText[40];

        Temp.pClassNames[24] = Temp.GlobalText[256];
        Temp.pClassNames[25] = Temp.GlobalText[257];
        Temp.pClassNames[26] = Temp.GlobalText[44];
        Temp.pClassNames[27] = Temp.GlobalText[46];

        Temp.pClassNames[28] = Temp.GlobalText[268];
        Temp.pClassNames[29] = Temp.GlobalText[269];
        Temp.pClassNames[30] = Temp.GlobalText[270];
        Temp.pClassNames[31] = Temp.GlobalText[48];

        Temp.pClassNames[32] = Temp.GlobalText[259];
        Temp.pClassNames[33] = Temp.GlobalText[260];
        Temp.pClassNames[34] = Temp.GlobalText[261];
        Temp.pClassNames[35] = Temp.GlobalText[49];

        Temp.aCharacterConditionNames[0] = Temp.GlobalText[52];
        Temp.aCharacterConditionNames[1] = Temp.GlobalText[241];
        Temp.aCharacterConditionNames[2] = Temp.GlobalText[14];
        Temp.aCharacterConditionNames[3] = Temp.GlobalText[4];
        Temp.aCharacterConditionNames[4] = Temp.GlobalText[69];
        Temp.aCharacterConditionNames[5] = Temp.GlobalText[117];
        Temp.aCharacterConditionNames[6] = Temp.GlobalText[166];
        Temp.aCharacterConditionNames[7] = Temp.GlobalText[65];
        Temp.aCharacterConditionNames[8] = Temp.GlobalText[166];
        Temp.aCharacterConditionNames[9] = Temp.GlobalText[65];
        Temp.aCharacterConditionNames[10] = Temp.GlobalText[166];
        Temp.aCharacterConditionNames[11] = Temp.GlobalText[65];
        Temp.aCharacterConditionNames[12] = Temp.GlobalText[162];
        Temp.aCharacterConditionNames[13] = Temp.GlobalText[231];
        Temp.aCharacterConditionNames[14] = Temp.GlobalText[58];
        Temp.aCharacterConditionNames[15] = Temp.GlobalText[220];
        Temp.aCharacterConditionNames[16] = Temp.GlobalText[76];
        Temp.aCharacterConditionNames[17] = Temp.GlobalText[601];
        Temp.aCharacterConditionNames[18] = Temp.GlobalText[98];
    }
    void Start () {
        m_AudioSource = GetComponent<AudioSource>();
        database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();
        //Players = new PlayerStats[4];
        ActiveCharacter = 0;
        TakenItemTexture = null;
        Person1_coord_x = (Screen.width / 2) - 198;
        Person_coord_y = (Screen.height - 91);
        Person2_coord_x = (Screen.width / 2) - 83;
        Person3_coord_x = (Screen.width / 2) + 32;
        Person4_coord_x = (Screen.width / 2) + 147;
        if (!Temp.create_flag && !Temp.transition_flag) {
			Debug.Log("No load");
            for (int j = 0; j < 4; j++) {
                //Players[j].InventoryItemList = new ItemGen[126];
                for (uint i = 0; i < 126; ++i)
                    Players[j].InventoryItemListReset(i);
            }
			//Temp.Player1CurentFacePath = false;
			//Temp.Player2CurentFacePath = false;
			//Temp.Player3CurentFacePath = false;
			//Temp.Player4CurentFacePath = false;
			//Temp.Player1fileName = "Empty";
			//Temp.Player2fileName = "Empty";
			//Temp.Player3fileName = "Empty";
			//Temp.Player4fileName = "Empty";
		} else {
			GetComponent<Load>().LoadGame();
			Debug.Log("Load");
		}
			//PartyBuffs = new pSpellBuffs[20];
			//for (int i = 1; i < 20; ++i)
			//SpellBuffReset(i);
			//Party.PartyBuffs [0].Power = 0;
			
	}
	
	// Update is called once per frame
	void Update () {
        if ((Application.loadedLevelName != "MM7_MainMenu") && Person1.GetComponent<PlayerStats>().sHealth <= 0 && Person2.GetComponent<PlayerStats>().sHealth <= 0 && Person3.GetComponent<PlayerStats>().sHealth <= 0 && Person4.GetComponent<PlayerStats>().sHealth <= 0)
        {
            Application.LoadLevel("PartyMM7Dead");
        }
        if (oreol != null)
            oreol.GetComponent<Characters_panel>().indicator = Characters_panel.Indicator.green;
        Collider[] cols = Physics.OverlapSphere(myTransform.position, 20f);
        foreach (Collider col in cols)
        {
            if (col.tag == "Actor" /*&& col.GetComponentInParent<Actors>().Actor_visible*/ && col.GetComponentInParent<MonsterAI>().uHostilityType != MonsterAI.HostilityRadius.Hostility_Friendly && col.GetComponentInParent<Actors>().sCurrentHP > 0)
                oreol.GetComponent<Characters_panel>().indicator = Characters_panel.Indicator.yellow;
        }
        cols = Physics.OverlapSphere(myTransform.position, 4f);
        foreach (Collider col in cols)
        {
            if (col.tag == "Actor" /*&& col.GetComponentInParent<Actors>().Actor_visible*/ && col.GetComponentInParent<MonsterAI>().uHostilityType != MonsterAI.HostilityRadius.Hostility_Friendly && col.GetComponentInParent<Actors>().sCurrentHP > 0)
                oreol.GetComponent<Characters_panel>().indicator = Characters_panel.Indicator.red;
        }
        if (Input.GetKeyDown(KeyCode.A))//atack
        {
            if (oreol.GetComponent<Characters_panel>().indicator != Characters_panel.Indicator.red && Players[Temp.ActiveCharacter - 1].current_bow > 0)
            {//стрельба из лука
                Shoot.GetComponent<Shoot>().Shoot_flag = true;// флаг стрельбы
            }
            else
            { //рукопашная
                m_AudioSource.PlayOneShot(atack_sounds[0]);
                PartyAtack();
            }
            Temp.ActiveCharacter++;//следующий перс
            oreol.GetComponent<Characters_panel>().person_oreol_ID++;//переключение ореола
            if (Temp.ActiveCharacter > 4)
            {
                oreol.GetComponent<Characters_panel>().person_oreol_ID = 1;
                Temp.ActiveCharacter = 1;
            }
        }
            if (Temp.transition_flag)
            GetComponent<Load>().LoadGame();
        if (TakenItemTexture != null)
        {
            MousePos = Input.mousePosition;
            //Debug.DrawRay(MyRay.origin, MyRay.direction * 10, Color.yellow);
            //MousePos = MyRay.direction;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Debug.Log("вещь брошена");
                if (((MousePos.x > Person1_coord_x) && MousePos.x < (Person1_coord_x + 60)) && ((Screen.height - MousePos.y) > Person_coord_y && (Screen.height - MousePos.y) < (Person_coord_y + 80)))
                {
                    //Debug.Log("вещь брошена в Золтана");
                    Person1.GetComponent<Inventory>().AddItem(1, -1, TakenItemID);
                    GameObject.Find("Party_panel").GetComponent<Characters_panel>().Inventory_open = false;
                    //GameObject.Find("Party_panel").GetComponent<Characters_panel>().person_oreol_ID = 2;
                    TakenItemTexture = null;
                }
                else if (((MousePos.x > Person2_coord_x) && MousePos.x < (Person2_coord_x + 60)) && ((Screen.height - MousePos.y) > Person_coord_y && (Screen.height - MousePos.y) < (Person_coord_y + 80)))
                {
                    //Debug.Log("вещь брошена в Родерика");
                    Person2.GetComponent<Inventory>().AddItem(2, -1, TakenItemID);
                    GameObject.Find("Party_panel").GetComponent<Characters_panel>().Inventory_open = false;
                    //GameObject.Find("Party_panel").GetComponent<Characters_panel>().person_oreol_ID = 1;
                    TakenItemTexture = null;
                }
                else if (((MousePos.x > Person3_coord_x) && MousePos.x < (Person3_coord_x + 60)) && ((Screen.height - MousePos.y) > Person_coord_y && (Screen.height - MousePos.y) < (Person_coord_y + 80)))
                {
                    //Debug.Log("вещь брошена в Сирену");
                    Person3.GetComponent<Inventory>().AddItem(3, -1, TakenItemID);
                    GameObject.Find("Party_panel").GetComponent<Characters_panel>().Inventory_open = false;
                    //GameObject.Find("Party_panel").GetComponent<Characters_panel>().person_oreol_ID = 1;
                    TakenItemTexture = null;
                }
                else if (((MousePos.x > Person4_coord_x) && MousePos.x < (Person4_coord_x + 60)) && ((Screen.height - MousePos.y) > Person_coord_y && (Screen.height - MousePos.y) < (Person_coord_y + 80)))
                {
                    //Debug.Log("вещь брошена в Алексис");
                    Person4.GetComponent<Inventory>().AddItem(4, -1, TakenItemID);
                    GameObject.Find("Party_panel").GetComponent<Characters_panel>().Inventory_open = false;
                    //GameObject.Find("Party_panel").GetComponent<Characters_panel>().person_oreol_ID = 1;
                    TakenItemTexture = null;
                }
                else if (Temp.current_screen == Temp.screen_name.screen_game)
                {
                    GameObject Item;
                    //GetItem(TakenItemID);
                    Item = (GameObject)Instantiate(item, transform.position, transform.rotation); //Создаем дубликат стрелы в позиции объекта на котором скрипт
                    Item.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
                    Item.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(new Vector3(0, 0, throwForce * 1000)));
                    TakenItemTexture = null;

                }
            }
        }
    }
    public void GetItem(uint item_id)
    {

    }
    void OnGUI()
    {
        if (TakenItemTexture != null)
        {

            GUI.DrawTexture(new Rect(MousePos.x, Screen.height - MousePos.y, TakenItemTexture.width, TakenItemTexture.height), TakenItemTexture);

        }
    }
    /*void SpellBuffReset(int i)
	{
		PartyBuffs[i].Skill = 0;
		PartyBuffs[i].Power = 0;
		PartyBuffs[i].ExpireTime = 0.0;
		PartyBuffs[i].Caster = 0;
		PartyBuffs[i].Flags = 0;
		if (PartyBuffs[i].OverlayID>0)
		{
			//pOtherOverlayList->pOverlays[uOverlayID - 1].Reset();
			//pOtherOverlayList->bRedraw = true;
			PartyBuffs[i].OverlayID = 0;
		}
	}*/

    public void PartyAtack()
    {
        if (Time.timeScale == 0)
            return;
        Collider[] cols = Physics.OverlapSphere(myTransform.position, 4f);
        foreach (Collider col in cols)
        {
            if (col.tag == "Actor" && col.GetComponentInParent<Actors>().Actor_visible)
            {
                //Debug.Log("visible");
                col.GetComponentInParent<MonsterAI>().uHostilityType = MonsterAI.HostilityRadius.Hostility_Short;
                col.GetComponentInParent<Actors>().sCurrentHP -= 5;
                col.GetComponentInParent<MonsterAI>().anim.SetBool("anim_wound", true);
                col.GetComponentInParent<MonsterAI>().wound_timer = 4f;
            }
        }
        
        switch (Temp.ActiveCharacter)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
	void Zero()
	{
		//uFlags2 = 0;
		NumGoldInBank = 0;

		uCurrentYear = 0;
		uCurrentMonth = 0;
		uCurrentMonthWeek = 0;
		uDaysPlayed = 0;
		uCurrentHour = 0;
		uCurrentMinute = 0;
		uCurrentTimeSecond = 0;
		
		//field_6FC = 0;
		//days_played_without_rest = 0;
		//vPosition.x = 0;
		//vPosition.y = 0;
		//vPosition.z = 0;
		//uFallStartY = 0;
		//sRotationY = 0;
		//sRotationX = 0;
		//uFallSpeed = 0;
		//field_28 = 0;
		//uDefaultPartyHeight = 192;
		//field_14_radius = 37;
		//y_rotation_granularity = 25;
		//y_rotation_speed = 90;
		
		//uWalkSpeed = 384;
		//walk_sound_timer = 0;
		
		//field_24 = 5;
		//field_6FC = 0;
		//field_708 = 15;
		//field_0 = 25;
		
		NumDeaths = 0;
		//uNumPrisonTerms = 0;
		//uNumBountiesCollected = 0;
		//monster_for_hunting_killed.fill(0);
		//monster_id_for_hunting.fill(0);
		//memset(_quest_bits, 0, sizeof(_quest_bits));
		//pArcomageWins.fill(0);
		//uNumArenaPageWins = 0;
		//uNumArenaSquireWins = 0;
		//uNumArenaKnightWins = 0;
		//uNumArenaLordWins = 0;
	}
	void Reset()
	{  
		Zero();
		
		//field_708 = 15;
		//sEyelevel = 160;
		NumGold = 200;
		uNumFoodRations = 7;
		
		
		//alignment = PartyAlignment_Neutral;
		//SetUserInterface(alignment, true);
		
		Temp.TimePlayed = 0x21C00u;
		//LastRegenerationTime = 0x21C00;
		/*
		bTurnBasedModeOn = false;
		
		uActiveCharacter = 1;
		::pPlayers.ZerothIndex() = &pPlayers[0];
		for (uint i = 0; i < 4; ++i)
			::pPlayers[i + 1] = &pPlayers[i];
		
		pPlayers[0].Reset(PLAYER_CLASS_KNIGHT);
		pPlayers[1].Reset(PLAYER_CLASS_THEIF);
		pPlayers[2].Reset(PLAYER_CLASS_CLERIC);
		pPlayers[3].Reset(PLAYER_CLASS_SORCERER);
		pPlayers[0].uCurrentFace = 17;
		pPlayers[0].uPrevVoiceID = 17;
		pPlayers[0].uVoiceID = 17;
		pPlayers[0].SetInitialStats();
		
		pPlayers[0].uSex = pPlayers[0].GetSexByVoice();
		pPlayers[0].RandomizeName();
		strcpy(pPlayers[0].pName, pGlobalTXT_LocalizationStrings[509]);
		
		
		pPlayers[1].uCurrentFace = 3;
		pPlayers[1].uPrevVoiceID = 3;
		pPlayers[1].uVoiceID = 3;
		pPlayers[1].SetInitialStats();
		pPlayers[1].uSex = pPlayers[1].GetSexByVoice();
		pPlayers[1].RandomizeName();
		strcpy(pPlayers[1].pName, pGlobalTXT_LocalizationStrings[506]);
		pPlayers[2].uCurrentFace = 14;
		pPlayers[2].uPrevVoiceID = 14;
		pPlayers[2].uVoiceID = 14;
		pPlayers[2].SetInitialStats();
		pPlayers[2].uSex = pPlayers[3].GetSexByVoice();
		pPlayers[2].RandomizeName();
		strcpy(pPlayers[2].pName, pGlobalTXT_LocalizationStrings[508]);
		pPlayers[3].uCurrentFace = 10;
		pPlayers[3].uPrevVoiceID = 10;
		pPlayers[3].uVoiceID = 10;
		pPlayers[3].SetInitialStats();
		pPlayers[3].uSex = pPlayers[3].GetSexByVoice();
		pPlayers[3].RandomizeName();
		strcpy(pPlayers[3].pName, pGlobalTXT_LocalizationStrings[507]);
		
		for (uint i = 0; i < 4; ++i)
		{
			pPlayers[i].uTimeToRecovery = 0;
			for (uint j = 0; j < 20; ++j)
				pPlayers[i].pConditions[j] = 0;
			
			for (uint j = 0; j < 24; ++j)
				pPlayers[i].pPlayerBuffs[j].Reset();
			
			pPlayers[i].expression = CHARACTER_EXPRESSION_1;
			pPlayers[i].uExpressionTimePassed = 0;
			pPlayers[i].uExpressionTimeLength = rand() % 256 + 128;
		}
		
		for (uint i = 1; i < 20; ++i)
			pPartyBuffs[i].Reset();
		
		
		pWindowList_at_506F50_minus1_indexing_buttons____and_an_int_[0] = 100;  // default character ui - stats
		uFlags = 0;
		memset(_autonote_bits, 0, sizeof(_autonote_bits));
		memset(_quest_bits, 0, sizeof(_quest_bits));
		pIsArtifactFound.fill(0);
		_449B7E_toggle_bit(_quest_bits, PARTY_QUEST_EMERALD_RED_POTION_ACTIVE, 1);
		_449B7E_toggle_bit(_quest_bits, PARTY_QUEST_EMERALD_SEASHELL_ACTIVE, 1);
		_449B7E_toggle_bit(_quest_bits, PARTY_QUEST_EMERALD_LONGBOW_ACTIVE, 1);
		_449B7E_toggle_bit(_quest_bits, PARTY_QUEST_EMERALD_PLATE_ACTIVE, 1);
		_449B7E_toggle_bit(_quest_bits, PARTY_QUEST_EMERALD_LUTE_ACTIVE, 1);
		_449B7E_toggle_bit(_quest_bits, PARTY_QUEST_EMERALD_HAT_ACTIVE, 1);
		
		PartyTimes._shop_ban_times.fill(0);
		
		memcpy(pNPCStats->pNewNPCData, pNPCStats->pNPCData, 0x94BCu);
		memcpy(pNPCStats->pGroups_copy, pNPCStats->pGroups, 0x66u);
		pNPCStats->pNewNPCData[3].uFlags |= 128;//|= 0x80u; Lady Margaret
		_494035_timed_effects__water_walking_damage__etc();*/
		//pEventTimer->Pause();
	}
	public void CreateDefaultParty(/*char bGiveItems*/)
	{
		//PlayerStats *pCharacter; // esi@3
		//int uSkillIdx; // eax@11
		//uint v16; // [sp-4h] [bp-44h]@26
		//int uNumPlayers; // [sp+18h] [bp-28h]@1
		//ItemGen Dst; // [sp+1Ch] [bp-24h]@10
		
		//pHireling1Name[0] = 0;
		//pHireling2Name[0] = 0;
		//this->hirelingScrollPosition = 0;
		//memset(&pHirelings, 0, sizeof(pHirelings));
		if (!Temp.create_flag || !create_flag) {
			Players [0] = (PlayerStats)Char0.GetComponent ("PlayerStats");
			Players [1] = (PlayerStats)Char1.GetComponent ("PlayerStats");
			Players [2] = (PlayerStats)Char2.GetComponent ("PlayerStats");
			Players [3] = (PlayerStats)Char3.GetComponent ("PlayerStats");

			Players [0].Name = Temp.GlobalText [509]; //Zoltan
			Players [0].PrevFace = 17;
			Players [0].CurrentFace = 17;
			Players [0].PrevVoiceID = 17;
			Players [0].VoiceID = 17;
			Players [0].Might = 30;
			Players [0].Intelligence = 5;
			Players [0].Willpower = 5;
			Players [0].Endurance = 13;
			Players [0].Accuracy = 13;
			Players [0].Speed = 14;
			Players [0].Luck = 7;
			Players [0].ClassType = (PlayerStats.PlayerClassType)0;
			Players[0].Sex= (PlayerStats.PlayerSex)0;
            Players[0].skillLeather = 1;
            Players[0].skillArmsmaster = 1;
            Players[0].skillBow = 1;
            Players[0].skillSword = 1;
			Players[0].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEATHER] = 1;         // leather
			Players[0].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ARMSMASTER] = 1;        // armsmaster
			Players[0].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BOW] = 1;         // bow
			Players[0].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SWORD] = 1;         // sword

			Players [1].Name = Temp.GlobalText [506]; //Roderic
			Players [1].PrevFace = 3;
			Players [1].CurrentFace = 3;
			Players [1].PrevVoiceID = 3;
			Players [1].VoiceID = 3;
			Players [1].Might = 13;
			Players [1].Intelligence = 9;
			Players [1].Willpower = 9;
			Players [1].Endurance = 13;
			Players [1].Accuracy = 13;
			Players [1].Speed = 13;
			Players [1].Luck = 13;
			Players [1].ClassType = (PlayerStats.PlayerClassType)4;
			Players[1].Sex= (PlayerStats.PlayerSex)0;
            Players[1].skillLeather = 1;
            Players[1].skillStealing = 1;
            Players[1].skillDagger = 1;
            Players[1].skillDisarmTrap = 1;
			Players[1].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEATHER] = 1;         // leather
			Players[1].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_STEALING] = 1;        // stealing
			Players[1].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DAGGER] = 1;         // dagger
			Players[1].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_TRAP_DISARM] = 1;        // disarm trap

			Players [2].Name = Temp.GlobalText [508]; // Serena
			Players [2].PrevFace = 14;
			Players [2].CurrentFace = 14;
			Players [2].PrevVoiceID = 14;
			Players [2].VoiceID = 14;
			Players [2].Might = 12;
			Players [2].Intelligence = 9;
			Players [2].Willpower = 20;
			Players [2].Endurance = 22;
			Players [2].Accuracy = 7;
			Players [2].Speed = 13;
			Players [2].Luck = 7;
			Players [2].ClassType = (PlayerStats.PlayerClassType)24;
			Players[2].Sex= (PlayerStats.PlayerSex)1;
            Players[2].skillAlchemy = 1;
            Players[2].skillLeather = 1;
            Players[2].skillBody = 1;
            Players[2].skillMace = 1;
			Players[2].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ALCHEMY] = 1;        // alchemy
			Players[2].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEATHER] = 1;         // leather
			Players[2].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BODY] = 1;        // body
			Players[2].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MACE] = 1;         // mace

			Players [3].Name = Temp.GlobalText [507]; // Alexis
			Players [3].PrevFace = 10;
			Players [3].CurrentFace = 10;
			Players [3].PrevVoiceID = 10;
			Players [3].VoiceID = 10;
			Players [3].Endurance = 13;
			Players [3].Accuracy = 13;
			Players [3].Speed = 13;
			Players [3].Might = 5;
			Players [3].Intelligence = 30;
			Players [3].Willpower = 9;
			Players [3].Luck = 7;
			Players [3].ClassType = (PlayerStats.PlayerClassType)32;
			Players[3].Sex= (PlayerStats.PlayerSex)1;
            Players[3].skillLeather = 1;
            Players[3].skillAir = 1;
            Players[3].skillFire = 1;
            Players[3].skillStaff = 1;
			Players[3].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEATHER] = 1;         // leather
			Players[3].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_AIR] = 1;        // air
			Players[3].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_FIRE] = 1;        // fire
			Players[3].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_STAFF] = 1;         // staff

			PosActiveItemX = (Screen.width / 2) - 310;
			PosActiveItemY =(Screen.height / 2) - 65;

            Players[0].Experience = 251 + Random.Range(0, 100);
            Players[1].Experience = 251 + Random.Range(0, 100);
            Players[2].Experience = 251 + Random.Range(0, 100);
            Players[3].Experience = 251 + Random.Range(0, 100);
            Players[0].BirthYear = 1147 - Random.Range(0, 6);
            Players[1].BirthYear = 1147 - Random.Range(0, 6);
            Players[2].BirthYear = 1147 - Random.Range(0, 6);
            Players[3].BirthYear = 1147 - Random.Range(0, 6);
            Players[0].Level = 1;
            Players[1].Level = 1;
            Players[2].Level = 1;
            Players[3].Level = 1;
            Players[0].sHealth = GetMaxHealth(0);
            Players[1].sHealth = GetMaxHealth(1);
            Players[2].sHealth = GetMaxHealth(2);
            Players[3].sHealth = GetMaxHealth(3);
            Players[0].sMana = GetMaxMana(0);
            Players[1].sMana = GetMaxMana(1);
            Players[2].sMana = GetMaxMana(2);
            Players[3].sMana = GetMaxMana(3);

            NumGold = 200;
            uNumFoodRations = 7;


			Temp.create_flag = true;
            //Temp.transition_flag = true;
            create_flag = true;
		}

		/*for (uNumPlayers = 0; uNumPlayers < 4; uNumPlayers++)
		{
			pCharacter = &pParty->pPlayers[uNumPlayers];
			if (pCharacter->classType == PLAYER_CLASS_KNIGHT)
				pCharacter->sResMagicBase = 10; //player[i].pResMagicBase
			pCharacter->lastOpenedSpellbookPage = 0;
			for (int i = 0; i < 9; i++)//for Magic Book
			{
				if (pPlayers[uNumPlayers].pActiveSkills[12+i])
				{
					pCharacter->lastOpenedSpellbookPage = i;
					break;
				}
			}
			pCharacter->uExpressionTimePassed = 0;
			Dst.Reset();
			if ( bGiveItems )
			{
				pItemsTable->GenerateItem(2, 40, &Dst); //ring
				pCharacter->AddItem2(-1, &Dst);
				for (uSkillIdx = 0; uSkillIdx < 36; uSkillIdx++)
				{
					if ( pCharacter->pActiveSkills[uSkillIdx] )
					{
						switch ( uSkillIdx )
						{
						case PLAYER_SKILL_STAFF:
							pCharacter->WearItem(ITEM_STAFF_1);
							break;
						case PLAYER_SKILL_SWORD:
							pCharacter->WearItem(ITEM_LONGSWORD_1);
							break;
						case PLAYER_SKILL_DAGGER:
							pCharacter->WearItem(ITEM_DAGGER_1);
							break;
						case PLAYER_SKILL_AXE:
							pCharacter->WearItem(ITEM_AXE_1);
							break;
						case PLAYER_SKILL_SPEAR:
							pCharacter->WearItem(ITEM_SPEAR_1);
							break;
						case PLAYER_SKILL_BOW:
							pCharacter->WearItem(ITEM_CROSSBOW_1);
							break;
						case PLAYER_SKILL_MACE:
							pCharacter->WearItem(ITEM_MACE_1);
							break;
						case PLAYER_SKILL_SHIELD:
							pCharacter->WearItem(ITEM_BUCKLER_1);
							break;
						case PLAYER_SKILL_LEATHER:
							pCharacter->WearItem(ITEM_LEATHER_1);
							break;
						case PLAYER_SKILL_CHAIN:
							pCharacter->WearItem(ITEM_CHAINMAIL_1);
							break;
						case PLAYER_SKILL_PLATE:
							pCharacter->WearItem(ITEM_PLATE_1);
							break;
						case PLAYER_SKILL_FIRE:
							pCharacter->AddItem(-1, ITEM_SPELLBOOK_FIRE_STRIKE);
							break;
						case PLAYER_SKILL_AIR:
							pCharacter->AddItem(-1, ITEM_SPELLBOOK_AIR_FEATHER_FALL);
							break;
						case PLAYER_SKILL_WATER:
							pCharacter->AddItem(-1, ITEM_SPELLBOOK_WATER_POISON_SPRAY);
							break;
						case PLAYER_SKILL_EARTH:
							pCharacter->AddItem(-1, ITEM_SPELLBOOK_EARTH_SLOW);
							break;
						case PLAYER_SKILL_SPIRIT:
							pCharacter->AddItem(-1, ITEM_SPELLBOOK_SPIRIT_BLESS);
							break;
						case PLAYER_SKILL_MIND:
							pCharacter->AddItem(-1, ITEM_SPELLBOOK_MIND_MIND_BLAST);
							break;
						case PLAYER_SKILL_BODY:
							pCharacter->AddItem(-1, ITEM_SPELLBOOK_BODY_FIRST_AID);
							break;
						case PLAYER_SKILL_ITEM_ID:
						case PLAYER_SKILL_REPAIR:
						case PLAYER_SKILL_MEDITATION:
						case PLAYER_SKILL_PERCEPTION:
						case PLAYER_SKILL_DIPLOMACY:
						case PLAYER_SKILL_TRAP_DISARM:
						case PLAYER_SKILL_LEARNING:
							pCharacter->AddItem(-1, ITEM_POTION_BOTTLE);
							v16 = 5 * (rand() % 3 + 40);      // simple reagent
							pCharacter->AddItem(-1, v16);
							break;
						case PLAYER_SKILL_DODGE:
							pCharacter->AddItem(-1, ITEM_BOOTS_1);
							break;
						case PLAYER_SKILL_UNARMED:
							pCharacter->AddItem(-1, ITEM_GAUNTLETS_1);
							break;
						default:
							break;
						}
					}
				}
				for (int i = 0; i < 138; i++)
				{
					if ( pCharacter->pInventoryItemList[i].uItemID != 0)
						pCharacter->pInventoryItemList[i].SetIdentified();
				}
			}*/

		//}
	}

    //----- (0048C9C2) --------------------------------------------------------
    public uint GetActualIntelligence(int ip)
    {
      return GetActualAttribute(ip, (int)PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_INTELLIGENCE, Players[ip].Intelligence, Players[ip].IntelligenceBonus);
    }

    //----- (0048CA3F) --------------------------------------------------------
    public uint GetActualWillpower(int ip)
    {
        return GetActualAttribute(ip, (int)PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_WILLPOWER, Players[ip].Willpower, Players[ip].WillpowerBonus);
    }

    //----- (0048E565) --------------------------------------------------------
    public int GetMaxMana(int ip)
    {
      uint v2; // eax@2
      int v3; // esi@4
      uint v4; // eax@5
      int v5; // esi@5
      uint v6; // eax@5
      int v7; // esi@6
      int v8; // esi@6
      int v9; // esi@6
  
      switch (Players[ip].ClassType)
      {
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_ROGUE:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_SPY:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_ASSASSIN:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_ARCHER:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_WARRIOR_MAGE:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_MASTER_ARCHER:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_SNIPER:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_SORCERER:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_WIZARD:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_ARCHMAGE:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_LICH:
          v2 = GetActualIntelligence(ip);
          v3 = GetParameterBonus(v2);
          break;
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_INITIATE:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_MASTER:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_NINJA:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_PALADIN:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_CRUSADER:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_HERO:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_VILLIAN:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_CLERIC:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_PRIEST:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_PRIEST_OF_SUN:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_PRIEST_OF_MOON:
          v2 = GetActualWillpower(ip);
          v3 = GetParameterBonus(v2);
          break;
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_HUNTER:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_RANGER_LORD:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_BOUNTY_HUNTER:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_DRUID:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_GREAT_DRUID:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_ARCH_DRUID:
          case (PlayerStats.PlayerClassType)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_WARLOCK:
          v4 = GetActualWillpower(ip);
          v5 = GetParameterBonus(v4);
          v6 = GetActualIntelligence(ip);
          v3 = GetParameterBonus(v6) + v5;
          break;
        default:
          return 0;
          break;
      }
      v7 = pBaseManaPerLevelByClass[(int)Players[ip].ClassType] * (GetActualLevel(ip) + v3);
      v8 = GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MANA, false) + v7;
      v9 = Players[ip].FullManaBonus
          + pBaseManaByClass[(int)Players[ip].ClassType / 4]
      + GetSkillBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MANA)
          + v8;
      return max(0,v9);
    }

	public int GetRace(int cur_face_id){
		if (cur_face_id <= 7) {
			return 0;
		} else if (cur_face_id <= 11) {
			return 1;
		} else if (cur_face_id <= 15) {
			return 3;
		} else if (cur_face_id <= 19) {
			return 2;
		} else {
			return 0;
		}
	}

	public int GetSexByVoice(int VoiceID)
	{
		switch ( VoiceID )
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 8:
		case 9:
		case 12:
		case 13:
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
		case 14:
		case 15:
		case 18:
		case 19:
		case 21:
		case 24:
			return 1;
		}
		//Error("(%u)", this->uVoiceID);
		return 0;
	}

	/*public struct PlayerCreation_AttributeProps
	{
		int uBaseValue;
		int uMaxValue;
		int uDroppedStep;
		int uBaseStep;
	}*/

	public int[][][] StatTable = new int[4][][]{
		new int[7][]{new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{ 9, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{9, 25, 1, 1}},
		new int[7][]{new int[4]{ 7, 15, 2, 1}, new int[4]{14, 30, 1, 2}, new int[4]{11, 25, 1, 1}, new int[4]{ 7, 15, 2, 1}, new int[4]{14, 30, 1, 2}, new int[4]{11, 25, 1, 1}, new int[4]{9, 20, 1, 1}},
		new int[7][]{new int[4]{14, 30, 1, 2}, new int[4]{ 7, 15, 2, 1}, new int[4]{ 7, 15, 2, 1}, new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{14, 30, 1, 2}, new int[4]{9, 20, 1, 1}},
		new int[7][]{new int[4]{14, 30, 1, 2}, new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{14, 30, 1, 2}, new int[4]{ 7, 15, 2, 1}, new int[4]{ 7, 15, 2, 1}, new int[4]{9, 20, 1, 1}}
	};

	void SetInitialStats(int playerID)
	{
		int v1 = GetRace(Players[playerID].CurrentFace);
		Players[playerID].Might = StatTable[v1][0][0];
		Players[playerID].Intelligence = StatTable[v1][1][0];
		Players[playerID].Willpower = StatTable[v1][2][0];
		Players[playerID].Endurance = StatTable[v1][3][0];
		Players[playerID].Accuracy = StatTable[v1][4][0];
		Players[playerID].Speed = StatTable[v1][5][0];
		Players[playerID].Luck = StatTable[v1][6][0];
	}

	string RandomizeName(PlayerStats.PlayerSex male)
	{
		if (male==PlayerStats.PlayerSex.Male)
			return Temp.NPCNames[Random.Range(0,30)];
        else
			return Temp.NPCNames[Random.Range(30,60)];
	}

	public uint GetBaseAge(int ip)
	{
		//Проблема с временем
        double x1 = (Temp.TimePlayed * 0.234375);
        double x2 = x1 / 60;
        double x3 = x2 / 60;
        double x4 = x3 / 24;
        double x5 = x4 / 7;
        double x6 = x5 / 4;
        double x7 = x6 / 12;
		return (uint)(x7 - Players[ip].BirthYear + GameTime.STARTING_YEAR);
	}
	uint[] pAgeingTable = new uint[4]{50, 100, 150, 0xFFFF};
	uint[][] pAgingAttributeModifier = new uint[][]  
	{new uint[]{100,  75,  40, 10},   //Might
		new uint[]{100, 150, 100, 10},   //Intelligence
		new uint[]{100, 150, 100, 10},   //Willpower
		new uint[]{100,  75,  40, 10},   //Endurance
		new uint[]{100, 100,  40, 10},   //Accuracy
		new uint[]{100, 100,  40, 10},   //Speed
		new uint[]{100, 100, 100, 100}}; //Luck
	uint[][] pConditionAttributeModifier = new uint[][]  
	{new uint[]{100, 100, 100, 120,  50, 200,  75,  60,  50,  30,  25,  10, 100, 100, 100, 100, 100, 100, 100},  //Might
		new uint[]{100, 100, 100,  50,  25,  10, 100, 100,  75,  60,  50,  30, 100, 100, 100, 100, 100,   1, 100},  //Intelligence
		new uint[]{100, 100, 100,  50,  25,  10, 100, 100,  75,  60,  50,  30, 100, 100, 100, 100, 100,   1, 100},  //Willpower
		new uint[]{100, 100, 100, 100,  50, 150,  75,  60,  50,  30,  25,  10, 100, 100, 100, 100, 100, 100, 100},  //Endurance
		new uint[]{100, 100, 100,  50,  10, 100,  75,  60,  50,  30,  25,  10, 100, 100, 100, 100, 100,  50, 100},  //Accuracy
		new uint[]{100, 100, 100, 120,  20, 120,  75,  60,  50,  30,  25,  10, 100, 100, 100, 100, 100,  50, 100},  //Speed
		new uint[]{100, 100, 100, 100, 200, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100}}; //Luck
	uint[] pConditionImportancyTable = new uint[]{16, 15, 14, 17, 13, 2, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 1, 0};

	public uint GetMajorConditionIdx(int ip)
	{
		for (uint i = 0; i < 18; ++i)
			if (Players[ip].Conditions[pConditionImportancyTable[i]])
				return pConditionImportancyTable[i];
		
		return 18;
	}

    //----- (00417939) --------------------------------------------------------
    public int GetConditionDrawColor(uint uConditionIdx)
    {
      switch (uConditionIdx)
      {
        case (uint)Characters_panel.Condition.Zombie:
        case (uint)Characters_panel.Condition.Good:
          return 1;//ui_character_condition_normal_color;

        case (uint)Characters_panel.Condition.Cursed:
        case (uint)Characters_panel.Condition.Weak:
        case (uint)Characters_panel.Condition.Fear:
        case (uint)Characters_panel.Condition.Drunk:
        case (uint)Characters_panel.Condition.Insane:
        case (uint)Characters_panel.Condition.Poison_weak:
        case (uint)Characters_panel.Condition.Disease_weak:
          return 2;//ui_character_condition_light_color;

        case (uint)Characters_panel.Condition.Sleep:
        case (uint)Characters_panel.Condition.Poison_medium:
        case (uint)Characters_panel.Condition.Disease_medium:
        case (uint)Characters_panel.Condition.Paralyzed:
        case (uint)Characters_panel.Condition.Unconcious:
          return 3;//ui_character_condition_moderate_color;

        case (uint)Characters_panel.Condition.Poison_severe:
        case (uint)Characters_panel.Condition.Disease_severe:
        case (uint)Characters_panel.Condition.Dead:
        case (uint)Characters_panel.Condition.Pertified:
        case (uint)Characters_panel.Condition.Eradicated:
          return 4;//ui_character_condition_severe_color;
      }
      Debug.Log("Invalid condition "+uConditionIdx);
      return 0;
    }

	int GetMagicalBonus(int a2)
	{
		int v3 = 0; // eax@4
		int v4 = 0; // ecx@5
		
		switch ( a2 )
		{
		case 0:
			v3 = Temp.PlayerBuffs[19].Power;
			v4 = Temp.PartyBuffs[2].Power;
			break;
		case 1:
			v3 = Temp.PlayerBuffs[17].Power;
			v4 = Temp.PartyBuffs[2].Power;
			break;
		case 2:
			v3 = Temp.PlayerBuffs[20].Power;
			v4 = Temp.PartyBuffs[2].Power;
			break;
		case 3:
			v3 = Temp.PlayerBuffs[16].Power;
			v4 = Temp.PartyBuffs[2].Power;
			break;
		case 4:
			v3 = Temp.PlayerBuffs[15].Power;
			v4 = Temp.PartyBuffs[2].Power;
			break;
		case 5:
			v3 = Temp.PlayerBuffs[21].Power;
			v4 = Temp.PartyBuffs[2].Power;
			break;
		case 6:
			v3 = Temp.PlayerBuffs[18].Power;
			v4 = Temp.PartyBuffs[2].Power;
			break;
		case 9:
			v3 = Temp.PlayerBuffs[14].Power;
			v4 = Temp.PartyBuffs[15].Power;
			break;
		case 10:
			v3 = Temp.PlayerBuffs[5].Power;
			v4 = Temp.PartyBuffs[6].Power;
			break;
		case 11:
			v3 = Temp.PlayerBuffs[0].Power;
			v4 = Temp.PartyBuffs[0].Power;
			break;
		case 12:
			v3 = Temp.PlayerBuffs[22].Power;
			v4 = Temp.PartyBuffs[17].Power;
			break;
		case 13:
			v3 = Temp.PlayerBuffs[3].Power;
			v4 = Temp.PartyBuffs[4].Power;
			break;
		case 14:
			v3 = Temp.PlayerBuffs[9].Power;
			v4 = Temp.PartyBuffs[12].Power;
			break;
		case 15:
			v3 = Temp.PlayerBuffs[2].Power;
			v4 = Temp.PartyBuffs[1].Power;
			break;
		case 25:
		case 29:
			v3 = Temp.PlayerBuffs[1].Power;  //only player effect spell in both VI and VII
			break;
		case 26:
			v3 = Temp.PlayerBuffs[8].Power;
			v4 = Temp.PartyBuffs[9].Power;
			break;
		}
		return v3 + v4;
	}

	uint GetActualAttribute( int ip, int attrId, int attrValue, int attrBonus )
	{
		uint uActualAge = (uint)Players[ip].AgeModifier + GetBaseAge(ip);
		uint uAgeingMultiplier = 100;
		for (uint i = 0; i < 4; ++i)
		{
			if (uActualAge >= pAgeingTable[i])
				uAgeingMultiplier = pAgingAttributeModifier[attrId][i];
			else 
				break;
		}
		
		uint uConditionMult = pConditionAttributeModifier[attrId][GetMajorConditionIdx(ip)];
		uint magicBonus = (uint)GetMagicalBonus(attrId);
		uint itemBonus = 0;//GetItemsBonus(attrId);
		return uConditionMult * uAgeingMultiplier * (uint)attrValue / 100 / 100
			+ magicBonus
				+ itemBonus
				+ (uint)attrBonus;
	}

	void GetStatColor(int i, int uStat)
	{
		int attribute_value = 0; // edx@1
		int base_attribute_value = 0;

		base_attribute_value = StatTable[GetRace(Players[i].CurrentFace)][uStat][0];
		switch (uStat)
		{
		case 0:  attribute_value = Players[i].Might;        break;
		case 1:  attribute_value = Players[i].Intelligence; break;
		case 2:  attribute_value = Players[i].Willpower;    break;
		case 3:  attribute_value = Players[i].Endurance;    break;
		case 4:  attribute_value = Players[i].Accuracy;     break;
		case 5:  attribute_value = Players[i].Speed;        break;
		case 6:  attribute_value = Players[i].Luck;         break;
		default: Debug.Log("Unexpected attribute"); break;
		};
		
		if (attribute_value == base_attribute_value)
			GUI.color=Color.white;
		else if (attribute_value > base_attribute_value)
			GUI.color=Color.green;
		else
			GUI.color=Color.red;
	}

	int GetSkillIdxByOrder(int ip,int order)
	{
		int counter; // edx@5
		bool canBeInactive;
		int requiredValue;
		int offset;
		
		if ( order <= 1 )
		{
			canBeInactive = false;
			requiredValue = 2;  // 2 - primary skill
			offset = 0;
		}
		else if ( order <= 3 )
		{
			canBeInactive = false;
			requiredValue = 1;  // 1 - available
			offset = 2;
		}
		else if ( order <= 12 )
		{
			canBeInactive = true;
			requiredValue = 1;  // 1 - available
			offset = 4;
		}
		else
		{
			return 37;
		}
		counter = 0;
		for (int i = 0; i < 37; i++)
		{
			if ( Players[ip].ActiveSkills[i]>0)
			{
				if(Temp.SkillAvailabilityPerClass[(int)Players[ip].ClassType / 4][i] == requiredValue ){
					if ( counter == order - offset )
						return i;
					++counter;
				}
			}
			else if ( canBeInactive && Temp.SkillAvailabilityPerClass[(int)Players[ip].ClassType / 4][i] == requiredValue )
			{
				if ( counter == order - offset )
					return i;
				++counter;
			}
		}
		
		return 37;
	}
	void PlayerReset(int ip, PlayerStats.PLAYER_CLASS_TYPE cls)
	{
		Players[ip].LevelModifier = 0;
		Players[ip].AgeModifier = 0;
		
		Players[ip].ClassType = (PlayerStats.PlayerClassType)cls;
		Players[ip].LuckBonus = 0;
		Players[ip].SpeedBonus = 0;
		Players[ip].AccuracyBonus = 0;
		Players[ip].EnduranceBonus = 0;
		Players[ip].WillpowerBonus = 0;
		Players[ip].IntelligenceBonus = 0;
		Players[ip].MightBonus = 0;
		Players[ip].Level = 1;
		Players[ip].Experience = 251 + Random.Range(0,100);
		Players[ip].BirthYear = 1147 - Random.Range(0,6);//???
		for (int i=0; i<37; ++i) {
			Players [ip].ActiveSkills [i] = 0;
			if (Temp.SkillAvailabilityPerClass[(int)Players [ip].ClassType / 4][i] != 2)
				continue;
			
			Players [ip].ActiveSkills[i] = 1;
		}
		//memset(_achieved_awards_bits, 0, sizeof(_achieved_awards_bits));
		//memset(&spellbook, 0, sizeof(spellbook));
		
		/*for (uint i = 0; i < 37; ++i)
		{
			if (pSkillAvailabilityPerClass[classType / 4][i] != 2)
				continue;
			
			pActiveSkills[i] = 1;
			
			switch (i)
			{
			case PLAYER_SKILL_FIRE:
				spellbook.pFireSpellbook.bIsSpellAvailable[0] = true;//its temporary, for test spells
				
				extern bool all_magic;
				if ( all_magic == true )
				{
					pActiveSkills[PLAYER_SKILL_AIR] = 1;
					pActiveSkills[PLAYER_SKILL_WATER] = 1;
					pActiveSkills[PLAYER_SKILL_EARTH] = 1;
					spellbook.pFireSpellbook.bIsSpellAvailable[1] = true;
					spellbook.pFireSpellbook.bIsSpellAvailable[2] = true;
					spellbook.pFireSpellbook.bIsSpellAvailable[3] = true;
					spellbook.pFireSpellbook.bIsSpellAvailable[4] = true;
					spellbook.pFireSpellbook.bIsSpellAvailable[5] = true;
					spellbook.pFireSpellbook.bIsSpellAvailable[6] = true;
					spellbook.pFireSpellbook.bIsSpellAvailable[7] = true;
					spellbook.pFireSpellbook.bIsSpellAvailable[8] = true;
					spellbook.pFireSpellbook.bIsSpellAvailable[9] = true;
					spellbook.pFireSpellbook.bIsSpellAvailable[10] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[0] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[1] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[2] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[3] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[4] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[5] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[6] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[7] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[8] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[9] = true;
					spellbook.pAirSpellbook.bIsSpellAvailable[10] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[0] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[1] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[2] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[3] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[4] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[5] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[6] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[7] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[8] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[9] = true;
					spellbook.pWaterSpellbook.bIsSpellAvailable[10] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[0] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[1] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[2] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[3] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[4] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[5] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[6] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[7] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[8] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[9] = true;
					spellbook.pEarthSpellbook.bIsSpellAvailable[10] = true;
				}
				break;
			case PLAYER_SKILL_AIR:
				spellbook.pAirSpellbook.bIsSpellAvailable[0] = true;
				break;
			case PLAYER_SKILL_WATER:
				spellbook.pWaterSpellbook.bIsSpellAvailable[0] = true;
				break;
			case PLAYER_SKILL_EARTH:
				spellbook.pEarthSpellbook.bIsSpellAvailable[0] = true;
				break;
			case PLAYER_SKILL_SPIRIT:
				spellbook.pSpiritSpellbook.bIsSpellAvailable[0] = true;
				break;
			case PLAYER_SKILL_MIND:
				spellbook.pMindSpellbook.bIsSpellAvailable[0] = true;
				break;
			case PLAYER_SKILL_BODY:
				spellbook.pBodySpellbook.bIsSpellAvailable[0] = true;
				
				if ( all_magic == true )
				{
					pActiveSkills[PLAYER_SKILL_MIND] = 1;
					pActiveSkills[PLAYER_SKILL_SPIRIT] = 1;
					spellbook.pBodySpellbook.bIsSpellAvailable[1] = true;
					spellbook.pBodySpellbook.bIsSpellAvailable[2] = true;
					spellbook.pBodySpellbook.bIsSpellAvailable[3] = true;
					spellbook.pBodySpellbook.bIsSpellAvailable[4] = true;
					spellbook.pBodySpellbook.bIsSpellAvailable[5] = true;
					spellbook.pBodySpellbook.bIsSpellAvailable[6] = true;
					spellbook.pBodySpellbook.bIsSpellAvailable[7] = true;
					spellbook.pBodySpellbook.bIsSpellAvailable[8] = true;
					spellbook.pBodySpellbook.bIsSpellAvailable[9] = true;
					spellbook.pBodySpellbook.bIsSpellAvailable[10] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[0] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[1] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[2] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[3] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[4] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[5] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[6] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[7] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[8] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[9] = true;
					spellbook.pMindSpellbook.bIsSpellAvailable[10] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[0] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[1] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[2] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[3] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[4] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[5] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[6] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[7] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[8] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[9] = true;
					spellbook.pSpiritSpellbook.bIsSpellAvailable[10] = true;
				}
				break;
			case PLAYER_SKILL_LIGHT:
				spellbook.pLightSpellbook.bIsSpellAvailable[0] = true;
				break;
			case PLAYER_SKILL_DARK:
				spellbook.pDarkSpellbook.bIsSpellAvailable[0] = true;
				break;
			}
		}
		
		memset(&pEquipment, 0, sizeof(PlayerEquipment));
		pInventoryMatrix.fill(0);*/
		for (uint i = 0; i < 126; ++i)
			Players[ip].InventoryItemListReset(i);
		/*for (uint i = 0; i < 12; ++i)
			pEquippedItems[i].Reset();*/

        Players[ip].sHealth = GetMaxHealth(ip);
		Players[ip].sMana = GetMaxMana(ip);
	}

    //----- (0048E4F8) --------------------------------------------------------
    public int GetMaxHealth(int ip)
    {
      int v3; // esi@1
      int v4; // esi@1
      int v6; // esi@1

      v3 = GetParameterBonus(GetActualEndurance(ip));
      v4 = pBaseHealthPerLevelByClass[(int)Players[ip].ClassType] * (GetActualLevel(ip) + v3);
      v6 = Players[ip].FullHealthBonus
         + pBaseHealthByClass[(int)Players[ip].ClassType / 4]
         + GetSkillBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_HEALTH)
         + GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_HEALTH, false) + v4;
      return max(1, v6);
    }



    //----- (0048C90D) --------------------------------------------------------
    public int GetActualLevel(int ip)
    {
        return Players[ip].Level + Players[ip].LevelModifier +
             GetMagicalBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_LEVEL) +
             GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_LEVEL, false);
    }

    //----- (0048D6AA) --------------------------------------------------------
    /*public bool HasItemEquipped(int ip, ITEM_EQUIP_TYPE uEquipIndex)
    {
      uint i = Players[ip].Equipment.Indices[(int)uEquipIndex];
      if (i > 0){
          return !Players[ip].OwnItems[i - 1].IsBroken();
      }
      else 
        return false;
    }*/

    //----- (0049107D) --------------------------------------------------------
    public int GetBodybuilding(int ip)
    {
      int v1; // al@1

      v1 = GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BODYBUILDING);
      int multiplier = GetMultiplierForSkillLevel(ip, v1, 1, 2, 3, 5);
      return multiplier * (v1 & 0x3F);
    }

    //----- (004910A8) --------------------------------------------------------
    public int GetMeditation(int ip)
    {
      int v1; // al@1

      v1 = GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MEDITATION);
      int multiplier = GetMultiplierForSkillLevel(ip, v1, 1, 2, 3, 5);
      return multiplier * (v1 & 0x3F);
    }

    //----- (0048FC00) --------------------------------------------------------
    public int GetSkillBonus(int ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE  inSkill)    //TODO: move the individual implementations to attribute classes once possible
    {
      int armsMasterBonus;

      armsMasterBonus = 0;
      int armmaster_skill = GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ARMSMASTER);
      if ( armmaster_skill > 0 )
      {
        int multiplier = 0;
        if ( inSkill == PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MELEE_DMG_BONUS )
        {
            multiplier = GetMultiplierForSkillLevel(ip, armmaster_skill, 0, 0, 1, 2);
        }
        else if ( inSkill == PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ATTACK )
        {
            multiplier = GetMultiplierForSkillLevel(ip, armmaster_skill, 0, 1, 1, 2);
        } 
        armsMasterBonus = multiplier * (armmaster_skill & 0x3F);
      }

      switch(inSkill)
      {
      case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RANGED_DMG_BONUS:
        /*if (HasItemEquipped(ip, Party.ITEM_EQUIP_TYPE.EQUIP_BOW))
        {
            int bowSkillLevel = GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DODGE);
            int multiplier = GetMultiplierForSkillLevel(ip, bowSkillLevel, 0, 0, 0, 1);
          return multiplier * (bowSkillLevel & 0x3F);
        }*/
        return 0;
        break;
      case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_HEALTH:
        {
            int base_value = pBaseHealthPerLevelByClass[(int)Players[ip].ClassType];
          int attrib_modif = GetBodybuilding(ip);
          return base_value * attrib_modif;
        }
        break;
      case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MANA:
        {
          int base_value = pBaseManaPerLevelByClass[(int)Players[ip].ClassType];
          int attrib_modif = GetMeditation(ip);
          return base_value * attrib_modif;
        }
        break;
      case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_AC_BONUS:
        {
          /*bool wearingArmor = false;
          bool wearingLeather = false;
          uint ACSum = 0;

          for (int j = 0; j < 16; ++j) 
          {
            ItemGen* currItem = GetNthEquippedIndexItem(j);
            if (currItem != nullptr && (!currItem->IsBroken()))
            {
                PlayerStats.PLAYER_SKILL_TYPE itemSkillType = (PlayerStats.PLAYER_SKILL_TYPE)currItem->GetPlayerSkillType();
              int currArmorSkillLevel = 0;
              int multiplier = 0;
              switch (itemSkillType)
              {
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_STAFF:
                      currArmorSkillLevel = GetActualSkillLevel(ip, itemSkillType);
                      multiplier = GetMultiplierForSkillLevel(ip, currArmorSkillLevel, 0, 1, 1, 1);
                break;
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SWORD:
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SPEAR:
                currArmorSkillLevel = GetActualSkillLevel(ip, itemSkillType);
                multiplier = GetMultiplierForSkillLevel(ip, currArmorSkillLevel, 0, 0, 0, 1);
                break;
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SHIELD:
                currArmorSkillLevel = GetActualSkillLevel(ip, itemSkillType);
                wearingArmor = true;
                multiplier = GetMultiplierForSkillLevel(ip, currArmorSkillLevel, 1, 1, 2, 2);
                break;
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEATHER:
                currArmorSkillLevel = GetActualSkillLevel(ip, itemSkillType);
                wearingLeather = true;
                multiplier = GetMultiplierForSkillLevel(ip, currArmorSkillLevel, 1, 1, 2, 2);
                break;
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_CHAIN:
                currArmorSkillLevel = GetActualSkillLevel(ip, itemSkillType);
                wearingArmor = true;
                multiplier = GetMultiplierForSkillLevel(ip, currArmorSkillLevel, 1, 1, 1, 1);
                break;
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_PLATE:
                currArmorSkillLevel = GetActualSkillLevel(ip, itemSkillType);
                wearingArmor = true;
                multiplier = GetMultiplierForSkillLevel(ip, currArmorSkillLevel, 1, 1, 1, 1);
                break;
              }
              ACSum += multiplier * (currArmorSkillLevel & 0x3F);
            }
          }

          int dodgeSkillLevel = GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DODGE);
          int dodgeMastery = SkillToMastery(dodgeSkillLevel);
          int multiplier = GetMultiplierForSkillLevel(ip, dodgeSkillLevel, 1, 2, 3, 3);
          if ( !wearingArmor && (!wearingLeather || dodgeMastery == 4) )
          {
            ACSum += multiplier * (dodgeSkillLevel & 0x3F);
          }*/
            return 0;// ACSum;
        }
        break;
      case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ATTACK:
        /*if ( IsUnarmed(ip) )
        {
            int unarmedSkill = GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_UNARMED);
          if (!unarmedSkill)
          {
            return 0;
          }
          int multiplier = GetMultiplierForSkillLevel(ip, unarmedSkill, 0, 1, 2, 2);
          return armsMasterBonus + multiplier * (unarmedSkill & 0x3F);
        }
        for (int i = 0; i < 16; ++i)
        {
          if ( this->HasItemEquipped((ITEM_EQUIP_TYPE)i) )
          {
            ItemGen* currItem = GetNthEquippedIndexItem(i);
            if (currItem->GetItemEquipType() <= Party.ITEM_EQUIP_TYPE.EQUIP_TWO_HANDED)
            {
                PlayerStats.PLAYER_SKILL_TYPE currItemSkillType = (PlayerStats.PLAYER_SKILL_TYPE)currItem->GetPlayerSkillType();
              int currentItemSkillLevel = GetActualSkillLevel(ip, currItemSkillType);
              if (currItemSkillType == PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BLASTER)
              {
                  int multiplier = GetMultiplierForSkillLevel(ip, currentItemSkillLevel, 1, 2, 3, 5);
                return multiplier * (currentItemSkillLevel & 0x3F);
              }
              else if (currItemSkillType == PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_STAFF && GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_UNARMED) > 0)
              {
                  int unarmedSkillLevel = GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_UNARMED);
                  int multiplier = GetMultiplierForSkillLevel(ip, currentItemSkillLevel, 1, 1, 2, 2);
                return multiplier * (unarmedSkillLevel & 0x3F) + armsMasterBonus + (currentItemSkillLevel & 0x3F);
              }
              else
              {
                return armsMasterBonus + (currentItemSkillLevel & 0x3F);
              }
            }
          }
        }*/
        return 0;
        break;

      case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RANGED_ATTACK:
        /*for (int i = 0; i < 16; i++)
        {
          if ( this->HasItemEquipped((ITEM_EQUIP_TYPE)i) )
          {
            ItemGen* currItemPtr = GetNthEquippedIndexItem(i);
            if (currItemPtr->GetItemEquipType() == Party.ITEM_EQUIP_TYPE.EQUIP_TWO_HANDED || currItemPtr->GetItemEquipType() == Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED)
            {
                PlayerStats.PLAYER_SKILL_TYPE currentItemSkillType = (PlayerStats.PLAYER_SKILL_TYPE)GetNthEquippedIndexItem(i)->GetPlayerSkillType();
              int currentItemSkillLevel = GetActualSkillLevel(ip, currentItemSkillType);
              if (currentItemSkillType == PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BOW)
              {
                  int multiplier = GetMultiplierForSkillLevel(ip, currentItemSkillLevel, 1, 1, 1, 1);
                return multiplier * (currentItemSkillLevel & 0x3F);
              }
              else if (currentItemSkillType == PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BLASTER)
              {
                  int multiplier = GetMultiplierForSkillLevel(ip, currentItemSkillLevel, 1, 2, 3, 5);
                return multiplier * (currentItemSkillLevel & 0x3F);
              }
            }
          }
        }*/
        return 0;
        break;

      case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MELEE_DMG_BONUS:
        /*if ( this->IsUnarmed() )
        {
            int unarmedSkillLevel = this->GetActualSkillLevel(PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_UNARMED);
          if ( !unarmedSkillLevel )
          {
            return 0;
          }
          int multiplier = GetMultiplierForSkillLevel(ip, unarmedSkillLevel, 0, 1, 2, 2);
          return multiplier * (unarmedSkillLevel & 0x3F);
        }
        for (int i = 0; i < 16; i++)
        {
          if ( this->HasItemEquipped((ITEM_EQUIP_TYPE)i) )
          {
            ItemGen* currItemPtr = GetNthEquippedIndexItem(i);
            if (currItemPtr->GetItemEquipType() == Party.ITEM_EQUIP_TYPE.EQUIP_TWO_HANDED || currItemPtr->GetItemEquipType() == Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED)
            {
                PlayerStats.PLAYER_SKILL_TYPE currItemSkillType = (PlayerStats.PLAYER_SKILL_TYPE)currItemPtr->GetPlayerSkillType();
              int currItemSkillLevel = GetActualSkillLevel(ip, currItemSkillType);
              int baseSkillBonus;
              int multiplier;
              switch (currItemSkillType)
              {
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_STAFF:
                if ( SkillToMastery(currItemSkillLevel) >= 4 && GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_UNARMED) > 0)
                {
                    int unarmedSkillLevel = GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_UNARMED);
                    int multiplier = GetMultiplierForSkillLevel(ip, unarmedSkillLevel, 0, 1, 2, 2);
                  return multiplier * (unarmedSkillLevel & 0x3F);
                }
                else
                {
                  return armsMasterBonus;
                }
                break;

                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DAGGER:
                multiplier = GetMultiplierForSkillLevel(ip, currItemSkillLevel, 0, 0, 0, 1);
                baseSkillBonus = multiplier * (currItemSkillLevel & 0x3F);
                return armsMasterBonus + baseSkillBonus;
                break;
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SWORD:
                multiplier = GetMultiplierForSkillLevel(ip, currItemSkillLevel, 0, 0, 0, 0);
                baseSkillBonus = multiplier * (currItemSkillLevel & 0x3F);
                return armsMasterBonus + baseSkillBonus;
                break;
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MACE:
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SPEAR:
                multiplier = GetMultiplierForSkillLevel(ip, currItemSkillLevel, 0, 1, 1, 1);
                baseSkillBonus = multiplier * (currItemSkillLevel & 0x3F);
                return armsMasterBonus + baseSkillBonus;
                break;
                  case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_AXE:
                multiplier = GetMultiplierForSkillLevel(ip, currItemSkillLevel, 0, 0, 1, 1);
                baseSkillBonus = multiplier * (currItemSkillLevel & 0x3F);
                return armsMasterBonus + baseSkillBonus;
                break;
              }
            }
          }
        }*/
        return 0;
        break;
      default:
        return 0;
      }
    }

    //----- (0048E7D0) --------------------------------------------------------
    public int GetActualResistance(int ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE a2)
    {
      int v10 = 0; // [sp+14h] [bp-4h]@1
      int resStat = 0;
      int result;
      int baseRes;

      int leatherArmorSkillLevel = GetActualSkillLevel(ip, PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEATHER);
      //if ( CheckHiredNPCSpeciality(Enchanter) )
        //v10 = 20;
      if ((a2 == PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE
         || a2 == PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR
         || a2 == PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER
         || a2 == PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH)
        && SkillToMastery(leatherArmorSkillLevel) == 4/*
        && HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_ARMOUR)
        && GetEquippedItemSkillType(Party.ITEM_EQUIP_TYPE.EQUIP_ARMOUR) == PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEATHER*/)
        v10 += leatherArmorSkillLevel & 0x3F;
      switch (a2)
      {
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE:
              resStat = Players[ip].ResFireBonus;
          break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR:
          resStat = Players[ip].ResAirBonus;
          break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER:
          resStat = Players[ip].ResWaterBonus;
          break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH:
          resStat = Players[ip].ResEarthBonus;
          break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND:
          resStat = Players[ip].ResMindBonus;
          break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY:
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_SPIRIT:
          resStat = Players[ip].ResBodyBonus;
          break;
        default:
            Debug.Log("Unexpected attribute");
            break;
      }
      baseRes = GetBaseResistance(ip, a2);
      result = v10 + GetMagicalBonus(ip, a2) + baseRes + resStat;
      if ((PlayerStats.PLAYER_CLASS_TYPE)Players[ip].ClassType == PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_LICH)
      {
        if ( result > 200 )
          result = 200;
      }
      return result;
    }

    //----- (0048E73F) --------------------------------------------------------
    public int GetBaseResistance(int ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE a2)
    {
      int v7; // esi@20
      int racialBonus = 0;
      int resStat = 0;
      int result;

      switch (a2)
      {
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE:
              resStat = Players[ip].ResFireBase;
              if (IsRaceGoblin(ip))
            racialBonus = 5;
          break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR:
          resStat = Players[ip].ResAirBase;
          if (IsRaceGoblin(ip))
            racialBonus = 5;
          break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER:
          resStat = Players[ip].ResWaterBase;
          if (IsRaceDwarf(ip))
            racialBonus = 5;
          break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH:
          resStat = Players[ip].ResEarthBase;
          if (IsRaceDwarf(ip))
            racialBonus = 5;
        break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND:
        resStat = Players[ip].ResMindBase;
        if (IsRaceElf(ip))
            racialBonus = 10;
          break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY:
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_SPIRIT:
          resStat = Players[ip].ResBodyBase;
          if (IsRaceHuman(ip))
            racialBonus = 5;
          break;
        default:
          Debug.Log("Unknown attribute");
          break;
      }
      v7 = GetItemsBonus(ip, a2, false) + racialBonus;
      result = v7 + resStat;
      if ((PlayerStats.PLAYER_CLASS_TYPE)Players[ip].ClassType == PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_LICH)
      {
        if ( result > 200 )
          result = 200;
      }
      return result;
    }

    public bool IsRaceHuman(int ip) { return GetRace(Players[ip].CurrentFace) == (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_HUMAN; }
    public bool IsRaceDwarf(int ip) { return GetRace(Players[ip].CurrentFace) == (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_DWARF; }
    public bool IsRaceElf(int ip) { return GetRace(Players[ip].CurrentFace) == (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_ELF; }
    public bool IsRaceGoblin(int ip) { return GetRace(Players[ip].CurrentFace) == (int)PlayerStats.CHARACTER_RACE.CHARACTER_RACE_GOBLIN; }

      /*public bool IsMale(int ip) { return GetSexByVoice() == SEX_MALE;}
      public bool IsFemale(int ip) { return !IsMale();}*/

    public int GetMultiplierForSkillLevel(int ip, int skillValue, int mult1, int mult2, int mult3, int mult4)
    {
      int masteryLvl = SkillToMastery(skillValue);
      switch (masteryLvl)
      {
        case 1: return mult1;
        case 2: return mult2;
        case 3: return mult3;
        case 4: return mult4;
      }
      Debug.Log(masteryLvl);
      return 0;
    }
    //----- (00458244) --------------------------------------------------------
    public int SkillToMastery( int skill_value )
    {
      switch (skill_value & 0x1C0)
      {
      case 0x100: return 4;     // Grandmaster
      case 0x80:  return 3;     // Master
      case 0x40:  return 2;     // Expert
      case 0x00:  return 1;     // Normal
      }
      //assert(false);
      return 0;
    }

    //----- (0048E68F) --------------------------------------------------------
    public int GetActualAC(int ip)
    {
      int v2; // eax@1
      int v3; // esi@1
      int v4; // esi@1
      int v5; // esi@1
      int v6; // esi@1

      v2 = (int)GetActualSpeed(ip);
      v3 = GetParameterBonus(ip, v2);
      v4 = GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_AC_BONUS, false) + v3;
      v5 = GetSkillBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_AC_BONUS) + v4;
      v6 = Players[ip].ACModifier + GetMagicalBonus((int)PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_AC_BONUS) + v5;
      return max(0, v6);
    }

    //----- (0048E656) --------------------------------------------------------
    public int GetBaseAC(int ip)
    {
      int v2; // eax@1
      int v3; // esi@1
      int v4; // esi@1
      int v5; // esi@1

      v2 = (int)GetActualSpeed(ip);
      v3 = GetParameterBonus(ip, v2);
      v4 = GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_AC_BONUS, false) + v3;
      v5 = GetSkillBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_AC_BONUS) + v4;
      return max(0, v5);
    }

    //----- (0048EA1B) --------------------------------------------------------
    public int GetParameterBonus( int ip, int player_parameter )
    {
      int i; // eax@1
      i = 0;
      while (Temp.param_to_bonus_table[i] > 0)
      { 
        if (player_parameter >= param_to_bonus_table[i])
          break;
        ++i;    
      }   
      return parameter_to_bonus_value[i];
    }

    //----- (0048CBB6) --------------------------------------------------------
    public uint GetActualSpeed(int ip)
    {
      return GetActualAttribute(ip, (int)PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SPEED, Players[ip].Speed, Players[ip].SpeedBonus);
    }

    //----- (0048F882) --------------------------------------------------------
    public int GetActualSkillLevel( int ip, PlayerStats.PLAYER_SKILL_TYPE uSkillType )
    {
      int bonus_value; // esi@1
      int skill_value; // ax@126
      int result; // al@127
  
      bonus_value = 0;
      switch (uSkillType)
      {
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MONSTER_ID:
        {
          if ( CheckHiredNPCSpeciality((uint)NPCProf.Hunter) )
            bonus_value = 6;
          if (CheckHiredNPCSpeciality((uint)NPCProf.Sage))
            bonus_value += 6;
          bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_MONSTER_ID, false);
        }
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ARMSMASTER:
        {
            if (CheckHiredNPCSpeciality((uint)NPCProf.Armsmaster))
              bonus_value = 2;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Weaponsmaster))
              bonus_value += 3;
            bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_ARMSMASTER, false);
        }
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_STEALING:
        {
            if (CheckHiredNPCSpeciality((uint)NPCProf.Burglar))
              bonus_value = 8;
            bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_STEALING, false);
        }
        break;


          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ALCHEMY:
        {
            if (CheckHiredNPCSpeciality((uint)NPCProf.Herbalist))
              bonus_value = 4;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Apothecary))
              bonus_value += 8;
            bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_ALCHEMY, false);
        }
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEARNING:
        {
            if (CheckHiredNPCSpeciality((uint)NPCProf.Teacher))
              bonus_value = 10;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Instructor))
              bonus_value += 15;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Scholar))
              bonus_value += 5;
            bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_LEARNING, false);
        }
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_UNARMED:
        {
            if (CheckHiredNPCSpeciality((uint)NPCProf.Monk))
            bonus_value = 2;
            bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_UNARMED, false);
        }
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DODGE:
        {
            if (CheckHiredNPCSpeciality((uint)NPCProf.Monk))
            bonus_value = 2;
            bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_DODGE, false);
        }
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BOW:
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_BOW, false);
        break;
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SHIELD:
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_SHIELD, false);
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_EARTH:
        if (CheckHiredNPCSpeciality((uint)NPCProf.Apprentice))
                bonus_value = 2;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Mystic))
                bonus_value += 3;
              if ( CheckHiredNPCSpeciality((uint)NPCProf.Spellmaster) )
                bonus_value += 4;
              if ((PlayerStats.PLAYER_CLASS_TYPE)Players[ip].ClassType == PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_WARLOCK/* && PartyHasDragon()*/)
                bonus_value += 3;
              bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_EARTH, false);
        break;
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_FIRE:
        if (CheckHiredNPCSpeciality((uint)NPCProf.Apprentice))
                bonus_value = 2;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Mystic))
                bonus_value += 3;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Spellmaster))
                bonus_value += 4;
        if ((PlayerStats.PLAYER_CLASS_TYPE)Players[ip].ClassType == PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_WARLOCK/* && PartyHasDragon()*/)
                bonus_value += 3;
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_FIRE, false);
        break;
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_AIR:
        if (CheckHiredNPCSpeciality((uint)NPCProf.Apprentice))
                bonus_value = 2;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Mystic))
                bonus_value += 3;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Spellmaster))
                bonus_value += 4;
        if ((PlayerStats.PLAYER_CLASS_TYPE)Players[ip].ClassType == PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_WARLOCK/* && PartyHasDragon()*/)
                bonus_value += 3;
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_AIR, false);
        break;
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_WATER:
        if (CheckHiredNPCSpeciality((uint)NPCProf.Apprentice))
                bonus_value = 2;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Mystic))
                bonus_value += 3;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Spellmaster))
                bonus_value += 4;
        if ((PlayerStats.PLAYER_CLASS_TYPE)Players[ip].ClassType == PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_WARLOCK /*&& PartyHasDragon()*/)
                bonus_value += 3;
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_WATER, false);
        break;
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SPIRIT:
        if (CheckHiredNPCSpeciality((uint)NPCProf.Acolyte2))
                bonus_value = 2;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Initiate))
                bonus_value += 3;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Prelate))
                bonus_value += 4;
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_SPIRIT, false);
        break;
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MIND:
        if (CheckHiredNPCSpeciality((uint)NPCProf.Acolyte2))
                bonus_value = 2;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Initiate))
                bonus_value += 3;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Prelate))
                bonus_value += 4;
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_MIND, false);
        break;
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BODY:
        if (CheckHiredNPCSpeciality((uint)NPCProf.Acolyte2))
                bonus_value = 2;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Initiate))
                bonus_value += 3;
        if (CheckHiredNPCSpeciality((uint)NPCProf.Prelate))
                bonus_value += 4;
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_BODY, false);
        break;
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LIGHT:
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_LIGHT, false);
        break;
          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DARK:
        {
            bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_DARK, false);
        }
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MERCHANT:
        {
            if (CheckHiredNPCSpeciality((uint)NPCProf.Trader))
              bonus_value = 4;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Merchant))
              bonus_value += 6;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Gypsy))
              bonus_value += 3;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Duper))
              bonus_value += 8;
        }
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_PERCEPTION:
        {
            if (CheckHiredNPCSpeciality((uint)NPCProf.Scout))
            bonus_value = 6;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Psychic))
            bonus_value += 5;
        }
        break;

          case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ITEM_ID:
        bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_ITEM_ID, false);
          break;
        case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MEDITATION:
          bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_MEDITATION, false);
        break;
        case PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_TRAP_DISARM:
        {
            if (CheckHiredNPCSpeciality((uint)NPCProf.Tinker))
            bonus_value = 4;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Locksmith))
            bonus_value += 6;
            if (CheckHiredNPCSpeciality((uint)NPCProf.Burglar))
            bonus_value += 8;
          bonus_value += GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_TRAP_DISARM, false);
        }
        break;
      }

      skill_value = Players[ip].ActiveSkills[(int)uSkillType];
      if ( bonus_value + (skill_value & 0x3F) < 60 )
        result = bonus_value + skill_value;
      else
        result = skill_value & 0xFFFC | 0x3C; //al
      return result;
    }

    //----- (0048EAAE) --------------------------------------------------------
    public int GetItemsBonus( int ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE attr, bool getOnlyMainHandDmg /*= false*/ )
    {
        return 0;
      /*int v5; // edi@1
      int v9; // eax@49
      int v14; // ecx@58
      int v15; // eax@58
      int v17; // eax@62
      int v22; // eax@76
      int v25; // ecx@80
      int v26; // edi@80
      int v32; // eax@98
      int v56; // eax@365
      int v58; // [sp-4h] [bp-20h]@10
      int v61; // [sp+10h] [bp-Ch]@1
      int v62; // [sp+14h] [bp-8h]@1
      ItemGen *currEquippedItem; // [sp+20h] [bp+4h]@101
      bool no_skills;

      v5 = 0;
      v62 = 0;
      v61 = 0;
  
      no_skills=false;
      switch (attr)
      {
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_ALCHEMY:      v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ALCHEMY;      break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_STEALING:     v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_STEALING;     break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_TRAP_DISARM:  v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_TRAP_DISARM;  break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_ITEM_ID:      v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ITEM_ID;      break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_MONSTER_ID:   v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MONSTER_ID;   break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_ARMSMASTER:   v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_ARMSMASTER;   break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_DODGE:        v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DODGE;        break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_UNARMED:      v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_UNARMED;      break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_FIRE:         v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_FIRE;         break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_AIR:          v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_AIR;          break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_WATER:        v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_WATER;        break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_EARTH:        v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_EARTH;        break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_SPIRIT:       v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SPIRIT;       break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_MIND:         v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MIND;         break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_BODY:         v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BODY;         break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_LIGHT:        v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LIGHT;        break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_DARK:         v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_DARK;         break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_MEDITATION:   v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_MEDITATION;   break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_BOW:          v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BOW;          break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_SHIELD:       v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SHIELD;       break;
        case  PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_LEARNING:     v58 = (int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_LEARNING;     break;
        default:
          no_skills=true;
      }
      if (!no_skills)
      {
        if ( Players[ip].ActiveSkills[v58] == 0 )
          return 0;
      }

      switch(attr)      //TODO would be nice to move these into separate functions
      {
        case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RANGED_DMG_BONUS:
        case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RANGED_ATTACK:
          if ( HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_BOW) )
            v5 = GetBowItem()->GetDamageMod();
          return v5;
          break;

        case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RANGED_DMG_MIN:
          if ( !HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_BOW) )
            return 0;
          v5 = GetBowItem()->GetDamageMod();
          v56 = GetBowItem()->GetDamageDice();
          return v5 + v56;
          break;

        case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RANGED_DMG_MAX:
          if ( !HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_BOW) )
            return 0;
          v5 = GetBowItem()->GetDamageDice() * GetBowItem()->GetDamageRoll();
          v56 = GetBowItem()->GetDamageMod();
          return v5 + v56;

        case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_LEVEL: 
          if ( !Player::HasEnchantedItemEquipped(25) )
            return 0;
          return 5;
          break;

        case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MELEE_DMG_MAX:
          if ( IsUnarmed() )
          {
            return 3;
          }
          else
          {
            if ( this->HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_TWO_HANDED) )
            {
              v22 = this->GetEquippedItemEquipType(Party.ITEM_EQUIP_TYPE.EQUIP_TWO_HANDED);
              if ( v22 >= 0 && v22 <= 2)
              {
                ItemGen* mainHandItem = GetMainHandItem();
                v26 = mainHandItem->GetDamageRoll();
                if ( GetOffHandItem() != nullptr || mainHandItem->GetPlayerSkillType() != 4 )
                {
                  v25 = mainHandItem->GetDamageDice();
                }
                else
                {
                  v25 = mainHandItem->GetDamageDice() + 1;
                }
                v5 = mainHandItem->GetDamageMod() + v25 * v26;
              }
            }
            if ( getOnlyMainHandDmg || !this->HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED) ||  (GetEquippedItemEquipType(Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED) < 0 || GetEquippedItemEquipType(Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED) > 2))
            {
                return v5;
            }
            else
            {
              ItemGen* offHandItem = GetOffHandItem();
              v15 = offHandItem->GetDamageMod();
              v14 = offHandItem->GetDamageDice() * offHandItem->GetDamageRoll();
              return v5 + v15 + v14;
            }
          }
        break;

        case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MELEE_DMG_BONUS:
        case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ATTACK:
          if ( IsUnarmed() )
          {
            return 0;
          }
          if ( this->HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_TWO_HANDED) )
          {
            v17 = this->GetEquippedItemEquipType(Party.ITEM_EQUIP_TYPE.EQUIP_TWO_HANDED);
            if ( v17 >= 0 && v17 <= 2)
            {
              v5 = GetMainHandItem()->GetDamageMod();
            }
          }
          if ( getOnlyMainHandDmg || !this->HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED) || (this->GetEquippedItemEquipType(Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED) < 0) || this->GetEquippedItemEquipType(Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED) > 2 )
            return v5;
          else
          {
            v56 = GetOffHandItem()->GetDamageMod();
            return v5 + v56;
          }
          break;

        case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MELEE_DMG_MIN:
          if ( IsUnarmed() )
          {
            return 1;
          }
          if ( this->HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_TWO_HANDED) )
          {
            v9 = this->GetEquippedItemEquipType(Party.ITEM_EQUIP_TYPE.EQUIP_TWO_HANDED);
            if ( v9 >= 0 && v9 <= 2)
            {
              ItemGen* mainHandItem = GetMainHandItem();
              v5 = mainHandItem->GetDamageDice() +
                mainHandItem->GetDamageMod();
              if ( GetOffHandItem() == nullptr && mainHandItem->GetPlayerSkillType() == 4)
              {
                ++v5;
              }
            }
          }

          if ( getOnlyMainHandDmg || !this->HasItemEquipped(Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED) || (this->GetEquippedItemEquipType(Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED) < 0) || this->GetEquippedItemEquipType(Party.ITEM_EQUIP_TYPE.EQUIP_SINGLE_HANDED) > 2 )
          {
            return v5;
          }
          else
          {
            ItemGen* offHandItem = GetOffHandItem();
            v14 = offHandItem->GetDamageMod();
            v15 = offHandItem->GetDamageDice();
            return v5 + v15 + v14;
          }
          break;

        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_STRENGTH:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_INTELLIGENCE:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_WILLPOWER:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ENDURANCE:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ACCURACY:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SPEED:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_LUCK:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_HEALTH:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MANA:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_AC_BONUS:

        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY:        
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_SPIRIT:

        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_ALCHEMY:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_STEALING:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_TRAP_DISARM:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_ITEM_ID:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_MONSTER_ID:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_ARMSMASTER:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_DODGE:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_UNARMED:

        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_FIRE:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_AIR:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_WATER:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_EARTH:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_SPIRIT:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_MIND:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_BODY:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_LIGHT:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_DARK:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_MEDITATION:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_BOW:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_SHIELD:
        case   PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SKILL_LEARNING:
          for (int i = 0; i < 16; i++)
          {
            if ( HasItemEquipped((ITEM_EQUIP_TYPE)i) )
            {
              currEquippedItem = GetNthEquippedIndexItem(i);
              if ( attr == PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_AC_BONUS )
              {
                v32 = currEquippedItem->GetItemEquipType();
                if ( v32 >= 3 && v32 <= 11 )
                {
                  v5 += currEquippedItem->GetDamageDice() + currEquippedItem->GetDamageMod();
                }
              }
              if ( pItemsTable->IsMaterialNonCommon(currEquippedItem)
                && !pItemsTable->IsMaterialSpecial(currEquippedItem) )
              {
                currEquippedItem->GetItemBonusArtifact(this, attr, &v62);
              }
              else if ( currEquippedItem->uEnchantmentType != 0 )
              {
                if (this->pInventoryItemList[this->pEquipment.pIndices[i] - 1].uEnchantmentType - 1 == attr)//if (currEquippedItem->IsRegularEnchanmentForAttribute(attr))
                {
                  if ( attr > PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY && v5 < currEquippedItem->m_enchantmentStrength )//for skills bonuses
                    v5 = currEquippedItem->m_enchantmentStrength;
                  else // for resists and attributes bonuses
                    v5 += currEquippedItem->m_enchantmentStrength;
                }
              }
              else
              {
                currEquippedItem->GetItemBonusSpecialEnchantment(this, attr, &v5, &v61);
              }
            }
          }
          return v5 + v62 + v61;
          break;
        default:
          return 0;
        }*/
    }

    //----- (0048F73C) --------------------------------------------------------
    public int GetMagicalBonus(int ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE a2)
    {
      int v3 = 0; // eax@4
      int v4 = 0; // ecx@5

      /*switch ( a2 )
      {
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_FIRE:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_RESIST_FIRE].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_RESIST_FIRE].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_AIR:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_RESIST_AIR].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_RESIST_AIR].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_BODY:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_RESIST_BODY].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_RESIST_BODY].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_WATER:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_RESIST_WATER].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_RESIST_WATER].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_EARTH:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_RESIST_EARTH].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_RESIST_EARTH].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RESIST_MIND:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_RESIST_MIND].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_RESIST_MIND].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ATTACK:
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_RANGED_ATTACK:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_BLESS].Power;  //only player effect spell in both VI and VII
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MELEE_DMG_BONUS:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_HEROISM].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_HEROISM].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_STRENGTH:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_STRENGTH].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_DAY_OF_GODS].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_INTELLIGENCE:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_INTELLIGENCE].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_DAY_OF_GODS].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_WILLPOWER:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_WILLPOWER].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_DAY_OF_GODS].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ENDURANCE:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_ENDURANCE].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_DAY_OF_GODS].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ACCURACY:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_ACCURACY].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_DAY_OF_GODS].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_SPEED:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_SPEED].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_DAY_OF_GODS].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_LUCK:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_LUCK].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_DAY_OF_GODS].Power;
              break;
          case PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_AC_BONUS:
              v3 = Players[ip].PlayerBuffs[(int)PlayerStats.PLAYER_BUFFS.PLAYER_BUFF_STONESKIN].Power;
              v4 = Temp.PartyBuffs[(int)Party.PARTY_BUFF_INDEX.PARTY_BUFF_STONE_SKIN].Power;
              break;
      }*/
      return v3 + v4;
    }

    public int max(int a, int b)
    {
        if (a > b)
            return a;
        else
            return b;
    }
    //----- (0048EA1B) --------------------------------------------------------
    public int GetParameterBonus( uint player_parameter )
    {
      int i; // eax@1
      i = 0;
      while (param_to_bonus_table[i]>0)
      { 
        if ((int)player_parameter >= param_to_bonus_table[i])
          break;
        ++i;    
      }   
      return parameter_to_bonus_value[i];
    }
    int[] param_to_bonus_table = new int[29]{500, 400, 350, 300, 275, 250, 225, 200, 175, 150, 125, 100,  75,  50,  40,  35,  30,  25,  21,  19,   17,  15,  13,  11,   9,   7,   5,   3,   0};

    int[] parameter_to_bonus_value = new int[29]{30, 25, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6};

    int[] pBaseHealthByClass = new int[12]{40, 35, 35, 30, 30, 30, 25, 20, 20, 0, 0, 0};
    int[] pBaseManaByClass = new int[12]{ 0,  0,  0,  5,  5,  0, 10, 10, 15, 0, 0, 0};

    int[] pBaseHealthPerLevelByClass = new int[36]{5, 7, 9, 9, 4, 6, 8, 8, 5, 6, 8, 8, 4, 5, 6, 6, 3, 4, 6, 6, 4, 5, 6, 6, 2, 3, 4, 4, 2, 3, 4, 4, 2, 3, 3, 3};
    int[] pBaseManaPerLevelByClass = new int[36]{0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 2, 3, 3, 1, 2, 3, 3, 0, 2, 3, 3, 3, 4, 5, 5, 3, 4, 5, 5, 3, 4, 6, 6};



	
    //----- (0048CABC) --------------------------------------------------------
    public uint GetActualEndurance(int ip)
    {
      return GetActualAttribute( ip, 3, Players[ip].Endurance, Players[ip].EnduranceBonus);
    }


    public void PlayerCreationUI_Draw()
	{

		string inpString = "";
		int uClassType;
		Event e = Event.current;
		int HintNum = 0;


		//Подложка
		GUI.DrawTexture (new Rect ((Screen.width / 2) - 320, (Screen.height / 2) - 240, 640, 480), NewGame_tex);

			//движение облаков
			/*uPlayerCreationUI_SkySliderPos = (GetTickCount() % 12800) / 20;
		pRenderer->DrawTextureIndexed(uPlayerCreationUI_SkySliderPos, 2, pTexture_MAKESKY);
		pRenderer->DrawTextureIndexed(uPlayerCreationUI_SkySliderPos - window->GetWidth(), 2, pTexture_MAKESKY);
		pRenderer->DrawTextureIndexedAlpha(0, 0, pTexture_MAKETOP);*/

		//arrows
		arrow_timer += Time.deltaTime*16.0f;
		if (arrow_timer > 19.0f)
			arrow_timer = 0.0f;
		uPlayerCreationUI_ArrowAnim = (int)arrow_timer;
		if (!PosActiveItem_flag) {
			PosActiveItemX = ((Screen.width / 2) - 302) - 9;
			PosActiveItemY = (Screen.height / 2) - 65;
			PosActiveItem_flag = true;
			eAttribute=0;
		}
		GUI.DrawTexture (new Rect (PosActiveItemX, PosActiveItemY, 16, 16), pTextures_arrowr[uPlayerCreationUI_ArrowAnim]);
		GUI.DrawTexture (new Rect (PosActiveItemX+130, PosActiveItemY, 16, 16), pTextures_arrowl[uPlayerCreationUI_ArrowAnim]);

		//СТАТЫ
		int pIntervalX = (Screen.width / 2) - 302;//
		int pIntervalY = 17;

		GUI.skin = skin;
		GUI.Box (new Rect ((Screen.width / 2) - 120, (Screen.height / 2) - 237, 250, 28), Temp.GlobalText [51]);
		GUI.skin = skin2;
		for (int i = 0; i < players_Count; ++i) {
			GUI.color = Color.white;

			//выбор партретов
			if (GUI.Button (new Rect (pIntervalX - 15, (Screen.height / 2) - 215, 20, 20), "")) {	
				if (e.button == 0 && e.isMouse)
					Debug.Log ("Left Click");
				else {
					Players [i].CurrentFace -= 1;
					if (Players [i].CurrentFace == -1)           
						Players [i].CurrentFace = 19;
					Players [i].VoiceID = Players [i].CurrentFace;
					SetInitialStats (i);
					Players [i].Sex = (PlayerStats.PlayerSex)GetSexByVoice (Players [i].VoiceID);
					Players [i].Name = RandomizeName (Players [i].Sex);
					GetComponent<AudioSource> ().clip = VoiceList [Players [i].VoiceID];
					GetComponent<AudioSource> ().Play ();
					GetComponent<AudioSource> ().loop = false;
					GetComponent<AudioSource> ().volume = 0.8f;
					ActiveCharacter = i;
					HintWindow=false;
					PosActiveItemX = pIntervalX-9;
					PosActiveItemY = (Screen.height / 2) - 65;
				}
			}
			if (GUI.Button (new Rect (pIntervalX + 45, (Screen.height / 2) - 215, 20, 20), "")) {
				if (e.button == 0 && e.isMouse)
					Debug.Log ("Left Click");
				else {
					Players [i].CurrentFace += 1;
					if (Players [i].CurrentFace == 20)       //if number of person > max - return to the first person
						Players [i].CurrentFace = 0;
					Players [i].VoiceID = Players [i].CurrentFace;
					SetInitialStats (i);
					Players [i].Sex = (PlayerStats.PlayerSex)GetSexByVoice (Players [i].VoiceID);
					Players [i].Name = RandomizeName (Players [i].Sex);
					GetComponent<AudioSource> ().clip = VoiceList [Players [i].VoiceID];
					GetComponent<AudioSource> ().Play ();
					GetComponent<AudioSource> ().loop = false;
					GetComponent<AudioSource> ().volume = 0.8f;
					ActiveCharacter = i;
					HintWindow=false;
					PosActiveItemX = pIntervalX-9;
					PosActiveItemY = (Screen.height / 2) - 65;
				}
			}

			//выбор голоса
			if (GUI.Button (new Rect (pIntervalX - 15, (Screen.height / 2) - 140, 20, 20), "")) {	
				int pSex = GetSexByVoice (Players [i].VoiceID);
				do {
					Players [i].VoiceID -= 1;
					if (Players [i].VoiceID == -1)           
						Players [i].VoiceID = 19;
				} while(GetSexByVoice(Players[i].VoiceID) != pSex);
				GetComponent<AudioSource> ().clip = VoiceList [Players [i].VoiceID];
				GetComponent<AudioSource> ().Play ();
				GetComponent<AudioSource> ().loop = false;
				GetComponent<AudioSource> ().volume = 0.8f;
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = (Screen.height / 2) - 65;
			}
			if (GUI.Button (new Rect (pIntervalX + 45, (Screen.height / 2) - 140, 20, 20), "")) {
				int pSex = GetSexByVoice (Players [i].VoiceID);
				do {
					Players [i].VoiceID += 1;
					if (Players [i].VoiceID == 20)       //if number of person > max - return to the first person
						Players [i].VoiceID = 0;
				} while(GetSexByVoice(Players[i].VoiceID) != pSex);
				GetComponent<AudioSource> ().clip = VoiceList [Players [i].VoiceID];
				GetComponent<AudioSource> ().Play ();
				GetComponent<AudioSource> ().loop = false;
				GetComponent<AudioSource> ().volume = 0.8f;
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = (Screen.height / 2) - 65;
			}
			GUI.DrawTexture (new Rect (pIntervalX - 1, (Screen.height / 2) - 205, 59, 79), aTexture_Face [Players [i].CurrentFace]);
			if (GUI.Button (new Rect (pIntervalX - 4, (Screen.height / 2) - 210, 65, 85), "")) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = (Screen.height / 2) - 65;
			}
			if (ActiveCharacter == i) {
				int pXcoord = 0;
				switch (ActiveCharacter) {
				case 0: 
					pXcoord = 12;
					break;
				case 1: 
					pXcoord = 171;
					break;
				case 2:
					pXcoord = 329;
					break;
				case 3:
					pXcoord = 488; 
					break;
				default:
					Debug.Log ("Invalid selected character");
					break;
				}
				GUI.DrawTexture (new Rect (((Screen.width / 2) - 320) + pXcoord, (Screen.height / 2) - 212, 69, 91), Aframe_tex);
			}

			//Класс
			GUI.Box (new Rect (pIntervalX + 73, (Screen.height / 2) - 145, 70, 26), Temp.pClassNames [(int)Players [i].ClassType]);

			//картинка класса
			GUI.DrawTexture (new Rect (pIntervalX + 77, (Screen.height / 2) - 190, 48, 52), Texture_Logo [((int)Players [i].ClassType) / 4]);

			Players [i].Name = GUI.TextField (new Rect (pIntervalX, (Screen.height / 2) - 118, 135, 26), Players [i].Name, 25);
/*
			if ( pGUIWindow_CurrentMenu->receives_keyboard_input_2 != WINDOW_INPUT_NONE && pGUIWindow_CurrentMenu->ptr_1C == (void *)i )
			{
				switch ( pGUIWindow_CurrentMenu->receives_keyboard_input_2 )
				{
				case WINDOW_INPUT_IN_PROGRESS://press name panel
					v17 = pGUIWindow_CurrentMenu->DrawTextInRect(pFontCreate, 159 * (int)pGUIWindow_CurrentMenu->ptr_1C + 18, 124, 0, pKeyActionMap->pPressedKeysBuffer, 120, 1);
					pGUIWindow_CurrentMenu->DrawFlashingInputCursor(159 * (unsigned int)pGUIWindow_CurrentMenu->ptr_1C + v17 + 20, 124, pFontCreate);
					break;
				case WINDOW_INPUT_CONFIRMED: // press enter
					pGUIWindow_CurrentMenu->receives_keyboard_input_2 = WINDOW_INPUT_NONE;
					v126 = 0;
					for ( int i = 0; i < strlen(pKeyActionMap->pPressedKeysBuffer); ++i )//edit name
					{
						if ( pKeyActionMap->pPressedKeysBuffer[i] == ' ' )
							++v126;
					}
					if ( strlen(pKeyActionMap->pPressedKeysBuffer) && v126 != strlen(pKeyActionMap->pPressedKeysBuffer) )
						strcpy(pParty->pPlayers[i].pName, pKeyActionMap->pPressedKeysBuffer);
					pGUIWindow_CurrentMenu->DrawTextInRect(pFontCreate, pIntervalX, 124, 0, pParty->pPlayers[i].pName, 130, 0);
					pParty->pPlayers[i].field_1988[27] = 1;
					break;
				case WINDOW_INPUT_CANCELLED: // press escape
					pGUIWindow_CurrentMenu->receives_keyboard_input_2 = WINDOW_INPUT_NONE;
					pGUIWindow_CurrentMenu->DrawTextInRect(pFontCreate, pIntervalX, 124, 0, pParty->pPlayers[i].pName, 130, 0);
					SetCurrentMenuID(MENU_NAMEPANELESC);
					break;
				}
			}
			else
			{
				pGUIWindow_CurrentMenu->DrawTextInRect(pFontCreate, pIntervalX, 124, 0, pParty->pPlayers[i].pName, 130, 0);
			}*/

				switch (GetRace (Players [i].CurrentFace)) {
				case 0:
					uRaceName = Temp.GlobalText [99];
					break; // "Human"
				case 1:
					uRaceName = Temp.GlobalText [103];
					break; // "Dwarf"
				case 2:
					uRaceName = Temp.GlobalText [106];
					break; // "Goblin"
				case 3:
					uRaceName = Temp.GlobalText [101];
					break; // "Elf"
				}
			GUI.Box (new Rect (pIntervalX + 73, (Screen.height / 2) - 215, 70, 26), uRaceName);

			GUI.color = new Color (209, 187, 0/*97*/, 1);
			GUI.Box (new Rect (pIntervalX + 30, (Screen.height / 2) + 48, 70, 26), Temp.GlobalText [205]);

			//Сила
			uint uStatLevel = GetActualAttribute (i, 0, Players [i].Might, Players [i].MightBonus);
			GetStatColor (i, 0);
			if (e.button == 1 && e.isMouse){
				if(e.mousePosition.x>((Screen.width/2)-320)&&e.mousePosition.x<((Screen.width/2)+320)){
					if(e.mousePosition.x>((Screen.width/2)-320)&&e.mousePosition.x<((Screen.width/2)+320)){
						HintWindow=true;
						HintNum = 1;
					}
				}
			}
			else {
				if (GUI.Button (new Rect (pIntervalX + 7, (Screen.height / 2) - 71, 87, 26), "Сила")) {
					HintWindow=false;
					ActiveCharacter = i;
					PosActiveItemX = pIntervalX-9;
					PosActiveItemY = (Screen.height / 2) - 65;
					eAttribute=0;
					//sound
				}
			}
			GUI.skin = skinRight;
			if (GUI.Button (new Rect (pIntervalX + 97, (Screen.height / 2) - 71, 35, 26), "" + uStatLevel)) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = (Screen.height / 2) - 65;
				eAttribute=0;
				//sound
			}

			//Интеллект
			GUI.skin = skin2;
			uStatLevel = GetActualAttribute (i, 1, Players [i].Intelligence, Players [i].IntelligenceBonus); 
			GetStatColor (i, 1);
			if (GUI.Button (new Rect (pIntervalX + 7, ((Screen.height / 2) - 240) + pIntervalY + 169, 87, 26), "Интеллект")) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + pIntervalY + 169;
				eAttribute=1;
				//sound
			}
			GUI.skin = skinRight;
			if (GUI.Button (new Rect (pIntervalX + 97, ((Screen.height / 2) - 240) + pIntervalY + 169, 35, 26), "" + uStatLevel)) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + pIntervalY + 169;
				eAttribute=1;
				//sound
			}

			//Сила духа
			GUI.skin = skin2;
			uStatLevel = GetActualAttribute (i, 2, Players [i].Willpower, Players [i].WillpowerBonus); 
			GetStatColor (i, 2);
			if (GUI.Button (new Rect (pIntervalX + 7, ((Screen.height / 2) - 240) + 2 * pIntervalY + 169, 87, 26), "Сила духа")) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 2*pIntervalY + 169;
				eAttribute=2;
				//sound
			}
			GUI.skin = skinRight;
			if (GUI.Button (new Rect (pIntervalX + 97, ((Screen.height / 2) - 240) + (2 * pIntervalY) + 169, 35, 26), "" + uStatLevel)) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 2*pIntervalY + 169;
				eAttribute=2;
				//sound
			}

			GUI.skin = skin2;
			uStatLevel = GetActualAttribute (i, 3, Players [i].Endurance, Players [i].AccuracyBonus); 
			GetStatColor (i, 3);
			if (GUI.Button (new Rect (pIntervalX + 7, ((Screen.height / 2) - 240) + 3 * pIntervalY + 169, 99, 26), "Выносливость")) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 3*pIntervalY + 169;
				eAttribute=3;
				//sound
			}
			GUI.skin = skinRight;
			if (GUI.Button (new Rect (pIntervalX + 97, ((Screen.height / 2) - 240) + 3 * pIntervalY + 169, 35, 26), "" + uStatLevel)) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 3*pIntervalY + 169;
				eAttribute=3;
				//sound
			}

			GUI.skin = skin2;
			uStatLevel = GetActualAttribute (i, 4, Players [i].Accuracy, Players [i].AccuracyBonus); 
			GetStatColor (i, 4);
			if (GUI.Button (new Rect (pIntervalX + 7, ((Screen.height / 2) - 240) + 4 * pIntervalY + 169, 87, 26), "Меткость")) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 4*pIntervalY + 169;
				eAttribute=4;
				//sound
			}
			GUI.skin = skinRight;
			if (GUI.Button (new Rect (pIntervalX + 97, ((Screen.height / 2) - 240) + 4 * pIntervalY + 169, 35, 26), "" + uStatLevel)) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 4*pIntervalY + 169;
				eAttribute=4;
				//sound
			}

			GUI.skin = skin2;
			uStatLevel = GetActualAttribute (i, 5, Players [i].Speed, Players [i].SpeedBonus); 
			GetStatColor (i, 5);
			if (GUI.Button (new Rect (pIntervalX + 7, ((Screen.height / 2) - 240) + 5 * pIntervalY + 169, 87, 26), "Скорость")) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 5*pIntervalY + 169;
				eAttribute=5;
				//sound
			}
			GUI.skin = skinRight;
			if (GUI.Button (new Rect (pIntervalX + 97, ((Screen.height / 2) - 240) + 5 * pIntervalY + 169, 35, 26), "" + uStatLevel)) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 5*pIntervalY + 169;
				eAttribute=5;
				//sound
			}

			GUI.skin = skin2;
			uStatLevel = GetActualAttribute (i, 6, Players [i].Luck, Players [i].LuckBonus); 
			GetStatColor (i, 6);
			if (GUI.Button (new Rect (pIntervalX + 7, ((Screen.height / 2) - 240) + 6 * pIntervalY + 169, 87, 26), "Удача")) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 6*pIntervalY + 169;
				eAttribute=6;
				//sound
			}
			GUI.skin = skinRight;
			if (GUI.Button (new Rect (pIntervalX + 97, ((Screen.height / 2) - 240) + 6 * pIntervalY + 169, 35, 26), "" + uStatLevel)) {
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = ((Screen.height / 2) - 235) + 6*pIntervalY + 169;
				eAttribute=6;
				//sound
			}

			//Skill 1
			GUI.skin = skin2;
			int pSkillsType = GetSkillIdxByOrder (i, 0);
			GUI.color = Color.white;
			int pXtext = Temp.pSkillNames [pSkillsType].Length;
			GUI.Box (new Rect ((pIntervalX + 50) - ((pXtext / 2 + 1) * 5), (Screen.height / 2) + 71, 150, 26), Temp.pSkillNames [pSkillsType]);

			//Skill 2
			pSkillsType = GetSkillIdxByOrder (i, 1);
			GUI.color = Color.white;
			pXtext = Temp.pSkillNames [pSkillsType].Length;
			GUI.Box (new Rect ((pIntervalX + 50) - ((pXtext / 2 + 1) * 5), (Screen.height / 2) + pIntervalY + 71, 150, 26), Temp.pSkillNames [pSkillsType]);

			//Skill 3
			pSkillsType = GetSkillIdxByOrder (i, 2);
			GUI.color = new Color (0, 0xFF, 0);
			pXtext = Temp.pSkillNames [pSkillsType].Length;
			if (pSkillsType >= 37)
				GUI.color = new Color (0, 0xF7, 0xF7);
			if(GUI.Button (new Rect ((pIntervalX + 50) - ((pXtext / 2 + 1) * 5), (Screen.height / 2) + 2 * pIntervalY + 71, 150, 26), Temp.pSkillNames [pSkillsType])){
				eAttribute = 0;
				ActiveCharacter = i;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = (Screen.height / 2) - 65;
				Players [ActiveCharacter].ActiveSkills[GetSkillIdxByOrder(ActiveCharacter, 2)] = 0;
                GetSkillDisable(ActiveCharacter, pSkillsType + 1);
			}

			//Skill 4
			pSkillsType = GetSkillIdxByOrder (i, 3);
			GUI.color = new Color (0, 0xFF, 0);
			pXtext = Temp.pSkillNames [pSkillsType].Length;
			if (pSkillsType >= 37)
				GUI.color = new Color (0, 0xF7, 0xF7);
			if(GUI.Button (new Rect ((pIntervalX + 50) - ((pXtext / 2 + 1) * 5), (Screen.height / 2) + 3 * pIntervalY + 71, 150, 26), Temp.pSkillNames [pSkillsType])){
				ActiveCharacter = i;
				eAttribute = 0;
				HintWindow=false;
				PosActiveItemX = pIntervalX-9;
				PosActiveItemY = (Screen.height / 2) - 65;
				Players [ActiveCharacter].ActiveSkills[GetSkillIdxByOrder(ActiveCharacter, 3)] = 0;
                GetSkillDisable(ActiveCharacter, pSkillsType + 1);
			}

			pIntervalX += 159;
		}

        GUI.color = Color.white;
        //button plus
        if (players_Count < 4) {
            if (GUI.Button(new Rect((Screen.width / 2) - plus_pos, (Screen.height / 2) - 195, 40, 40), Plus_text)) {
                players_Count++;
                plus_pos -= 160;
                if (players_Count == 5) {
                    players_Count = 4;
                    plus_pos += 160;
                }
            }
        }
        //button minus
        if (players_Count > 1) {
            if (GUI.Button(new Rect((Screen.width / 2) - (plus_pos + 160), (Screen.height / 2) - 195, 40, 40), Minus_text))
            {
                players_Count--;
                plus_pos += 160;
                if (players_Count == 0)
                {
                    players_Count = 1;
                    plus_pos -= 160;
                }
            }
        }

        // "Class"
        //PLAYER_CLASS_KNIGHT
        GUI.color = new Color (209, 187, 0/*97*/, 1);
		GUI.Box (new Rect ((Screen.width / 2) + 84, (Screen.height / 2) + 153, 150, 26), Temp.GlobalText [41]);

		GUI.skin = skinCenter;
		uClassType = (int)Players [ActiveCharacter].ClassType;
		GUI.color = new Color (0, 0xF7, 0xF7);
		if (uClassType > 0)
			GUI.color = Color.white;
		if (GUI.Button (new Rect ((Screen.width / 2) + 3, (Screen.height / 2) + 175, 70, 22), Temp.pClassNames [0])) {
			PlayerReset (ActiveCharacter, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_KNIGHT);
			//sound
		}

		// PLAYER_CLASS_PALADIN 
		GUI.color = new Color (0, 0xF7, 0xF7);
		if (uClassType != (int)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_PALADIN)
			GUI.color = Color.white;
		if (GUI.Button (new Rect ((Screen.width / 2) + 3, (Screen.height / 2) + pIntervalY + 175, 70, 22), Temp.pClassNames [12])) {
			PlayerReset (ActiveCharacter, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_PALADIN);
			//sound
		}

		//PLAYER_CLASS_DRUID
		GUI.color = new Color (0, 0xF7, 0xF7);
		if (uClassType != (int)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_RANGER)
			GUI.color = Color.white;
		if (GUI.Button (new Rect ((Screen.width / 2) + 3, (Screen.height / 2) + 2 * pIntervalY + 175, 70, 22), Temp.pClassNames [20])) {
			PlayerReset (ActiveCharacter, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_RANGER);
			//sound
		}

		//PLAYER_CLASS_CLERIC
		GUI.color = new Color (0, 0xF7, 0xF7);
		if (uClassType != (int)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_CLERIC)
			GUI.color = Color.white;
		if (GUI.Button (new Rect ((Screen.width / 2) + 68, (Screen.height / 2) + 175, 70, 22), Temp.pClassNames [24])) {
			PlayerReset (ActiveCharacter, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_CLERIC);
			//sound
		}

		//PLAYER_CLASS_DRUID
		GUI.color = new Color (0, 0xF7, 0xF7);
		if (uClassType != (int)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_DRUID)
			GUI.color = Color.white;
		if (GUI.Button (new Rect ((Screen.width / 2) + 68, (Screen.height / 2) + pIntervalY + 175, 70, 22), Temp.pClassNames [28])) {
			PlayerReset (ActiveCharacter, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_DRUID);
			//sound
		}

		//PLAYER_CLASS_SORCERER
		GUI.color = new Color (0, 0xF7, 0xF7);
		if (uClassType != (int)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_SORCERER)
			GUI.color = Color.white;
		if (GUI.Button (new Rect ((Screen.width / 2) + 68, (Screen.height / 2) + 2 * pIntervalY + 175, 70, 22), Temp.pClassNames [32])) {
			PlayerReset (ActiveCharacter, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_SORCERER);
			//sound
		}

		//PLAYER_CLASS_ARCHER 
		GUI.color = new Color (0, 0xF7, 0xF7);
		if (uClassType != (int)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_ARCHER)
			GUI.color = Color.white;
		if (GUI.Button (new Rect ((Screen.width / 2) + 133, (Screen.height / 2) + 175, 70, 22), Temp.pClassNames [16])) {
			PlayerReset (ActiveCharacter, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_ARCHER);
			//sound
		}

		//PLAYER_CLASS_MONK
		GUI.color = new Color (0, 0xF7, 0xF7);
		if (uClassType != (int)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_MONK)
			GUI.color = Color.white;
		if (GUI.Button (new Rect ((Screen.width / 2) + 133, (Screen.height / 2) + pIntervalY + 175, 70, 22), Temp.pClassNames [8])) {
			PlayerReset (ActiveCharacter, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_MONK);
			//sound
		}
	
		//PLAYER_CLASS_THEIF
		GUI.color = new Color (0, 0xF7, 0xF7);
		if (uClassType != (int)PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_THEIF)
			GUI.color = Color.white;
		if (GUI.Button (new Rect ((Screen.width / 2) + 133, (Screen.height / 2) + 2 * pIntervalY + 175, 70, 22), Temp.pClassNames [4])) {
			PlayerReset (ActiveCharacter, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_THEIF);
			//sound
		}

		//Skills
		GUI.color = new Color (209, 187, 0/*97*/, 1);
		GUI.Box (new Rect ((Screen.width / 2) - 310, (Screen.height / 2) + 153, 300, 26), Temp.GlobalText [20]);

		for (uint i_skill = 0; i_skill < 9; ++i_skill) {
			int pSkillId = GetSkillIdxByOrder (ActiveCharacter, (int)i_skill + 4);
			GUI.color = new Color (0, 0xF7, 0xF7);
			if (Players [ActiveCharacter].ActiveSkills [pSkillId] == 0)
				GUI.color = Color.white;
			if(GUI.Button (new Rect (((Screen.width / 2) - 312) + (100 * (i_skill / 3)), (Screen.height / 2) + pIntervalY * (i_skill % 3) + 177, 110, 26), Temp.pSkillNames [pSkillId])){
                if (GetSkillIdxByOrder(ActiveCharacter, 3) == 37)
                {
                    Players[ActiveCharacter].ActiveSkills[GetSkillIdxByOrder(ActiveCharacter, (int)i_skill + 4)] = 1;
                    GetSkillActive(ActiveCharacter, GetSkillIdxByOrder(ActiveCharacter, (int)i_skill + 4) + 1);
                }
			}
		}

		GUI.color = new Color (209, 187, 0/*97*/, 1);
		GUI.Box (new Rect ((Screen.width / 2) + 215, (Screen.height / 2) + 148, 80, 26), Temp.GlobalText [30]);

		// "Bonus"
		int pBonusNum = PlayerCreation_GetUnspentAttributePointCount ();
		GUI.color = Color.white;
		GUI.Box (new Rect ((Screen.width / 2) + 215, (Screen.height / 2) + 165, 80, 26), "" + pBonusNum);

		//OK
		if (GUI.Button (new Rect ((Screen.width / 2) + 260, (Screen.height / 2) + 192, 50, 37), "")) {
			if ((PlayerCreation_GetUnspentAttributePointCount()==0)&&PlayerCreation_Choose4Skills ()){
				GetComponent<Save>().AutoSave();
				Application.LoadLevel ("PostIntroVideo");
			}
			else {
				HintWindow = true;
			}
		}

		//Сброс
		if (GUI.Button (new Rect ((Screen.width / 2) + 207, (Screen.height / 2) + 192, 50, 37), "")) {
			PlayerReset (0, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_KNIGHT);
			SetInitialStats (0);
			PlayerReset (1, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_THEIF);
			SetInitialStats (1);
			PlayerReset (2, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_CLERIC);
			SetInitialStats (2);
			PlayerReset (3, PlayerStats.PLAYER_CLASS_TYPE.PLAYER_CLASS_SORCERER);
			SetInitialStats (3);
		}

		//-
		if (GUI.Button (new Rect ((Screen.width / 2) + 200, (Screen.height / 2) + 152, 20, 37), "")) {
			if(eAttribute>=0)
				DecreaseAttribute(ActiveCharacter, eAttribute);
		}

		//+
		if (GUI.Button (new Rect ((Screen.width / 2) + 290, (Screen.height / 2) + 152, 20, 37), "")) {
			if(eAttribute>=0)
				IncreaseAttribute(ActiveCharacter, eAttribute);
		}
		if (HintWindow) {
			string texts;
			texts = Temp.GlobalText [412];
			if (pBonusNum < 0)
				texts = Temp.GlobalText [413];

			OnGUIHint (170, 10, texts, 40);
		}
	}
	int PlayerCreation_GetUnspentAttributePointCount()
	{
		int v0; // edi@1
		int raceId; // ebx@2
		int v4; // eax@17
		int v5; // edx@18
		int v6; // ecx@18
		int remainingStatPoints; // [sp+Ch] [bp-8h]@1
		
		remainingStatPoints = 50;
		v0 = 0;
		for (int playerNum = 0; playerNum < 4; playerNum++)
		{
			raceId = GetRace(Players[playerNum].CurrentFace);
			//Debug.Log (raceId);//0
			for (int statNum = 0; statNum <= 6; statNum++)
			{
				switch ( statNum )
				{
				case 0:
					v0 = Players[playerNum].Might;
					break;
				case 1:
					v0 = Players[playerNum].Intelligence;
					break;
				case 2:
					v0 = Players[playerNum].Willpower;
					break;
				case 3:
					v0 = Players[playerNum].Endurance;
					break;
				case 4:
					v0 = Players[playerNum].Accuracy;
					break;
				case 5:
					v0 = Players[playerNum].Speed;
					break;
				case 6:
					v0 = Players[playerNum].Luck;
					break;
				}
				v4 = StatTable[raceId][statNum][0];
				//Debug.Log (v4);//9/11
				if ( v0 >= v4 )
				{
					v5 = StatTable[raceId][statNum][2];
					v6 = StatTable[raceId][statNum][3];
				}
				else
				{
					v5 = StatTable[raceId][statNum][3];
					v6 = StatTable[raceId][statNum][2];
				}
				//Debug.Log (v5);//1
				//Debug.Log (v6);//1
				remainingStatPoints += v5 * (v4 - v0) / v6;
			}
		}
		return remainingStatPoints;
	}
	bool PlayerCreation_Choose4Skills()
	{
		int skills_count; // edx@2
		
		for ( uint j = 0; j < 4; ++j )
		{
			skills_count = 0;
			for ( uint i = 0; i < 37; ++i )
			{
				if ( Players[j].ActiveSkills[i]>0 )
					++skills_count;
			}
			if ( skills_count < 4 )
				return false;
		}
		return true;
	}
	public void OnGUIHint(int x, int y, string text, int curlegth){
		//fadeColor.a = 0.8f;
		//GUI.color = fadeColor;
		//GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), nullTexture, ScaleMode.StretchToFill, true);
		if (text=="")
		{
			//MessageBoxW(nullptr, L"Invalid string passed !", L"E:\\WORK\\MSDEV\\MM7\\MM7\\Code\\Font.cpp:445", 0);
			Debug.Log( "Строка пуста" );
			return;
		}
		
		int uInStrLen = text.Length;
		int	InStrLen = text.Length;//Узнать длину строки
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
		int z = (num_line * 20)+32;
		//Debug.Log( z );
		GUI.DrawTexture(new Rect((Screen.width/2)-x, (Screen.height/2)-y,w, z), GUITextureBackground);
		
		GUI.DrawTexture(new Rect(((Screen.width/2)-x)-4, ((Screen.height/2)-y)-4,32, 32), tex_left_up);//верхний левый угол
		GUI.DrawTexture(new Rect(((Screen.width/2)-x)+28, ((Screen.height/2)-y)-4,(w-(int)ir)-line, 8), tex_horizontal_top);//верхняя горизонтальная полоса
		GUI.DrawTexture(new Rect((((Screen.width/2)-x)+w)-28, ((Screen.height/2)-y)-4,32, 32), tex_right_up);//верхний правый угол
		
		GUI.DrawTexture(new Rect(((Screen.width/2)-x)-4, ((Screen.height/2)-y)+28,8, (vline*num_line)), tex_vertical_left);//вертикальная левая полоса
		
		GUI.DrawTexture(new Rect(((Screen.width/2)-x)-4, (((Screen.height/2)-y)+z)-28,32, 32), tex_left_bottom);//нижний левый угол
		GUI.DrawTexture(new Rect(((Screen.width/2)-x)+28, ((Screen.height/2)-y)+z-4,(w-(int)ir)-line, 8), tex_horizontal_btm);//нижняя горизонтальная полоса
		GUI.DrawTexture (new Rect((((Screen.width/2)-x)+w)-28,(((Screen.height/2)-y)+z)-28,32, 32),tex_right_bottom);//нижний правый угол
		
		GUI.DrawTexture(new Rect(((Screen.width/2)-x)+w-4, ((Screen.height/2)-y)+28,8, (vline*num_line)), tex_vertical_right);
		
		GUI.skin = skinTemp;
		GUI.TextArea(new Rect((Screen.width/2)-x, (Screen.height/2)-y,w, z), text, InStrLen);
	}
	void DecreaseAttribute(int ip, int eAttribute)
	{
		int pBaseValue; // ecx@1
		int pDroppedStep; // ebx@1
		int pStep; // esi@1
		int uMinValue; // [sp+Ch] [bp-4h]@1
		
		int raceId = GetRace(Players[ip].CurrentFace);
		pBaseValue = StatTable[raceId][eAttribute][0];
		pDroppedStep = StatTable[raceId][eAttribute][2];
		uMinValue = pBaseValue - 2;
		pStep = StatTable[raceId][eAttribute][3];
		int AttrToChange = 0;
		switch ( eAttribute )
		{
		case 0:
			AttrToChange = Players[ip].Might;
			break;
		case 1:
			AttrToChange = Players[ip].Intelligence;
			break;
		case 2:
			AttrToChange = Players[ip].Willpower;
			break;
		case 3:
			AttrToChange = Players[ip].Endurance;
			break;
		case 4:
			AttrToChange = Players[ip].Accuracy;
			break;
		case 5:
			AttrToChange = Players[ip].Speed;
			break;
		case 6:
			AttrToChange = Players[ip].Luck;
			break;
		}
		if ( AttrToChange <= pBaseValue )
			pStep = pDroppedStep;
		if ( AttrToChange - pStep >= uMinValue )
			AttrToChange -= pStep;
		switch ( eAttribute )
		{
		case 0:
			Players[ip].Might=AttrToChange;
			break;
		case 1:
			Players[ip].Intelligence=AttrToChange;
			break;
		case 2:
			Players[ip].Willpower=AttrToChange;
			break;
		case 3:
			Players[ip].Endurance=AttrToChange;
			break;
		case 4:
			Players[ip].Accuracy=AttrToChange;
			break;
		case 5:
			Players[ip].Speed=AttrToChange;
			break;
		case 6:
			Players[ip].Luck=AttrToChange;
			break;
		}
	}
	void IncreaseAttribute( int ip, int eAttribute )
	{
		int raceId; // eax@1
		int maxValue; // ebx@1
		int baseStep; // edi@1
		int tmp; // eax@17
		int result; // eax@18
		int baseValue; // [sp+Ch] [bp-8h]@1
		int droppedStep; // [sp+10h] [bp-4h]@1
		int statToChange=0;
		
		raceId = GetRace(Players[ip].CurrentFace);
		maxValue = StatTable[raceId][eAttribute][1];
		baseStep = StatTable[raceId][eAttribute][3];
		baseValue = StatTable[raceId][eAttribute][0];
		droppedStep = StatTable[raceId][eAttribute][2];
		PlayerCreation_GetUnspentAttributePointCount();

		switch ( eAttribute )
		{
		case 0:
			statToChange = Players[ip].Might;
			break;
		case 1:
			statToChange = Players[ip].Intelligence;
			break;
		case 2:
			statToChange = Players[ip].Willpower;
			break;
		case 3:
			statToChange = Players[ip].Endurance;
			break;
		case 4:
			statToChange = Players[ip].Accuracy;
			break;
		case 5:
			statToChange = Players[ip].Speed;
			break;
		case 6:
			statToChange = Players[ip].Luck;
			break;
		default:
			Debug.Log(eAttribute);
			break;
		}
		if ( statToChange < baseValue )
		{
			tmp = baseStep;
			baseStep = droppedStep;
			droppedStep = tmp;
		}
		result = PlayerCreation_GetUnspentAttributePointCount();
		if ( result >= droppedStep )
		{
			if ( baseStep + statToChange <= maxValue )
				statToChange += baseStep;
		}
		switch ( eAttribute )
		{
		case 0:
			Players[ip].Might=statToChange;
			break;
		case 1:
			Players[ip].Intelligence=statToChange;
			break;
		case 2:
			Players[ip].Willpower=statToChange;
			break;
		case 3:
			Players[ip].Endurance=statToChange;
			break;
		case 4:
			Players[ip].Accuracy=statToChange;
			break;
		case 5:
			Players[ip].Speed=statToChange;
			break;
		case 6:
			Players[ip].Luck=statToChange;
			break;
		}
	}

	public void GameUI_DrawPortraits(uint _this)
	{
		uint face_expression_ID; // eax@17
		//PlayerFrame *pFrame; // eax@21
		int pTextureID; // eax@57
		Texture pPortrait; // [sp-4h] [bp-1Ch]@27
		
		/*if ( _A750D8_player_speech_timer )
		{
			_A750D8_player_speech_timer -= (int)pMiscTimer->uTimeElapsed;
			if ( _A750D8_player_speech_timer <= 0 )
			{
				if ( pPlayers[uSpeakingCharacter]->CanAct() )
					pPlayers[uSpeakingCharacter]->PlaySound(PlayerSpeechID, 0);
				_A750D8_player_speech_timer = 0i64;
			}
		}*/
		
		for (int i = 0; i < 4; ++i)
		{
			//Player* pPlayer = &pParty->pPlayers[i];
			if ( IsEradicated(i) )
			{
				//уничтожен
				/*
				pPortrait = pTexture_PlayerFaceEradicated;
				if ( pParty->pPartyBuffs[PARTY_BUFF_INVISIBILITY].uExpireTime )
					pRenderer->DrawTranslucent(pPlayerPortraitsXCoords_For_PlayerBuffAnimsDrawing[i], 388, pPortrait);
				else
					pRenderer->DrawTextureIndexedAlpha(pPlayerPortraitsXCoords_For_PlayerBuffAnimsDrawing[i] + 1, 388, pPortrait);
				if ( pPlayer->pPlayerBuffs[PLAYER_BUFF_BLESS].uExpireTime | pPlayer->pPlayerBuffs[PLAYER_BUFF_HASTE].uExpireTime
				    | pPlayer->pPlayerBuffs[PLAYER_BUFF_HEROISM].uExpireTime | pPlayer->pPlayerBuffs[PLAYER_BUFF_SHIELD].uExpireTime
				    | pPlayer->pPlayerBuffs[PLAYER_BUFF_STONESKIN].uExpireTime )
					sub_441A4E(i);
					*/
				continue;
			}
			if (IsDead(i))
			{
				//мертв
				/*
				pPortrait = pTexture_PlayerFaceDead;
				if ( pParty->pPartyBuffs[PARTY_BUFF_INVISIBILITY].uExpireTime )
					pRenderer->DrawTranslucent(pPlayerPortraitsXCoords_For_PlayerBuffAnimsDrawing[i], 388, pPortrait);
				else
					pRenderer->DrawTextureIndexedAlpha(pPlayerPortraitsXCoords_For_PlayerBuffAnimsDrawing[i] + 1, 388, pPortrait);
				if ( pPlayer->pPlayerBuffs[PLAYER_BUFF_BLESS].uExpireTime | pPlayer->pPlayerBuffs[PLAYER_BUFF_HASTE].uExpireTime
				    | pPlayer->pPlayerBuffs[PLAYER_BUFF_HEROISM].uExpireTime | pPlayer->pPlayerBuffs[PLAYER_BUFF_SHIELD].uExpireTime
				    | pPlayer->pPlayerBuffs[PLAYER_BUFF_STONESKIN].uExpireTime )
					sub_441A4E(i);*/
				continue;
			}
			face_expression_ID = 0;
			/*for ( uint j = 0; j < pPlayerFrameTable->uNumFrames; ++j ){
				if ( pPlayerFrameTable->pFrames[j].expression == pPlayer->expression )
				{
					face_expression_ID = j;
					break;
				}
			}*/
			if ( face_expression_ID == 0 )
				face_expression_ID = 1;
			//if (pPlayer->expression == CHARACTER_EXPRESSION_21)
				//pFrame = pPlayerFrameTable->GetFrameBy_y(&pPlayer->_expression21_frameset, &pPlayer->_expression21_animtime, pMiscTimer->uTimeElapsed);
			//else
				//pFrame = pPlayerFrameTable->GetFrameBy_x(face_expression_ID, pPlayer->uExpressionTimePassed);
			//if (pPlayer->field_1AA2 != pFrame->uTextureID - 1 || _this )
			//{
				//pPlayer->field_1AA2 = pFrame->uTextureID - 1;
				//pPortrait = (Texture *)pTextures_PlayerFaces[i][pPlayer->field_1AA2];//pFace = (Texture *)pTextures_PlayerFaces[i][pFrame->uTextureID];
				//if ( pParty->pPartyBuffs[PARTY_BUFF_INVISIBILITY].uExpireTime )
					//pRenderer->DrawTranslucent(pPlayerPortraitsXCoords_For_PlayerBuffAnimsDrawing[i], 388, pPortrait);
				//else
					//pRenderer->DrawTextureIndexedAlpha(pPlayerPortraitsXCoords_For_PlayerBuffAnimsDrawing[i] + 1, 388, pPortrait);
				//if ( pPlayer->pPlayerBuffs[PLAYER_BUFF_BLESS].uExpireTime | pPlayer->pPlayerBuffs[PLAYER_BUFF_HASTE].uExpireTime
				    //| pPlayer->pPlayerBuffs[PLAYER_BUFF_HEROISM].uExpireTime | pPlayer->pPlayerBuffs[PLAYER_BUFF_SHIELD].uExpireTime
				   // | pPlayer->pPlayerBuffs[PLAYER_BUFF_STONESKIN].uExpireTime )
					//sub_441A4E(i);
				continue;
			//}
		}
		/*if ( pParty->bTurnBasedModeOn == 1 )
		{
			if ( pTurnEngine->turn_stage != TE_WAIT )
			{
				if (PID_TYPE(pTurnEngine->pQueue[0].uPackedID) == OBJECT_Player)
				{
					if ( pTurnEngine->uActorQueueSize > 0 )
					{
						for (uint i = 0; i < (uint)pTurnEngine->uActorQueueSize; ++i)
						{
							if (PID_TYPE(pTurnEngine->pQueue[i].uPackedID) != OBJECT_Player)
								break;
							pTextureID = dword_5079D0;
							if ( pParty->uFlags & 0x10 )
								pTextureID = dword_5079CC;
							else
							{
								if ( pParty->uFlags & 0x20 )
									pTextureID = dword_5079C8;
							}
							pRenderer->DrawTextureIndexedAlpha(pPlayerPortraitsXCoords_For_PlayerBuffAnimsDrawing[PID_ID(pTurnEngine->pQueue[i].uPackedID)] - 4, 385, pIcons_LOD->GetTexture(pTextureID));
						}
					}
				}
			}
		}
		else
		{
			for (uint i = 0; i < 4; ++i)
			{
				if (pParty->pPlayers[i].CanAct() && !pParty->pPlayers[i].uTimeToRecovery)
				{
					pTextureID = dword_5079D0;
					if ( pParty->uFlags & 0x10 )
						pTextureID = dword_5079CC;
					else
					{
						if ( pParty->uFlags & 0x20 )
							pTextureID = dword_5079C8;
					}
					pRenderer->DrawTextureIndexedAlpha(pPlayerPortraitsXCoords_For_PlayerBuffAnimsDrawing[i] - 4, 385, pIcons_LOD->GetTexture(pTextureID));
				}
			}
		}*/
	}
	bool IsWeak(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Weak];
	}
	
	public bool IsDead(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Dead];
	}
	
	public bool IsEradicated(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Eradicated];
	}
	
	bool IsZombie(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Zombie];
	}
	
	bool IsCursed(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Cursed];
	}
	
	bool IsPertified(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Pertified];
	}
	
	bool IsUnconcious(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Unconcious];
	}
	
	bool IsAsleep(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Sleep];
	}
	
	bool IsParalyzed(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Paralyzed];
	}
	
	bool IsDrunk(int player_id)
	{
		return Players[player_id].Conditions[(int)Characters_panel.Condition.Drunk];
	}

    enum NPCProf
    {
        Smith = 1,           // GM Weapon Repair;
        Armorer = 2,         // GM Armor Repair;
        Alchemist = 3,       // GM Potion Repair;
        Scholar = 4,         // GM Item ID;               Learning: +5
        Guide = 5,           // Travel by foot: -1 day;
        Tracker = 6,         // Travel by foot: -2 days;
        Pathfinder = 7,      // Travel by foot: -3 days;
        Sailor = 8,          // Travel by sea: -2 days;
        Navigator = 9,       // Travel by sea: -3 days;
        Healer = 10,
        ExpertHealer = 11,
        MasterHealer = 12,
        Teacher = 13,        // Learning: +10;
        Instructor = 14,     // Learning: +15;
        Armsmaster = 15,     // Armsmaster: +2;
        Weaponsmaster = 16,  // Armsmaster: +3;
        Apprentice = 17,     // Fire: +2;         Air: +2;    Water: +2;   Earth: +2;
        Mystic = 18,         // Fire: +3;         Air: +3;    Water: +3;   Earth: +3;
        Spellmaster = 19,    // Fire: +4;         Air: +4;    Water: +4;   Earth: +4;
        Trader = 20,         // Merchant: +4;
        Merchant = 21,       // Merchant: +6;
        Scout = 22,          // Perception: +6;
        Herbalist = 23,      // Alchemy: +4;
        Apothecary = 24,     // Alchemy: +8;
        Tinker = 25,         // Traps: +4;
        Locksmith = 26,      // Traps: +6;
        Fool = 27,           // Luck: +5;
        ChimneySweep = 28,   // Luck: +20;
        Porter = 29,         // Food for rest: -1;
        QuarterMaster = 30,  // Food for rest: -2;
        Factor = 31,         // Gold finds: +10%;
        Banker = 32,         // Gold finds: +20%;
        Cook = 33,
        Chef = 34,
        Horseman = 35,       // Travel by foot: -2 days;
        Bard = 36,
        Enchanter = 37,      // Resist All: +20;
        Cartographer = 38,   // Wizard Eye level 2;
        WindMaster = 39,
        WaterMaster = 40,
        GateMaster = 41,
        Acolyte = 42,
        Piper = 43,
        Explorer = 44,       // Travel by foot -1 day;     Travel by sea: -1 day;
        Pirate = 45,         // Travel by sea: -2 days;    Gold finds: +10%;      Reputation: +5;
        Squire = 46,
        Psychic = 47,        // Perception: +5;            Luck: +10;
        Gypsy = 48,          // Food for rest: -1;         Merchant: +3;          Reputation: +5;
        Diplomat = 49,
        Duper = 50,          // Merchant: +8;              Reputation: +5;
        Burglar = 51,        // Traps: +8;                 Stealing: +8;          Reputation: +5;
        FallenWizard = 52,   // Reputation: +5;
        Acolyte2 = 53,       // Spirit: +2;                Mind: +2;              Body: +2;
        Initiate = 54,       // Spirit: +3;                Mind: +3;              Body: +3;
        Prelate = 55,        // Spirit: +4;                Mind: +4;              Body: +4;
        Monk = 56,           // Unarmed: +2;               Dodge: +2;
        Sage = 57,           // Monster ID: +6
        Hunter = 58          // Monster ID: +6
    };

    //----- (0048E72C) --------------------------------------------------------
    public uint GetActualAge(int ip)
    {
      return (uint)Players[ip].AgeModifier + GetBaseAge(ip);
    }

    //----- (0048C8F6) --------------------------------------------------------
    public int GetBaseLevel(int ip)
    {
      return Players[ip].Level + GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_LEVEL, false);
    }

    //----- (0048D45A) --------------------------------------------------------
    public bool CanTrainToNextLevel(int ip)
    {
      int lvl = Players[ip].Level + 1;
      int neededExp = ((lvl * (lvl - 1)) / 2 * 1000);
      return Players[ip].Experience >= neededExp;
    }

    //----- (0048CCF5) --------------------------------------------------------
    public int GetActualAttack(int ip, bool a2 )
    {
      uint v3; // eax@1
      int v4; // edi@1
      int v5; // ebx@1
      int v6; // ebp@1

      v3 = GetActualAccuracy(ip);
      v4 = GetParameterBonus(v3);
      v5 = GetSkillBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ATTACK);
      v6 = GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ATTACK, a2);
      return v4 + v5 + v6 + GetMagicalBonus((int)PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ATTACK) + Players[ip].some_attack_bonus;
    }
    //----- (0048CB39) --------------------------------------------------------
    public uint GetActualAccuracy(int ip)
    {
      return GetActualAttribute(ip, (int)PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_ACCURACY, Players[ip].Accuracy, Players[ip].AccuracyBonus);
    }
    //----- (0048D2EA) --------------------------------------------------------
    /*public char GetMeleeDamageString(int ip)
    {
      int min_damage; // edi@3
      int max_damage; // eax@3

      char[] player__getmeleedamagestring_static_buff = new char[40];

      ItemGen* mainHandItem = GetMainHandItem();

      if (mainHandItem != nullptr && (mainHandItem->uItemID >= ITEM_WAND_FIRE) && (mainHandItem->uItemID <= ITEM_WAND_INCENERATION))
      {
        strcpy(player__getmeleedamagestring_static_buff, pGlobalTXT_LocalizationStrings[595]); //"Wand"
        return player__getmeleedamagestring_static_buff;
      }
      else if (mainHandItem != nullptr && (mainHandItem->uItemID == ITEM_BLASTER || mainHandItem->uItemID == ITEM_LASER_RIFLE))
      {
        min_damage = GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MELEE_DMG_MIN, true);
        max_damage = GetItemsBonus(ip, PlayerStats.CHARACTER_ATTRIBUTE_TYPE.CHARACTER_ATTRIBUTE_MELEE_DMG_MAX, true);
      }
      else
      {
        min_damage = GetMeleeDamageMinimal();
        max_damage = GetMeleeDamageMaximal();
      }
      if ( min_damage == max_damage )
      {
        sprintf(player__getmeleedamagestring_static_buff, "%d", min_damage);
      }
      else
      {
        sprintf(player__getmeleedamagestring_static_buff, "%d - %d", min_damage, max_damage);
      }
      return player__getmeleedamagestring_static_buff;
    }

    //----- (0048D0B9) --------------------------------------------------------
    public int GetRangedAttack(int ip)
    {
      int v3; // edi@3
      //int v4; // eax@4
      //int v5; // edi@4
      int v6; // edi@4
      int v7; // edi@4

      ItemGen* mainHandItem = GetMainHandItem();
      if ( mainHandItem != nullptr && ( mainHandItem->uItemID < ITEM_BLASTER || mainHandItem->uItemID > ITEM_LASER_RIFLE ))
      {
        //v4 = GetActualAccuracy();
        //v5 = GetParameterBonus(GetActualAccuracy());
        v6 = GetItemsBonus(CHARACTER_ATTRIBUTE_RANGED_ATTACK) + GetParameterBonus(GetActualAccuracy());
        v7 = GetSkillBonus(CHARACTER_ATTRIBUTE_RANGED_ATTACK) + v6;
        v3 = this->_ranged_atk_bonus + GetMagicalBonus(CHARACTER_ATTRIBUTE_RANGED_ATTACK) + v7;
      }
      else
      {
        v3 = GetActualAttack(true);
      }
      return v3;
    }

    //----- (0048D396) --------------------------------------------------------
    char *Player::GetRangedDamageString()
    {
        int min_damage; // edi@3
        int max_damage; // eax@3

        static char player__getrangeddamagestring_static_buff[40]; // idb

        ItemGen* mainHandItem = GetMainHandItem();

        if (mainHandItem != nullptr && ( mainHandItem->uItemID >= 135 ) && ( mainHandItem->uItemID <= 159 ))
        {
          strcpy(player__getrangeddamagestring_static_buff, pGlobalTXT_LocalizationStrings[595]); //"Wand"
          return player__getrangeddamagestring_static_buff;
        }
        else if (mainHandItem != nullptr && (mainHandItem->uItemID == ITEM_BLASTER || mainHandItem->uItemID == ITEM_LASER_RIFLE))
        {
          min_damage = GetItemsBonus(CHARACTER_ATTRIBUTE_MELEE_DMG_MIN, true);
          max_damage = GetItemsBonus(CHARACTER_ATTRIBUTE_MELEE_DMG_MAX, true);
        }
        else
        {
          min_damage = GetRangedDamageMin();
          max_damage = GetRangedDamageMax();
        }
        if ( max_damage > 0)
        {
          if ( min_damage == max_damage )
          {
            sprintf(player__getrangeddamagestring_static_buff, "%d", min_damage);
          }
          else
          {
            sprintf(player__getrangeddamagestring_static_buff, "%d - %d", min_damage, max_damage);
          }
        }
        else
        {
          strcpy(player__getrangeddamagestring_static_buff, "N/A");
        }
        return player__getrangeddamagestring_static_buff;
    }
    */

    public void GetSkillDisable(int ip, int id)
    {
        switch (id)
        {
            case 1:
                Players[ip].skillStaff = 0;
                break;
            case 2:
                Players[ip].skillSword = 0;
                break;
            case 3:
                Players[ip].skillDagger = 0;
                break;
            case 4:
                Players[ip].skillAxe = 0;
                break;
            case 5:
                Players[ip].skillSpear = 0;
                break;
            case 6:
                Players[ip].skillBow = 0;
                break;
            case 7:
                Players[ip].skillMace = 0;
                break;
            case 8:
                Players[ip].skillBlaster = 0;
                break;
            case 9:
                Players[ip].skillShield = 0;
                break;
            case 10:
                Players[ip].skillLeather = 0;
                break;
            case 11:
                Players[ip].skillChain = 0;
                break;
            case 12:
                Players[ip].skillPlate = 0;
                break;
            case 13:
                Players[ip].skillFire = 0;
                break;
            case 14:
                Players[ip].skillAir = 0;
                break;
            case 15:
                Players[ip].skillWater = 0;
                break;
            case 16:
                Players[ip].skillEarth = 0;
                break;
            case 17:
                Players[ip].skillSpirit = 0;
                break;
            case 18:
                Players[ip].skillMind = 0;
                break;
            case 19:
                Players[ip].skillBody = 0;
                break;
            case 20:
                Players[ip].skillLight = 0;
                break;
            case 21:
                Players[ip].skillDark = 0;
                break;
            case 22:
                Players[ip].skillItemId = 0;
                break;
            case 23:
                Players[ip].skillMerchant = 0;
                break;
            case 24:
                Players[ip].skillRepair = 0;
                break;
            case 25:
                Players[ip].skillBodybuilding = 0;
                break;
            case 26:
                Players[ip].skillMeditation = 0;
                break;
            case 27:
                Players[ip].skillPerception = 0;
                break;
            case 28:
                Players[ip].skillDiplomacy = 0;
                break;
            case 29:
                Players[ip].skillThievery = 0;
                break;
            case 30:
                Players[ip].skillDisarmTrap = 0;
                break;
            case 31:
                Players[ip].skillDodge = 0;
                break;
            case 32:
                Players[ip].skillUnarmed = 0;
                break;
            case 33:
                Players[ip].skillMonsterId = 0;
                break;
            case 34:
                Players[ip].skillArmsmaster = 0;
                break;
            case 35:
                Players[ip].skillStealing = 0;
                break;
            case 36:
                Players[ip].skillAlchemy = 0;
                break;
            case 37:
                Players[ip].skillLearning = 0;
                break;
        }
    }

    public void GetSkillActive(int ip, int id)
    {
        switch(id) {
            case 1:
                Players[ip].skillStaff = 1;
                break;
            case 2:
                	Players[ip].skillSword = 1;
                break;
            case 3:
	Players[ip].skillDagger = 1;
                break;
            case 4:
	Players[ip].skillAxe = 1;
                break;
            case 5:
	Players[ip].skillSpear = 1;
                break;
            case 6:
	Players[ip].skillBow = 1;
                break;
            case 7:
	Players[ip].skillMace= 1;
                break;
            case 8:
	Players[ip].skillBlaster = 1;
                break;
            case 9:
	Players[ip].skillShield = 1;
                break;
            case 10:
	Players[ip].skillLeather = 1;
                break;
            case 11:
	Players[ip].skillChain = 1;
                break;
            case 12:
	Players[ip].skillPlate = 1;
                break;
            case 13:
	Players[ip].skillFire = 1;
                break;
            case 14:
	Players[ip].skillAir = 1;
                break;
            case 15:
	Players[ip].skillWater = 1;
                break;
            case 16:
	Players[ip].skillEarth = 1;
                break;
            case 17:
	Players[ip].skillSpirit = 1;
                break;
            case 18:
	Players[ip].skillMind = 1;
                break;
            case 19:
	Players[ip].skillBody = 1;
                break;
            case 20:
	Players[ip].skillLight = 1;
                break;
            case 21:
	Players[ip].skillDark = 1;
                break;
            case 22:
	Players[ip].skillItemId = 1;
                break;
            case 23:
	Players[ip].skillMerchant = 1;
                break;
            case 24:
	Players[ip].skillRepair = 1;
                break;
            case 25:
	Players[ip].skillBodybuilding = 1;
                break;
            case 26:
	Players[ip].skillMeditation = 1;
                break;
            case 27:
	Players[ip].skillPerception = 1;
                break;
            case 28:
	Players[ip].skillDiplomacy = 1;
                break;
            case 29:
	Players[ip].skillThievery = 1;
                break;
            case 30:
	Players[ip].skillDisarmTrap = 1;
                break;
            case 31:
	Players[ip].skillDodge = 1;
                break;
            case 32:
	Players[ip].skillUnarmed = 1;
                break;
            case 33:
	Players[ip].skillMonsterId = 1;
                break;
            case 34:
	Players[ip].skillArmsmaster = 1;
                break;
            case 35:
	Players[ip].skillStealing = 1;
                break;
            case 36:
	Players[ip].skillAlchemy = 1;
                break;
            case 37:
                Players[ip].skillLearning = 1;
                break;
        }
    }

    //----- (00476395) --------------------------------------------------------
    //0x26 Wizard eye at skill level 2
    public bool CheckHiredNPCSpeciality(uint uProfession)
    {


        /*if (bNoNPCHiring == 1)
            return 0;

        for (uint i = 0; i < pNPCStats->uNumNewNPCs; ++i)
        {
            if (pNPCStats->pNewNPCData[i].uProfession == uProfession &&
                (pNPCStats->pNewNPCData[i].uFlags & 0x80))//Uninitialized memory access
                return true;
        }
        if (pParty->pHirelings[0].uProfession == uProfession ||
             pParty->pHirelings[1].uProfession == uProfession)
            return true;
        else*/
            return false;

    }
}
