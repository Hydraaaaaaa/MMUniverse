using UnityEngine;
using System.Collections;
using System.IO; // Используем библиотеку ввода вывода

public class Save : MonoBehaviour {
   
	public string filename; // Путь сохранения
    public GameObject mouse_select;
	const string savePath = "Data/Save";


	void Start () // Данный скрипт выполняется при инициализации объекта.
	{
		if ( filename == "" ) filename = savePath+"/Position.sg"; 
		// Если название файла не указанно то пишем по умолчанию
	}

	void OnGUI () // Создаем ГУИ элементы, текстовое поле и 2 кнопки
	{
		/*if ( GUI.Button( new Rect(10,10,60,20),"Write") ) // Нажата кнопка "запись"?
		{
		 StreamWriter sw = new StreamWriter(filename); // Создаем файл
		    sw.WriteLine(transform.position.x); // Пишем координаты
			sw.WriteLine(transform.position.y);
			sw.WriteLine(transform.position.z);
			Debug.Log("Save" + transform.position);
		    sw.Close(); // Закрываем(сохраняем)
		}*/
	}

	public void AutoSave(){
		if (!Directory.Exists (savePath)) {    
			Directory.CreateDirectory(savePath);
		}
		StreamWriter sw = new StreamWriter(filename); // Создаем файл

        //sw.WriteLine(transform.position.x); // Пишем координаты
        //sw.WriteLine(transform.position.y);
        //sw.WriteLine(transform.position.z);

        //количество героев
        sw.WriteLine("//Количество в группе");
        Temp.players_Count = GetComponent<Party>().players_Count;
        sw.WriteLine(GetComponent<Party>().players_Count);

        //имена
        sw.WriteLine("//Имена");
        Temp.Player0Name = GetComponent<Party> ().Players [0].Name;
        sw.WriteLine(GetComponent<Party>().Players[0].Name);
        Temp.Player1Name = GetComponent<Party> ().Players [1].Name;
        sw.WriteLine(GetComponent<Party>().Players[1].Name);
        Temp.Player2Name = GetComponent<Party> ().Players [2].Name;
        sw.WriteLine(GetComponent<Party>().Players[2].Name);
        Temp.Player3Name = GetComponent<Party> ().Players [3].Name;
        sw.WriteLine(GetComponent<Party>().Players[3].Name);

        //номер портрета
        sw.WriteLine("//номер портрета");
        sw.WriteLine (GetComponent<Party>().Players[0].CurrentFace);
		sw.WriteLine (GetComponent<Party>().Players[1].CurrentFace);
		sw.WriteLine (GetComponent<Party>().Players[2].CurrentFace);
		sw.WriteLine (GetComponent<Party>().Players[3].CurrentFace);

        //тип класса
        sw.WriteLine("//тип класса");
        sw.WriteLine((int)GetComponent<Party>().Players[0].ClassType);
        sw.WriteLine((int)GetComponent<Party>().Players[1].ClassType);
        sw.WriteLine((int)GetComponent<Party>().Players[2].ClassType);
        sw.WriteLine((int)GetComponent<Party>().Players[3].ClassType);

        //характеристики
        sw.WriteLine("//характеристики");
        sw.WriteLine((int)GetComponent<Party>().Players[0].Might);
        sw.WriteLine((int)GetComponent<Party>().Players[1].Might);
        sw.WriteLine((int)GetComponent<Party>().Players[2].Might);
        sw.WriteLine((int)GetComponent<Party>().Players[3].Might);
        sw.WriteLine((int)GetComponent<Party>().Players[0].MightBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[1].MightBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[2].MightBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[3].MightBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[0].Intelligence);
        sw.WriteLine((int)GetComponent<Party>().Players[1].Intelligence);
        sw.WriteLine((int)GetComponent<Party>().Players[2].Intelligence);
        sw.WriteLine((int)GetComponent<Party>().Players[3].Intelligence);
        sw.WriteLine((int)GetComponent<Party>().Players[0].IntelligenceBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[1].IntelligenceBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[2].IntelligenceBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[3].IntelligenceBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[0].Willpower);
        sw.WriteLine((int)GetComponent<Party>().Players[1].Willpower);
        sw.WriteLine((int)GetComponent<Party>().Players[2].Willpower);
        sw.WriteLine((int)GetComponent<Party>().Players[3].Willpower);
        sw.WriteLine((int)GetComponent<Party>().Players[0].WillpowerBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[1].WillpowerBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[2].WillpowerBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[3].WillpowerBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[0].Endurance);
        sw.WriteLine((int)GetComponent<Party>().Players[1].Endurance);
        sw.WriteLine((int)GetComponent<Party>().Players[2].Endurance);
        sw.WriteLine((int)GetComponent<Party>().Players[3].Endurance);
        sw.WriteLine((int)GetComponent<Party>().Players[0].EnduranceBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[1].EnduranceBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[2].EnduranceBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[3].EnduranceBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[0].Speed);
        sw.WriteLine((int)GetComponent<Party>().Players[1].Speed);
        sw.WriteLine((int)GetComponent<Party>().Players[2].Speed);
        sw.WriteLine((int)GetComponent<Party>().Players[3].Speed);
        sw.WriteLine((int)GetComponent<Party>().Players[0].SpeedBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[1].SpeedBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[2].SpeedBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[3].SpeedBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[0].Accuracy);
        sw.WriteLine((int)GetComponent<Party>().Players[1].Accuracy);
        sw.WriteLine((int)GetComponent<Party>().Players[2].Accuracy);
        sw.WriteLine((int)GetComponent<Party>().Players[3].Accuracy);
        sw.WriteLine((int)GetComponent<Party>().Players[0].AccuracyBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[1].AccuracyBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[2].AccuracyBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[3].AccuracyBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[0].Luck);
        sw.WriteLine((int)GetComponent<Party>().Players[1].Luck);
        sw.WriteLine((int)GetComponent<Party>().Players[2].Luck);
        sw.WriteLine((int)GetComponent<Party>().Players[3].Luck);
        sw.WriteLine((int)GetComponent<Party>().Players[0].LuckBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[1].LuckBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[2].LuckBonus);
        sw.WriteLine((int)GetComponent<Party>().Players[3].LuckBonus);

        //здоровье и сила
        sw.WriteLine("//здоровье и сила");
        sw.WriteLine((int)GetComponent<Party>().Players[0].sHealth);
        sw.WriteLine((int)GetComponent<Party>().Players[1].sHealth);
        sw.WriteLine((int)GetComponent<Party>().Players[2].sHealth);
        sw.WriteLine((int)GetComponent<Party>().Players[3].sHealth);
        sw.WriteLine((int)GetComponent<Party>().Players[0].MaxHealth);
        sw.WriteLine((int)GetComponent<Party>().Players[1].MaxHealth);
        sw.WriteLine((int)GetComponent<Party>().Players[2].MaxHealth);
        sw.WriteLine((int)GetComponent<Party>().Players[3].MaxHealth);
        sw.WriteLine((int)GetComponent<Party>().Players[0].sMana);
        sw.WriteLine((int)GetComponent<Party>().Players[1].sMana);
        sw.WriteLine((int)GetComponent<Party>().Players[2].sMana);
        sw.WriteLine((int)GetComponent<Party>().Players[3].sMana);
        sw.WriteLine((int)GetComponent<Party>().Players[0].MaxMana);
        sw.WriteLine((int)GetComponent<Party>().Players[1].MaxMana);
        sw.WriteLine((int)GetComponent<Party>().Players[2].MaxMana);
        sw.WriteLine((int)GetComponent<Party>().Players[3].MaxMana);

        //возраст
        sw.WriteLine("//возраст");
        sw.WriteLine((int)GetComponent<Party>().Players[0].BirthYear);
        sw.WriteLine((int)GetComponent<Party>().Players[1].BirthYear);
        sw.WriteLine((int)GetComponent<Party>().Players[2].BirthYear);
        sw.WriteLine((int)GetComponent<Party>().Players[3].BirthYear);

        //опыт
        sw.WriteLine("//опыт");
        sw.WriteLine((int)GetComponent<Party>().Players[0].Experience);
        sw.WriteLine((int)GetComponent<Party>().Players[1].Experience);
        sw.WriteLine((int)GetComponent<Party>().Players[2].Experience);
        sw.WriteLine((int)GetComponent<Party>().Players[3].Experience);

        //уровень
        sw.WriteLine("//уровень");
        sw.WriteLine((int)GetComponent<Party>().Players[0].Level);
        sw.WriteLine((int)GetComponent<Party>().Players[1].Level);
        sw.WriteLine((int)GetComponent<Party>().Players[2].Level);
        sw.WriteLine((int)GetComponent<Party>().Players[3].Level);

        //навыки
        sw.WriteLine("//навыки");
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillStaff);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillStaff);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillStaff);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillStaff);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillSword);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillSword);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillSword);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillSword);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillAxe);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillAxe);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillAxe);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillAxe);       
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillSpear);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillSpear);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillSpear);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillSpear);  
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillBow);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillBow);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillBow);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillBow);  
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillMace);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillMace);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillMace);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillMace);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillBlaster);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillBlaster);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillBlaster);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillBlaster);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillShield);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillShield);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillShield);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillShield);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillLeather);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillLeather);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillLeather);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillLeather);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillChain);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillChain);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillChain);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillChain);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillPlate);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillPlate);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillPlate);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillPlate);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillFire);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillFire);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillFire);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillFire);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillAir);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillAir);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillAir);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillAir);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillWater);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillWater);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillWater);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillWater);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillEarth);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillEarth);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillEarth);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillEarth);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillSpirit);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillSpirit);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillSpirit);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillSpirit);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillMind);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillMind);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillMind);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillMind);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillBody);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillBody);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillBody);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillBody);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillLight);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillLight);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillLight);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillLight);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillDark);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillDark);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillDark);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillDark);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillItemId);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillItemId);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillItemId);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillItemId);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillMerchant);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillMerchant);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillMerchant);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillMerchant);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillRepair);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillRepair);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillRepair);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillRepair);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillBodybuilding);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillBodybuilding);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillBodybuilding);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillBodybuilding);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillMeditation);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillMeditation);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillMeditation);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillMeditation);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillPerception);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillPerception);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillPerception);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillPerception);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillDiplomacy);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillDiplomacy);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillDiplomacy);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillDiplomacy);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillThievery);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillThievery);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillThievery);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillThievery);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillDisarmTrap);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillDisarmTrap);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillDisarmTrap);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillDisarmTrap);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillDodge);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillDodge);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillDodge);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillDodge);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillUnarmed);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillUnarmed);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillUnarmed);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillUnarmed);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillMonsterId);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillMonsterId);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillMonsterId);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillMonsterId);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillArmsmaster);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillArmsmaster);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillArmsmaster);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillArmsmaster);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillStealing);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillStealing);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillStealing);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillStealing);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillAlchemy);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillAlchemy);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillAlchemy);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillAlchemy);
        sw.WriteLine((int)GetComponent<Party>().Players[0].skillLearning);
        sw.WriteLine((int)GetComponent<Party>().Players[1].skillLearning);
        sw.WriteLine((int)GetComponent<Party>().Players[2].skillLearning);
        sw.WriteLine((int)GetComponent<Party>().Players[3].skillLearning);

        //золото и еда
        sw.WriteLine("//золото и еда");
        sw.WriteLine((int)GetComponent<Party>().NumGold);
        sw.WriteLine((int)GetComponent<Party>().uNumFoodRations);

        //скилы и инвентарь
        sw.WriteLine("//скилы и инвентарь");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 37; j++)
            {
                sw.WriteLine((int)GetComponent<Party>().Players[i].ActiveSkills[j]);
            }
            for (int j = 0; j < 126; j++)
            {
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryItemList[j].HolderPlayer);
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryItemList[j].Attributes);
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryItemList[j].NumCharges);
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryItemList[j].SpecEnchantmentType);
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryItemList[j].EnchantmentStrength);
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryItemList[j].EnchantmentType);
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryItemList[j].ItemID);
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryItemList[j].BodyAnchor);
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryItemList[j].ExpireTime);
                sw.WriteLine((int)GetComponent<Party>().Players[i].InventoryMatrix[j]);
            }
        }


		TakeScrShot ();
        //Debug.Log((int)GetComponent<Party>().Players[3].ClassType);
        
        sw.Close(); // Закрываем(сохраняем)
	}

	private IEnumerator TakeScrShot()
	{
		yield return new WaitForEndOfFrame();

		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();

		var bytes = tex.EncodeToPNG();
		Destroy(tex);

		File.WriteAllBytes(Application.persistentDataPath + "Data/Save/screenshot.png", bytes);
		Debug.Log(Application.persistentDataPath + "Data/Save/screenshot.png");

	}
}