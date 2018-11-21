using UnityEngine;
using System.Collections;

public class MonsterInfo : MonoBehaviour {
	public enum SPECIAL_ATTACK_TYPE : uint
	{
		SPECIAL_ATTACK_NONE = 0,
		SPECIAL_ATTACK_CURSE = 1,
		SPECIAL_ATTACK_WEAK = 2,
		SPECIAL_ATTACK_SLEEP = 3,
		SPECIAL_ATTACK_DRUNK = 4,
		SPECIAL_ATTACK_INSANE = 5,
		SPECIAL_ATTACK_POISON_WEAK = 6,
		SPECIAL_ATTACK_POISON_MEDIUM = 7,
		SPECIAL_ATTACK_POISON_SEVERE = 8,
		SPECIAL_ATTACK_DISEASE_WEAK = 9,
		SPECIAL_ATTACK_DISEASE_MEDIUM = 10,
		SPECIAL_ATTACK_DISEASE_SEVERE = 11,
		SPECIAL_ATTACK_PARALYZED = 12,
		SPECIAL_ATTACK_UNCONSCIOUS = 13,
		SPECIAL_ATTACK_DEAD = 14,
		SPECIAL_ATTACK_PETRIFIED = 15,
		SPECIAL_ATTACK_ERADICATED = 16,
		SPECIAL_ATTACK_BREAK_ANY = 17,
		SPECIAL_ATTACK_BREAK_ARMOR = 18,
		SPECIAL_ATTACK_BREAK_WEAPON = 19,
		SPECIAL_ATTACK_STEAL = 20,
		SPECIAL_ATTACK_AGING = 21,
		SPECIAL_ATTACK_MANA_DRAIN = 22,
		SPECIAL_ATTACK_FEAR = 23,
	};
	public enum HostilityRadius: uint
	{
		Hostility_Friendly = 0,
		Hostility_Close = 1,
		Hostility_Short = 2,
		Hostility_Medium = 3,
		Hostility_Long = 4
	};
	
	public string pName;
	public string pPictureName;
	public uint uLevel;
	public uint uTreasureDropChance;
	public uint uTreasureDiceRolls;
	public uint uTreasureDiceSides;
	public uint uTreasureLevel;
	public uint uTreasureType;
	public uint uFlying;
	public uint uMovementType;
	public uint uAIType;
	HostilityRadius uHostilityType;
	//char field_12;
	SPECIAL_ATTACK_TYPE uSpecialAttackType;
	public uint uSpecialAttackLevel;
	public uint uAttack1Type;
	public uint uAttack1DamageDiceRolls;
	public uint uAttack1DamageDiceSides;
	public uint uAttack1DamageBonus;
	public uint uMissleAttack1Type;
	public uint uAttack2Chance;
	public uint uAttack2Type;
	public uint uAttack2DamageDiceRolls;
	public uint uAttack2DamageDiceSides;
	public uint uAttack2DamageBonus;
	public uint uMissleAttack2Type;
	public uint uSpell1UseChance;
	public uint uSpell1ID;
	public uint uSpell2UseChance;
	public uint uSpell2ID;
	public uint uResFire;
	public uint uResAir;
	public uint uResWater;
	public uint uResEarth;
	public uint uResMind;
	public uint uResSpirit;
	public uint uResBody;
	public uint uResLight;
	public uint uResDark;
	public uint uResPhysical;
	public uint uSpecialAbilityType;           // 0   SPECIAL_ABILITY_TYPE_NONE
	// 1   SPECIAL_ABILITY_TYPE_SHOT
	// 2   SPECIAL_ABILITY_TYPE_SUMMON
	// 3   SPECIAL_ABILITY_TYPE_EXPLODE
	public uint uSpecialAbilityDamageDiceRolls;
	public uint uSpecialAbilityDamageDiceSides;
	public uint uSpecialAbilityDamageDiceBonus;
	public uint uNumCharactersAttackedPerSpecialAbility;
	//char field_33;
	public uint uID;
	public uint bQuestMonster;
	public uint uSpellSkillAndMastery1;
	public uint uSpellSkillAndMastery2;
	public int field_3C_some_special_attack;
	//__int16 field_3E;
	public uint uHP;
	public uint uAC;
	public uint uExp;
	public uint uBaseSpeed;
	public int uRecoveryTime;
	public uint uAttackPreference;
	// Use this for initialization

}
