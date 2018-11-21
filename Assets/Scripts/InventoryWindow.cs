using UnityEngine;
using System.Collections;

public class InventoryWindow : MonoBehaviour {
    public GUISkin skin;
    private int current_character;
    public GameObject party;
    public GameObject Inventory;
    private Vector2 MousePos;
    private ItemDatebase database;
    private bool actives = false;
    private bool actives_tumbler = false;
    private bool actives2 = false;
    public bool Inventory_change_flag = false;

    // Use this for initialization
    void Start () {
        database = GameObject.Find("Item Datebase").GetComponent<ItemDatebase>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI() {
        if (Temp.current_inventory_window == 3 && Inventory.GetComponent<Inventory>().Inventory_open_flag)//Inventory
        {
            GUI.skin = skin;
            if (Temp.current_screen == Temp.screen_name.screen_game)
                current_character = Inventory.GetComponent<Inventory>().GetCurrentCharacter(this.gameObject.name);
            Temp.current_screen = Temp.screen_name.screen_inventory;
            CharacterUI_InventoryTab_Draw();
        }
    }
    //----- (0041A2D1) --------------------------------------------------------
    public void CharacterUI_InventoryTab_Draw()
    {
        Texture2D pTexture = null;
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
        for (uint i = 0; i < 126; ++i)
        {
            uCellY = 32 * (i / 14);
            uCellX = 32 * (i % 14) + 7;
            if (Player.InventoryMatrix[i] == 0)
            //continue;
            {
                if (GUI.Button(new Rect((Screen.width / 2 - 230) + uCellX/*(uCellX - 35)*/, (Screen.height / 2 - 163) + uCellY, 32, 32), pTexture))
                {

                    if (Inventory.GetComponent<Inventory>().AddItem(Temp.ActiveCharacter, (int)i, party.GetComponent<Party>().TakenItemID) != 0)
                    {
                        pTexture = null;
                        party.GetComponent<Party>().TakenItemID = 0;
                        party.GetComponent<Party>().TakenItemTexture = null;
                    }
                    else {
                        //beep
                    }
                    //                    }
                }
                continue;
            }
            else if (Player.InventoryMatrix[i] < 0)
            {
                continue;
            }
            if (Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID < 0)
                continue;
            int pr = Player.InventoryMatrix[i] - 1;
            int itm = Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID - 1;
            pTexture = database.items[Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID - 1].itemTexture;
            if (GUI.RepeatButton(new Rect((Screen.width / 2 - 230) + uCellX/*(uCellX - 35)*/, (Screen.height / 2 - 163) + uCellY, pTexture.width, pTexture.height), pTexture))
            {
                if (actives2)
                {
                    if (party.GetComponent<Party>().TakenItemTexture != null)
                    {
                        int new_item_id = Inventory.GetComponent<Inventory>().mix_items(party.GetComponent<Party>().TakenItemID, Player.InventoryItemList[i].ItemID);
                        if (new_item_id == 0)
                        {
                            Inventory_change_flag = true;
                            int temp_id = Player.InventoryItemList[i].ItemID;
                            Texture2D temp_texture = pTexture;
                            if (Inventory.GetComponent<Inventory>().AddItem(Temp.ActiveCharacter, (int)i, party.GetComponent<Party>().TakenItemID) != 0)
                            {
                                Player.InventoryItemList[i].ItemID = (int)party.GetComponent<Party>().TakenItemID;
                                party.GetComponent<Party>().TakenItemTexture = temp_texture;
                                party.GetComponent<Party>().TakenItemID = (uint)temp_id;
                            }
                        }
                        else {
                            Player.InventoryItemList[i].ItemID = new_item_id;
                            party.GetComponent<Party>().TakenItemTexture = null;
                            party.GetComponent<Party>().TakenItemID = 0;
                        }
                    }
                    else
                    {
                        party.GetComponent<Party>().TakenItemTexture = pTexture;
                        party.GetComponent<Party>().TakenItemID = (uint)Player.InventoryItemList[i].ItemID;
                        Inventory.GetComponent<Inventory>().DeleteItemArInventoryIndex(Player, (int)party.GetComponent<Party>().TakenItemID, (int)i);
                        Player.InventoryItemList[i].ItemID = -1;
                    }
                }
                if (actives)
                {
                    party.GetComponent<ModalWindow>().x = uCellX;
                    party.GetComponent<ModalWindow>().y = uCellY;
                    if (Player.InventoryMatrix[i] - 1 > 0)
                    {
                        string txt = database.items[Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID - 1].pDescription;
                        party.GetComponent<ModalWindow>().text = database.items[Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID - 1].pDescription;
                        party.GetComponent<ModalWindow>().price = database.items[Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID - 1].uValue;
                        party.GetComponent<ModalWindow>().Topic = database.items[Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID - 1].pName;
                        party.GetComponent<ModalWindow>().Item_type = database.items[Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID - 1].pUnidentifiedName;
                        party.GetComponent<ModalWindow>().Item_texture = database.items[Player.InventoryItemList[Player.InventoryMatrix[i] - 1].ItemID - 1].itemTexture;
                        party.GetComponent<ModalWindow>().curlegth = 40;
                        party.GetComponent<ModalWindow>().flag = true;
                    }
                    actives_tumbler = true;
                }
            }
            pTexture = null;

        }
        if (party.GetComponent<Party>().TakenItemTexture != null)
        {

            GUI.DrawTexture(new Rect(MousePos.x, Screen.height - MousePos.y, party.GetComponent<Party>().TakenItemTexture.width, party.GetComponent<Party>().TakenItemTexture.height), party.GetComponent<Party>().TakenItemTexture);

        }
    }
}
