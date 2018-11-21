using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Inventory_info : MonoBehaviour {

    public GUISkin skin;
    private ItemDatebase database;
    private uint INVETORYSLOTSWIDTH = 14;
    private uint INVETORYSLOTSHEIGHT = 9;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Temp.current_inventory_window == 3 && GameObject.Find("Stats_window").GetComponent<Image>().enabled == true)
        {
            //if (Temp.current_screen == Temp.screen_name.screen_game)
            //  current_character = GetCurrentCharacter(this.gameObject.name);
            GUI.skin = skin;
            Temp.current_screen = Temp.screen_name.screen_inventory;
            CharacterUI_InventoryTab_Draw();
        }
	
	}
    //----- (0041A2D1) --------------------------------------------------------
    public void CharacterUI_InventoryTab_Draw()
    {
        //Texture *pTexture; // esi@6
        Texture2D pTexture;
        //uint v17; // edi@15
        uint uCellX; // [sp+30h] [bp-8h]@5
        uint uCellY; // [sp+34h] [bp-4h]@5

        string ip_string = "";
        switch (Temp.ActiveCharacter)
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
        //pRenderer->DrawTextureIndexed(8, 8, pIcons_LOD->GetTexture(uTextureID_CharacterUI_InventoryBackground));
        //if (a2)
        //pRenderer->DrawTextureIndexed(8, 305, pIcons_LOD->LoadTexturePtr("fr_strip", TEXTURE_16BIT_PALETTE));
        for (uint i = 0; i < 126; ++i)
        {
            if (Player.InventoryMatrix[i] <= 0)
                continue;
            if (Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID == 0)
                continue;
            uCellY = 32 * (i / 14) + 17;
            uCellX = 32 * (i % 14) + 14;
            //uint item_texture_id = pIcons_LOD->LoadTexture(player->pInventoryItemList[player->pInventoryMatrix[i] - 1].GetIconName(), TEXTURE_16BIT_PALETTE);
            database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();
            pTexture = database.items[Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID].itemTexture;//pIcons_LOD->GetTexture(item_texture_id);
            //if (pTexture.width < 14)
            // pTexture.width = 14;
            //if ( (pTexture.width - 14) / 32 == 0 && pTexture.width < 32)
            //uCellX += (32 - (uint)pTexture.width) / 2;
            //v13 = pTexture->uTextureWidth - 14;
            //LOBYTE(v13) = v13 & 0xE0;
            //v15 = v13 + 32;
            //if (pTexture.height < 14 )
            // pTexture.height = 14;

            GUI.DrawTexture(new Rect((Screen.width / 2 - 230) + uCellX/*(uCellX - 35)*/, (Screen.height / 2 - 179) + uCellY, pTexture.width, pTexture.height), pTexture);

            /*v17 = uCellX + (( (int)((pTexture.width - 14) & 0xE0) + 32 - pTexture.width) / 2)
               + pSRZBufferLineOffsets[uCellY + (( (int)((pTexture.height - 14) & 0xFFFFFFE0) - pTexture.height + 32) / 2)];   //added typecast. without it the value in the brackets got cat to unsigned which messed stuff up
            if (Player.InventoryItemList[Player.InventoryMatrix[i] - 1].Attributes == (int)Items.ITEM_FLAGS.ITEM_ENCHANT_ANIMATION)
            {
              Texture2D loadedTextureptr = null;
              switch (Player.InventoryItemList[Player.InventoryMatrix[i] - 1].Attributes == (int)Items.ITEM_FLAGS.ITEM_ENCHANT_ANIMATION)
              {
                case ITEM_AURA_EFFECT_RED:    loadedTextureptr = pIcons_LOD->LoadTexturePtr("sptext01", TEXTURE_16BIT_PALETTE); break;
                case ITEM_AURA_EFFECT_BLUE:   loadedTextureptr = pIcons_LOD->LoadTexturePtr("sp28a", TEXTURE_16BIT_PALETTE);    break;
                case ITEM_AURA_EFFECT_GREEN:  loadedTextureptr = pIcons_LOD->LoadTexturePtr("sp30a", TEXTURE_16BIT_PALETTE);    break;
                case ITEM_AURA_EFFECT_PURPLE: loadedTextureptr = pIcons_LOD->LoadTexturePtr("sp91a", TEXTURE_16BIT_PALETTE);    break;
              }
              _50C9A8_item_enchantment_timer -= pEventTimer->uTimeElapsed;
              if (_50C9A8_item_enchantment_timer <= 0)
              {
                _50C9A8_item_enchantment_timer = 0;
                LOBYTE(Player.InventoryItemList[Player.InventoryMatrix[i] - 1].Attributes) &= 0xF;
                ptr_50C9A4_ItemToEnchant = nullptr;
              }

              pRenderer->DrawAura(uCellX, uCellY, pTexture, loadedTextureptr, GetTickCount() * 0.1, 0, 255);
              ZBuffer_Fill(&pRenderer->pActiveZBuffer[v17], item_texture_id, Player.InventoryMatrix[i]);
            }
            else
            {
              if (Player.InventoryItemList[Player.InventoryMatrix[i] - 1].IsIdentified() || current_screen_type != SCREEN_HOUSE)
              {
                if (Player.InventoryItemList[Player.InventoryMatrix[i] - 1].IsBroken())
                  pRenderer->DrawTransparentRedShade(uCellX, uCellY, pTexture);
                else
                  pRenderer->DrawTextureIndexedAlpha(uCellX, uCellY, pTexture);
              }
              else
                pRenderer->DrawTransparentGreenShade(uCellX, uCellY, pTexture);
              ZBuffer_Fill(&pRenderer->pActiveZBuffer[v17], item_texture_id, Player.InventoryMatrix[i]);
              continue;
            }*/
        }
    }

    //----- (004927A8) --------------------------------------------------------
    public int AddItem(int ip, int index, uint uItemID)
    {
        if (index == -1)
        {
            for (int xcoord = 0; xcoord < INVETORYSLOTSWIDTH; xcoord++)
            {
                for (int ycoord = 0; ycoord < INVETORYSLOTSHEIGHT; ycoord++)
                {
                    if (CanFitItem(ip, (int)(ycoord * INVETORYSLOTSWIDTH + xcoord), (int)uItemID))
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
            return 0;
        }
        return CreateItemInInventory(ip, (uint)index, uItemID);
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
        if (freeSlot == -1)
        {
            //if ( uActiveCharacter )
            //pPlayers[uActiveCharacter]->PlaySound(SPEECH_NoRoom, 0);
            return 0;
        }
        else
        {
            PutItemArInventoryIndex(Player, (int)uItemID, freeSlot, (int)uSlot);
            result = freeSlot + 1;
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
                    Player.InventoryMatrix[pInvPos] = -1 - index;
                pInvPos += INVETORYSLOTSWIDTH;
            }
        }
        Player.InventoryMatrix[index] = uItemID; // itemListPos;// +1;
    }

    //----- (0041A2C1) --------------------------------------------------------
    public uint GetSizeInInventorySlots(uint uNumPixels)
    {
        if ((int)uNumPixels < 14)
            uNumPixels = 14;
        return (uint)((int)(uNumPixels - 14) >> 5) + 1;
    }

    //----- (004925E6) --------------------------------------------------------
    public int FindFreeInventoryListSlot(PlayerStats Player)
    {
        for (int i = 0; i < 126; i++)
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
        if ((slotWidth + uSlot % INVETORYSLOTSWIDTH) <= INVETORYSLOTSWIDTH && (slotHeight + uSlot / INVETORYSLOTSWIDTH) <= INVETORYSLOTSHEIGHT)
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
            return true;
        }
        return false;
    }
}
