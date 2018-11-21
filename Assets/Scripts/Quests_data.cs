using UnityEngine;
using System.Collections;

public class Quests_data : MonoBehaviour {

    public enum EventType
    {
        EVENT_Exit = 0x1,
        EVENT_SpeakInHouse = 0x2,
        EVENT_PlaySound = 0x3,
        EVENT_MouseOver = 0x4,
        EVENT_LocationName = 0x5,
        EVENT_MoveToMap = 0x6,
        EVENT_OpenChest = 0x7,
        EVENT_ShowFace = 0x8,
        EVENT_ReceiveDamage = 0x9,
        EVENT_SetSnow = 0xA,
        EVENT_SetTexture = 0xB,
        EVENT_ShowMovie = 0xC,
        EVENT_SetSprite = 0xD,
        EVENT_Compare = 0xE,
        EVENT_ChangeDoorState = 0xF,
        EVENT_Add = 0x10,
        EVENT_Substract = 0x11,
        EVENT_Set = 0x12,
        EVENT_SummonMonsters = 0x13,
        EVENT_CastSpell = 0x15,
        EVENT_SpeakNPC = 0x16,
        EVENT_SetFacesBit = 0x17,
        EVENT_ToggleActorFlag = 0x18,
        EVENT_RandomGoTo = 0x19,
        EVENT_InputString = 0x1A,
        EVENT_StatusText = 0x1D,
        EVENT_ShowMessage = 0x1E,
        EVENT_OnTimer = 0x1F,
        EVENT_ToggleIndoorLight = 0x20,
        EVENT_PressAnyKey = 0x21,
        EVENT_SummonItem = 0x22,
        EVENT_ForPartyMember = 0x23,
        EVENT_Jmp = 0x24,
        EVENT_OnMapReload = 0x25,
        EVENT_Initialize = 0x26,
        EVENT_SetNPCTopic = 0x27,
        EVENT_MoveNPC = 0x28,
        EVENT_GiveItem = 0x29,
        EVENT_ChangeEvent = 0x2A,
        EVENT_CheckSkill = 0x2B,
        EVENT_OnCanShowDialogItemCmp = 44,
        EVENT_EndCanShowDialogItem = 45,
        EVENT_SetCanShowDialogItem = 46,
        EVENT_SetNPCGroupNews = 0x2F,
        EVENT_SetActorGroup = 0x30,
        EVENT_NPCSetItem = 0x31,
        EVENT_SetNPCGreeting = 0x32,
        EVENT_IsActorAlive = 0x33,
        EVENT_IsActorAssasinated = 52,
        EVENT_OnMapLeave = 0x35,
        EVENT_ChangeGroup = 0x36,
        EVENT_ChangeGroupAlly = 0x37,
        EVENT_CheckSeason = 0x38,
        EVENT_ToggleActorGroupFlag = 0x39,
        EVENT_ToggleChestFlag = 0x3A,
        EVENT_CharacterAnimation = 0x3B,
        EVENT_SetActorItem = 0x3C,
        EVENT_OnDateTimer = 0x3D,
        EVENT_EnableDateTimer = 0x3E,
        EVENT_StopAnimation = 0x3F,
        EVENT_CheckItemsCount = 0x40,
        EVENT_RemoveItems = 0x41,
        EVENT_SpecialJump = 0x42,
        EVENT_IsTotalBountyHuntingAwardInRange = 0x43,
        EVENT_IsNPCInParty = 0x44,
    };
    public Quest[] Quests;
    public GameObject character;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public bool gui_hint;
    public bool gui_hint_not_done;
    public bool gui_hint_done;
    private string hint_not_found_text;
    public int quest_id;
    //public int curent_quest_id;
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
    public enum VariableType
    {
        VAR_Sex = 0x1,
        VAR_Class = 0x2,
        VAR_CurrentHP = 0x3,
        VAR_MaxHP = 0x4,
        VAR_CurrentSP = 0x5,
        VAR_MaxSP = 0x6,
        VAR_ActualAC = 0x7,
        VAR_ACModifier = 0x8,
        VAR_BaseLevel = 0x9,
        VAR_LevelModifier = 0xA,
        VAR_Age = 0xB,
        VAR_Award = 0xC,
        VAR_Experience = 0xD,
        VAR_Race = 0xE,
        VAR_QBits_QuestsDone = 0x10,
        VAR_PlayerItemInHands = 0x11,
        VAR_Hour = 0x12,
        VAR_DayOfYear = 0x13,
        VAR_DayOfWeek = 0x14,
        VAR_FixedGold = 0x15,
        VAR_RandomGold = 0x16,
        VAR_FixedFood = 0x17,
        VAR_RandomFood = 0x18,
        VAR_MightBonus = 0x19,
        VAR_IntellectBonus = 0x1A,
        VAR_PersonalityBonus = 0x1B,
        VAR_EnduranceBonus = 0x1C,
        VAR_SpeedBonus = 0x1D,
        VAR_AccuracyBonus = 0x1E,
        VAR_LuckBonus = 0x1F,
        VAR_BaseMight = 0x20,
        VAR_BaseIntellect = 0x21,
        VAR_BasePersonality = 0x22,
        VAR_BaseEndurance = 0x23,
        VAR_BaseSpeed = 0x24,
        VAR_BaseAccuracy = 0x25,
        VAR_BaseLuck = 0x26,
        VAR_ActualMight = 0x27,
        VAR_ActualIntellect = 0x28,
        VAR_ActualPersonality = 0x29,
        VAR_ActualEndurance = 0x2A,
        VAR_ActualSpeed = 0x2B,
        VAR_ActualAccuracy = 0x2C,
        VAR_ActualLuck = 0x2D,
        VAR_FireResistance = 0x2E,
        VAR_AirResistance = 0x2F,
        VAR_WaterResistance = 0x30,
        VAR_EarthResistance = 0x31,
        VAR_SpiritResistance = 0x32,
        VAR_MindResistance = 0x33,
        VAR_BodyResistance = 0x34,
        VAR_LightResistance = 0x35,
        VAR_DarkResistance = 0x36,
        VAR_PhysicalResistance = 0x37,
        VAR_MagicResistance = 0x38,
        VAR_FireResistanceBonus = 0x39,
        VAR_AirResistanceBonus = 0x3A,
        VAR_WaterResistanceBonus = 0x3B,
        VAR_EarthResistanceBonus = 0x3C,
        VAR_SpiritResistanceBonus = 0x3D,
        VAR_MindResistanceBonus = 0x3E,
        VAR_BodyResistanceBonus = 0x3F,
        VAR_LightResistanceBonus = 0x40,
        VAR_DarkResistanceBonus = 0x41,
        VAR_PhysicalResistanceBonus = 0x42,
        VAR_MagicResistanceBonus = 0x43,
        VAR_StaffSkill = 0x44,
        VAR_SwordSkill = 0x45,
        VAR_DaggerSkill = 0x46,
        VAR_AxeSkill = 0x47,
        VAR_SpearSkill = 0x48,
        VAR_BowSkill = 0x49,
        VAR_MaceSkill = 0x4A,
        VAR_BlasterSkill = 0x4B,
        VAR_ShieldSkill = 0x4C,
        VAR_LeatherSkill = 0x4D,
        VAR_SkillChain = 0x4E,
        VAR_PlateSkill = 0x4F,
        VAR_FireSkill = 0x50,
        VAR_AirSkill = 0x51,
        VAR_WaterSkill = 0x52,
        VAR_EarthSkill = 0x53,
        VAR_SpiritSkill = 0x54,
        VAR_MindSkill = 0x55,
        VAR_BodySkill = 0x56,
        VAR_LightSkill = 0x57,
        VAR_DarkSkill = 0x58,
        VAR_IdentifyItemSkill = 0x59,
        VAR_MerchantSkill = 0x5A,
        VAR_RepairSkill = 0x5B,
        VAR_BodybuildingSkill = 0x5C,
        VAR_MeditationSkill = 0x5D,
        VAR_PerceptionSkill = 0x5E,
        VAR_DiplomacySkill = 0x5F,
        VAR_ThieverySkill = 0x60,
        VAR_DisarmTrapSkill = 0x61,
        VAR_DodgeSkill = 0x62,
        VAR_UnarmedSkill = 0x63,
        VAR_IdentifyMonsterSkill = 0x64,
        VAR_ArmsmasterSkill = 0x65,
        VAR_StealingSkill = 0x66,
        VAR_AlchemySkill = 0x67,
        VAR_LearningSkill = 0x68,
        VAR_Cursed = 0x69,
        VAR_Weak = 0x6A,
        VAR_Asleep = 0x6B,
        VAR_Afraid = 0x6C,
        VAR_Drunk = 0x6D,
        VAR_Insane = 0x6E,
        VAR_PoisonedGreen = 0x6F,
        VAR_DiseasedGreen = 0x70,
        VAR_PoisonedYellow = 0x71,
        VAR_DiseasedYellow = 0x72,
        VAR_PoisonedRed = 0x73,
        VAR_DiseasedRed = 0x74,
        VAR_Paralyzed = 0x75,
        VAR_Unconsious = 0x76,
        VAR_Dead = 0x77,
        VAR_Stoned = 0x78,
        VAR_Eradicated = 0x79,
        VAR_MajorCondition = 0x7A,
        VAR_MapPersistentVariable_0 = 123,
        VAR_MapPersistentVariable_74 = 0xC5,
        VAR_MapPersistentVariable_75 = 0xC6,
        VAR_MapPersistentVariable_99 = 0xDE,
        VAR_AutoNotes = 0xDF,
        VAR_IsMightMoreThanBase = 0xE0,
        VAR_IsIntellectMoreThanBase = 0xE1,
        VAR_IsPersonalityMoreThanBase = 0xE2,
        VAR_IsEnduranceMoreThanBase = 0xE3,
        VAR_IsSpeedMoreThanBase = 0xE4,
        VAR_IsAccuracyMoreThanBase = 0xE5,
        VAR_IsLuckMoreThanBase = 0xE6,
        VAR_PlayerBits = 0xE7,
        VAR_NPCs2 = 0xE8,
        VAR_IsFlying = 0xF0,
        VAR_HiredNPCHasSpeciality = 0xF1,
        VAR_CircusPrises = 0xF2,
        VAR_NumSkillPoints = 0xF3,
        VAR_MonthIs = 0xF4,
        VAR_Counter1 = 0xF5,
        VAR_Counter2 = 0xF6,
        VAR_Counter3 = 0xF7,
        VAR_Counter4 = 0xF8,
        VAR_Counter5 = 0xF9,
        VAR_Counter6 = 0xFa,
        VAR_Counter7 = 0xFB,
        VAR_Counter8 = 0xFC,
        VAR_Counter9 = 0xFD,
        VAR_Counter10 = 0xFE,
        VAR_UnknownTimeEvent0 = 0xFF,
        VAR_UnknownTimeEvent19 = 0x112,
        VAR_ReputationInCurrentLocation = 0x113,
        VAR_History_0 = 0x114,
        VAR_History_28 = 0x130,
        VAR_Unknown1 = 0x131,
        VAR_GoldInBank = 0x132,
        VAR_NumDeaths = 0x133,
        VAR_NumBounties = 0x134,
        VAR_PrisonTerms = 0x135,
        VAR_ArenaWinsPage = 0x136,
        VAR_ArenaWinsSquire = 0x137,
        VAR_ArenaWinsKnight = 0x138,
        VAR_ArenaWinsLord = 0x139,
        VAR_Invisible = 0x13A,
        VAR_ItemEquipped = 0x13B,
    };
    // Use this for initialization
    void Start () {
        gui_hint = false;
        gui_hint_not_done = false;
        gui_hint_done = false;
        hint_not_found_text = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (Temp.current_screen == Temp.screen_name.screen_house)
        {
            for (int i = 0; i < Quests.Length; i++)
            {
                if (Quests[i].QuestState == Quest.Quest_state.Quest_taken || Quests[i].QuestState == Quest.Quest_state.Quest_performed)
                {
                    CheckQuest(Quests[i]);
                }
            }
        }
	}
    public void CheckQuest(Quest quest)
    {
        switch (quest.QuestID) {
            case 0:
                //Debug.Log(quest.QuestTopic);
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                gui_hint = false;
                gui_hint_not_done = false;
                break;
            case 1://снять комнату
                //Debug.Log(quest.QuestTopic);
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                gui_hint = false;
                gui_hint_not_done = false;
                break;
            case 2://продажа еды в таверне
                //Debug.Log(quest.QuestTopic);
                if (quest.QuestState == Quest.Quest_state.Quest_performed)
                {
                    if (character.GetComponent<Party>().uNumFoodRations < quest.Quest_food_exchange)
                    {
                        character.GetComponent<Party>().uNumFoodRations = quest.Quest_food_exchange;
                        character.GetComponent<Party>().NumGold -= quest.Quest_gold_exchange;
                    }
                }
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                gui_hint = false;
                gui_hint_not_done = false;
                break;
            case 3://Обучаться навыкам
                   //Debug.Log(quest.QuestTopic);
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                gui_hint = false;
                gui_hint_not_done = false;
                break;
            case 4://Замок Хермондейл
                //Debug.Log("квест 4");
                gui_hint = true;
                gui_hint_not_done = false;
                gui_hint_done = false;
                quest_id = 4;
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                break;
            case 5://Гонка
                Debug.Log("квест 5");
                gui_hint = false;
                gui_hint_not_done = false;
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                break;
            case 6://Пропавшие участники(принести щит)
                Debug.Log("квест 6");
                gui_hint = false;
                gui_hint_not_done = false;
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                break;
            case 7://Правила гонки
                gui_hint = true;
                gui_hint_not_done = false;
                quest_id = 7;
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                break;
            case 8://Что у вас есть?
                gui_hint = false;
                gui_hint_not_done = false;
                hint_not_found_text = "";
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                //проверка наличия вещей
                if (quest.Quest_findItem1ID_done == false && quest.Quest_findItem1ID > 0)
                {
                    if (FindItem(quest.Quest_findItem1ID - 1))
                        quest.Quest_findItem1ID_done = true;
                    else
                        hint_not_found_text += quest.Quest_findItem1Name + " ";
                }
                if (quest.Quest_findItem2ID_done == false && quest.Quest_findItem2ID > 0)
                {
                    if (FindItem(quest.Quest_findItem2ID - 1))
                        quest.Quest_findItem2ID_done = true;
                    else
                        hint_not_found_text += quest.Quest_findItem2Name + " ";
                }
                if (quest.Quest_findItem3ID_done == false && quest.Quest_findItem3ID > 0)
                {
                    if (FindItem(quest.Quest_findItem3ID - 1))
                        quest.Quest_findItem3ID_done = true;
                    else
                        hint_not_found_text += quest.Quest_findItem3Name + " ";
                }
                if (quest.Quest_findItem4ID_done == false && quest.Quest_findItem4ID > 0)
                {
                    if (FindItem(quest.Quest_findItem4ID - 1))
                        quest.Quest_findItem4ID_done = true;
                    else
                        hint_not_found_text += quest.Quest_findItem4Name + " ";
                }
                if (quest.Quest_findItem5ID_done == false && quest.Quest_findItem5ID > 0)
                {
                    if (FindItem(quest.Quest_findItem5ID - 1))
                        quest.Quest_findItem5ID_done = true;
                    else
                        hint_not_found_text += quest.Quest_findItem5Name + " ";
                }
                if (quest.Quest_findItem6ID_done == false && quest.Quest_findItem6ID > 0)
                {
                    if (FindItem(quest.Quest_findItem6ID - 1))
                        quest.Quest_findItem6ID_done = true;
                    else
                        hint_not_found_text += quest.Quest_findItem6Name + " ";
                }
                //подведение итога
                if (quest.Quest_findItem1ID_done == true && quest.Quest_findItem2ID_done == true
                    && quest.Quest_findItem3ID_done == true && quest.Quest_findItem4ID_done == true
                    && quest.Quest_findItem5ID_done == true && quest.Quest_findItem6ID_done == true)
                {
                    gui_hint_done = true;
                    quest_id = 8;
                    Player1.GetComponent<PlayerStats>().AwardsBits[1] = 1;
                    Player2.GetComponent<PlayerStats>().AwardsBits[1] = 1;
                    Player3.GetComponent<PlayerStats>().AwardsBits[1] = 1;
                    Player4.GetComponent<PlayerStats>().AwardsBits[1] = 1;
                }
                else
                {
                    gui_hint_not_done = true;
                }
                break;
            case 9://Путешествие на корабле
                //Debug.Log(quest.QuestTopic);
                quest.QuestState = Quest.Quest_state.Quest_no_taken;
                //gui_hint = true;
                quest_id = 9;
                gui_hint_done = true;
                Temp.CurrentMapName = "emerald_01";
                Temp.NextMapName = "Hermondale";
                Temp.NextLevelID = 12;
                pausedgame();
                character.GetComponent<Save>().AutoSave();
                Application.LoadLevel("Load");
                break;
        }
    }
    IEnumerator pausedgame()
    {
        yield return new WaitForSeconds(3f);
    }
    public void OnGUI()
    {
        if (Temp.current_screen == Temp.screen_name.screen_house) {
            if (gui_hint && !gui_hint_done)
                OnGUIHint(230, -172, "" + Quests[quest_id - 1].QuestDescription, 51);
            if (gui_hint_not_done)
                OnGUIHint(230, -172, "Вы не нашли:" + hint_not_found_text, 51);
            if (gui_hint_done)
                OnGUIHint(230, -172, "" + Quests[quest_id - 1].QuestPostText, 51);
        }
    }
    public bool FindItem(int ItemID)
    {
        for (uint i = 0; i < 126; ++i)
        {
            if (Player1.GetComponent<PlayerStats>().InventoryMatrix[i] > 0)
            {
                int p = Player1.GetComponent<PlayerStats>().InventoryItemList[0].ItemID;
                if (Player1.GetComponent<PlayerStats>().InventoryItemList[Player1.GetComponent<PlayerStats>().InventoryMatrix[i] - 1].ItemID == ItemID)
                    return true;
            }
            if (Player2.GetComponent<PlayerStats>().InventoryMatrix[i] > 0)
            {
                if (Player2.GetComponent<PlayerStats>().InventoryItemList[Player2.GetComponent<PlayerStats>().InventoryMatrix[i] - 1].ItemID == ItemID)
                    return true;
            }
            if (Player3.GetComponent<PlayerStats>().InventoryMatrix[i] > 0)
            {
                if (Player3.GetComponent<PlayerStats>().InventoryItemList[Player3.GetComponent<PlayerStats>().InventoryMatrix[i] - 1].ItemID == ItemID)
                    return true;
            }
            if (Player4.GetComponent<PlayerStats>().InventoryMatrix[i] > 0)
            {
                if (Player4.GetComponent<PlayerStats>().InventoryItemList[Player4.GetComponent<PlayerStats>().InventoryMatrix[i] - 1].ItemID == ItemID)
                    return true;
            }
        }     
        return false;
    }
    public void OnGUIHint(int x, int y, string text, int curlegth)
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
        if (z > 175)
            y += z - 175; 
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
        GUI.skin.textArea.alignment = TextAnchor.LowerCenter;
        GUI.TextArea(new Rect((Screen.width / 2) - x, (Screen.height / 2) - y, w, z), text, InStrLen);
    }
    //----- (0044684A) --------------------------------------------------------
    public void EventProcessor(int uEventID, int targetObj, int canShowMessages, int entry_line)
    {
        /*int v4; // esi@7
        int v11; // eax@14
        char* v12; // eax@15
        const char* v16; // esi@21
        bool v17; // edx@21
        int v18; // ecx@22
        int v19; // ebp@36
        signed int v20; // ecx@40
        int v21; // eax@40
        int v22; // edx@40
        int v23; // eax@40
        unsigned __int16 v24; // ax@45
        LevelDecoration* v26; // eax@55
        int v27; // eax@57
        int pEventID; // eax@58
        int pNPC_ID; // ecx@58
        int pIndex; // esi@58
        NPCData* pNPC; // ecx@58
        int v38; // eax@78
        int v39; // ecx@78
        int v42; // eax@84
        int v43; // ecx@84
        GUIButton* v48; // ecx@93
        GUIButton* v49; // esi@94
        signed int pValue; // ebp@124
        Player* pPlayer; // esi@125
        int v83; // eax@212
        int v84; // ebp@220
        int v90; // eax@243
        const char* v91; // ecx@247
        int v94; // ecx@262
        int v95; // ebp@262
        int v96; // edx@262
        int v97; // eax@262
        unsigned int v98; // edx@265
        const char* v99; // esi@267
        int v100; // edx@267
        unsigned int v102; // esi@281
        int v104; // eax@288
        int v106; // [sp-20h] [bp-4C8h]@278
        signed int v109; // [sp-14h] [bp-4BCh]@278
        signed int v110; // [sp-10h] [bp-4B8h]@278*/
        int curr_seq_num; // [sp+10h] [bp-498h]@4
        //int v126; // [sp+1Ch] [bp-48Ch]@262
        int player_choose; // [sp+20h] [bp-488h]@4
        /*int v128; // [sp+24h] [bp-484h]@21
        int v129; // [sp+24h] [bp-484h]@262
        signed int v130; // [sp+28h] [bp-480h]@0
        int v132; // [sp+30h] [bp-478h]@262
        signed int v133; // [sp+34h] [bp-474h]@1
        int v134; // [sp+38h] [bp-470h]@262
        int v135; // [sp+3Ch] [bp-46Ch]@262
        int v136; // [sp+40h] [bp-468h]@40
        int v137; // [sp+44h] [bp-464h]@40
        int v138; // [sp+48h] [bp-460h]@40
        int v139; // [sp+4Ch] [bp-45Ch]@40
        ItemGen item; // [sp+50h] [bp-458h]@15
        char Source[120]; // [sp+74h] [bp-434h]@15
        char Str[120]; // [sp+ECh] [bp-3BCh]@21
        Actor Dst; // [sp+164h] [bp-344h]@53*/

        //v133 = 0;
        //EvtTargetObj = targetObj;
        //dword_5B65C4_cancelEventProcessing = 0;
       
        if (uEventID == 0)
        {
            //if (!GameUI_Footer_TimeLeft)
                //ShowStatusBarString(pGlobalTXT_LocalizationStrings[521], 2u);// Nothing here
            return;
        }
        player_choose = (Temp.ActiveCharacter == 0) ? 6 : 4;  //4 - active or  6 - random player if active =0
        curr_seq_num = entry_line;

        /*if (activeLevelDecoration)
        {
            uSomeEVT_NumEvents = uGlobalEVT_NumEvents;
            pSomeEVT = pGlobalEVT.data();
            memcpy(pSomeEVT_Events.data(), pGlobalEVT_Index.data(), sizeof(EventIndex) * 4400); //4400 evts
        }
        else
        {
            uSomeEVT_NumEvents = uLevelEVT_NumEvents;
            pSomeEVT = pLevelEVT.data();
            memcpy(pSomeEVT_Events.data(), pLevelEVT_Index.data(), sizeof(EventIndex) * 4400);
        }

        for (v4 = 0; v4 < uSomeEVT_NumEvents; ++v4)
        {
            if (dword_5B65C4_cancelEventProcessing)
            {
                if (v133 == 1)
                    OnMapLeave();
                return;
            }
            if (pSomeEVT_Events[v4].uEventID == uEventID && pSomeEVT_Events[v4].event_sequence_num == curr_seq_num)
            {
                _evt_raw* _evt = (_evt_raw*)(pSomeEVT + pSomeEVT_Events[v4].uEventOffsetInEVT);

                switch (_evt->_e_type)
                {
                    case EVENT_CheckSeason:
                        if (!sub_4465DF_check_season(_evt->v5))
                        {
                            ++curr_seq_num;
                            //v4 = v124;
                            break;
                        }
                        v4 = -1;
                        curr_seq_num = _evt->v6 - 1;
                        ++curr_seq_num;
                        break;
                    case EVENT_ShowMovie:
                        {
                            strcpy(Source, (char*)&_evt->v7);
                            v12 = (char*)&item.uExpireTime + strlen(Source) + 7;
                            if (*v12 == 32)
                                *v12 = 0;
                            if (pMediaPlayer->bPlaying_Movie)
                                pMediaPlayer->Unload();
                            pMediaPlayer->bStopBeforeSchedule = 0;
                            //        pMediaPlayer->pResetflag = 0;

                            v128 = current_screen_type;
                            strcpy(Str, Source);
                            v16 = RemoveQuotes(Str);
                            pMediaPlayer->FullscreenMovieLoop(v16, 0/*, _evt->v5*//*);
                            if (!_stricmp(v16, "arbiter good"))
                            {
                                pParty->alignment = PartyAlignment_Good;
                                v18 = 0;
                                LOBYTE(v17) = 1;
                                SetUserInterface(PartyAlignment_Good, v17);
                                if (!_evt->v6 || v128 == SCREEN_BOOKS)
                                {
                                    current_screen_type = (CURRENT_SCREEN)v128;
                                    if (v128 == SCREEN_BOOKS)
                                        pGameLoadingUI_ProgressBar->uType = GUIProgressBar::TYPE_Fullscreen;
                                    if (v128 == SCREEN_HOUSE)
                                        pMediaPlayer->OpenHouseMovie(pAnimatedRooms[uCurrentHouse_Animation].video_name, 1);
                                }
                                ++curr_seq_num;
                                break;
                            }
                            if (!_stricmp(v16, "arbiter evil"))
                            {
                                v18 = 2;
                                pParty->alignment = PartyAlignment_Evil;
                                LOBYTE(v17) = 1;
                                SetUserInterface(PartyAlignment_Evil, v17);
                                if (!_evt->v6 || v128 == SCREEN_BOOKS)
                                {
                                    current_screen_type = (CURRENT_SCREEN)v128;
                                    if (v128 == SCREEN_BOOKS)
                                        pGameLoadingUI_ProgressBar->uType = GUIProgressBar::TYPE_Fullscreen;
                                    if (v128 == SCREEN_HOUSE)
                                        pMediaPlayer->OpenHouseMovie(pAnimatedRooms[uCurrentHouse_Animation].video_name, 1);
                                }
                                ++curr_seq_num;
                                break;
                            }
                            if (!_stricmp(v16, "pcout01"))    // moving to harmondale from emerald isle
                            {
                                Rest(0x2760u);
                                pParty->RestAndHeal();
                                pParty->days_played_without_rest = 0;
                            }
                            if (!_evt->v6 || v128 == SCREEN_BOOKS)
                            {
                                current_screen_type = (CURRENT_SCREEN)v128;
                                if (v128 == SCREEN_BOOKS)
                                    pGameLoadingUI_ProgressBar->uType = GUIProgressBar::TYPE_Fullscreen;
                                if (v128 == SCREEN_HOUSE)
                                    pMediaPlayer->OpenHouseMovie(pAnimatedRooms[uCurrentHouse_Animation].video_name, 1);
                            }
                            ++curr_seq_num;
                        }
                        break;
                    case EVENT_CheckSkill:
                        {
                            v19 = _evt->v7 + ((_evt->v8 + ((_evt->v9 + ((unsigned int)_evt->v10 << 8)) << 8)) << 8);
        if (player_choose < 0)
            goto LABEL_47;
        if (player_choose <= 3)
            v24 = pParty->pPlayers[0].pActiveSkills[3486 * player_choose + _evt->v5];
        else
        {
            if (player_choose == 4)
                v24 = pPlayers[uActiveCharacter]->pActiveSkills[_evt->v5];
            else
            {
                if (player_choose == 5)
                {
                    v20 = 0;
                    v21 = 3486 * v130 + _evt->v5;
                    v136 = 1;
                    LOWORD(v21) = pParty->pPlayers[0].pActiveSkills[v21];
                    v137 = v21 & 0x40;
                    v138 = v21 & 0x80;
                    v22 = v21 & 0x100;
                    v23 = v21 & 0x3F;
                    v139 = v22;
                    while (v23 < v19 || !*(&v136 + _evt->v6))
                    {
                        ++v20;
                        if (v20 >= 4)
                        {
                            ++curr_seq_num;
                            break;
                        }
                    }
                    curr_seq_num = _evt->v11 - 1;
                    ++curr_seq_num;
                    break;
                }
            LABEL_47:
                //v10 = (ByteArray *)&v5[v9];
                v24 = pParty->pPlayers[0].pActiveSkills[_evt->v5 + 3486 * rand() % 4];
            }
        }
        v136 = 1;
        v137 = v24 & 0x40;
        v138 = v24 & 0x80;
        v139 = v24 & 0x100;
        if ((v24 & 0x3F) >= v19 && *(&v136 + _evt->v6))
        {
            curr_seq_num = _evt->v11 - 1;
            ++curr_seq_num;
            break;
        }
        ++curr_seq_num;
    }
        break;

      case EVENT_SpeakNPC:
        if ( canShowMessages )
          {
          //Actor::Actor(&Dst);
          memset(&Dst, 0, 0x344u);
    dword_5B65D0_dialogue_actor_npc_id = _evt->v5 + ((_evt->v6 + ((_evt->v7 + ((unsigned int)_evt->v8 << 8)) << 8)) << 8);
          Dst.sNPC_ID = dword_5B65D0_dialogue_actor_npc_id;
          GameUI_InitializeDialogue(&Dst, false);
}
        else
          bDialogueUI_InitializeActor_NPC_ID = _evt->v5 + ((_evt->v6 + ((_evt->v7 + ((unsigned int)_evt->v8 << 8)) << 8)) << 8);
        ++curr_seq_num;
        break;
      case EVENT_ChangeEvent:
        if ( EVT_DWORD(_evt->v5) )
          stru_5E4C90_MapPersistVars._decor_events[activeLevelDecoration->_idx_in_stru123] = _evt->v5 - 124;
        else
        {
          v26 = (LevelDecoration*)activeLevelDecoration;
          stru_5E4C90_MapPersistVars._decor_events[activeLevelDecoration->_idx_in_stru123] = 0;
          v26->uFlags |= LEVEL_DECORATION_INVISIBLE;
        }
        ++curr_seq_num;

        break;
      case EVENT_SetNPCGreeting:
        v27 = EVT_DWORD(_evt->v5);
pNPCStats->pNewNPCData[v27].uFlags &= 0xFFFFFFFCu;
        pNPCStats->pNewNPCData[v27].greet = EVT_DWORD(_evt->v9);
        ++curr_seq_num;
        break;
            case EVENT_SetNPCTopic:
            {
              //v29 = _evt->v5 + ((_evt->v6 + ((_evt->v7 + ((uint)_evt->v8 << 8)) << 8)) << 8);
              pEventID = _evt->v10 + ((_evt->v11 + ((_evt->v12 + ((uint)_evt->v13 << 8)) << 8)) << 8);
              pNPC_ID = _evt->v5 + ((_evt->v6 + ((_evt->v7 + ((uint)_evt->v8 << 8)) << 8)) << 8);
              pIndex = _evt->v9;
              pNPC = &pNPCStats->pNewNPCData[pNPC_ID];
              if ( pIndex == 0 )
                pNPC->evt_A = pEventID;
              if ( pIndex == 1 )
                pNPC->evt_B = pEventID;
              if ( pIndex == 2 )
                pNPC->evt_C = pEventID;
              if ( pIndex == 3 )
                pNPC->evt_D = pEventID;
              if ( pIndex == 4 )
                pNPC->evt_E = pEventID;
              if ( pIndex == 5 )
                pNPC->evt_F = pEventID;
              if ( pNPC_ID == 8 )
              {
                if ( pEventID == 78 )
                {
                  HouseDialogPressCloseBtn();
window_SpeakInHouse->Release();
pParty->uFlags &= ~2;
                  if ( EnterHouse(HOUSE_DARK_GUILD_PIT) )
                  {
                    pAudioPlayer->StopChannels(-1, -1);
window_SpeakInHouse = new GUIWindow_House(0, 0, window->GetWidth(), window->GetHeight(), 170, 0);
                    window_SpeakInHouse->CreateButton( 61, 424, 31, 0, 2, 94, UIMSG_SelectCharacter, 1, '1',  "", 0);
window_SpeakInHouse->CreateButton(177, 424, 31, 0, 2, 94, UIMSG_SelectCharacter, 2, '2',  "", 0);
window_SpeakInHouse->CreateButton(292, 424, 31, 0, 2, 94, UIMSG_SelectCharacter, 3, '3',  "", 0);
window_SpeakInHouse->CreateButton(407, 424, 31, 0, 2, 94, UIMSG_SelectCharacter, 4, '4',  "", 0);
window_SpeakInHouse->CreateButton(  0,   0,  0, 0, 1,  0, UIMSG_CycleCharacters, 0, '\t', "", 0);
current_npc_text = pNPCTopics[90].pText;
                  }
                }
              }
              ++curr_seq_num;
            }
            break;
      case EVENT_NPCSetItem:
        sub_448518_npc_set_item(EVT_DWORD(_evt->v5),EVT_DWORD(_evt->v9), _evt->v13);
        ++curr_seq_num;
        break;
      case EVENT_SetActorItem:
        Actor::GiveItem(EVT_DWORD(_evt->v5),EVT_DWORD(_evt->v9), _evt->v13);
        ++curr_seq_num;
        break;
      case EVENT_SetNPCGroupNews:
        pNPCStats->pGroups_copy[_evt->v5 + ((_evt->v6 + ((_evt->v7 + ((uint)_evt->v8 << 8)) << 8)) << 8)] = _evt->v9 + ((uint)_evt->v10 << 8);
        ++curr_seq_num;
        break;
      case EVENT_SetActorGroup:
        __debugbreak();
        *(&pActors[0].uGroup + 0x11000000 * _evt->v8 + 209 * (_evt->v5 + ((_evt->v6 + ((uint)_evt->v7 << 8)) << 8))) = _evt->v9 + ((_evt->v10 + ((_evt->v11 + ((uint)_evt->v12 << 8)) << 8)) << 8);
        ++curr_seq_num;
        break;
      case EVENT_ChangeGroup:
        v38 = _evt->v5 + ((_evt->v6 + ((_evt->v7 + ((uint)_evt->v8 << 8)) << 8)) << 8);
        v39 = _evt->v9 + ((_evt->v10 + ((_evt->v11 + ((uint)_evt->v12 << 8)) << 8)) << 8);
        __debugbreak();
        for ( uint actor_id = 0; actor_id<uNumActors; actor_id++ )
        {
          if ( pActors[actor_id].uGroup == v38 )
            pActors[actor_id].uGroup = v39;
        }
        ++curr_seq_num;
        break;
      case EVENT_ChangeGroupAlly:
        v42 = _evt->v5 + ((_evt->v6 + ((_evt->v7 + ((uint)_evt->v8 << 8)) << 8)) << 8);
        v43 = _evt->v9 + ((_evt->v10 + ((_evt->v11 + ((uint)_evt->v12 << 8)) << 8)) << 8);
        __debugbreak();
        for ( uint actor_id = 0; actor_id<uNumActors; actor_id++ )
        {
          if ( pActors[actor_id].uGroup == v42 )
            pActors[actor_id].uAlly = v43;
        }
        ++curr_seq_num;
        break;
      case EVENT_MoveNPC:
        {
        pNPCStats->pNewNPCData[EVT_DWORD(_evt->v5)].Location2D =EVT_DWORD(_evt->v9);
        if ( window_SpeakInHouse )
          {

          if ( window_SpeakInHouse->par1C == 165 )
            {
            HouseDialogPressCloseBtn();
pMediaPlayer->Unload();
window_SpeakInHouse->Release();
pParty->uFlags &= ~2;
            activeLevelDecoration = (LevelDecoration*)1;
            if ( EnterHouse(HOUSE_BODY_GUILD_ERATHIA) )
              {
              pAudioPlayer->PlaySound(SOUND_Invalid, 0, 0, -1, 0, 0, 0, 0);
window_SpeakInHouse = new GUIWindow_House(0, 0, window->GetWidth(), window->GetHeight(), 165, 0);
              v48 = window_SpeakInHouse->pControlsHead;
              if ( window_SpeakInHouse->pControlsHead )
                {
                do
                  {
                  v49 = v48->pNext;
                  free(v48);
v48 = v49;
                  }
                  while ( v49 );
                }
              window_SpeakInHouse->pControlsHead = 0;
              window_SpeakInHouse->pControlsTail = 0;
              window_SpeakInHouse->uNumControls = 0;
              }
            }
          else
            {
            if ( window_SpeakInHouse->par1C == 553 )
              pMediaPlayer->bLoopPlaying = 0;
            }
          }

        }
        ++curr_seq_num;
        break;
      case EVENT_Jmp:
        curr_seq_num = _evt->v5 - 1;
        ++curr_seq_num;
        v4 = -1;

        break;
      case EVENT_ShowFace:
        if ( _evt->v5 <= 3u ) //someone
          pParty->pPlayers[_evt->v5].PlayEmotion((CHARACTER_EXPRESSION_ID)_evt->v6, 0);
        else if ( _evt->v5 == 4 ) //active
          pParty->pPlayers[uActiveCharacter].PlayEmotion((CHARACTER_EXPRESSION_ID)_evt->v6, 0);
        else if ( _evt->v5 == 5 ) //all players
          {
          for(int i = 0; i< 4; ++i)
            pParty->pPlayers[i].PlayEmotion((CHARACTER_EXPRESSION_ID)_evt->v6, 0);
          }
        else  //random player
          pParty->pPlayers[rand() % 4].PlayEmotion((CHARACTER_EXPRESSION_ID)_evt->v6, 0);
          ++curr_seq_num;
          break;
      case EVENT_CharacterAnimation:
        if ( _evt->v5 <= 3 ) //someone
          pParty->pPlayers[_evt->v5].PlaySound((PlayerSpeech) _evt->v6, 0);
        else if ( _evt->v5 == 4 ) //active
          pParty->pPlayers[uActiveCharacter].PlaySound((PlayerSpeech) _evt->v6, 0);
        else if ( _evt->v5 == 5 ) //all
          for(int i = 0; i< 4; ++i)
            pParty->pPlayers[i].PlaySound((PlayerSpeech) _evt->v6, 0);
        else  //random
          pParty->pPlayers[rand() % 4].PlaySound((PlayerSpeech) _evt->v6, 0);
        ++curr_seq_num;
        break;
      case EVENT_ForPartyMember:
        player_choose = _evt->v5;
        ++curr_seq_num;
        break;
      case EVENT_SummonItem:
        SpriteObject::sub_42F7EB_DropItemAt(
            (SPRITE_OBJECT_TYPE)(_evt->v5 + ((_evt->v6 + ((_evt->v7 + ((uint)_evt->v8 << 8)) << 8)) << 8)),
            _evt->v9 + ((_evt->v10 + ((_evt->v11 + ((uint)_evt->v12 << 8)) << 8)) << 8),
            _evt->v13 + ((_evt->v14 + ((_evt->v15 + ((uint)_evt->v16 << 8)) << 8)) << 8),
            _evt->v17 + ((_evt->v18 + ((_evt->v19 + ((uint)_evt->v20 << 8)) << 8)) << 8),
            _evt->v21 + ((_evt->v22 + ((_evt->v23 + ((uint)_evt->v24 << 8)) << 8)) << 8),
            _evt->v25, _evt->v26, 0, 0
        );
        ++curr_seq_num;
        break;
      case EVENT_Compare:
        pValue = EVT_DWORD(_evt->v7);
        if ( player_choose <= 3 )
        {
          if ( pPlayers[player_choose]->CompareVariable((enum VariableType)EVT_WORD(_evt->v5), pValue) )
          {
           // v124 = -1;
            curr_seq_num = _evt->v11 - 1;
          }
        }
        else if ( player_choose == 4 ) //active
        {
          if ( uActiveCharacter )
          {
            if ( pPlayers[uActiveCharacter]->CompareVariable((enum VariableType)EVT_WORD(_evt->v5), pValue) )
            {
             // v124 = -1;
              curr_seq_num = _evt->v11 - 1;
            }
          }
        }
        else  if ( player_choose == 5 )//all
        {
          v130 = 0;
          for(int i = 1; i< 5; ++i)
          {
            if ( pPlayers[i]->CompareVariable((enum VariableType)EVT_WORD(_evt->v5), pValue) )
            {
             // v124 = -1;
              curr_seq_num = _evt->v11 - 1;
              break;
            }
            ++v130;
          }
        }
        else if ( player_choose == 6 ) //random
        {
          if ( pPlayers[rand() % 4 + 1]->CompareVariable((enum VariableType)EVT_WORD(_evt->v5), pValue) )
          {
           // v124 = -1;
            curr_seq_num = _evt->v11 - 1;
          }
        }
        ++curr_seq_num;
        v4 = -1;
        break;
      case EVENT_IsActorAlive:
         if  (IsActorAlive(EVT_BYTE(_evt->v5), EVT_DWORD(_evt->v6), EVT_BYTE(_evt->v10)))
         {
           //v124 = -1;
           curr_seq_num = _evt->v11 - 1;
         }
         ++curr_seq_num;
         v4 = -1;
         break;
      case EVENT_Substract:
        pValue = EVT_DWORD(_evt->v7);*/
        /*if ( EVT_WORD(_evt->v5) == VAR_PlayerItemInHands )
        {
          if ( pParty->pPickedItem.uItemID == pValue )//In hand
          {
            pMouse->RemoveHoldingItem();
            ++curr_seq_num;
            v4 = v124;
            break;
          }
          //v67 = (int)pPlayers[uActiveCharacter]->pInventoryMatrix.data();
          for ( v65 = 0; v65 < 126; ++v65 )
          {
            v67 = &pPlayers[uActiveCharacter]->pInventoryMatrix[v65];
            if ( v67 > 0 )
            {
              if ( pPlayers[uActiveCharacter]->pInventoryItemList[v67 - 1].uItemID == pValue )
              {
                pPlayers[uActiveCharacter]->RemoveItemAtInventoryIndex(v65);
                //++curr_seq_num;
                //v4 = v124;
                goto substract;
              }
            }
            //v67 += 4;
          }
          //while ( (signed int)v65 < 126 );
          //v69 = (int)&pPlayers[uActiveCharacter]->pEquipment.pIndices;
          for ( v68 = 0; v68 < 16; ++v68 )
          {
            if ( pPlayers[uActiveCharacter]->pInventoryItemList[pPlayers[uActiveCharacter]->pEquipment.pIndices[v68]].uItemID == pValue )
            {
              pPlayers[uActiveCharacter]->pEquipment.pIndices[v68] = 0;
              //++curr_seq_num;
              //v4 = v124;
              goto substract;
            }
            //v69 += 4;
          }
          for (int i = 1; i < 5; i++)
          {
            //v72 = (int)pPlayers[i]->pInventoryMatrix.data();
            for ( int v71 = 0; v71 < 126; ++v71 )
            {
              v72 = &pPlayers[i]->pInventoryMatrix[v71];
              if ( v72 > 0 )
              {
                if ( pPlayers[i]->pInventoryItemList[v72 - 1].uItemID == pValue )
                {
                  pPlayers[i]->RemoveItemAtInventoryIndex(v71);
                  goto substract;
                }
              }
              //v72 += 4;
            }
            for ( v73 = 0; v73 < 16; ++v73 )
            {
              //v74 = (int)&pPlayers[i]->pEquipment;
              if (pPlayers[i]->pEquipment.pIndices[v73])
              {
                if (pPlayers[i]->pInventoryItemList[pPlayers[i]->pEquipment.pIndices[v73] - 1].uItemID == pValue )
                {
                  pPlayers[i]->pEquipment.pIndices[v73] = 0;
                  //v74 += 4;
                  goto substract;
                }
              }
            }
          }
        }*/
        /*if ( player_choose <= 3 )
          pParty->pPlayers[player_choose].SubtractVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        else if ( player_choose == 4 ) //active
        {
          if ( uActiveCharacter )
            pPlayers[uActiveCharacter]->SubtractVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        }
        else  if ( player_choose == 5 )//all
        {
          for(int i = 1; i< 5; ++i)
            pPlayers[i]->SubtractVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        }
        else if ( player_choose == 6 ) //random
          pParty->pPlayers[rand() % 4].SubtractVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        ++curr_seq_num;
        break;
      case EVENT_Set:
        pValue = EVT_DWORD(_evt->v7);
        if ( player_choose <= 3 )
          pParty->pPlayers[player_choose].SetVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        else if ( player_choose == 4 ) //active
        {
          if ( uActiveCharacter )
            pPlayers[uActiveCharacter]->SetVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        }
        else if ( player_choose == 5 )//all
        {
          //recheck v130
          for ( int i = 1; i< 5; ++i )
            pPlayers[i]->SetVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        }
        else if ( player_choose == 6 ) //random
          pParty->pPlayers[rand() % 4].SetVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        ++curr_seq_num;
        break;
      case EVENT_Add:
        pValue = EVT_DWORD(_evt->v7);
        if ( player_choose <= 3 )
        {
          pPlayer = &pParty->pPlayers[player_choose];
          pPlayer->AddVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        }
        else if ( player_choose == 4 ) //active
        {
          if ( uActiveCharacter )
            pPlayers[uActiveCharacter]->AddVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        }
        else if ( player_choose == 5 )//all
        {
          for(int i = 1; i< 5; ++i)
            pPlayers[i]->AddVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        }
        else if ( player_choose == 6 ) //random
          pParty->pPlayers[rand() % 4].AddVariable((enum VariableType)EVT_WORD(_evt->v5), pValue);
        v83 = EVT_WORD(_evt->v5);
        if (v83 == 21 ||  // gold well on emerald isle
            v83 == 22 || v83 == 23 || v83 == 24 )
        {
          //__debugbreak(); // bonfire
          viewparams->bRedrawGameUI = true;
        }
        ++curr_seq_num;
        break;
      case EVENT_InputString:
        if ( !entry_line )
        {
          strcpy(GameUI_Footer_TimedString.data(), &pLevelStr[pLevelStrOffsets[EVT_DWORD(_evt->v5)]]);
          sub_4451A8_press_any_key(uEventID, curr_seq_num, 26);
          if ( v133 == 1 )
            OnMapLeave();
          return;
        }
        v84 = _evt->v13 + ((_evt->v14 + ((_evt->v15 + ((uint)_evt->v16 << 8)) << 8)) << 8);
        if ( !_stricmp(GameUI_Footer_TimedString.data(), &pLevelStr[pLevelStrOffsets[_evt->v9 + ((_evt->v10 + ((_evt->v11 + ((uint)_evt->v12 << 8)) << 8)) << 8)]])
          || !_stricmp(GameUI_Footer_TimedString.data(), &pLevelStr[pLevelStrOffsets[v84]]) )
        {
          v11 = _evt->v17;
          curr_seq_num = v11 - 1;
        }
        ++curr_seq_num;
        v4 = -1;
        break;
      case EVENT_RandomGoTo:
        //v124 = -1;
        v11 = (unsigned __int8)*(&_evt->v5 + rand() % ((_evt->v5 != 0) + (_evt->v6 != 0) + (_evt->v7 != 0) + (_evt->v8 != 0) + (_evt->v9 != 0)
          + (_evt->v10 != 0)));
                curr_seq_num = v11 - 1;
                ++curr_seq_num;
                v4 = -1;
                break;
      case EVENT_ReceiveDamage:
        if ( (unsigned __int8)_evt->v5 <= 3 )
        {
          pParty->pPlayers[(unsigned __int8)_evt->v5].ReceiveDamage(EVT_DWORD(_evt->v7 ), (DAMAGE_TYPE)_evt->v6);
          ++curr_seq_num;
          break;
        }
        if ( _evt->v5 == 4 )
        {
          if ( !uActiveCharacter )
          {
            ++curr_seq_num;
            break;
          }
          pPlayers[uActiveCharacter]->ReceiveDamage(EVT_DWORD(_evt->v7 ), (DAMAGE_TYPE)_evt->v6);
          ++curr_seq_num;
          break;
        }
        if ( _evt->v5 != 5 )
        {
          pParty->pPlayers[rand() % 4].ReceiveDamage(EVT_DWORD(_evt->v7 ), (DAMAGE_TYPE)_evt->v6);
          ++curr_seq_num;
          break;
        }
        for ( uint pl_id = 0; pl_id< 4; pl_id++ )
          pParty->pPlayers[pl_id].ReceiveDamage(EVT_DWORD(_evt->v7 ), (DAMAGE_TYPE)_evt->v6);
          ++curr_seq_num;
          break;
      case EVENT_ToggleIndoorLight:
        pIndoor->ToggleLight(EVT_DWORD(_evt->v5 ), _evt->v9);
        ++curr_seq_num;
        break;
      case EVENT_SetFacesBit:
        sub_44892E_set_faces_bit(EVT_DWORD(_evt->v5),EVT_DWORD(_evt->v9), _evt->v13);
        ++curr_seq_num;
        break;
      case EVENT_ToggleChestFlag:
        Chest::ToggleFlag(EVT_DWORD(_evt->v5 ), EVT_DWORD(_evt->v9 ), _evt->v13);
        ++curr_seq_num;
        break;
      case EVENT_ToggleActorFlag:
        Actor::ToggleFlag(EVT_DWORD(_evt->v5 ), EVT_DWORD(_evt->v9 ), _evt->v13);
        ++curr_seq_num;
        break;
      case EVENT_ToggleActorGroupFlag:
        ToggleActorGroupFlag(EVT_DWORD(_evt->v5 ),  EVT_DWORD(_evt->v9 ), _evt->v13);
        ++curr_seq_num;
        break;
      case EVENT_SetSnow:
        if ( !_evt->v5 )
          pWeather->bRenderSnow = _evt->v6 != 0;
        ++curr_seq_num;
        break;
      case EVENT_StatusText:
        v90 = EVT_DWORD(_evt->v5 );
        if ( activeLevelDecoration )
        {
          if ( activeLevelDecoration == (LevelDecoration*)1 )
            current_npc_text = pNPCTopics[v90 - 1].pText;//(&dword_721664)[8 * v90];
          if ( canShowMessages == 1 )
            {
            v91 = pNPCTopics[v90 - 1].pText;//(&dword_721664)[8 * v90];
            //LABEL_248:
            ShowStatusBarString(v91, 2);
            }
        }
        else
        {
          if ( canShowMessages == 1 )
          {
            v91 = &pLevelStr[pLevelStrOffsets[v90]];
            ShowStatusBarString(v91, 2);
          }
        }
        ++curr_seq_num;
        break;
      case EVENT_ShowMessage:
        if ( activeLevelDecoration )
        {
          current_npc_text = pNPCTopics[EVT_DWORD(_evt->v5) - 1].pText;//(&dword_721664)[8 * v92];
          byte_5B0938[0] = 0;
        }
        else
          strcpy(byte_5B0938.data(), &pLevelStr[pLevelStrOffsets[EVT_DWORD(_evt->v5)]]);
        ++curr_seq_num;
        break;
      case EVENT_CastSpell:
              EventCastSpell(_evt->v5, _evt->v6, _evt->v7, EVT_DWORD(_evt->v8 ),
                    EVT_DWORD(_evt->v12 ), EVT_DWORD(_evt->v16 ), EVT_DWORD(_evt->v20 ),
                    EVT_DWORD(_evt->v24 ), EVT_DWORD(_evt->v28 ));
              ++curr_seq_num;
              break;
      case EVENT_SetTexture:
        sub_44861E_set_texture(EVT_DWORD(_evt->v5 ), (char*)&_evt->v9);
        ++curr_seq_num;
        break;
      case EVENT_SetSprite:
        SetDecorationSprite(EVT_DWORD(_evt->v5 ), _evt->v9, (char*)&_evt->v10);
        ++curr_seq_num;
        break;
      case EVENT_SummonMonsters:
        sub_448CF4_spawn_monsters(_evt->v5, _evt->v6, _evt->v7, EVT_DWORD(_evt->v8 ),
                    EVT_DWORD(_evt->v12 ), EVT_DWORD(_evt->v16 ), EVT_DWORD(_evt->v20 ),
                    EVT_DWORD(_evt->v24 ));
        ++curr_seq_num;
        break;
      case EVENT_MouseOver:
      case EVENT_LocationName:
        --curr_seq_num;
        ++curr_seq_num;
        break;
      case EVENT_ChangeDoorState:
        Door_switch_animation(_evt->v5, _evt->v6);
        ++curr_seq_num;
        break;
      case EVENT_OpenChest:
        if ( !Chest::Open(_evt->v5) )
        {
          if ( v133 == 1 )
            OnMapLeave();
          return;
        }
        ++curr_seq_num;
        break;
      case EVENT_MoveToMap:
        v94 = _evt->v5 + ((_evt->v6 + ((_evt->v7 + ((uint)_evt->v8 << 8)) << 8)) << 8);
        v135 = _evt->v5 + ((_evt->v6 + ((_evt->v7 + ((uint)_evt->v8 << 8)) << 8)) << 8);
        v132 = _evt->v9 + ((_evt->v10 + ((_evt->v11 + ((uint)_evt->v12 << 8)) << 8)) << 8);
        v126 = _evt->v13 + ((_evt->v14 + ((_evt->v15 + ((uint)_evt->v16 << 8)) << 8)) << 8);
        v129 = _evt->v17 + ((_evt->v18 + ((_evt->v19 + ((uint)_evt->v20 << 8)) << 8)) << 8);
        v95 = _evt->v21 + ((_evt->v22 + ((_evt->v23 + ((uint)_evt->v24 << 8)) << 8)) << 8);
        v96 = _evt->v25;
        v97 = v96 + ((_evt->v26 + ((_evt->v27 + ((uint)_evt->v28 << 8)) << 8)) << 8);
        v134 = v96 + ((_evt->v26 + ((_evt->v27 + ((uint)_evt->v28 << 8)) << 8)) << 8);
        if ( _evt->v29 || _evt->v30 )
          {
            pRenderer->Sub01();
pDialogueWindow = new GUIWindow_Transition(_evt->v29, _evt->v30, v135, v132, v126, v129, v95, v134, (char*)&_evt->v31);
          dword_5C3418 = uEventID;
          dword_5C341C = curr_seq_num + 1;
          if ( v133 == 1 )
            OnMapLeave();
          return;
          }
        _5B65AC_npcdata_fame_or_other = _evt->v9 + ((_evt->v10 + ((_evt->v11 + ((uint)_evt->v12 << 8)) << 8)) << 8);
        _5B65A8_npcdata_uflags_or_other = v94;
        _5B65B0_npcdata_rep_or_other = v126;
        if ( v129 == -1 )
          v98 = _5B65B4_npcdata_loword_house_or_other;
        else
        {
          v98 = v129 & stru_5C6E00->uDoublePiMask;
          _5B65B4_npcdata_loword_house_or_other = v129 & stru_5C6E00->uDoublePiMask;
        }
        v99 = (char*)&_evt->v31;
        _5B65B8_npcdata_hiword_house_or_other = v95;
        dword_5B65BC = v97;
        v100 = v94 | v132 | v126 | v95 | v97 | v98;
        dword_5B65C0 = v100;
        if ( * v99 == 48 )
          {
          if ( v100 )
            {
            pParty->vPosition.x = v135;
            pParty->vPosition.y = v132;
            pParty->vPosition.z = v126;
            pParty->uFallStartY = v126;
            if ( _5B65B4_npcdata_loword_house_or_other != -1 )
              pParty->sRotationY = _5B65B4_npcdata_loword_house_or_other;
            _5B65B4_npcdata_loword_house_or_other = -1;
            pParty->sRotationX = v95;
            pParty->uFallSpeed = v134;
            dword_5B65C0 = 0;
            dword_5B65BC = 0;
            _5B65B8_npcdata_hiword_house_or_other = 0;
            _5B65B0_npcdata_rep_or_other = 0;
            _5B65AC_npcdata_fame_or_other = 0;
            _5B65A8_npcdata_uflags_or_other = 0;
            v106 = 232;
            pAudioPlayer->PlaySound((SoundID)v106, 0, 0, -1, 0, 0, 0, 0);
            }
          }
        else
          {
          pGameLoadingUI_ProgressBar->uType = (GUIProgressBar::Type)((activeLevelDecoration == NULL) + 1);
          Transition_StopSound_Autosave(v99, MapStartPoint_Party);
v133 = 1;
          if ( current_screen_type == SCREEN_HOUSE )
            {
            if ( uGameState == GAME_STATE_CHANGE_LOCATION )
              {
              pAudioPlayer->StopChannels(-1, -1);
dialog_menu_id = HOUSE_DIALOGUE_NULL;
              while ( HouseDialogPressCloseBtn() )
                ;
              pMediaPlayer->Unload();
window_SpeakInHouse->Release();
window_SpeakInHouse = 0;
              if ( pMessageQueue_50CBD0->uNumMessages )
                pMessageQueue_50CBD0->uNumMessages = pMessageQueue_50CBD0->pMessages[0].field_8 != 0;
              current_screen_type = SCREEN_GAME;
              viewparams->bRedrawGameUI = 1;
              pDialogueNPCCount = 0;
              pDialogueWindow->Release();
dialog_menu_id = HOUSE_DIALOGUE_NULL;
              pDialogueWindow = 0;
              pIcons_LOD->SyncLoadedFilesCount();
              }
            OnMapLeave();
            return;
            }
          }
        ++curr_seq_num;
        break;
      case EVENT_PlaySound:
        v110 = _evt->v13 + ((_evt->v14 + ((_evt->v15 + ((uint)_evt->v16 << 8)) << 8)) << 8);
        v109 = _evt->v9 + ((_evt->v10 + ((_evt->v11 + ((uint)_evt->v12 << 8)) << 8)) << 8);
        v106 = _evt->v5 + ((_evt->v6 + ((_evt->v7 + ((uint)_evt->v8 << 8)) << 8)) << 8);
        pAudioPlayer->PlaySound((SoundID)v106, 0, 0, v109, v110, 0, 0, 0);
        ++curr_seq_num;
        break;
      case EVENT_GiveItem:
        item.Reset();
        v102 = _evt->v7 + ((_evt->v8 + ((_evt->v9 + ((uint)_evt->v10 << 8)) << 8)) << 8);
        pItemsTable->GenerateItem(_evt->v5, _evt->v6, &item);
        if ( v102 )
          item.uItemID = v102;
        pParty->SetHoldingItem(&item);
        ++curr_seq_num;
        break;
      case EVENT_SpeakInHouse:
        if ( EnterHouse((enum HOUSE_ID)EVT_DWORD(_evt->v5)))
          {
            pRenderer->Sub01();
pAudioPlayer->PlaySound(SOUND_Invalid, 0, 0, -1, 0, 0, 0, 0);
pAudioPlayer->PlaySound(SOUND_enter, 814, 0, -1, 0, 0, 0, 0);
v104 = 187;
          if ( uCurrentHouse_Animation != 167 )
            v104 = EVT_DWORD(_evt->v5);
window_SpeakInHouse = new GUIWindow_House(0, 0, window->GetWidth(), window->GetHeight(), v104, 0);
          window_SpeakInHouse->CreateButton( 61, 424, 31, 0, 2, 94, UIMSG_SelectCharacter, 1,  '1', "", 0);
window_SpeakInHouse->CreateButton(177, 424, 31, 0, 2, 94, UIMSG_SelectCharacter, 2,  '2', "", 0);
window_SpeakInHouse->CreateButton(292, 424, 31, 0, 2, 94, UIMSG_SelectCharacter, 3,  '3', "", 0);
window_SpeakInHouse->CreateButton(407, 424, 31, 0, 2, 94, UIMSG_SelectCharacter, 4,  '4', "", 0);
window_SpeakInHouse->CreateButton(  0,   0,  0, 0, 1,  0, UIMSG_CycleCharacters, 0, '\t', "", 0);
          }
        ++curr_seq_num;
        break;
      case EVENT_PressAnyKey:
        sub_4451A8_press_any_key(uEventID, curr_seq_num + 1, 33);
        if ( v133 == 1 )
          OnMapLeave();
        return;
      case EVENT_Exit:
        if ( v133 == 1 )
              OnMapLeave();
        return;
      default:
        ++curr_seq_num;
        break;
        }
      }
    }
    if ( v133 == 1 )
      OnMapLeave();
    return;*/
  }
}
