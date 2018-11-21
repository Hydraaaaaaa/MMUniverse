using UnityEngine;
using System.Collections;
using System.IO;

public class Load : MonoBehaviour {
	
	public float x = 0.0f;
	public float y = 0.0f;
	public float z = 0.0f;
	private string result = "";
    public GameObject mouse_select;

    const string savePath = "Data/Save";

	// Use this for initialization
	public void LoadGame () {

		if (!Directory.Exists (savePath)) {    
			Directory.CreateDirectory(savePath);
		}
		StreamReader streamReader = new StreamReader(savePath+"/Position.sg"); // Открываем файл

		if(streamReader != null)
        {
          while (!streamReader.EndOfStream) // Читаем строки пока они не закончатся
          {
			if(Temp.transition || Temp.transition_flag)
            {
                    if (Temp.CurrentMapName == "dragon_cave" && Temp.NextMapName == "emerald_01")
                    {
                        Temp.CurrentMapName = Temp.NextMapName;
                        Temp.transition = false;
                        Temp.transition_flag = false;
                        Debug.Log("Загрузка");
                        transform.position = new Vector3(-203.0f, 2.8f, -223.0f);
                        Debug.Log("Load" + transform.position);
                    }
                    else if (Temp.CurrentMapName == "Tample_of_moon" && Temp.NextMapName == "emerald_01")
                    {
                        Temp.CurrentMapName = Temp.NextMapName;
                        Temp.transition = false;
                        Temp.transition_flag = false;
                        Debug.Log("Загрузка");
                        transform.position = new Vector3(-221.0f, 17.8f, -167.0f);
                        Debug.Log("Load" + transform.position);
                    }
                    else if (Temp.CurrentMapName == "emerald_01" && Temp.NextMapName == "dragon_cave")
                    {
                        Temp.CurrentMapName = Temp.NextMapName;
                        Temp.transition = false;
                        Temp.transition_flag = false;
                        Debug.Log("Загрузка");
                        transform.position = new Vector3(-2.99f, 1.45f, -14.42f);
                        Debug.Log("Load" + transform.position);
                    }
                    else if (Temp.CurrentMapName == "emerald_01" && Temp.NextMapName == "Tample_of_moon")
                    {
                        Temp.CurrentMapName = Temp.NextMapName;
                        Temp.transition = false;
                        Temp.transition_flag = false;
                        Debug.Log("Загрузка");
                        transform.position = new Vector3(19.0f, 10.33f, 72.3f);
                        Debug.Log("Load" + transform.position);
                    }
            }
            else
            {
			  //x = System.Convert.ToSingle(streamReader.ReadLine());
			  //y = System.Convert.ToSingle(streamReader.ReadLine());
			  //z = System.Convert.ToSingle(streamReader.ReadLine());
			}

                // количество в группе
                string temp_text;
                temp_text = streamReader.ReadLine();// имена;
                GetComponent<Party>().players_Count = (int)System.Convert.ToSingle(streamReader.ReadLine());

                //имена
            temp_text = streamReader.ReadLine();// имена;
            if (Temp.Player0Name != null)
			  GetComponent<Party>().Players[0].Name = streamReader.ReadLine();// Temp.Player0Name;
			else
			  GetComponent<Party>().Players[0].Name = "Золтан";
            if (Temp.Player1Name != null)
               GetComponent<Party>().Players[1].Name = streamReader.ReadLine();//Temp.Player1Name;
                else
               GetComponent<Party>().Players[1].Name = "Родерик";
            if (Temp.Player2Name != null)
               GetComponent<Party>().Players[2].Name = streamReader.ReadLine();//Temp.Player2Name;
                else
               GetComponent<Party>().Players[2].Name = "Сирена";
            if (Temp.Player3Name != null)
               GetComponent<Party>().Players[3].Name = streamReader.ReadLine();//Temp.Player3Name;
                else
                GetComponent<Party>().Players[3].Name = "Алексис";

            temp_text = streamReader.ReadLine();//номер портрета
            GetComponent<Party>().Players[0].CurrentFace = (int)System.Convert.ToSingle(streamReader.ReadLine());
			Temp.Player1fileName = GetFilePath(GetComponent<Party>().Players[0].CurrentFace);
            Temp.Player1BodyfileID = GetComponent<Party>().Players[0].CurrentFace;
				//Debug.Log(Temp.Player1fileName);

			GetComponent<Party>().Players[1].CurrentFace = (int)System.Convert.ToSingle(streamReader.ReadLine());
			Temp.Player2fileName = GetFilePath(GetComponent<Party>().Players[1].CurrentFace);
            Temp.Player2BodyfileID = GetComponent<Party>().Players[1].CurrentFace;
				//Debug.Log(Temp.Player2fileName);

			GetComponent<Party>().Players[2].CurrentFace = (int)System.Convert.ToSingle(streamReader.ReadLine());
			Temp.Player3fileName = GetFilePath(GetComponent<Party>().Players[2].CurrentFace);
            Temp.Player3BodyfileID = GetComponent<Party>().Players[2].CurrentFace;
				//Debug.Log(Temp.Player3fileName);

			GetComponent<Party>().Players[3].CurrentFace = (int)System.Convert.ToSingle(streamReader.ReadLine());
			Temp.Player4fileName = GetFilePath(GetComponent<Party>().Players[3].CurrentFace);
            Temp.Player4BodyfileID = GetComponent<Party>().Players[3].CurrentFace;
                //Debug.Log(Temp.Player4fileName);

            temp_text = streamReader.ReadLine();//тип класса
            GetComponent<Party>().Players[0].ClassType = (PlayerStats.PlayerClassType)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].ClassType = (PlayerStats.PlayerClassType)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].ClassType = (PlayerStats.PlayerClassType)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].ClassType = (PlayerStats.PlayerClassType)System.Convert.ToSingle(streamReader.ReadLine());

            temp_text = streamReader.ReadLine();//характеристики
            GetComponent<Party>().Players[0].Might = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].Might = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].Might = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].Might = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].MightBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].MightBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].MightBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].MightBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].Intelligence = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].Intelligence = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].Intelligence = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].Intelligence = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].IntelligenceBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].IntelligenceBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].IntelligenceBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].IntelligenceBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].Willpower = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].Willpower = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].Willpower = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].Willpower = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].WillpowerBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].WillpowerBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].WillpowerBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].WillpowerBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].Endurance = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].Endurance = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].Endurance = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].Endurance = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].EnduranceBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].EnduranceBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].EnduranceBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].EnduranceBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].Speed = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].Speed = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].Speed = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].Speed = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].SpeedBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].SpeedBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].SpeedBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].SpeedBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].Accuracy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].Accuracy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].Accuracy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].Accuracy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].AccuracyBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].AccuracyBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].AccuracyBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].AccuracyBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].Luck = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].Luck = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].Luck = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].Luck = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].LuckBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].LuckBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].LuckBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].LuckBonus = (int)System.Convert.ToSingle(streamReader.ReadLine());

            temp_text = streamReader.ReadLine();//здоровье и сила
            GetComponent<Party>().Players[0].sHealth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].sHealth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].sHealth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].sHealth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].MaxHealth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].MaxHealth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].MaxHealth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].MaxHealth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].sMana = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].sMana = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].sMana = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].sMana = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].MaxMana = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].MaxMana = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].MaxMana = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].MaxMana = (int)System.Convert.ToSingle(streamReader.ReadLine());

            temp_text = streamReader.ReadLine();//возраст
            GetComponent<Party>().Players[0].BirthYear = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].BirthYear = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].BirthYear = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].BirthYear = (int)System.Convert.ToSingle(streamReader.ReadLine());

            temp_text = streamReader.ReadLine();//опыт
            GetComponent<Party>().Players[0].Experience = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].Experience = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].Experience = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].Experience = (int)System.Convert.ToSingle(streamReader.ReadLine());

            temp_text = streamReader.ReadLine();//уровень
            GetComponent<Party>().Players[0].Level = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].Level = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].Level = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].Level = (int)System.Convert.ToSingle(streamReader.ReadLine());

            temp_text = streamReader.ReadLine();//навыки
            GetComponent<Party>().Players[0].skillStaff = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillStaff = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillStaff = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillStaff = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillSword = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillSword = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillSword = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillSword = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillAxe = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillAxe = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillAxe = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillAxe = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillSpear = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillSpear = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillSpear = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillSpear = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillBow = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillBow = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillBow = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillBow = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillMace = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillMace = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillMace = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillMace = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillBlaster = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillBlaster = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillBlaster = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillBlaster = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillShield = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillShield = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillShield = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillShield = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillLeather = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillLeather = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillLeather = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillLeather = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillChain = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillChain = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillChain = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillChain = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillPlate = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillPlate = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillPlate = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillPlate = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillFire = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillFire = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillFire = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillFire = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillAir = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillAir = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillAir = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillAir = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillWater = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillWater = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillWater = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillWater = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillEarth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillEarth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillEarth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillEarth = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillSpirit = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillSpirit = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillSpirit = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillSpirit = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillMind = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillMind = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillMind = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillMind = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillBody = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillBody = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillBody = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillBody = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillLight = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillLight = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillLight = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillLight = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillDark = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillDark = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillDark = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillDark = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillItemId = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillItemId = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillItemId = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillItemId = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillMerchant = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillMerchant = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillMerchant = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillMerchant = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillRepair = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillRepair = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillRepair = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillRepair = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillBodybuilding = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillBodybuilding = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillBodybuilding = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillBodybuilding = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillMeditation = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillMeditation = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillMeditation = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillMeditation = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillPerception = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillPerception = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillPerception = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillPerception = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillDiplomacy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillDiplomacy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillDiplomacy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillDiplomacy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillThievery = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillThievery = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillThievery = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillThievery = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillDisarmTrap = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillDisarmTrap = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillDisarmTrap = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillDisarmTrap = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillDodge = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillDodge = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillDodge = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillDodge = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillUnarmed = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillUnarmed = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillUnarmed = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillUnarmed = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillMonsterId = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillMonsterId = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillMonsterId = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillMonsterId = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillArmsmaster = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillArmsmaster = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillArmsmaster = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillArmsmaster = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillStealing = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillStealing = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillStealing = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillStealing = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillAlchemy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillAlchemy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillAlchemy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillAlchemy = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[0].skillLearning = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[1].skillLearning = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[2].skillLearning = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().Players[3].skillLearning = (int)System.Convert.ToSingle(streamReader.ReadLine());

            temp_text = streamReader.ReadLine();//золото и еда
            GetComponent<Party>().NumGold = (int)System.Convert.ToSingle(streamReader.ReadLine());
            GetComponent<Party>().uNumFoodRations= (int)System.Convert.ToSingle(streamReader.ReadLine());

            temp_text = streamReader.ReadLine();//скилы и инвентарь
            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 37; j++) 
                {
                    GetComponent<Party>().Players[i].ActiveSkills[j] = (int)System.Convert.ToSingle(streamReader.ReadLine());
                }
                for (int j = 0; j < 126; j++)
                {
                    GetComponent<Party>().Players[i].InventoryItemList[j].HolderPlayer = (int)System.Convert.ToSingle(streamReader.ReadLine());
                    GetComponent<Party>().Players[i].InventoryItemList[j].Attributes = (int)System.Convert.ToSingle(streamReader.ReadLine());
                    GetComponent<Party>().Players[i].InventoryItemList[j].NumCharges = (int)System.Convert.ToSingle(streamReader.ReadLine());
                    GetComponent<Party>().Players[i].InventoryItemList[j].SpecEnchantmentType = (int)System.Convert.ToSingle(streamReader.ReadLine());
                    GetComponent<Party>().Players[i].InventoryItemList[j].EnchantmentStrength = (int)System.Convert.ToSingle(streamReader.ReadLine());
                    GetComponent<Party>().Players[i].InventoryItemList[j].EnchantmentType = (int)System.Convert.ToSingle(streamReader.ReadLine());
                    GetComponent<Party>().Players[i].InventoryItemList[j].ItemID = (int)System.Convert.ToSingle(streamReader.ReadLine());
                    GetComponent<Party>().Players[i].InventoryItemList[j].BodyAnchor = (int)System.Convert.ToSingle(streamReader.ReadLine());
                    GetComponent<Party>().Players[i].InventoryItemList[j].ExpireTime = (double)System.Convert.ToSingle(streamReader.ReadLine());
                    GetComponent<Party>().Players[i].InventoryMatrix[j] = (int)System.Convert.ToSingle(streamReader.ReadLine());
                }
            }

                Temp.Player1CurentFacePath = false;
			Temp.Player2CurentFacePath = false;
			Temp.Player3CurentFacePath = false;
			Temp.Player4CurentFacePath = false;
          }
		  if(x != 0.0f && y != 0.0f && z != 0.0f)
          {
			transform.position = new Vector3(x, y, z);
			Debug.Log("Load" + transform.position);
		  }
		}
        streamReader.Close();
        Temp.transition_flag = false;
    }

 	public string GetFilePath(int num){
		switch (num) {
		case 0:
			result = "Faces/PC01";
			break;
		case 1:
			result = "Faces/PC02";
			break;
		case 2:
			result = "Faces/PC03";
			break;
		case 3:
			result = "Faces/PC04";
			break;
		case 4:
			result = "Faces/PC05";
			break;
		case 5:
			result = "Faces/PC06";
			break;
		case 6:
			result = "Faces/PC07";
			break;
		case 7:
			result = "Faces/PC08";
			break;
		case 8:
			result = "Faces/PC09";
			break;
		case 9:
			result = "Faces/PC10";
			break;
		case 10:
			result = "Faces/PC11";
			break;
		case 11:
			result = "Faces/PC12";
			break;
		case 12:
			result = "Faces/PC13";
			break;
		case 13:
			result = "Faces/PC14";
			break;
		case 14:
			result = "Faces/PC15";
			break;
		case 15:
			result = "Faces/PC16";
			break;
		case 16:
			result = "Faces/PC17";
			break;
		case 17:
			result = "Faces/PC18";
			break;
		case 18:
			result = "Faces/PC19";
			break;
		case 19:
			result = "Faces/PC20";
			break;
		}
		return result;
	}
}
