/// <summary>
/// Player stats.
/// Хранит данные о игроке
/// Вешать на игрока
/// </summary>
using UnityEngine;
using System.Collections;
//#include <array>

public class PlayerStats : MonoBehaviour {
	
	public bool[] Conditions = new bool[18];
	public int Experience;
	public string Name;
	public PlayerSex Sex;
	public PlayerClassType ClassType;
	public int CurrentFace;
	public int Might;
	public int MightBonus;
	public int Intelligence;
	public int IntelligenceBonus;
	public int Willpower;
	public int WillpowerBonus;
	public int Endurance;
	public int EnduranceBonus;
	public int Speed;
	public int SpeedBonus;
	public int Accuracy;
	public int AccuracyBonus;
	public int Luck;
	public int LuckBonus;
	public int ACModifier;
	public int Level;
	public int LevelModifier;
	public int AgeModifier;
	//skills
	public int skillStaff;
	public int skillSword;
	public int skillDagger;
	public int skillAxe;
	public int skillSpear;
	public int skillBow;
	public int skillMace;
	public int skillBlaster;
	public int skillShield;
	public int skillLeather;
	public int skillChain;
	public int skillPlate;
	public int skillFire;
	public int skillAir;
	public int skillWater;
	public int skillEarth;
	public int skillSpirit;
	public int skillMind;
	public int skillBody;
	public int skillLight;
	public int skillDark;
	public int skillItemId;
	public int skillMerchant;
	public int skillRepair;
	public int skillBodybuilding;
	public int skillMeditation;
	public int skillPerception;
	public int skillDiplomacy;
	public int skillThievery;
	public int skillDisarmTrap;
	public int skillDodge;
	public int skillUnarmed;
	public int skillMonsterId;
	public int skillArmsmaster;
	public int skillStealing;
	public int skillAlchemy;
	public int skillLearning;
	public int[] ActiveSkills = new int[37];
	public int[] AwardsBits = new int[64];
	public PlayerSpells spellbook;
	public int pure_luck_used;
	public int pure_speed_used;
	public int pure_intellect_used;
	public int pure_endurance_used;
	public int pure_willpower_used;
	public int pure_accuracy_used;
	public int pure_might_used;

	public ItemGen[] InventoryItemList = new ItemGen[126];//126
	public ItemGen[] EquippedItems;//12
	public ItemGen[] OwnItems;//138
	public int[] InventoryMatrix = new int[126];

	public int ResFireBase;
	public int ResAirBase;
	public int ResWaterBase;
	public int ResEarthBase;
	public int ResMagicBase;
	public int ResSpiritBase;
	public int ResMindBase;
	public int ResBodyBase;
	public int ResLightBase;
	public int ResDarkBase;
	public int ResFireBonus;
	public int ResAirBonus;
	public int ResWaterBonus;
	public int ResEarthBonus;
	public int ResMagicBonus;
	public int ResSpiritBonus;
	public int ResMindBonus;
	public int ResBodyBonus;
	public int ResLightBonus;
	public int ResDarkBonus;

	public SpellBuffs[] PlayerBuffs=new SpellBuffs[24];
	public int VoiceID;
	public int PrevVoiceID;
	public int PrevFace;
	public int TimeToRecovery;
	public int SkillPoints = 0;

	public int MaxHealth; // Максимальное количество здоровья
    public int sHealth;
	public int CurHealth; // Текущее количество здоровья
	public int MaxMana; // Максимально количество маны
    public int sMana;
	public int CurMana; // Текущее количество маны

	public int BirthYear;
	public PlayerEquipment Equipment;
	public char lastOpenedSpellbookPage;
	public int QuickSpell;
	public char[] playerEventBits = new char[64];
	public char some_attack_bonus;
	public char melee_dmg_bonus;
	public char ranged_attack_bonus;
	public char ranged_dmg_bonus;

	public int FullHealthBonus = 0;
	public char health_related;
	public char FullManaBonus;
	public char mana_related;

	public Character_expression_ID expression;
	public float ExpressionTimePassed;
	public int ExpressionTimeLength;
	public int expression21_animtime;
	public int expression21_frameset;
	public LloydBeacon[] InstalledBeacons;

	public char NumDivineInterventionCastsThisDay;
	public char NumArmageddonCasts;
	public char NumFireSpikeCasts;

    public int current_helm;
    public int current_armor;
    public int current_weapon1;
    public int current_weapon2;
    public int current_shield;
    public int current_belt;
    public int current_cloak;
    public int current_boot;
    public int current_bow;

    public enum PLAYER_BUFFS
    {
        PLAYER_BUFF_RESIST_AIR = 0,
        PLAYER_BUFF_BLESS = 1,
        PLAYER_BUFF_RESIST_BODY = 2,
        PLAYER_BUFF_RESIST_EARTH = 3,
        PLAYER_BUFF_FATE = 4,
        PLAYER_BUFF_RESIST_FIRE = 5,
        PLAYER_BUFF_HAMMERHANDS = 6,
        PLAYER_BUFF_HASTE = 7,
        PLAYER_BUFF_HEROISM = 8,
        PLAYER_BUFF_RESIST_MIND = 9,
        PLAYER_BUFF_PAIN_REFLECTION = 10,
        PLAYER_BUFF_PRESERVATION = 11,
        PLAYER_BUFF_REGENERATION = 12,
        PLAYER_BUFF_SHIELD = 13,
        PLAYER_BUFF_STONESKIN = 14,
        PLAYER_BUFF_ACCURACY = 15,
        PLAYER_BUFF_ENDURANCE = 16,
        PLAYER_BUFF_INTELLIGENCE = 17,
        PLAYER_BUFF_LUCK = 18,
        PLAYER_BUFF_STRENGTH = 19,
        PLAYER_BUFF_WILLPOWER = 20,
        PLAYER_BUFF_SPEED = 21,
        PLAYER_BUFF_RESIST_WATER = 22,
        PLAYER_BUFF_WATER_WALK = 23
    };

	public enum PLAYER_CLASS_TYPE
	{
		PLAYER_CLASS_KNIGHT = 0,
		PLAYER_CLASS_CHEVALIER = 1,
		PLAYER_CLASS_CHAMPION = 2,
		PLAYER_CLASS_BLACK_KNIGHT = 3,
		PLAYER_CLASS_THEIF = 4,
		PLAYER_CLASS_ROGUE = 5,
		PLAYER_CLASS_SPY = 6,
		PLAYER_CLASS_ASSASSIN = 7,
		PLAYER_CLASS_MONK = 8,
		PLAYER_CLASS_INITIATE = 9,
		PLAYER_CLASS_MASTER = 10,
		PLAYER_CLASS_NINJA = 11,
		PLAYER_CLASS_PALADIN = 12,
		PLAYER_CLASS_CRUSADER = 13,
		PLAYER_CLASS_HERO = 14,
		PLAYER_CLASS_VILLIAN = 15,
		PLAYER_CLASS_ARCHER = 16,
		PLAYER_CLASS_WARRIOR_MAGE = 17,
		PLAYER_CLASS_MASTER_ARCHER = 18,
		PLAYER_CLASS_SNIPER = 19,
		PLAYER_CLASS_RANGER = 20,
		PLAYER_CLASS_HUNTER = 21,
		PLAYER_CLASS_RANGER_LORD = 22,
		PLAYER_CLASS_BOUNTY_HUNTER = 23,
		PLAYER_CLASS_CLERIC = 24,
		PLAYER_CLASS_PRIEST = 25,
		PLAYER_CLASS_PRIEST_OF_SUN = 26,
		PLAYER_CLASS_PRIEST_OF_MOON = 27,
		PLAYER_CLASS_DRUID = 28,
		PLAYER_CLASS_GREAT_DRUID = 29,
		PLAYER_CLASS_ARCH_DRUID = 30,
		PLAYER_CLASS_WARLOCK = 31,
		PLAYER_CLASS_SORCERER = 32,
		PLAYER_CLASS_WIZARD = 33,
		PLAYER_CLASS_ARCHMAGE = 34,
		PLAYER_CLASS_LICH = 35
	};
    public PlayerStats() {
        InventoryItemList = new ItemGen[126];
    }
	public PlayerStats(int a, int b, int c, int d){
		InventoryItemList = new ItemGen[a];
		EquippedItems = new ItemGen[b];
		OwnItems = new ItemGen[c];
		PlayerBuffs = new SpellBuffs[24];
		InstalledBeacons = new LloydBeacon[5];

	}
    //----- (00402F07) --------------------------------------------------------
    public void InventoryItemListReset(uint i)
    {
      InventoryItemList[i].HolderPlayer = 0;
      InventoryItemList[i].Attributes = 0;
      InventoryItemList[i].NumCharges = 0;
      InventoryItemList[i].SpecEnchantmentType = 0;// ITEM_ENCHANTMENT_NULL;
      InventoryItemList[i].EnchantmentStrength = 0;
      InventoryItemList[i].EnchantmentType = 0;
      InventoryItemList[i].ItemID = -1;// ITEM_NULL;
      InventoryItemList[i].BodyAnchor = 0;
      InventoryItemList[i].ExpireTime = 0;
    }
	public struct LloydBeacon
	{
		public double BeaconTime;
		public int PartyPos_X;
		public int PartyPos_Y;
		public int PartyPos_Z;
		public int PartyRot_X;
		public int PartyRot_Y;
		public int SaveFileID;
	}
	public enum PLAYER_SKILL_TYPE
	{
		PLAYER_SKILL_STAFF = 0,
		PLAYER_SKILL_SWORD = 1,
		PLAYER_SKILL_DAGGER = 2,
		PLAYER_SKILL_AXE = 3,
		PLAYER_SKILL_SPEAR = 4,
		PLAYER_SKILL_BOW = 5,
		PLAYER_SKILL_MACE = 6,
		PLAYER_SKILL_BLASTER = 7,
		PLAYER_SKILL_SHIELD = 8,
		PLAYER_SKILL_LEATHER = 9,
		PLAYER_SKILL_CHAIN = 10,
		PLAYER_SKILL_PLATE = 11,
		PLAYER_SKILL_FIRE = 12,
		PLAYER_SKILL_AIR = 13,
		PLAYER_SKILL_WATER = 14,
		PLAYER_SKILL_EARTH = 15,
		PLAYER_SKILL_SPIRIT = 16,
		PLAYER_SKILL_MIND = 17,
		PLAYER_SKILL_BODY = 18,
		PLAYER_SKILL_LIGHT = 19,
		PLAYER_SKILL_DARK = 20,
		PLAYER_SKILL_ITEM_ID = 21,
		PLAYER_SKILL_MERCHANT = 22,
		PLAYER_SKILL_REPAIR = 23,
		PLAYER_SKILL_BODYBUILDING = 24,
		PLAYER_SKILL_MEDITATION = 25,
		PLAYER_SKILL_PERCEPTION = 26,
		PLAYER_SKILL_DIPLOMACY = 27,
		PLAYER_SKILL_TIEVERY = 28,
		PLAYER_SKILL_TRAP_DISARM = 29,
		PLAYER_SKILL_DODGE = 30,
		PLAYER_SKILL_UNARMED = 31,
		PLAYER_SKILL_MONSTER_ID = 32,
		PLAYER_SKILL_ARMSMASTER = 33,
		PLAYER_SKILL_STEALING = 34,
		PLAYER_SKILL_ALCHEMY = 35,
		PLAYER_SKILL_LEARNING = 36,
		PLAYER_SKILL_CLUB = 37,
		PLAYER_SKILL_MISC = 38,
		PLAYER_SKILL_INVALID = -1
	};
	public enum Character_expression_ID
	{
        CHARACTER_EXPRESSION_INVALID = 0,
        CHARACTER_EXPRESSION_NORMAL = 1,      //нормальный
        CHARACTER_EXPRESSION_CURSED = 2,      //отравлен
        CHARACTER_EXPRESSION_WEAK = 3,        //слабость
        CHARACTER_EXPRESSION_SLEEP = 4,       //спит
        CHARACTER_EXPRESSION_FEAR = 5,        //страх
        CHARACTER_EXPRESSION_DRUNK = 6,       //пьян
        CHARACTER_EXPRESSION_INSANE = 7,      //безумие
        CHARACTER_EXPRESSION_POISONED = 8,    //отравлен
        CHARACTER_EXPRESSION_DISEASED = 9,    //болен
        CHARACTER_EXPRESSION_PARALYZED = 10,  //парализован
        CHARACTER_EXPRESSION_UNCONCIOUS = 11, //без сознания
        CHARACTER_EXPRESSION_PERTIFIED = 12,  //окаменел
        CHARACTER_EXPRESSION_CLOSED_EYES = 13,// закрыл глаза
        CHARACTER_EXPRESSION_BLINKED = 14,    //моргание
        CHARACTER_EXPRESSION_OPENED_MOUTH1 = 15,//открыть рот1
        CHARACTER_EXPRESSION_OPENED_MOUTH2 = 16,//открыть рот шире
        CHARACTER_EXPRESSION_VIEWUP = 17,     // взгляд вверх
        CHARACTER_EXPRESSION_VIEWRIGHT = 18,  // взгляд вправо
        CHARACTER_EXPRESSION_VIEWLEFT = 19,   // взгляд влево
        CHARACTER_EXPRESSION_VIEWDOWN = 20,   // взгляд вниз
        CHARACTER_EXPRESSION_SURPRISE1 = 21,  //сюрприз1
        CHARACTER_EXPRESSION_SURPRISE2 = 22,  //сюрприз2
        CHARACTER_EXPRESSION_SURPRISE3 = 23,  //
        CHARACTER_EXPRESSION_SURPRISE4 = 24,  //
        CHARACTER_EXPRESSION_BIG_TURN_RIGHT = 25,         //
        CHARACTER_EXPRESSION_SMALL_TURN_RIGHT = 26,         //
        CHARACTER_EXPRESSION_CENTER = 27,         //
        CHARACTER_EXPRESSION_SMALL_TURN_LEFT = 28,         //
        CHARACTER_EXPRESSION_BIG_TURN_LEFT = 29,         //
        CHARACTER_EXPRESSION_BIG_TURN_DOWN = 30,         //
        CHARACTER_EXPRESSION_SMALL_TURN_DOWN = 31,         //
        CHARACTER_EXPRESSION_SMALL_TURN_UP = 32,         //
        CHARACTER_EXPRESSION_BIG_TURN_UP = 33,         //
        CHARACTER_EXPRESSION_SQUATTING_SMALL = 34,     //присел
        CHARACTER_EXPRESSION_SQUATTING_MEDIUM = 35,  //
        CHARACTER_EXPRESSION_SQUATTING_BIG = 36,     //
        CHARACTER_EXPRESSION_DMGRECVD_MINOR = 37,                 //
        CHARACTER_EXPRESSION_DMGRECVD_MODERATE = 38,                 //
        CHARACTER_EXPRESSION_DMGRECVD_MAJOR = 39,                 //
        CHARACTER_EXPRESSION_SMILE = 40,//улыбка
        CHARACTER_EXPRESSION_LAUGH = 41,//смех
        CHARACTER_EXPRESSION_SADNESS = 42,//грусть
        CHARACTER_EXPRESSION_ANGER = 43,//злость
        CHARACTER_EXPRESSION_SHOCK = 44,//шок
        CHARACTER_EXPRESSION_SHAME = 45,//досада
        CHARACTER_EXPRESSION_TENDER = 46,             // нежность
        CHARACTER_EXPRESSION_APATHY = 47,                 //
        CHARACTER_EXPRESSION_SMIRK = 48,                 //ухмылка
        CHARACTER_EXPRESSION_CRY = 49,                 //крик
        CHARACTER_EXPRESSION_EUREKA = 50,                 //
        CHARACTER_EXPRESSION_RAISED_EYEBROW_BIG = 51,                 //бровка вверх
        CHARACTER_EXPRESSION_RAISED_EYEBROW_SMAL = 52,                 //
        CHARACTER_EXPRESSION_AGRESSOR = 53,                 //
        CHARACTER_EXPRESSION_RED = 54,                 //краснеет
        CHARACTER_EXPRESSION_TIPSY = 55,                 //на веселе
        CHARACTER_EXPRESSION_SCARED = 56,                 //испуган
        CHARACTER_EXPRESSION_57 = 57,                 //
        CHARACTER_EXPRESSION_FALLING = 58,            //падение
        CHARACTER_EXPRESSION_DEAD = 98,               //мертв
        CHARACTER_EXPRESSION_ERADICATED = 99,         //уничтожен
    };
	public struct PlayerEquipment
	{
		public int Shield;
		public int MainHund;
		public int Bow;
		public int Armor;
		public int Helm;
		public int Belt;
		public int Cloak;
		public int Glove;
		public int Boot;
		public int Amulet;
		public char[] Rings;//6
		public char[] Indices;//16
		PlayerEquipment(int a, int b)
		{
			Shield = 0;
			MainHund = 0;
			Bow = 0;
			Armor = 0;
			Helm = 0;
			Belt = 0;
			Cloak = 0;
			Glove = 0;
			Boot = 0;
			Amulet = 0;
			Rings = new char[a];
			Indices = new char[b];
		}
	}

	public struct SpellBuffs
	{
		public double ExpireTime;
		public int Power;
		public int Skill;
		public int OwerlayID;
		public int Caster;
		public int Flags;
		SpellBuffs(int a)//0
		{
			ExpireTime = a;
			Power = a;
			Skill = a;
			OwerlayID = a;
			Caster = a;
			Flags = a;
		}
	}

	public struct ItemGen
	{
		public int ItemID;
		public int EnchantmentType;
		public int EnchantmentStrength;
		public int SpecEnchantmentType;
		public int NumCharges;
        public int BodyAnchor;
		public int Attributes;
		public int MaxCharges;
		public int HolderPlayer;
		public double ExpireTime;
	}

	public struct PlayerSpells
	{
		public PlayerSpellbookChapter FireSpellbook;
		public PlayerSpellbookChapter AirSpellbook;
		public PlayerSpellbookChapter WaterSpellbook;
		public PlayerSpellbookChapter EarthSpellbook;
		public PlayerSpellbookChapter SpiritSpellbook;
		public PlayerSpellbookChapter MindSpellbook;
		public PlayerSpellbookChapter BodySpellbook;
		public PlayerSpellbookChapter LightSpellbook;
		public PlayerSpellbookChapter DarkSpellbook;
		public char[] Chapters;
		public char[] HaveSpell;
		public PlayerSpells(int a, int b){
			FireSpellbook = new PlayerSpellbookChapter(11);
			AirSpellbook = new PlayerSpellbookChapter(11);
			WaterSpellbook = new PlayerSpellbookChapter(11);
			EarthSpellbook = new PlayerSpellbookChapter(11);
			SpiritSpellbook = new PlayerSpellbookChapter(11);
			MindSpellbook = new PlayerSpellbookChapter(11);
			BodySpellbook = new PlayerSpellbookChapter(11);
			LightSpellbook = new PlayerSpellbookChapter(11);
			DarkSpellbook = new PlayerSpellbookChapter(11);

			Chapters = new char[a];
			HaveSpell = new char[b];
		}
	};
	public struct PlayerSpellbookChapter
	{
		public char[] IsSpellAvailable;//11
		public PlayerSpellbookChapter(int a){
			IsSpellAvailable = new char[a];
		}
	};

	public enum PlayerSex : int {
		Male = 0,
		Female = 1
	};
	public enum PlayerClassType : int {
		Knight = 0,
		Chevalier = 1,
		Champion = 2,
		BlackKnight = 3,
		Theif = 4,
		Rogue = 5,
		Spy = 6,
		Assassin = 7,
		Monk = 8,
		Initiate = 9,
		Master = 10,
		Ninja = 11,
		Paladin = 12,
		Crusader = 13,
		Hero = 14,
		Villian = 15,
		Archer = 16,
		Varrior_mage = 17,
		Master_archer = 18,
		Sniper = 19,
		Ranger = 20,
		Hunter = 21,
		Ranger_lord = 22,
		Bounty_hunter = 23,
		Cleric = 24,
		Priest = 25,
		Priest_of_sun = 26,
		Priest_of_moon = 27,
		Druid = 28,
		Great_druid = 29,
		Arch_druid = 30,
		Warlock = 31,
		Sorcerer = 32,
		Wizard = 33,
		Archmage = 34,
		Lich = 35
	};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(MaxHealth < CurHealth) CurHealth = MaxHealth;
		if(MaxMana < CurMana) CurMana = MaxMana;
	}
    public enum CHARACTER_RACE
    {
        CHARACTER_RACE_HUMAN = 0,
        CHARACTER_RACE_ELF = 1,
        CHARACTER_RACE_GOBLIN = 2,
        CHARACTER_RACE_DWARF = 3,
    };

	/*short[] param_to_bonus_table=new short[]{500, 400, 350, 300, 275, 250, 225, 200, 175,
		150, 125, 100,  75,  50,  40,  35,  30,  25,  21,
		19,   17,  15,  13,  11,   9,   7,   5,   3,   0};
	int[] parameter_to_bonus_value = new int[]{30, 25, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6};
    */
    public enum CHARACTER_ATTRIBUTE_TYPE : int {
		CHARACTER_ATTRIBUTE_STRENGTH          = 0,
		CHARACTER_ATTRIBUTE_INTELLIGENCE      = 1,
		CHARACTER_ATTRIBUTE_WILLPOWER         = 2,
		CHARACTER_ATTRIBUTE_ENDURANCE         = 3,
		CHARACTER_ATTRIBUTE_ACCURACY          = 4,
		CHARACTER_ATTRIBUTE_SPEED             = 5,
		CHARACTER_ATTRIBUTE_LUCK              = 6,
		CHARACTER_ATTRIBUTE_HEALTH            = 7,
		CHARACTER_ATTRIBUTE_MANA              = 8,
		CHARACTER_ATTRIBUTE_AC_BONUS          = 9,
		
		CHARACTER_ATTRIBUTE_RESIST_FIRE       = 10,
		CHARACTER_ATTRIBUTE_RESIST_AIR        = 11,
		CHARACTER_ATTRIBUTE_RESIST_WATER      = 12,
		CHARACTER_ATTRIBUTE_RESIST_EARTH      = 13,
		CHARACTER_ATTRIBUTE_RESIST_MIND       = 14,
		CHARACTER_ATTRIBUTE_RESIST_BODY       = 15,
		
		CHARACTER_ATTRIBUTE_SKILL_ALCHEMY     = 16,
		CHARACTER_ATTRIBUTE_SKILL_STEALING    = 17,
		CHARACTER_ATTRIBUTE_SKILL_TRAP_DISARM = 18,
		CHARACTER_ATTRIBUTE_SKILL_ITEM_ID     = 19,
		CHARACTER_ATTRIBUTE_SKILL_MONSTER_ID  = 20,
		CHARACTER_ATTRIBUTE_SKILL_ARMSMASTER  = 21,
		CHARACTER_ATTRIBUTE_SKILL_DODGE       = 22,
		CHARACTER_ATTRIBUTE_SKILL_UNARMED     = 23,
		
		CHARACTER_ATTRIBUTE_LEVEL             = 24,
		CHARACTER_ATTRIBUTE_ATTACK            = 25,
		CHARACTER_ATTRIBUTE_MELEE_DMG_BONUS   = 26,
		CHARACTER_ATTRIBUTE_MELEE_DMG_MIN     = 27,
		CHARACTER_ATTRIBUTE_MELEE_DMG_MAX     = 28,
		CHARACTER_ATTRIBUTE_RANGED_ATTACK     = 29,
		CHARACTER_ATTRIBUTE_RANGED_DMG_BONUS  = 30,
		CHARACTER_ATTRIBUTE_RANGED_DMG_MIN    = 31,
		CHARACTER_ATTRIBUTE_RANGED_DMG_MAX    = 32,
		CHARACTER_ATTRIBUTE_RESIST_SPIRIT     = 33,
		
		CHARACTER_ATTRIBUTE_SKILL_FIRE        = 34,
		CHARACTER_ATTRIBUTE_SKILL_AIR         = 35,
		CHARACTER_ATTRIBUTE_SKILL_WATER       = 36,
		CHARACTER_ATTRIBUTE_SKILL_EARTH       = 37,
		CHARACTER_ATTRIBUTE_SKILL_SPIRIT      = 38,
		CHARACTER_ATTRIBUTE_SKILL_MIND        = 39,
		CHARACTER_ATTRIBUTE_SKILL_BODY        = 40,
		CHARACTER_ATTRIBUTE_SKILL_LIGHT       = 41,
		CHARACTER_ATTRIBUTE_SKILL_DARK        = 42,
		CHARACTER_ATTRIBUTE_SKILL_MEDITATION  = 43,
		CHARACTER_ATTRIBUTE_SKILL_BOW         = 44,
		CHARACTER_ATTRIBUTE_SKILL_SHIELD      = 45,
		CHARACTER_ATTRIBUTE_SKILL_LEARNING    = 46
	};
    /*
	uint[] pAgeingTable = new uint[] {50, 100, 150, 0xFFFF};

	uchar[,] pAgingAttributeModifier = new uchar[][]{{100,  75,  40, 10},   //Might
		{100, 150, 100, 10},   //Intelligence
		{100, 150, 100, 10},   //Willpower
		{100,  75,  40, 10},   //Endurance
		{100, 100,  40, 10},   //Accuracy
		{100, 100,  40, 10},   //Speed
		{100, 100, 100, 100}}; //Luck

	uchar[,] pConditionAttributeModifier= new uchar[][]{{100, 100, 100, 120,  50, 200,  75,  60,  50,  30,  25,  10, 100, 100, 100, 100, 100, 100, 100},  //Might
		{100, 100, 100,  50,  25,  10, 100, 100,  75,  60,  50,  30, 100, 100, 100, 100, 100,   1, 100},  //Intelligence
		{100, 100, 100,  50,  25,  10, 100, 100,  75,  60,  50,  30, 100, 100, 100, 100, 100,   1, 100},  //Willpower
		{100, 100, 100, 100,  50, 150,  75,  60,  50,  30,  25,  10, 100, 100, 100, 100, 100, 100, 100},  //Endurance
		{100, 100, 100,  50,  10, 100,  75,  60,  50,  30,  25,  10, 100, 100, 100, 100, 100,  50, 100},  //Accuracy
		{100, 100, 100, 120,  20, 120,  75,  60,  50,  30,  25,  10, 100, 100, 100, 100, 100,  50, 100},  //Speed
		{100, 100, 100, 100, 200, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100}}; //Luck

	uint[] pConditionImportancyTable = new uint[]{{16, 15, 14, 17, 13, 2, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 1, 0}};*/


}
