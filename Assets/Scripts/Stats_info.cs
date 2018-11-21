using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats_info : MonoBehaviour {
    public GUISkin skin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        string name = "";
        int exp = 0;

        if (Temp.current_inventory_window == 1 && GameObject.Find("Stats_window").GetComponent<Image>().enabled == true)//Stats
        {
            GUI.skin = skin;
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
            switch (Temp.ActiveCharacter)
            {
                case 1:
                    name = GameObject.Find("Player0").GetComponent<PlayerStats>().Name;
                    classType = Temp.pClassNames[(int)GameObject.Find("Player0").GetComponent<PlayerStats>().ClassType];
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
                        qspell = GameObject.Find("Player0").GetComponent<PlayerStats>().QuickSpell + "";//pSpellStats->pInfos[GameObject.Find("Player0").GetComponent<PlayerStats>().QuickSpell].pShortName;
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
            GUI.color = new Color(209, 187, 0, 1);
            if (name != "")
                GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 162, name.Length * 16 + classType.Length * 16, 20), name + "  " + classType);
            else
                GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 162, 70 + classType.Length * 16, 20), "name  " + classType);
            GUI.color = Color.white;
            GUI.skin.box.alignment = TextAnchor.MiddleRight;
            GUI.Box(new Rect((Screen.width / 2) + 65, (Screen.height / 2) - 162, 150, 20), "Очки навыков: " + exp);
            GUI.skin.box.alignment = TextAnchor.MiddleLeft;
            GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) - 125, 65, 20), "Сила ");
            GUI.skin.box.alignment = TextAnchor.MiddleCenter;
            GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) - 125, 90, 20), abs_might + "/" + curent_might);
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
            GUI.Box(new Rect((Screen.width / 2) - 70, (Screen.height / 2) + 46, 90, 20), AC_cur + "/" + AC_max);
            GUI.skin.box.alignment = TextAnchor.MiddleLeft;
            GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) + 86, 220, 20), "Состояние: " + condition);
            GUI.Box(new Rect((Screen.width / 2) - 220, (Screen.height / 2) + 104, 220, 20), "Б.заклинание: " + qspell);

            GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 125, 100, 20), "Возраст");
            GUI.skin.box.alignment = TextAnchor.MiddleCenter;
            GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) - 125, 90, 20), age_m + "/" + age);
            GUI.skin.box.alignment = TextAnchor.MiddleLeft;
            GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 108, 85, 20), "Уров.");
            GUI.skin.box.alignment = TextAnchor.MiddleCenter;
            GUI.Box(new Rect((Screen.width / 2) + 125, (Screen.height / 2) - 108, 90, 20), "" + level);
            GUI.skin.box.alignment = TextAnchor.MiddleLeft;
            GUI.Box(new Rect((Screen.width / 2) + 35, (Screen.height / 2) - 90, 85, 20), "Опыт");
            GUI.skin.box.alignment = TextAnchor.MiddleRight;
            if (CanTrain)
                GUI.color = Color.green;
            GUI.Box(new Rect((Screen.width / 2) + 100, (Screen.height / 2) - 90, 120, 20), "" + exper);

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
	}
}
