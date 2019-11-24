using UnityEngine;
using System.Collections;

public class InventoryC : MonoBehaviour {
	
	private bool  menu = false;
	private bool  itemMenu = true;
	private bool  equipMenu = false;
	
	public int[] itemSlot = new int[126];
	public int[] itemQuantity = new int[126];
	public int[] equipment = new int[8];
	
	public int weaponEquip = 0;
	public bool  allowWeaponUnequip = false;
	public int armorEquip = 0;
	public bool  allowArmorUnequip = true;
	public GameObject[] weapon = new GameObject[1];
	
	public GameObject player;
	public GameObject database;
	public GameObject fistPrefab;
    public GameObject body_database;

    public int cash = 500;
	
	public GUISkin skin;
    const int INVENTORY_WINDOW_ID = 0; //id окна инвентаря 
    public Rect windowRect = new Rect (200 ,200 ,800 ,385);
    const int INVENTORY_TEXTURE_ID = 1; //id окна с иконкой 
    const int CHARACTER_WINDOW_ID = 2; //id окна персонажа
    Rect inventoryBoxRect = new Rect(); //область окна с изображением иконки 
    public Rect characterBoxRect = new Rect(1001,200,400,400); //область окна с изображением иконки 
    public float ButtonWidth = 40; //высота ячейки 
    public float ButtonHeight = 40; //ширина ячейки 
    public int indent_x = 0;//отступы
    public int indent_y = 0;
    int invRows = 9; //количество колонок 
    int invColumns = 14; //количество в строке 
    bool isDraggable; //перемещение предмета 
    //int TempitemQuantity;
    int Item_Count;
    //public Texture2D BG;
    public GUIStyle BG_style;
    public GUIStyle BG_Char;
    public float gold_positionX;
    public float gold_positionY;
    public float Hint_positionX;
    public float Hint_positionY;
    public float Hint_Width;
    public float Hint_Height;
    public float Papperdoll_bodypositionX;
    public float Papperdoll_bodypositionY;
    public Rect Papperdoll_rhandposition = new Rect(0,0,0,0);
    public Rect Papperdoll_lhandposition = new Rect(0,0,0,0);
   
    int selectItem; //вспомогательная переменная куда заносим предмет инвентаря 
    Texture2D dragTexture; //текстура которая отображается при перетягивании предмета в инвентаре
    ItemDataC dataItem;
    BodyDataC databody;
    //private string hover = ""; 

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
    public bool panel2_texture_flag = false;
    public Texture2D panel2_texture;
    public Texture2D character_body;
    public Texture2D character_hand;
    public Texture2D character_hand2;
    public Texture2D character_fast;
    public Texture2D character_fast_left;
    public Texture2D character_fast_left2;


    void  Start (){
		if(!player){
			player = this.gameObject;
		}
		ItemDataC dataItem = database.GetComponent<ItemDataC>();
        BodyDataC databody = body_database.GetComponent<BodyDataC>();
        //Reset Power of Current Weapon & Armor
        player.GetComponent<StatusC>().addAtk = 0;
		player.GetComponent<StatusC>().addDef = 0;
		player.GetComponent<StatusC>().addMatk = 0;
		player.GetComponent<StatusC>().addMdef = 0;
		player.GetComponent<StatusC>().weaponAtk = 0;
		player.GetComponent<StatusC>().weaponMatk = 0;
		//Set New Variable of Weapon
		player.GetComponent<StatusC>().weaponAtk += dataItem.equipment[weaponEquip].attack;
		player.GetComponent<StatusC>().addDef += dataItem.equipment[weaponEquip].defense;
		player.GetComponent<StatusC>().weaponMatk += dataItem.equipment[weaponEquip].magicAttack;
		player.GetComponent<StatusC>().addMdef += dataItem.equipment[weaponEquip].magicDefense;
		//Set New Variable of Armor
		player.GetComponent<StatusC>().weaponAtk += dataItem.equipment[armorEquip].attack;
		player.GetComponent<StatusC>().addDef += dataItem.equipment[armorEquip].defense;
		player.GetComponent<StatusC>().weaponMatk += dataItem.equipment[armorEquip].magicAttack;
		player.GetComponent<StatusC>().addMdef += dataItem.equipment[armorEquip].magicDefense;
		player.GetComponent<StatusC>().CalculateStatus();
    }
	
	void  Update (){
		if (Input.GetKeyDown("i") || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
			OnOffMenu();
			//AutoSortItem();
		}
	}
	
	public void  UseItem ( int id  ){
		ItemDataC dataItem = database.GetComponent<ItemDataC>();
		player.GetComponent<StatusC>().Heal(dataItem.usableItem[id].hpRecover , dataItem.usableItem[id].mpRecover);
		player.GetComponent<StatusC>().atk += dataItem.usableItem[id].atkPlus;
		player.GetComponent<StatusC>().def += dataItem.usableItem[id].defPlus;
		player.GetComponent<StatusC>().matk += dataItem.usableItem[id].matkPlus;
		player.GetComponent<StatusC>().mdef += dataItem.usableItem[id].mdefPlus;
		
		AutoSortItem();

	}
	
	public void  EquipItem ( int id  ,   int slot  ){
		GameObject wea = new GameObject ();
		if(id == 0){
			return;
		}
		if(!player){
			player = this.gameObject;
		}
		ItemDataC dataItem = database.GetComponent<ItemDataC>();
		//Backup Your Current Equipment before Unequip
		int tempEquipment = 0;
		
		if(dataItem.equipment[id].EquipmentType == 0){//Equipment = Weapon
			//Weapon Type
			tempEquipment = weaponEquip;
			weaponEquip = id;
			if(dataItem.equipment[id].attackPrefab){
				player.GetComponent<AttackTriggerC>().attackPrefab = dataItem.equipment[id].attackPrefab.transform;
			}
			//Change Weapon Mesh
			if(dataItem.equipment[id].model && weapon.Length > 0 && weapon[0] != null){
				int allWeapon = weapon.Length;
				int a = 0;
				if(allWeapon > 0 && dataItem.equipment[id].assignAllWeapon){
					while(a < allWeapon && weapon[a]){
						weapon[a].SetActive(true);
						wea = Instantiate(dataItem.equipment[id].model,weapon[a].transform.position,weapon[a].transform.rotation) as GameObject;
						wea.transform.parent = weapon[a].transform.parent;
						Destroy(weapon[a].gameObject);
						weapon[a] = wea;
						a++;
					}
				}else if(allWeapon > 0){
					while(a < allWeapon && weapon[a]){
						if(a == 0){
							weapon[a].SetActive(true);
							wea = Instantiate(dataItem.equipment[id].model,weapon[a].transform.position,weapon[a].transform.rotation) as GameObject;
							wea.transform.parent = weapon[a].transform.parent;
							Destroy(weapon[a].gameObject);
							weapon[a] = wea;
						}else{
							weapon[a].SetActive(false);
						}
						a++;
					}
				}
			}
		}else{
			//Armor Type
			tempEquipment = armorEquip;
			armorEquip = id;
		}
		if(slot <= equipment.Length){
			equipment[slot] = 0;
		}
		//Assign Weapon Animation to PlayerAnimation Script
		AssignWeaponAnimation(id);
		//Reset Power of Current Weapon & Armor
		player.GetComponent<StatusC>().addAtk = 0;
		player.GetComponent<StatusC>().addDef = 0;
		player.GetComponent<StatusC>().addMatk = 0;
		player.GetComponent<StatusC>().addMdef = 0;
		player.GetComponent<StatusC>().weaponAtk = 0;
		player.GetComponent<StatusC>().weaponMatk = 0;
		//Set New Variable of Weapon
		player.GetComponent<StatusC>().weaponAtk += dataItem.equipment[weaponEquip].attack;
		player.GetComponent<StatusC>().addDef += dataItem.equipment[weaponEquip].defense;
		player.GetComponent<StatusC>().weaponMatk += dataItem.equipment[weaponEquip].magicAttack;
		player.GetComponent<StatusC>().addMdef += dataItem.equipment[weaponEquip].magicDefense;
		//Set New Variable of Armor
		player.GetComponent<StatusC>().weaponAtk += dataItem.equipment[armorEquip].attack;
		player.GetComponent<StatusC>().addDef += dataItem.equipment[armorEquip].defense;
		player.GetComponent<StatusC>().weaponMatk += dataItem.equipment[armorEquip].magicAttack;
		player.GetComponent<StatusC>().addMdef += dataItem.equipment[armorEquip].magicDefense;
		
		player.GetComponent<StatusC>().CalculateStatus();
		AutoSortEquipment();
		AddEquipment(tempEquipment);
		
	}

	public void  RemoveWeaponMesh (){
		if(weapon.Length > 0 && weapon[0] != null){
			int allWeapon = weapon.Length;
			int a = 0;
			if(allWeapon > 0){
				while(a < allWeapon && weapon[a]){
					weapon[a].SetActive(false);
					//Destroy(weapon[a].gameObject);
					a++;
				}
			}
		}
	}
	
	public void  UnEquip ( int id  ){
		bool full = false;
		ItemDataC dataItem = database.GetComponent<ItemDataC>();
		if(!player){
			player = this.gameObject;
		}
		if(dataItem.equipment[id].model && weapon.Length > 0 && weapon[0] != null){
			full = AddEquipment(weaponEquip);
		}else{
			full = AddEquipment(armorEquip);
		}
		if(!full){
			if(dataItem.equipment[id].model && weapon.Length > 0 && weapon[0] != null){
				weaponEquip = 0;
				player.GetComponent<AttackTriggerC>().attackPrefab = fistPrefab.transform;
				if(weapon.Length > 0 && weapon[0] != null){
					int allWeapon = weapon.Length;
					int a = 0;
					if(allWeapon > 0){
						while(a < allWeapon && weapon[a]){
							weapon[a].SetActive(false);
							//Destroy(weapon[a].gameObject);
							a++;
						}
					}
				}
			}else{
				armorEquip = 0;
			}
			//Reset Power of Current Weapon & Armor
			player.GetComponent<StatusC>().addAtk = 0;
			player.GetComponent<StatusC>().addDef = 0;
			player.GetComponent<StatusC>().addMatk = 0;
			player.GetComponent<StatusC>().addMdef = 0;
			player.GetComponent<StatusC>().weaponAtk = 0;
			player.GetComponent<StatusC>().weaponMatk = 0;
			//Set New Variable of Weapon
			player.GetComponent<StatusC>().weaponAtk += dataItem.equipment[weaponEquip].attack;
			player.GetComponent<StatusC>().addDef += dataItem.equipment[weaponEquip].defense;
			player.GetComponent<StatusC>().weaponMatk += dataItem.equipment[weaponEquip].magicAttack;
			player.GetComponent<StatusC>().addMdef += dataItem.equipment[weaponEquip].magicDefense;
			//Set New Variable of Armor
			player.GetComponent<StatusC>().weaponAtk += dataItem.equipment[armorEquip].attack;
			player.GetComponent<StatusC>().addDef += dataItem.equipment[armorEquip].defense;
			player.GetComponent<StatusC>().weaponMatk += dataItem.equipment[armorEquip].magicAttack;
			player.GetComponent<StatusC>().addMdef += dataItem.equipment[armorEquip].magicDefense;
		} 
	}
	
	void  OnGUI (){
		GUI.skin = skin;
		if(menu && itemMenu){//Создаем окно
            windowRect = GUI.Window(INVENTORY_WINDOW_ID, windowRect, ItemWindow, "INVENTORY", BG_style);
            if (isDraggable)
            {
                inventoryBoxRect = GUI.Window(INVENTORY_TEXTURE_ID, new Rect(Event.current.mousePosition.x + 1, Event.current.mousePosition.y + 1, 40, 40), insert, "", "box");

            }
            //characterBoxRect = GUI.Window(CHARACTER_WINDOW_ID, characterBoxRect, CharacterWindow, "CHARACTER", BG_Char);

        }
        if(menu && equipMenu){
			windowRect = GUI.Window (INVENTORY_WINDOW_ID, windowRect, ItemWindow, "EQUIPMENT", BG_style);
            if (isDraggable)
            {
                inventoryBoxRect = GUI.Window(INVENTORY_TEXTURE_ID, new Rect(Event.current.mousePosition.x + 1, Event.current.mousePosition.y + 1, 40, 40), insert, "", "box");

            }
            characterBoxRect = GUI.Window(CHARACTER_WINDOW_ID, characterBoxRect, CharacterWindow, "CHARACTER", BG_Char);
		}

        if(menu){
			if (GUI.Button ( new Rect(windowRect.x -50, windowRect.y +105,50,100), "Item")) {
				//Switch to Item Tab
				itemMenu = true;
				equipMenu = false;
			}
			if (GUI.Button ( new Rect(windowRect.x -50, windowRect.y +225,50,100), "Equip")) {
				//Switch to Equipment Tab
				equipMenu = true;
				itemMenu = false;	
			}
		}
        //hover = GUI.tooltip;
    }

    //окно с изображением иконки 
    void insert(int id)
    {
        GUI.BringWindowToFront(INVENTORY_TEXTURE_ID);//выводим на передний план окно с иконкой 
        GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 40, 40), dragTexture);//рисуем текстуру иконки 
        if (menu && itemMenu)
           GUI.Label(new Rect(30, 0, 20, 20), ""+Item_Count); //Количество
    }

    //Окно персонажа
    void CharacterWindow(int windowID)
    {
        dataItem = database.GetComponent<ItemDataC>();
        databody = body_database.GetComponent<BodyDataC>();
        GUI.Box(new Rect(characterBoxRect.x, characterBoxRect.y, characterBoxRect.width, characterBoxRect.height), "CHARACTER");

        if (panel2_texture_flag)//панель с кольцами
        {
            GUI.DrawTexture(new Rect(characterBoxRect.x, characterBoxRect.y, characterBoxRect.width, characterBoxRect.height), panel2_texture);
        }

        //определение персонажа

        //отрисовка лука

        //отрисовка плаща

        //отрисовка куклы
        //Body
        GUI.DrawTexture(new Rect(Papperdoll_bodypositionX, Papperdoll_bodypositionY, characterBoxRect.width, characterBoxRect.height), databody.Bodies[0].Body_parts[0]);
        //Hands
        //Right
        GUI.DrawTexture(new Rect(Papperdoll_rhandposition.x, Papperdoll_rhandposition.y, Papperdoll_rhandposition.width, Papperdoll_rhandposition.height), databody.Bodies[0].Body_parts[1]);

        //Left
        GUI.DrawTexture(new Rect(Papperdoll_lhandposition.x, Papperdoll_lhandposition.y, Papperdoll_lhandposition.width, Papperdoll_lhandposition.height), databody.Bodies[0].Body_parts[5]);

        //броня

        //шлем

        //обувь

        //пояс
        //плечи брони
        //воротник
        //оружие
        //оружие во второй руке
        //кулак
        //щит
       
        /*
        //отрисовка кнопок
        if (GUI.Button(new Rect(100, 115, 50, 50), new GUIContent(dataItem.equipment[weaponEquip].icon, dataItem.equipment[weaponEquip].itemName + "\n" + "\n" + dataItem.equipment[weaponEquip].description)))
        {
            if (!allowWeaponUnequip || weaponEquip == 0)
            {
                return;
            }
            UnEquip(weaponEquip);
        }
        //Armor
        GUI.Label(new Rect(20, 190, 150, 50), "Armor");
        if (GUI.Button(new Rect(100, 175, 50, 50), new GUIContent(dataItem.equipment[armorEquip].icon, dataItem.equipment[armorEquip].itemName + "\n" + "\n" + dataItem.equipment[armorEquip].description)))
        {
            if (!allowArmorUnequip || armorEquip == 0)
            {
                return;
            }
            UnEquip(armorEquip);

        }*/
        GUI.DragWindow();
    }

    //-----------Item Window-------------
    void ItemWindow(int windowID){
        dataItem = database.GetComponent<ItemDataC>();
        if(menu && itemMenu)
        {
            //GUI.Box ( new Rect(260,140,280,385), "Items");

            //Close Window Button
            float button_x = windowRect.width - 30;
            if (GUI.Button ( new Rect(button_x,0,25,25), "X")) {
				    OnOffMenu();
			}

            //Autosort button
            float button_autosort = button_x - 100;
            if (GUI.Button(new Rect(button_autosort, 0, 75, 25), "Autosort"))
            {
                AutoSortItem();
            }

            //Items Slot
            int i = 0;
            for (int y = 0; y < invRows; y++)
            {
                for (int x = 0; x < invColumns; x++)
                {
                    if (GUI.Button(new Rect(indent_x + (x * ButtonWidth), indent_y + (y * ButtonHeight), ButtonWidth, ButtonHeight), new GUIContent(dataItem.usableItem[itemSlot[i]].icon, dataItem.usableItem[itemSlot[i]].itemName + "\n" + "\n" + dataItem.usableItem[itemSlot[i]].description)))
                    {
                        if (Input.GetKeyUp(KeyCode.Mouse0))//только при нажатии ЛКМ
                        {
                            if (itemSlot[i] > 0)
                            {
                                if (!isDraggable)//еще не бралась вещь (первичный клик)
                                {
                                    //зажат ли шифт
                                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                                    {
                                        dragTexture = dataItem.usableItem[itemSlot[i]].icon;//присваиваем нашей текстуре которая должна отображаться при перетаскивании, текстуру предмета 
                                        isDraggable = true;//возможность перемещать предмет 
                                        selectItem = itemSlot[i];//присваиваем вспомогательной переменной наш предмет 
                                        Item_Count = 1;
                                        itemQuantity[i]--;
                                        if (itemQuantity[i] <= 0)
                                        {
                                            itemSlot[i] = 0;
                                        }
                                    }
                                    else
                                    {
                                        //шифт не зажат
                                        dragTexture = dataItem.usableItem[itemSlot[i]].icon;//присваиваем нашей текстуре которая должна отображаться при перетаскивании, текстуру предмета 
                                        isDraggable = true;//возможность перемещать предмет 
                                        selectItem = itemSlot[i];//присваиваем вспомогательной переменной наш предмет 
                                                                 //RemoveItem((x + y * invColumns) + 1, 1);//удаляем предмет
                                                                 // if (itemQuantity[i] > 0)
                                                                 //{
                                                                 //TempitemQuantity = itemQuantity[i];
                                        Item_Count = itemQuantity[i];
                                        itemQuantity[i] = 0;
                                        if (itemQuantity[i] <= 0)
                                            itemSlot[i] = 0;
                                    }
                                }
                                else//на этом месте другая вещь
                                {
                                    //проверка такая же вещь или нет
                                    if (itemSlot[i] == selectItem)
                                    {
                                        itemQuantity[i] += Item_Count;
                                        Item_Count = 0;
                                        selectItem = 0;
                                        isDraggable = false;//возможность перемещать предмет  
                                    }
                                    /*
                                     elseif(CreateNewItem()){//создание новых вещей

                                    }
                                     */
                                    else
                                    {//другая вещь (замена)
                                        int temp_selectItem = selectItem;
                                        int Temp_itemQuantity = Item_Count;
                                        Texture2D Temp_tex = dragTexture;

                                        //получить данные ячейки
                                        selectItem = itemSlot[i];//присваиваем вспомогательной переменной наш предмет 
                                                                 //TempitemQuantity = itemQuantity[i];
                                        Item_Count = itemQuantity[i];
                                        dragTexture = dataItem.usableItem[itemSlot[i]].icon;//присваиваем нашей текстуре которая должна отображаться при перетаскивании, текстуру предмета 

                                        //передача ячейке
                                        itemSlot[i] = temp_selectItem;
                                        itemQuantity[i] = Temp_itemQuantity;
                                        dataItem.usableItem[itemSlot[i]].icon = Temp_tex;
                                        isDraggable = true;//возможность перемещать предмет   
                                    }
                                }
                            }
                            else//это пустая ячейка
                            {

                                if (isDraggable)
                                {
                                    //обнуляем переменные 
                                    itemSlot[i] = selectItem;
                                    itemQuantity[i] = Item_Count;
                                    isDraggable = false;
                                    selectItem = 0;
                                }
                                else//делаем ячейки не выделяемыми 
                                {
                                    GUI.Label(new Rect(indent_x + (x * ButtonWidth), indent_y + (y * ButtonHeight), ButtonWidth, ButtonHeight), new GUIContent(dataItem.usableItem[itemSlot[i]].icon, dataItem.usableItem[itemSlot[i]].itemName + "\n" + "\n" + dataItem.usableItem[itemSlot[i]].description));
                                }
                            }
                        }
                        if (Input.GetKeyUp(KeyCode.Mouse1))//только при нажатии ПКМ
                        {
                            UseItem(itemSlot[i]);
                            if (itemQuantity[i] > 0)
                                itemQuantity[i]--;
                            if (itemQuantity[i] <= 0)
                            {
                                itemSlot[i] = 0;
                                itemQuantity[i] = 0;
                            }
                        }
                    }
                    //показать количество предметов
                    if (itemQuantity[i] > 0)
                    {
                        GUI.Label(new Rect(40 + (x * ButtonWidth), 20 + (y * ButtonHeight), 20, 20), itemQuantity[i].ToString()); //Количесство больше ноля
                    }
                    i++;
                }
            }
            GUI.DragWindow();

            GUI.Label ( new Rect(gold_positionX, gold_positionY, 150, 50), "Gold: " + cash.ToString());

            GUI.skin = skin;
            GUI.Box(new Rect(Hint_positionX, Hint_positionY, Hint_Width, Hint_Height), GUI.tooltip);//строка пояснения
            //---------------------------
        }
		
		//---------------Equipment Tab----------------------------
		if(menu && equipMenu)
        {
            //Close Window Button
            float button_x = windowRect.width - 30;
            if (GUI.Button(new Rect(button_x, 0, 25, 25), "X"))
                OnOffMenu();

            //Autosort button
            float button_autosort = button_x - 100;
            if (GUI.Button(new Rect(button_autosort, 0, 75, 25), "Autosort"))
                AutoSortEquipment();
            
            int i = 0;
            for (int y = 0; y < invRows; y++)
            {
                for (int x = 0; x < invColumns; x++)
                {
                    if (GUI.Button(new Rect(indent_x + (x * ButtonWidth), indent_y + (y * ButtonHeight), ButtonWidth, ButtonHeight), new GUIContent(dataItem.equipment[equipment[i]].icon, dataItem.equipment[equipment[i]].itemName + "\n" + "\n" + dataItem.equipment[equipment[i]].description)))
                    {
                        if (Input.GetKeyUp(KeyCode.Mouse0))//только при нажатии ЛКМ
                        {
                            if (equipment[i] > 0)
                            {
                                if (!isDraggable)//еще не бралась вещь (первичный клик)
                                {
                                    //шифт не зажат
                                    dragTexture = dataItem.equipment[equipment[i]].icon;//присваиваем нашей текстуре которая должна отображаться при перетаскивании, текстуру предмета 
                                    isDraggable = true;//возможность перемещать предмет 
                                    selectItem = equipment[i];//присваиваем вспомогательной переменной наш предмет 
                                    equipment[i] = 0;
                                }
                                else//на этом месте другая вещь
                                {
                                    //другая вещь (замена)
                                    int temp_selectItem = selectItem;
                                    Texture2D Temp_tex = dragTexture;

                                    //получить данные ячейки
                                    selectItem = equipment[i];//присваиваем вспомогательной переменной наш предмет 
                                    dragTexture = dataItem.equipment[equipment[i]].icon;//присваиваем нашей текстуре которая должна отображаться при перетаскивании, текстуру предмета 

                                    //передача ячейке
                                    equipment[i] = temp_selectItem;
                                    dataItem.equipment[equipment[i]].icon = Temp_tex;
                                    isDraggable = true;//возможность перемещать предмет   
                                    
                                }
                            }
                            else//это пустая ячейка
                            {
                                if (isDraggable)
                                {
                                    //обнуляем переменные 
                                    equipment[i] = selectItem;
                                    isDraggable = false;
                                    selectItem = 0;
                                }
                                else//делаем ячейки не выделяемыми 
                                {
                                    GUI.Label(new Rect(indent_x + (x * ButtonWidth), indent_y + (y * ButtonHeight), ButtonWidth, ButtonHeight), new GUIContent(dataItem.equipment[equipment[i]].icon, dataItem.equipment[equipment[i]].itemName + "\n" + "\n" + dataItem.equipment[equipment[i]].description));
                                }
                            }
                        }
                        if (Input.GetKeyUp(KeyCode.Mouse1))//только при нажатии ПКМ
                            EquipItem(equipment[i], i);
                    }
                    i++;
                }
            }
            GUI.Label(new Rect(gold_positionX, gold_positionY, 150, 50), "Gold: " + cash.ToString());

            GUI.skin = skin;
            GUI.Box(new Rect(Hint_positionX, Hint_positionY, Hint_Width, Hint_Height), GUI.tooltip);//строка пояснения
        }
		GUI.DragWindow (new Rect (0,0,10000,10000)); 
	}
	
	public bool AddItem ( int id ,  int quan  ){
		bool  full = false;
		bool  geta = false;
		
		int pt = 0;
		while(pt < itemSlot.Length && !geta){
			if(itemSlot[pt] == id){
				itemQuantity[pt] += quan;
				geta = true;
			}else if(itemSlot[pt] == 0){
				itemSlot[pt] = id;
				itemQuantity[pt] = quan;
				geta = true;
			}else{
				pt++;
				if(pt >= itemSlot.Length){
					full = true;
					print("Full");
				}
			}
			
		}
		
		return full;
		
	}
	
	public bool AddEquipment ( int id  ){
		bool  full = false;
		bool  geta = false;
		
		
		int pt = 0;
		while(pt < equipment.Length && !geta){
			if(equipment[pt] == 0){
				equipment[pt] = id;
				geta = true;
			}else{
				pt++;
				if(pt >= equipment.Length){
					full = true;
					print("Full");
				}
			}
			
		}
		
		return full;
		
	}
	//------------AutoSort----------
	public void  AutoSortItem (){
		int pt = 0;
		int nextp = 0;
		bool  clearr = false;
		while(pt < itemSlot.Length){
			if(itemSlot[pt] == 0){
				nextp = pt + 1;
				while(nextp < itemSlot.Length && !clearr){
					if(itemSlot[nextp] > 0){
						//Fine Next Item and Set
						itemSlot[pt] = itemSlot[nextp];
						itemQuantity[pt] = itemQuantity[nextp];
						itemSlot[nextp] = 0;
						itemQuantity[nextp] = 0;
						clearr = true;
					}else{
						nextp++;
					}
					
				}
				//Continue New Loop
				clearr = false;
				pt++;
			}else{
				pt++;
			}
			
		}
		
	}
	
	public void AutoSortEquipment (){
		int pt = 0;
		int nextp = 0;
		bool  clearr = false;
		while(pt < equipment.Length){
			if(equipment[pt] == 0){
				nextp = pt + 1;
				while(nextp < equipment.Length && !clearr){
					if(equipment[nextp] > 0){
						//Fine Next Item and Set
						equipment[pt] = equipment[nextp];
						equipment[nextp] = 0;
						clearr = true;
					}else{
						nextp++;
					}
					
				}
				//Continue New Loop
				clearr = false;
				pt++;
			}else{
				pt++;
			}
			
		}
		
	}
	
	
	void  OnOffMenu (){
		//Freeze Time Scale to 0 if Window is Showing
		if(!menu && Time.timeScale != 0.0f){
			menu = true;
			Time.timeScale = 0.0f;
			//Screen.lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
			ResetPosition();
		}else if(menu){
			menu = false;
			Time.timeScale = 1.0f;
            //Screen.lockCursor = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
		}
		
	}
	
	void  AssignWeaponAnimation ( int id  ){
		ItemDataC dataItem = database.GetComponent<ItemDataC>();
		PlayerAnimationC playerAnim = player.GetComponent<PlayerAnimationC>();
		if(!playerAnim){
			//If use Mecanim
			AssignMecanimAnimation(id);
			return;
		}
		
		//Assign All Attack Combo Animation of the weapon from Database
		if(dataItem.equipment[id].attackCombo.Length > 0 && dataItem.equipment[id].attackCombo[0] != null && dataItem.equipment[id].EquipmentType == 0){
			int allPrefab = dataItem.equipment[id].attackCombo.Length;
			player.GetComponent<AttackTriggerC>().attackCombo = new AnimationClip[allPrefab];
			
			int a = 0;
			if(allPrefab > 0){
				while(a < allPrefab){
					player.GetComponent<AttackTriggerC>().attackCombo[a] = dataItem.equipment[id].attackCombo[a];
					player.GetComponent<AttackTriggerC>().mainModel.GetComponent<Animation>()[dataItem.equipment[id].attackCombo[a].name].layer = 15;
					a++;
				}
			}
			int watk = (int)dataItem.equipment[id].whileAttack;
			player.GetComponent<AttackTriggerC>().WhileAttackSet(watk);
			//Assign Attack Speed
			player.GetComponent<AttackTriggerC>().attackSpeed = dataItem.equipment[id].attackSpeed;
			player.GetComponent<AttackTriggerC>().atkDelay1 = dataItem.equipment[id].attackDelay;
		}
		
		if(dataItem.equipment[id].idleAnimation){
			player.GetComponent<PlayerAnimationC>().idle = dataItem.equipment[id].idleAnimation;
		}
		if(dataItem.equipment[id].runAnimation){
			playerAnim.run = dataItem.equipment[id].runAnimation;
		}
		if(dataItem.equipment[id].rightAnimation){
			playerAnim.right = dataItem.equipment[id].rightAnimation;
		}
		if(dataItem.equipment[id].leftAnimation){
			playerAnim.left = dataItem.equipment[id].leftAnimation;
		}
		if(dataItem.equipment[id].backAnimation){
			playerAnim.back = dataItem.equipment[id].backAnimation;
		}
		if(dataItem.equipment[id].jumpAnimation){
			player.GetComponent<PlayerAnimationC>().jump = dataItem.equipment[id].jumpAnimation;
		}
		playerAnim.AnimationSpeedSet();
		
	}
	
	void ResetPosition(){
		//Reset GUI Position when it out of Screen.
		if(windowRect.x >= Screen.width -30 || windowRect.y >= Screen.height -30 || windowRect.x <= -70 || windowRect.y <= -70 ){
			windowRect = new Rect (260 ,140 ,280 ,385);
		}
		
	}

	void  AssignMecanimAnimation (int id){
		ItemDataC dataItem = database.GetComponent<ItemDataC>();
		if(dataItem.equipment[id].EquipmentType == 0){
			int watk = (int)dataItem.equipment[id].whileAttack;
			player.GetComponent<AttackTriggerC>().WhileAttackSet(watk);
			//Assign Attack Speed
			player.GetComponent<AttackTriggerC>().attackSpeed = dataItem.equipment[id].attackSpeed;
			player.GetComponent<AttackTriggerC>().atkDelay1 = dataItem.equipment[id].attackDelay;
			//Set Weapon Type ID to Mecanim Animator and Set New Idle
			player.GetComponent<PlayerMecanimAnimationC>().SetWeaponType(dataItem.equipment[id].weaponType , dataItem.equipment[id].idleAnimation.name);
			
			int allPrefab = dataItem.equipment[id].attackCombo.Length;
			player.GetComponent<AttackTriggerC>().attackCombo = new AnimationClip[allPrefab];
			
			//Set Attack Animation
			int a = 0;
			if(allPrefab > 0){
				while(a < allPrefab){
					player.GetComponent<AttackTriggerC>().attackCombo[a] = dataItem.equipment[id].attackCombo[a];
					a++;
				}
			}
		}
		
	}
	//--------------------------------------------

	public bool CheckItem(int id , int type, int qty){
		bool having = false;
		bool geta = false;
		//type 0 = Usable , 1 = Equipment
		
		int pt = 0;
		
		//================Usable==================
		if(type == 0){
			while(pt < itemSlot.Length && !geta){
				if(itemSlot[pt] == id){
					if(itemQuantity[pt] >= qty){
						having = true;
					}
					geta = true;
				}else{
					pt++;
				}
				//--------------------------
			}
		}
		//=================Equipment=================
		if(type == 1){
			while(pt < equipment.Length && !geta){
				if(equipment[pt] == id){
					having = true;
					geta = true;
				}else{
					pt++;
				}
				//--------------------------
			}
		}
		
		return having;
		
	}

	
	public int FindItemSlot(int id) {
		bool geta = false;
		int pt = 0;
		while(pt < itemSlot.Length && !geta){
			if(itemSlot[pt] == id){
				geta = true;
			}else{
				pt++;
				if(pt >= itemSlot.Length){
					pt = itemSlot.Length + 50;//No Item
					print("No Item");
				}
			}
			
		}
		
		return pt;
		
	}
	
	public int FindEquipmentSlot(int id){
		bool geta = false;
		int pt = 0;
		while(pt < equipment.Length && !geta){
			if(equipment[pt] == id){
				geta = true;
			}else{
				pt++;
				if(pt >= equipment.Length){
					pt = equipment.Length + 50;//No Item
					print("No Item");
				}
			}
			
		}
		
		return pt;
		
	}
	
	public bool RemoveItem(int id , int amount){
		bool haveItem = false;
		int slot = FindItemSlot(id);
		if(slot < itemSlot.Length){
			if(itemQuantity[slot] > 0){
				itemQuantity[slot] -= amount;
				haveItem = true;
			}
			if(itemQuantity[slot] <= 0){
				itemSlot[slot] = 0;
				itemQuantity[slot] = 0;
				AutoSortItem();
			}
		}
		return haveItem;
	}
	
	public bool RemoveEquipment(int id ){
		bool haveItem = false;
		int slot = FindEquipmentSlot(id);
		if(slot < equipment.Length){
			equipment[slot] = 0;
			AutoSortEquipment();
			haveItem = true;
		}
		return haveItem;
	}
	

}
