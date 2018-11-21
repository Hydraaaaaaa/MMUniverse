using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : MonoBehaviour {
    public enum CHEST_FLAGS : int
    {
        CHEST_TRAPPED = 1,
        CHEST_ITEMS_PLACED = 2,
        CHEST_ITEMS_NO_PLACED = 3,
        CHEST_OPENED = 4,
    };
    public enum CHEST_LEVEL : int
    {
        CHEST_LOW = 1,
        CHEST_MIDDLE = 2,
        CHEST_HIGHT = 3,
    };
    //public Texture2D nullTexture;
    public GUISkin skin;
    public CHEST_LEVEL Level;
    //public Color fadeColor;
    public GameObject mouse_select;
    public GameObject party;
    public Texture2D ChestBitmap; //0
    public CHEST_FLAGS uFlags; //2
    //struct ItemGen[] igChestItems = new ItemGen[140]; //4
    public int[] igChestItemsNum = new int[20];
    public List<Items> inventory = new List<Items>();
    private ItemDatebase database;
    public int[] pInventoryIndices = new int[140]; //0x13b4
    public bool Chest_open_flag;
    public int chestBitmapId;
    public bool chest_change_flag = false;
    public bool chest_select_items_flag;

    [Header("Флаги для окна подсказки")]
    private bool actives = false;
    private bool actives_tumbler = false;
    private bool actives2 = false;


    public bool Initialized()
    {
        if (uFlags == CHEST_FLAGS.CHEST_ITEMS_PLACED)
            return true;
        else
            return false;
    }
    public void SetInitialized(bool b)
    {
        if (b)
            uFlags = CHEST_FLAGS.CHEST_ITEMS_PLACED;
        else
            uFlags = CHEST_FLAGS.CHEST_ITEMS_NO_PLACED;
    }
    public bool Trapped()
    {
        if (uFlags == CHEST_FLAGS.CHEST_TRAPPED)
            return true;
        else
            return false;
    }

    public int[] pChestPixelOffsetX = new int[8]{ 42, 18, 18, 42, 42, 42, 18, 42 };
    public int[] pChestPixelOffsetY = new int[8]{ 34, 30, 30, 34, 34, 34, 30, 34 };
    public int[] pChestWidthsByType = new int[8]{ 9, 9, 9, 9, 9, 9, 9, 9 };
    public int[] pChestHeightsByType = new int[8]{ 9, 9, 9, 9, 9, 9, 9, 9 };

    // Use this for initialization
    void Start () {
        database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();
        Chest_open_flag = false;

        database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();

        //for (int i = 0; i < igChestItemsNum.Length; i++)
        //igChestItemsNum[i] = -1;
    }
    RaycastHit hit;
    Ray MyRay;
    Vector3 MyPosition;
    // Update is called once per frame
    void Update()
    {
        if (Chest_open_flag)
            Open();
        if (!mouse_select.GetComponent<MouseSelect>().chest_flag)
            Chest_open_flag = false;
        if (Temp.current_screen == Temp.screen_name.screen_chest)
        {
            OnMouseDrag();
        }
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
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //actives = actives ? false : true;
            actives = true;
            party.GetComponent<ModalWindow>().flag = true;
            //Debug.Log("actives = true");
        }
        else
        {
            actives = false;
            party.GetComponent<ModalWindow>().flag = false;
            //Debug.Log("actives = false");
        }
    }
    //----- (0042041E) --------------------------------------------------------
    public bool Open()
    {
        /*unsigned int pMapID; // eax@8
        int pRandom; // edx@16
        int v6; // eax@16
        ODMFace* pODMFace; // eax@19
        BLVFace* pBLVFace; // eax@20
        int pObjectX; // ebx@21
        int pObjectZ; // edi@21
        double dir_x; // st7@23
        double dir_y; // st6@23
        double length_vector; // st7@23
        int pDepth; // ecx@26
        Vec3_int_ v; // ST4C_12@28
        bool flag_shout; // edi@28
        SPRITE_OBJECT_TYPE pSpriteID[4]; // [sp+84h] [bp-40h]@16
        Vec3_int_ pOut; // [sp+A0h] [bp-24h]@28
        int pObjectY; // [sp+B0h] [bp-14h]@21
        int sRotX; // [sp+B4h] [bp-10h]@23
        float dir_z; // [sp+BCh] [bp-8h]@23
        int sRotY; // [sp+C0h] [bp-4h]@8
        SpriteObject pSpellObject; // [sp+14h] [bp-B0h]@28*/


        if (!Initialized())
            PlaceItems();

        //flag_shout = false;
        /*pMapID = pMapStats->GetMapInfo(pCurrentMapName);
        if (chest->Trapped() && pMapID)
        {
            if (pPlayers[uActiveCharacter]->GetDisarmTrap() < 2 * pMapStats->pInfos[pMapID].LockX5)
            {
                pSpriteID[0] = SPRITE_811;
                pSpriteID[1] = SPRITE_812;
                pSpriteID[2] = SPRITE_813;
                pSpriteID[3] = SPRITE_814;
                pRandom = rand() % 4;
                v6 = PID_ID(EvtTargetObj);
                if (PID_TYPE(EvtTargetObj) == OBJECT_Decoration)
                {
                    pObjectX = pLevelDecorations[v6].vPosition.x;
                    pObjectY = pLevelDecorations[v6].vPosition.y;
                    pObjectZ = pLevelDecorations[v6].vPosition.z + (pDecorationList->pDecorations[pLevelDecorations[v6].uDecorationDescID].uDecorationHeight / 2);
                }
                if (PID_TYPE(EvtTargetObj) == OBJECT_BModel)
                {
                    if (uCurrentlyLoadedLevelType == LEVEL_Outdoor)
                    {
                        pODMFace = &pOutdoor->pBModels[EvtTargetObj >> 9].pFaces[(EvtTargetObj >> 3) & 0x3F];
                        pObjectX = (pODMFace->pBoundingBox.x1 + pODMFace->pBoundingBox.x2) / 2;
                        pObjectY = (pODMFace->pBoundingBox.y1 + pODMFace->pBoundingBox.y2) / 2;
                        pObjectZ = (pODMFace->pBoundingBox.z1 + pODMFace->pBoundingBox.z2) / 2;
                    }
                    else//Indoor
                    {
                        pBLVFace = &pIndoor->pFaces[v6];
                        pObjectX = (pBLVFace->pBounding.x1 + pBLVFace->pBounding.x2) / 2;
                        pObjectY = (pBLVFace->pBounding.y1 + pBLVFace->pBounding.y2) / 2;
                        pObjectZ = (pBLVFace->pBounding.z1 + pBLVFace->pBounding.z2) / 2;
                    }
                }
                dir_x = (double)pParty->vPosition.x - (double)pObjectX;
                dir_y = (double)pParty->vPosition.y - (double)pObjectY;
                dir_z = ((double)pParty->sEyelevel + (double)pParty->vPosition.z) - (double)pObjectZ;
                length_vector = sqrt((dir_x * dir_x) + (dir_y * dir_y) + (dir_z * dir_z));
                if (length_vector <= 1.0)
                {
                    *(float*)&sRotX = 0.0;
                    *(float*)&sRotY = 0.0;
                }
                else
                {
                    sRotY = (signed __int64)sqrt(dir_x * dir_x + dir_y * dir_y);
                    sRotX = stru_5C6E00->Atan2((signed __int64)dir_x, (signed __int64)dir_y);
                    sRotY = stru_5C6E00->Atan2(dir_y * dir_y, (signed __int64)dir_z);
                }
                pDepth = 256;
                if (length_vector < 256.0)
                    pDepth = (signed __int64)length_vector / 4;
                v.x = pObjectX;
                v.y = pObjectY;
                v.z = pObjectZ;
                Vec3_int_::Rotate(pDepth, sRotX, sRotY, v, &pOut.x, &pOut.z, &pOut.y);
                SpriteObject::sub_42F7EB_DropItemAt(pSpriteID[pRandom], pOut.x, pOut.z, pOut.y, 0, 1, 0, 48, 0);

                pSpellObject.containing_item.Reset();
                pSpellObject.spell_skill = 0;
                pSpellObject.spell_level = 0;
                pSpellObject.spell_id = 0;
                pSpellObject.field_54 = 0;
                pSpellObject.uType = pSpriteID[pRandom];
                pSpellObject.uObjectDescID = 0;
                if (pObjectList->uNumObjects)
                {
                    for (uint i = 0; i < (signed int) pObjectList->uNumObjects; ++i )
        {
                        if (pSpriteID[pRandom] == pObjectList->pObjects[i].uObjectID)
                            pSpellObject.uObjectDescID = i;
                    }
                }
                pSpellObject.vPosition.y = pOut.z;
                pSpellObject.vPosition.x = pOut.x;
                pSpellObject.vPosition.z = pOut.y;
                pSpellObject.uSoundID = 0;
                pSpellObject.uAttributes = 48;
                pSpellObject.uSectorID = pIndoor->GetSector(pOut.x, pOut.z, pOut.y);
                pSpellObject.uSpriteFrameID = 0;
                pSpellObject.spell_caster_pid = 0;
                pSpellObject.spell_target_pid = 0;
                pSpellObject.uFacing = 0;
                pSpellObject.Create(0, 0, 0, 0);
                pAudioPlayer->PlaySound(SOUND_fireBall, 0, 0, -1, 0, 0, 0, 0);
                pSpellObject.ExplosionTraps();
                chest->uFlags &= 0xFEu;
                if (uActiveCharacter && !_A750D8_player_speech_timer && !OpenedTelekinesis)
                {
                    _A750D8_player_speech_timer = 256i64;
                    PlayerSpeechID = SPEECH_5;
                    uSpeakingCharacter = uActiveCharacter;
                }
                pIcons_LOD->RemoveTexturesPackFromTextureList();
                OpenedTelekinesis = false;
                return false;
            }
            chest->uFlags &= 0xFEu;
            flag_shout = true;
        }*/
        //pAudioPlayer->StopChannels(-1, -1);
        //pAudioPlayer->PlaySound(SOUND_openchest0101, 0, 0, -1, 0, 0, 0, 0);

        /*if (flag_shout == true)
        {
            if (!OpenedTelekinesis)
                pPlayers[uActiveCharacter]->PlaySound(SPEECH_4, 0);
        }*/
        //OpenedTelekinesis = false;
        //pChestWindow = pGUIWindow_CurrentMenu = new GUIWindow_Chest(uChestID);
        return true;
    }
    //----- (00420284) --------------------------------------------------------
    public void PlaceItems()
    {
        int uChestArea; // edi@1
        int random_chest_pos; // eax@2
        int test_position; // ebx@11
        int[] chest_cells_map = new int[144]; // [sp+Ch] [bp-A0h]@1
        int chest_item_id; // [sp+9Ch] [bp-10h]@10
        int items_counter; // [sp+A4h] [bp-8h]@8

        //pRenderer->ClearZBuffer(0, 479);
        //uChestArea = pChestWidthsByType[pChests[uChestID].uChestBitmapID] * pChestHeightsByType[pChests[uChestID].uChestBitmapID];
        uChestArea = 20;
        if (!chest_select_items_flag)
        {
            //chest_item_id = igChestItems[items_counter].uItemID;
            for (items_counter = 0; items_counter < uChestArea; ++items_counter)
            {
                if (igChestItemsNum[items_counter] == 0)
                {
                    if (Random.Range(0, 4) >= 3)
                    {
                        int num = Random.Range(0, 36);
                        if (Level == CHEST_LEVEL.CHEST_LOW)
                        {
                            switch (num)
                            {
                                case 0:
                                    igChestItemsNum[items_counter] = Random.Range(1, 3);
                                    break;
                                case 1:
                                    igChestItemsNum[items_counter] = Random.Range(9, 11);
                                    break;
                                case 2:
                                    igChestItemsNum[items_counter] = Random.Range(15, 17);
                                    break;
                                case 3:
                                    igChestItemsNum[items_counter] = Random.Range(23, 25);
                                    break;
                                case 4:
                                    igChestItemsNum[items_counter] = Random.Range(31, 33);
                                    break;
                                case 5:
                                    igChestItemsNum[items_counter] = Random.Range(42, 44);
                                    break;
                                case 6:
                                    igChestItemsNum[items_counter] = Random.Range(50, 52);
                                    break;
                                case 7:
                                    igChestItemsNum[items_counter] = 58;
                                    break;
                                case 8:
                                    igChestItemsNum[items_counter] = 61;
                                    break;
                                case 9:
                                    igChestItemsNum[items_counter] = Random.Range(66, 67);
                                    break;
                                case 10:
                                    igChestItemsNum[items_counter] = Random.Range(71, 72);
                                    break;
                                case 11:
                                    igChestItemsNum[items_counter] = 76;
                                    break;
                                case 12:
                                    igChestItemsNum[items_counter] = Random.Range(79, 80);
                                    break;
                                case 13:
                                    igChestItemsNum[items_counter] = Random.Range(89, 90);
                                    break;
                                case 14:
                                    igChestItemsNum[items_counter] = Random.Range(100, 102);
                                    break;
                                case 15:
                                    igChestItemsNum[items_counter] = Random.Range(105, 106);
                                    break;
                                case 16:
                                    igChestItemsNum[items_counter] = Random.Range(110, 111);
                                    break;
                                case 17:
                                    igChestItemsNum[items_counter] = Random.Range(115, 116);
                                    break;
                                case 18:
                                    igChestItemsNum[items_counter] = Random.Range(120, 121);
                                    break;
                                case 19:
                                    igChestItemsNum[items_counter] = Random.Range(130, 131);
                                    break;
                                case 20:
                                    igChestItemsNum[items_counter] = 135;
                                    break;
                                case 21:
                                    igChestItemsNum[items_counter] = Random.Range(140, 144);
                                    break;
                                case 22:
                                    igChestItemsNum[items_counter] = 156;
                                    break;
                                case 23:
                                    igChestItemsNum[items_counter] = Random.Range(160, 162);
                                    break;
                                case 24:
                                    igChestItemsNum[items_counter] = 164;
                                    break;
                                case 25:
                                    igChestItemsNum[items_counter] = Random.Range(166, 168);
                                    break;
                                case 26:
                                    igChestItemsNum[items_counter] = 181;
                                    break;
                                case 27:
                                    igChestItemsNum[items_counter] = 187;
                                    break;
                                case 28:
                                    igChestItemsNum[items_counter] = 190;
                                    break;
                                case 29:
                                    igChestItemsNum[items_counter] = 36;
                                    break;
                                case 30:
                                    igChestItemsNum[items_counter] = 39;
                                    break;
                                case 31:
                                    igChestItemsNum[items_counter] = 47;
                                    break;
                                case 32:
                                    igChestItemsNum[items_counter] = 84;
                                    break;
                                case 33:
                                    igChestItemsNum[items_counter] = 94;
                                    break;
                                case 34:
                                    igChestItemsNum[items_counter] = 97;
                                    break;
                                case 35:
                                    igChestItemsNum[items_counter] = 148;
                                    break;
                                case 36:
                                    igChestItemsNum[items_counter] = 152;
                                    break;
                            }
                        }
                        if (Level == CHEST_LEVEL.CHEST_MIDDLE)
                        {
                            switch (num)
                            {
                                case 0:
                                    igChestItemsNum[items_counter] = Random.Range(4, 6);
                                    break;
                                case 1:
                                    igChestItemsNum[items_counter] = Random.Range(12, 13);
                                    break;
                                case 2:
                                    igChestItemsNum[items_counter] = Random.Range(18, 20);
                                    break;
                                case 3:
                                    igChestItemsNum[items_counter] = Random.Range(26, 28);
                                    break;
                                case 4:
                                    igChestItemsNum[items_counter] = 34;
                                    break;
                                case 5:
                                    igChestItemsNum[items_counter] = 45;
                                    break;
                                case 6:
                                    igChestItemsNum[items_counter] = Random.Range(53, 55);
                                    break;
                                case 7:
                                    igChestItemsNum[items_counter] = 59;
                                    break;
                                case 8:
                                    igChestItemsNum[items_counter] = 62;
                                    break;
                                case 9:
                                    igChestItemsNum[items_counter] = 69;
                                    break;
                                case 10:
                                    igChestItemsNum[items_counter] = Random.Range(73, 74);
                                    break;
                                case 11:
                                    igChestItemsNum[items_counter] = 77;
                                    break;
                                case 12:
                                    igChestItemsNum[items_counter] = Random.Range(81, 82);
                                    break;
                                case 13:
                                    igChestItemsNum[items_counter] = 91;
                                    break;
                                case 14:
                                    igChestItemsNum[items_counter] = 103;
                                    break;
                                case 15:
                                    igChestItemsNum[items_counter] = Random.Range(107, 108);
                                    break;
                                case 16:
                                    igChestItemsNum[items_counter] = Random.Range(112, 113);
                                    break;
                                case 17:
                                    igChestItemsNum[items_counter] = Random.Range(117, 118);
                                    break;
                                case 18:
                                    igChestItemsNum[items_counter] = Random.Range(122, 124);
                                    break;
                                case 19:
                                    igChestItemsNum[items_counter] = Random.Range(132, 133);
                                    break;
                                case 20:
                                    igChestItemsNum[items_counter] = Random.Range(136, 137);
                                    break;
                                case 21:
                                    igChestItemsNum[items_counter] = Random.Range(145, 146);
                                    break;
                                case 22:
                                    igChestItemsNum[items_counter] = Random.Range(157, 158);
                                    break;
                                case 23:
                                    igChestItemsNum[items_counter] = 163;
                                    break;
                                case 24:
                                    igChestItemsNum[items_counter] = 164;
                                    break;
                                case 25:
                                    igChestItemsNum[items_counter] = Random.Range(169, 180);
                                    break;
                                case 26:
                                    igChestItemsNum[items_counter] = 181;
                                    break;
                                case 27:
                                    igChestItemsNum[items_counter] = 188;
                                    break;
                                case 28:
                                    igChestItemsNum[items_counter] = 191;
                                    break;
                                case 29:
                                    igChestItemsNum[items_counter] = 37;
                                    break;
                                case 30:
                                    igChestItemsNum[items_counter] = 40;
                                    break;
                                case 31:
                                    igChestItemsNum[items_counter] = 48;
                                    break;
                                case 32:
                                    igChestItemsNum[items_counter] = 85;
                                    break;
                                case 33:
                                    igChestItemsNum[items_counter] = 95;
                                    break;
                                case 34:
                                    igChestItemsNum[items_counter] = 98;
                                    break;
                                case 35:
                                    igChestItemsNum[items_counter] = Random.Range(149, 150);
                                    break;
                                case 36:
                                    igChestItemsNum[items_counter] = Random.Range(153, 154);
                                    break;
                            }
                        }
                        if (Level == CHEST_LEVEL.CHEST_HIGHT)
                        {
                            switch (num)
                            {
                                case 0:
                                    igChestItemsNum[items_counter] = Random.Range(7, 8);
                                    break;
                                case 1:
                                    igChestItemsNum[items_counter] = 14;
                                    break;
                                case 2:
                                    igChestItemsNum[items_counter] = Random.Range(21, 22);
                                    break;
                                case 3:
                                    igChestItemsNum[items_counter] = Random.Range(29, 30);
                                    break;
                                case 4:
                                    igChestItemsNum[items_counter] = 35;
                                    break;
                                case 5:
                                    igChestItemsNum[items_counter] = 46;
                                    break;
                                case 6:
                                    igChestItemsNum[items_counter] = Random.Range(56, 57);
                                    break;
                                case 7:
                                    igChestItemsNum[items_counter] = 60;
                                    break;
                                case 8:
                                    igChestItemsNum[items_counter] = 63;
                                    break;
                                case 9:
                                    igChestItemsNum[items_counter] = 70;
                                    break;
                                case 10:
                                    igChestItemsNum[items_counter] = 75;
                                    break;
                                case 11:
                                    igChestItemsNum[items_counter] = 78;
                                    break;
                                case 12:
                                    igChestItemsNum[items_counter] = 83;
                                    break;
                                case 13:
                                    igChestItemsNum[items_counter] = Random.Range(92, 93);
                                    break;
                                case 14:
                                    igChestItemsNum[items_counter] = 104;
                                    break;
                                case 15:
                                    igChestItemsNum[items_counter] = 109;
                                    break;
                                case 16:
                                    igChestItemsNum[items_counter] = 114;
                                    break;
                                case 17:
                                    igChestItemsNum[items_counter] = 119;
                                    break;
                                case 18:
                                    igChestItemsNum[items_counter] = Random.Range(125, 129);
                                    break;
                                case 19:
                                    igChestItemsNum[items_counter] = 134;
                                    break;
                                case 20:
                                    igChestItemsNum[items_counter] = 139;
                                    break;
                                case 21:
                                    igChestItemsNum[items_counter] = 147;
                                    break;
                                case 22:
                                    igChestItemsNum[items_counter] = 159;
                                    break;
                                case 23:
                                    igChestItemsNum[items_counter] = 165;
                                    break;
                                case 24:
                                    igChestItemsNum[items_counter] = 164;
                                    break;
                                case 25:
                                    igChestItemsNum[items_counter] = Random.Range(169, 180);
                                    break;
                                case 26:
                                    igChestItemsNum[items_counter] = 181;
                                    break;
                                case 27:
                                    igChestItemsNum[items_counter] = 189;
                                    break;
                                case 28:
                                    igChestItemsNum[items_counter] = Random.Range(192, 194);
                                    break;
                                case 29:
                                    igChestItemsNum[items_counter] = 38;
                                    break;
                                case 30:
                                    igChestItemsNum[items_counter] = 41;
                                    break;
                                case 31:
                                    igChestItemsNum[items_counter] = 49;
                                    break;
                                case 32:
                                    igChestItemsNum[items_counter] = Random.Range(86, 88);
                                    break;
                                case 33:
                                    igChestItemsNum[items_counter] = 96;
                                    break;
                                case 34:
                                    igChestItemsNum[items_counter] = 99;
                                    break;
                                case 35:
                                    igChestItemsNum[items_counter] = 151;
                                    break;
                                case 36:
                                    igChestItemsNum[items_counter] = 155;
                                    break;
                            }
                        }
                        igChestItemsNum[items_counter] = igChestItemsNum[items_counter] - 1;
                    }
                }
            }
        }
            //memset(chest_cells_map, 0, 144);
            //fill cell map at random positions
        for (items_counter = 0; items_counter < uChestArea; ++items_counter)
        {
            //get random position in chest
            do
                random_chest_pos = Random.Range(0, uChestArea-1);
            while (random_chest_pos >= uChestArea) ;
            //if this pos occupied move to next
            while (chest_cells_map[random_chest_pos] > 0)
            {
                ++random_chest_pos;
                if (random_chest_pos == uChestArea)
                    random_chest_pos = 0;
            }
            chest_cells_map[random_chest_pos] = items_counter;
        }
        items_counter = 0;

        for (items_counter = 0; items_counter < uChestArea; ++items_counter)
        {
            //chest_item_id = igChestItems[items_counter].uItemID;
            chest_item_id = igChestItemsNum[items_counter];
            
            //pTexture = database.items[Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID].itemTexture;
            if (chest_item_id > 0)
            {
                //test_position = 0;
                /*while (!CanPlaceItemAt(chest_cells_map[test_position], chest_item_id) )
                {
                    ++test_position;
                    if (test_position >= uChestArea)
                        break;
                }
                if (test_position < uChestArea)
                {
                    PlaceItemAt(chest_cells_map[test_position], chest_item_id); //items_counter
                    //if (uFlags == CHEST_FLAGS.CHEST_OPENED)
                    //igChestItemsNum[items_counter].SetIdentified();
                }*/
                for (test_position = 0; test_position < uChestArea; ++test_position)
                {
                    if (CanPlaceItemAt(chest_cells_map[test_position], chest_item_id))
                    {
                        PlaceItemAt(chest_cells_map[test_position], chest_item_id); //items_counter
                        break;
                    }
                }
            }
        }
        SetInitialized(true);
      }
    //----- (0041FE71) --------------------------------------------------------
     public bool CanPlaceItemAt(int test_cell_position, int item_id)
    {
        //    int v3; // eax@1
        //int item_texture_id; // eax@1
        Texture2D item_texture; // ecx@1
        int v6; // eax@1
                       //    signed int v7; // edi@3
        int v8; // eax@3
        int texture_cell_width; // edi@3
        int texture_cell_height; // ebx@5
        int _row; // esi@9
        int _cell_rows; // edx@10
        int _column; // ecx@11
                     //    char *v14; // eax@12
        int chest_cell_heght; // [sp+Ch] [bp-Ch]@1
                              //    signed int v17; // [sp+10h] [bp-8h]@1
        int chest_cell_width; // [sp+14h] [bp-4h]@1

        chest_cell_heght = 9;// pChestHeightsByType[uChestBitmapID];
        chest_cell_width = 9;// pChestWidthsByType[uChestBitmapID];
        //item_texture_id = pIcons_LOD->LoadTexture(pItemsTable->pItems[item_id].pIconName, TEXTURE_16BIT_PALETTE);
        //item_texture = pIcons_LOD->GetTexture(item_texture_id);

        item_texture = database.items[item_id].itemTexture;
        v6 = item_texture.width;
        if (v6 < 14)
            v6 = 14;
        texture_cell_width = ((v6 - 14) >> 5) + 1;
        v8 = item_texture.height;
        if (v8 < 14)
            v8 = 14;
        texture_cell_height = ((v8 - 14) >> 5) + 1;
        /*if (!areWeLoadingTexture)
        {
            item_texture->Release();
            pIcons_LOD->SyncLoadedFilesCount();
        }*/
        if ((texture_cell_width + test_cell_position % chest_cell_width <= chest_cell_width) &&
            (texture_cell_height + test_cell_position / chest_cell_width <= chest_cell_heght))
        { //we not put over borders
          //_row = 0;
          //if ( texture_cell_height <= 0 )
          //return true;
            _cell_rows = 0;
            //while ( 1 )
            for (_row = 0; _row < texture_cell_height; ++_row)
            {
                //_column = 0;
                //if ( texture_cell_width > 0 )
                //{
                /*
            while ( pChests[uChestID].pInventoryIndices[test_cell_position + _cell_rows+_column]==0)
                {
                ++_column;
                if ( _column >= texture_cell_width )
                    break;
                }
                */
                for (_column = 0; _column < texture_cell_width; ++_column)
                {
                    if (pInventoryIndices[test_cell_position + _cell_rows + _column] != 0)
                        return false;
                }
                //if (pChests[uChestID].pInventoryIndices[test_cell_position + _cell_rows+_column]!=0)
                //return false;
                //}
                _cell_rows += chest_cell_width;
                //++_row;
                //if ( _row >= texture_cell_height )
                //return true;
            }
            return true;
        }
        return false;
    }
    //----- (0042013E) --------------------------------------------------------
    public void PlaceItemAt(int put_cell_pos, int item_at_cell)
    {
            Texture2D texture; // ecx@5
            int v9; // eax@5
            int v10; // edi@7
            int texture_cell_width; // ebx@7
            int textute_cell_height; // edi@9
            int chest_cell_row_pos; // edx@12
            int chest_cell_width; // [sp+10h] [bp-Ch]@11

        //uItemID = pChests[uChestID].igChestItems[item_at_cell].uItemID;
        //pItemsTable->SetSpecialBonus(&pChests[uChestID].igChestItems[item_at_cell]);
        /*if (uItemID >= 135 && uItemID <= 159 && !pChests[uChestID].igChestItems[item_at_cell].uNumCharges)
        {
            v6 = rand() % 21 + 10;
            pChests[uChestID].igChestItems[item_at_cell].uNumCharges = v6;
            pChests[uChestID].igChestItems[item_at_cell].uMaxCharges = v6;
        }*/
        //v7 = pIcons_LOD->LoadTexture(pItemsTable->pItems[uItemID].pIconName, TEXTURE_16BIT_PALETTE);
        //texture = pIcons_LOD->GetTexture(v7);
        texture = database.items[item_at_cell].itemTexture;
        v9 = texture.width;
            if (texture.width < 14)
                v9 = 14;
            texture_cell_width = ((v9 - 14) >> 5) + 1;
            v10 = texture.height;
            if (texture.height < 14)
                v10 = 14;
            textute_cell_height = ((v10 - 14) >> 5) + 1;
            /*if (!areWeLoadingTexture)
            {
                texture->Release();
                pIcons_LOD->SyncLoadedFilesCount();
            }*/
        chest_cell_width = 9;// pChestWidthsByType[pChests[uChestID].uChestBitmapID];
            chest_cell_row_pos = 0;
            for (int i = 0; i < textute_cell_height; ++i)
            {
                for (int j = 0; j < texture_cell_width; ++j)
                    pInventoryIndices[put_cell_pos + chest_cell_row_pos + j] = -(put_cell_pos + 1);
            chest_cell_row_pos += chest_cell_width;
        }
        pInventoryIndices[put_cell_pos] = item_at_cell + 1;
    }
    void OnGUI() {
        uint uCellX; // [sp+30h] [bp-8h]@5
        uint uCellY; // [sp+34h] [bp-4h]@5
        int chest_offs_y;
        int chest_offs_x;
        int itemPixelWidth; // ecx@4
        int itemPixelHeght; // edx@4
        int itemPixelPosX; // ST34_4@8
        int itemPixelPosY; // edi@8

        Texture2D pTexture = null;
        if (Chest_open_flag && Temp.current_screen != Temp.screen_name.screen_inventory) {
            //fadeColor.a = 0.8f;
            //GUI.color = fadeColor;
            //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), nullTexture, ScaleMode.StretchToFill, true);


            GUI.color = Color.white;
            GUI.DrawTexture(new Rect((Screen.width / 2) - ChestBitmap.width/2, (Screen.height / 2) - ChestBitmap.height / 2, ChestBitmap.width, ChestBitmap.height), ChestBitmap);
            Time.timeScale = 0;
            int uChestArea = 81;
            chest_offs_x = pChestPixelOffsetX[chestBitmapId];
            chest_offs_y = pChestPixelOffsetY[chestBitmapId];
            //memset(chest_cells_map, 0, 144);
            //fill cell map at random positions
            GUI.skin = skin;
            for (uint i = 0; i < uChestArea; ++i)
            {
                uCellY = 32 * (i / 14);
                uCellX = 32 * (i % 14) + 7;

                if (pInventoryIndices[i] == 0)
                //continue;
                {
                    itemPixelWidth = 32;
                    itemPixelHeght = 32;
                    if (itemPixelWidth < 14)
                        itemPixelWidth = 14;
                    itemPixelPosX = (int)(chest_offs_x + 32 * (i % 9) + ((int)(((itemPixelWidth - 14) & 0xFFFFFFE0) + 32 - itemPixelWidth) / 2));
                    itemPixelPosY = (int)(chest_offs_y + 32 * (i / 9) + ((int)(((itemPixelHeght - 14) & 0xFFFFFFE0) + 32 - itemPixelHeght) / 2));

                    if (GUI.Button(new Rect((Screen.width / 2 - 230) + itemPixelPosX, (Screen.height / 2 - 179) + itemPixelPosY, 32, 32), pTexture))
                    {
                        if (party.GetComponent<Party>().TakenItemTexture != null)
                        {
                            chest_change_flag = true;
                            //int temp_id = pInventoryIndices[i];
                            //Texture2D temp_texture = pTexture;
                            if (AddItemInChest((int)i, (int)party.GetComponent<Party>().TakenItemID-1))
                            {
                                //Player.InventoryItemList[i].ItemID = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemTexture = null;// temp_texture;
                                party.GetComponent<Party>().TakenItemID = 0;// (uint)temp_id;
                            }
                            else
                            {
                                //beep
                            }
                        }
                    }
                }
                   if (pInventoryIndices[i] > 0) {
                     pTexture = database.items[pInventoryIndices[i]-1].itemTexture;//pIcons_LOD->GetTexture(item_texture_id);
                    itemPixelWidth = pTexture.width;
                    itemPixelHeght = pTexture.height;
                    if (itemPixelWidth < 14)
                        itemPixelWidth = 14;
                    itemPixelPosX = (int)(chest_offs_x + 32 * (i % 9) + ((int)(((itemPixelWidth - 14) & 0xFFFFFFE0) + 32 - itemPixelWidth) / 2));
                    itemPixelPosY = (int)(chest_offs_y + 32 * (i / 9) + ((int)(((itemPixelHeght - 14) & 0xFFFFFFE0) + 32 - itemPixelHeght) / 2));

                    if (GUI.RepeatButton(new Rect((Screen.width / 2 - 230) + itemPixelPosX, (Screen.height / 2 - 179) + itemPixelPosY, pTexture.width, pTexture.height), pTexture))
                    {
                        if (actives2)
                        {
                            if (pInventoryIndices[i] == 187)
                            {
                                party.GetComponent<Party>().NumGold += Random.Range(10, 50);
                                //pInventoryIndices[i] = 0;
                                DeleteItemArChestIndex(pInventoryIndices[i], (int)i);
                            }
                            else if (pInventoryIndices[i] == 188)
                            {
                                party.GetComponent<Party>().NumGold += Random.Range(50, 200);
                                //pInventoryIndices[i] = 0;
                                DeleteItemArChestIndex(pInventoryIndices[i], (int)i);
                            }
                            else if (pInventoryIndices[i] == 189)
                            {
                                party.GetComponent<Party>().NumGold += Random.Range(200, 500);
                                //pInventoryIndices[i] = 0;
                                DeleteItemArChestIndex(pInventoryIndices[i], (int)i);
                            }
                            else {
                                party.GetComponent<Party>().TakenItemTexture = pTexture;
                                party.GetComponent<Party>().TakenItemID = (uint)pInventoryIndices[i];
                                //pInventoryIndices[i] = 0;
                                DeleteItemArChestIndex(pInventoryIndices[i], (int)i);

                                /*else
                                {
                                    party.GetComponent<Party>().TakenItemTexture = pTexture;
                                    party.GetComponent<Party>().TakenItemID = (uint)Player.InventoryItemList[i].ItemID;
                                    //Player.InventoryMatrix[i] = 0;
                                    DeleteItemArInventoryIndex(Player, (int)party.GetComponent<Party>().TakenItemID, (int)i);
                                    Player.InventoryItemList[i].ItemID = -1;
                                }*/

                            }
                        }
                        /*if (Input.GetMouseButtonDown(0))
                        {
                            Vector3 MousePos = Input.mousePosition;
                            //pInventoryIndices[i] = 0;
                            Debug.Log(MousePos);
                        }
                        if (Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            Debug.Log(database.items[pInventoryIndices[i]].pDescription);
                        }*/
                    }
                    if (actives)
                    {
                        //Debug.Log("описание");
                        //string texts = Temp.GlobalText[412];
                        party.GetComponent<ModalWindow>().x = uCellX;
                        party.GetComponent<ModalWindow>().y = uCellY;
                        party.GetComponent<ModalWindow>().text = database.items[pInventoryIndices[i] - 1].pDescription;
                        party.GetComponent<ModalWindow>().price = database.items[pInventoryIndices[i] - 1].uValue;
                        party.GetComponent<ModalWindow>().Topic = database.items[pInventoryIndices[i] - 1].pName;
                        party.GetComponent<ModalWindow>().Item_type = database.items[pInventoryIndices[i] - 1].pUnidentifiedName;
                        party.GetComponent<ModalWindow>().Item_texture = database.items[pInventoryIndices[i] - 1].itemTexture;
                        party.GetComponent<ModalWindow>().curlegth = 40;
                        party.GetComponent<ModalWindow>().flag = true;
                        actives_tumbler = true;
                        //Debug.Log("actives_tumbler = true");
                    }
                }
                pTexture = null;
                // GUI.DrawTexture(new Rect((Screen.width / 2 - 230) + uCellX, (Screen.height / 2 - 179) + uCellY, pTexture.width, pTexture.height), pTexture);
            }
            }

    }
    public bool AddItemInChest(int position, int chest_item_id)
    {
        if (CanPlaceItemAt(position, chest_item_id))
        {
            PlaceItemAt(position, chest_item_id); //items_counter
            return true;
        }
        return false;
    }
    public void DeleteItemArChestIndex(int ItemID, int index)   //originally accepted ItemGen* but needed only its uItemID
    {
        Texture2D texture; // ecx@5
        int v9; // eax@5
        int v10; // edi@7
        int texture_cell_width; // ebx@7
        int textute_cell_height; // edi@9
        int chest_cell_row_pos; // edx@12
        int chest_cell_width; // [sp+10h] [bp-Ch]@11

        texture = database.items[ItemID].itemTexture;
        v9 = texture.width;
        if (texture.width < 14)
            v9 = 14;
        texture_cell_width = ((v9 - 14) >> 5) + 1;
        v10 = texture.height;
        if (texture.height < 14)
            v10 = 14;
        textute_cell_height = ((v10 - 14) >> 5) + 1;

        chest_cell_width = 9;// pChestWidthsByType[pChests[uChestID].uChestBitmapID];
        chest_cell_row_pos = 0;
        for (int i = 0; i < textute_cell_height; ++i)
        {
            for (int j = 0; j < texture_cell_width; ++j)
                pInventoryIndices[index + chest_cell_row_pos + j] = 0;
            chest_cell_row_pos += chest_cell_width;
        }
        pInventoryIndices[index] = 0;
    }
}
