using UnityEngine;
using System.Collections;

public class Actors : MonoBehaviour {
	/*public enum AIState : uint
	{
		Standing = 0x0,
		Tethered = 0x1,
		AttackingMelee = 0x2,
		AttackingRanged1 = 0x3,
		Dying = 0x4,
		Dead = 0x5,
		Pursuing = 0x6,
		Fleeing = 0x7,
		Stunned = 0x8,
		Fidgeting = 0x9,
		Interacting = 10,
		Removed = 11,
		AttackingRanged2 = 0xC,
		AttackingRanged3 = 0xD,
		Stoned = 0xE,
		Paralyzed = 0xF,
		Resurrected = 16,
		Summoned = 17,
		AttackingRanged4 = 18,
		Disabled = 19,
	};*/
	struct SpellBuff
	{
		int uExpireTime;
		uint uPower;
		uint uSkill;
		uint uOverlayID;
		uint uCaster;
		uint uFlags;
	};

	public string pActorName;
	public int sNPC_ID;
	//public int field_22;
	public uint uAttributes;
	public int sCurrentHP;
	//public char field_2A[2];
	MonsterInfo pMonsterInfo;
	public int word_000084_range_attack;
	public int word_000086_some_monster_id;
	public uint uActorRadius;
	public uint uActorHeight;
	public uint uMovementSpeed;
	Vector3 vPosition;
	Vector3 vVelocity;
	public uint uYawAngle;
	public uint uPitchAngle;
	public int uSectorID;
	public uint uCurrentActionLength;
	Vector3 vInitialPosition;
	Vector3 vGuardingPosition;
	public uint uTetherDistance;
	//public AIState uAIState = AIState.Standing;
	public uint uCurrentActionAnimation;
	public uint uCarriedItemID;
	//char field_B6;
	//char field_B7;
	public uint uCurrentActionTime;
	public uint[] pSpriteIDs = new uint[8];
	public uint[] pSoundSampleIDs = new uint[4]; // 1 die     3 bored
	//SpellBuff pActorBuffs[22];
	//struct ItemGen ActorHasItems[4];
	public uint uGroup;
	public uint uAlly;
	//struct ActorJob pScheduledJobs[8];
	public uint uSummonerID;
	public uint uLastCharacterIDToHit;
	int dword_000334_unique_name;
    //char field_338[12];
    public bool Actor_visible;
    public bool Actor_fly;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//----- (00401A91) --------------------------------------------------------
	void UpdateActorAI()
	{
		/*signed int v4; // edi@10
		signed int sDmg; // eax@14
		Player *pPlayer; // ecx@21
		Actor *pActor; // esi@34
		//unsigned __int16 v22; // ax@86
		unsigned int v27; // ecx@123
		unsigned int v28; // eax@123
		int v33; // eax@144
		int v34; // eax@147
		char v35; // al@150
		unsigned int v36; // edi@152
		signed int v37; // eax@154
		double v42; // st7@176
		double v43; // st6@176
		int v45; // eax@192
		unsigned __int8 v46; // cl@197
		signed int v47; // st7@206
		uint v58; // st7@246
		unsigned int v65; // [sp-10h] [bp-C0h]@144
		int v70; // [sp-10h] [bp-C0h]@213
		AIDirection v72; // [sp+0h] [bp-B0h]@246
		AIDirection a3; // [sp+1Ch] [bp-94h]@129
		int target_pid_type; // [sp+70h] [bp-40h]@83
		signed int a1; // [sp+74h] [bp-3Ch]@129
		int v78; // [sp+78h] [bp-38h]@79
		AIDirection* pDir; // [sp+7Ch] [bp-34h]@129
		float radiusMultiplier; // [sp+98h] [bp-18h]@33
		int v81; // [sp+9Ch] [bp-14h]@100
		signed int target_pid; // [sp+ACh] [bp-4h]@83
		AIState uAIState;
		uint v38;*/
		
		//Build AI array
		//if ( Temp.uCurrentlyLoadedLevelType == Temp.LEVEL_TYPE.LEVEL_Outdoor)
			MakeActorAIList_ODM();
		//else
			//Actor::MakeActorAIList_BLV();
		
		//Armageddon damage mechanic
		if ( Temp.uCurrentlyLoadedLevelType == Temp.LEVEL_TYPE.LEVEL_Outdoor /*&& pParty->armageddon_timer > 0*/ )
		{
			/*if ( pParty->armageddon_timer > 417 )
				pParty->armageddon_timer = 0;
			else
			{
				pParty->sRotationY = (stru_5C6E00->uIntegerDoublePi - 1) & (pParty->sRotationY + rand() % 16 - 8);
				pParty->sRotationX = pParty->sRotationX + rand() % 16 - 8;
				if ( pParty->sRotationX > 128) 
					pParty->sRotationX = 128;
				else if ( pParty->sRotationX < -128 )
					pParty->sRotationX = -128;
				
				pParty->uFlags |= 2u;
				pParty->armageddon_timer -= pMiscTimer->uTimeElapsed;
				v4 = pParty->armageddonDamage + 50;
				if ( pParty->armageddon_timer <= 0 )
				{
					pParty->armageddon_timer = 0;
					for(size_t i = 0; i < uNumActors; i++)
					{
						pActor=&pActors[i];
						if ( pActor->CanAct() )
						{
							sDmg = pActor->CalcMagicalDamageToActor((DAMAGE_TYPE)5, v4);
							pActor->sCurrentHP -= sDmg;
							if ( sDmg )
							{
								if ( pActor->sCurrentHP >= 0 )
									Actor::AI_Stun(i, 4, 0);
								else
								{
									Actor::Die(i);
									if ( pActor->pMonsterInfo.uExp )
										pParty->GivePartyExp(pMonsterStats->pInfos[pActor->pMonsterInfo.uID].uExp);
								}
							}
						}
					}
					for(int i = 1; i <= 4; i++)
					{
						pPlayer = pPlayers[i];
						if ( !pPlayer->pConditions[Condition_Dead] && !pPlayer->pConditions[Condition_Pertified] && !pPlayer->pConditions[Condition_Eradicated] )
							pPlayer->ReceiveDamage(v4, DMGT_MAGICAL);
					}
				}
				if (pTurnEngine->pending_actions)
					--pTurnEngine->pending_actions;
			}
		}
		
		//Turn-based mode: return
		if (pParty->bTurnBasedModeOn)
		{
			pTurnEngine->AITurnBasedAction();
			return;
		}
		
		for (uint i = 0; i < uNumActors; ++i)
		{
			pActor = &pActors[i];
			ai_near_actors_targets_pid[i] = OBJECT_Player;
			
			//Skip actor if: Dead / Removed / Disabled / uAttributes & 0x0400
			if (pActor->uAIState == Dead || pActor->uAIState == Removed || pActor->uAIState == Disabled || pActor->uAttributes & ACTOR_ALIVE)
				continue;
			
			//Kill actor if HP == 0
			if (!pActor->sCurrentHP && pActor->uAIState != Dying)
				Actor::Die(i);
			
			//Kill buffs if expired
			for (uint j = 0; j < 22; ++j)
			{
				if (j != 10)
					pActor->pActorBuffs[j].IsBuffExpiredToTime(pParty->uTimePlayed);
			}
			
			//If shrink expired: reset height
			if (pActor->pActorBuffs[ACTOR_BUFF_SHRINK].uExpireTime < 0)
				pActor->uActorHeight = pMonsterList->pMonsters[pActor->pMonsterInfo.uID - 1].uMonsterHeight;
			
			//If Charm still active: make actor friendly
			if (pActor->pActorBuffs[ACTOR_BUFF_CHARM].uExpireTime > 0)
				pActor->pMonsterInfo.uHostilityType = MonsterInfo::Hostility_Friendly;
			//Else: reset hostilty
			else if (pActor->pActorBuffs[ACTOR_BUFF_CHARM].uExpireTime < 0)
				pActor->pMonsterInfo.uHostilityType = pMonsterStats->pInfos[pActor->pMonsterInfo.uID].uHostilityType;
			
			//If actor Paralyzed or Stoned: skip
			if (pActor->pActorBuffs[ACTOR_BUFF_PARALYZED].uExpireTime > 0 || pActor->pActorBuffs[ACTOR_BUFF_STONED].uExpireTime > 0)
				continue;
			
			//Calculate RecoveryTime
			pActor->pMonsterInfo.uRecoveryTime = max(pActor->pMonsterInfo.uRecoveryTime - pMiscTimer->uTimeElapsed, 0);
			
			pActor->uCurrentActionTime += pMiscTimer->uTimeElapsed;
			if (pActor->uCurrentActionTime < pActor->uCurrentActionLength)
				continue;
			
			if (pActor->uAIState == Dying)
				pActor->uAIState = Dead;
			else
			{
				if (pActor->uAIState != Summoned)
				{
					Actor::AI_StandOrBored(i, OBJECT_Player, 256, nullptr);
					continue;
				}
				pActor->uAIState = Standing;
			}
			
			pActor->uCurrentActionTime = 0;
			pActor->uCurrentActionLength = 0;
			pActor->UpdateAnimation();
		}
		
		for(v78 = 0; v78 < ai_arrays_size; ++v78)
		{
			uint actor_id = ai_near_actors_ids[v78];
			assert(actor_id < uNumActors);
			
			pActor = &pActors[actor_id];
			
			v47 = (signed int)(pActor->pMonsterInfo.uRecoveryTime * 2.133333333333333);
			
			Actor::_SelectTarget(actor_id, &ai_near_actors_targets_pid[actor_id], true);
			
			if (pActor->pMonsterInfo.uHostilityType && !ai_near_actors_targets_pid[actor_id])
				pActor->pMonsterInfo.uHostilityType = MonsterInfo::Hostility_Friendly;
			
			target_pid = ai_near_actors_targets_pid[actor_id];
			target_pid_type = PID_TYPE(target_pid);
			
			if ( target_pid_type == OBJECT_Actor)
				radiusMultiplier = 0.5;
			else
				radiusMultiplier = 1.0;
			
			//v22 = pActor->uAIState;
			if ( pActor->uAIState == Dying || pActor->uAIState == Dead || pActor->uAIState == Removed
			    || pActor->uAIState == Disabled || pActor->uAIState == Summoned)
				continue;
			
			if ( !pActor->sCurrentHP )
				Actor::Die(actor_id);
			
			for( int i = 0;i < 22; i++ )
			{
				if ( i != 10 )
					pActor->pActorBuffs[i].IsBuffExpiredToTime(pParty->uTimePlayed);
			}
			
			if ( pActor->pActorBuffs[ACTOR_BUFF_SHRINK].uExpireTime < 0 )
				pActor->uActorHeight = pMonsterList->pMonsters[pActor->pMonsterInfo.uID - 1].uMonsterHeight;
			if ( pActor->pActorBuffs[ACTOR_BUFF_CHARM].uExpireTime > 0 )
				pActor->pMonsterInfo.uHostilityType = MonsterInfo::Hostility_Friendly;
			else if ( pActor->pActorBuffs[ACTOR_BUFF_CHARM].uExpireTime < 0 )
				pActor->pMonsterInfo.uHostilityType = pMonsterStats->pInfos[pActor->pMonsterInfo.uID].uHostilityType;
			
			//If actor is summoned and buff expired: continue and set state to Removed
			if ( pActor->pActorBuffs[ACTOR_BUFF_SUMMONED].uExpireTime < 0 )
			{
				pActor->uAIState = Removed;
				continue;
			}
			
			if ( (signed __int64)pActor->pActorBuffs[ACTOR_BUFF_STONED].uExpireTime > 0	|| (signed __int64)pActor->pActorBuffs[ACTOR_BUFF_PARALYZED].uExpireTime > 0)
			{
				continue;
			}
			
			v27 = pMiscTimer->uTimeElapsed;
			v28 = pActor->pMonsterInfo.uRecoveryTime;
			pActor->uCurrentActionTime += pMiscTimer->uTimeElapsed;
			
			if ( (signed int)v28 > 0 )
				pActor->pMonsterInfo.uRecoveryTime = v28 - v27;
			if ( pActor->pMonsterInfo.uRecoveryTime < 0 )
				pActor->pMonsterInfo.uRecoveryTime = 0;
			if ( !pActor->ActorNearby() )
				pActor->uAttributes |= ACTOR_NEARBY;
			
			a1 = PID(OBJECT_Actor,actor_id);
			Actor::GetDirectionInfo(PID(OBJECT_Actor,actor_id), target_pid, &a3, 0);
			pDir = &a3;
			uAIState = pActor->uAIState; 
			
			if ( pActor->pMonsterInfo.uHostilityType == MonsterInfo::Hostility_Friendly
			    || (signed int)pActor->pMonsterInfo.uRecoveryTime > 0
			    || radiusMultiplier * 307.2 < pDir->uDistance
			    || uAIState != Pursuing && uAIState != Standing && uAIState != Tethered && uAIState != Fidgeting
			    &&  !pActor->pMonsterInfo.uMissleAttack1Type || uAIState != Stunned )
			{
				if ( (signed int)pActor->uCurrentActionTime < pActor->uCurrentActionLength )
					continue;
				else if ( pActor->uAIState == AttackingMelee )
				{
					v35 = pActor->special_ability_use_check(actor_id);
					AttackerInfo.Add(a1, 5120, pActor->vPosition.x, pActor->vPosition.y, pActor->vPosition.z + ((signed int)pActor->uActorHeight >> 1), v35, 1 );
				}
				else if ( pActor->uAIState == AttackingRanged1 )
				{
					v34 = pActor->pMonsterInfo.uMissleAttack1Type;
					Actor::AI_RangedAttack(actor_id, pDir, v34, 0);
				}
				else if ( pActor->uAIState == AttackingRanged2 )
				{
					v34 = pActor->pMonsterInfo.uMissleAttack2Type;
					Actor::AI_RangedAttack(actor_id, pDir, v34, 1);
				}
				else if ( pActor->uAIState == AttackingRanged3 )
				{
					v65 = pActor->pMonsterInfo.uSpellSkillAndMastery1;
					v33 = pActor->pMonsterInfo.uSpell1ID;
					Actor::AI_SpellAttack(actor_id, pDir, v33, 2, v65);
				}
				else if ( pActor->uAIState == AttackingRanged4 )
				{
					v65 = pActor->pMonsterInfo.uSpellSkillAndMastery2;
					v33 = pActor->pMonsterInfo.uSpell2ID;
					Actor::AI_SpellAttack(actor_id, pDir, v33, 3, v65);
				}
			}
			
			v36 = pDir->uDistance;
			
			if ( pActor->pMonsterInfo.uHostilityType == MonsterInfo::Hostility_Friendly)
			{
				if ( target_pid_type == OBJECT_Actor )
				{
					v36 = pDir->uDistance;
					v37 =pFactionTable->relations[(pActor->pMonsterInfo.uID-1) / 3 + 1][(pActors[PID_ID(target_pid)].pMonsterInfo.uID - 1) / 3 + 1];
				}
				else
					v37 = 4;
				v38 = 0;
				if ( v37 == 2 )
					v38 = 1024;
				else if ( v37 == 3 )
					v38 = 2560;
				else if ( v37 == 4 )
					v38 = 5120;
				if ( v37 >= 1 && v37 <= 4 && v36 < v38  || v37 == 1 )
					pActor->pMonsterInfo.uHostilityType = MonsterInfo::Hostility_Long;
			}
			
			//If actor afraid: flee or if out of range random move
			if (pActor->pActorBuffs[ACTOR_BUFF_AFRAID].uExpireTime > 0)
			{
				if ( (signed int)v36 >= 10240 )
					Actor::AI_RandomMove(actor_id, target_pid, 1024, 0);
				else
					Actor::AI_Flee(actor_id, target_pid, 0, pDir);
				continue;
			}
			
			if ( pActor->pMonsterInfo.uHostilityType == MonsterInfo::Hostility_Long && target_pid )
			{
				if ( pActor->pMonsterInfo.uAIType == 1 )
				{
					if ( pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_STAIONARY )
						Actor::AI_Stand(actor_id, target_pid, (uint)(pActor->pMonsterInfo.uRecoveryTime * 2.133333333333333),	pDir);
					else
					{
						Actor::AI_Flee(actor_id, target_pid, 0, pDir);
						continue;
					}
					
				}
				if ( !(pActor->uAttributes & ACTOR_FLEEING) )
				{
					if ( pActor->pMonsterInfo.uAIType == 2 || pActor->pMonsterInfo.uAIType == 3)
					{
						if ( pActor->pMonsterInfo.uAIType == 2 )
							v43 = (double)(signed int)pActor->pMonsterInfo.uHP * 0.2;
						if ( pActor->pMonsterInfo.uAIType == 3 )
							v43 = (double)(signed int)pActor->pMonsterInfo.uHP * 0.1;
						v42 = (double)pActor->sCurrentHP;
						if ( v43 > v42 && (signed int)v36 < 10240 )
						{
							Actor::AI_Flee(actor_id, target_pid, 0, pDir);
							continue;
						}
					}
				}
				
				v81 = v36 - pActor->uActorRadius;
				if ( target_pid_type == OBJECT_Actor )
					v81 -= pActors[PID_ID(target_pid)].uActorRadius;
				if ( v81 < 0 )
					v81 = 0;
				rand();
				pActor->uAttributes &= ~ACTOR_UNKNOW5;//~0x40000
				if ( v81 < 5120 )
				{
					v45 = pActor->special_ability_use_check(actor_id);
					if ( v45 == 0 )
					{
						if ( pActor->pMonsterInfo.uMissleAttack1Type )
						{
							if ( (signed int)pActor->pMonsterInfo.uRecoveryTime <= 0 )
								Actor::AI_MissileAttack1(actor_id, target_pid, pDir);
							else if ( pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_STAIONARY )
								Actor::AI_Stand(actor_id, target_pid, v47, pDir);
							else
							{
								if ( radiusMultiplier * 307.2 > (double)v81 )
									Actor::AI_Stand(actor_id, target_pid, v47, pDir);
								else
									Actor::AI_Pursue1(actor_id, target_pid, actor_id, v47, pDir);
							}
						}
						else
						{
							if ( (double)v81 >= radiusMultiplier * 307.2 )
							{
								if (pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_STAIONARY)
									Actor::AI_Stand(actor_id, target_pid, v47, pDir);
								else if ( v81 >= 1024 )//monsters
									Actor::AI_Pursue3(actor_id, target_pid, 0, pDir);
								else
								{
									v70 = (signed int)(radiusMultiplier * 307.2);
									//monsters
									//guard after player runs away
									// follow player
									Actor::AI_Pursue2(actor_id, target_pid, 0, pDir, v70);
								}
							}
							else if ( (signed int)pActor->pMonsterInfo.uRecoveryTime > 0 )
							{
								Actor::AI_Stand(actor_id, target_pid, v47, pDir);
							}
							else
							{
								//monsters
								Actor::AI_MeleeAttack(actor_id, target_pid, pDir);
							}
						}
						continue;
					}
					else if ( v45 == 2 || v45 == 3 )
					{
						if ( v45 == 2 )
							v46 = pActor->pMonsterInfo.uSpell1ID;
						else
							v46 = pActor->pMonsterInfo.uSpell2ID;
						if ( v46 )
						{
							if ( (signed int)pActor->pMonsterInfo.uRecoveryTime <= 0 )
							{
								if ( v45 == 2 )
									Actor::AI_SpellAttack1(actor_id, target_pid, pDir);
								else
									Actor::AI_SpellAttack2(actor_id, target_pid, pDir);
							}
							else if ( radiusMultiplier * 307.2 > (double)v81 || pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_STAIONARY )
								Actor::AI_Stand(actor_id, target_pid, v47, pDir);
							else
								Actor::AI_Pursue1(actor_id, target_pid, actor_id, v47, pDir);
						}
						else
						{
							if ( (double)v81 >= radiusMultiplier * 307.2 ) 
							{
								if ( pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_STAIONARY )
									Actor::AI_Stand(actor_id, target_pid, v47, pDir);
								else if ( v81 >= 1024 )
									Actor::AI_Pursue3(actor_id, target_pid, 256, pDir);
								else
								{
									v70 = (signed int)(radiusMultiplier * 307.2);
									Actor::AI_Pursue2(actor_id, target_pid, 0, pDir, v70);
								}
							}
							else if ( (signed int)pActor->pMonsterInfo.uRecoveryTime > 0 )
							{
								Actor::AI_Stand(actor_id, target_pid, v47, pDir);
							}
							else
							{								
								Actor::AI_MeleeAttack(actor_id, target_pid, pDir);
							}
						}
						continue;
					}
				}
			}
			
			if ( pActor->pMonsterInfo.uHostilityType != MonsterInfo::Hostility_Long || !target_pid || v81 >= 5120 || v45 != 1 )
			{
				if ( pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_SHORT )
					Actor::AI_RandomMove(actor_id, 4, 1024, 0);
				else if ( pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_MEDIUM )
					Actor::AI_RandomMove(actor_id, 4, 2560, 0);
				else if ( pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_LONG )
					Actor::AI_RandomMove(actor_id, 4, 5120, 0);
				else if ( pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_FREE )
					Actor::AI_RandomMove(actor_id, 4, 10240, 0);
				else if ( pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_STAIONARY )
				{
					Actor::GetDirectionInfo(a1, 4, &v72, 0);
					v58 = (uint)(pActor->pMonsterInfo.uRecoveryTime * 2.133333333333333);
					Actor::AI_Stand(actor_id, 4, v58, &v72);
				}				
			}
			else if ( !pActor->pMonsterInfo.uMissleAttack2Type )
			{
				if ( (double)v81 >= radiusMultiplier * 307.2 )
				{
					if ( pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_STAIONARY )
						Actor::AI_Stand(actor_id, target_pid, v47, pDir);
					else if ( v81 >= 1024 )
						Actor::AI_Pursue3(actor_id, target_pid, 256, pDir);
					else
					{
						v70 = (int)(radiusMultiplier * 307.2);
						Actor::AI_Pursue2(actor_id, target_pid, 0, pDir, v70);
					}
				}
				else if ( (signed int)pActor->pMonsterInfo.uRecoveryTime > 0 )
					Actor::AI_Stand(actor_id, target_pid, v47, pDir);
				else
					Actor::AI_MeleeAttack(actor_id, target_pid, pDir);
			}
			else if ( (signed int)pActor->pMonsterInfo.uRecoveryTime > 0 )
			{
				if ( radiusMultiplier * 307.2 > (double)v81 || pActor->pMonsterInfo.uMovementType == MONSTER_MOVEMENT_TYPE_STAIONARY )
					Actor::AI_Stand(actor_id, target_pid, v47, pDir);
				else
					Actor::AI_Pursue1(actor_id, target_pid, actor_id, v47, pDir);
			}
			else
				Actor::AI_MissileAttack2(actor_id, target_pid, pDir);*/
		}
	}

	//----- (004014E6) --------------------------------------------------------
	void MakeActorAIList_ODM()
	{
		/*
		 *получаем данные о растоянии от камеры до монстра и определяем активен монстр или нет 
		 */
		int v1; // eax@4
		uint v7; // ST20_4@10
		int distance; // edi@10
		int v10; // ebx@14
		int v21; // [sp+Ch] [bp-14h]@4
		int v22; // [sp+10h] [bp-10h]@4
		
		//pParty->uFlags &= 0xFFFFFFCF;//~0x30
		
		/*ai_arrays_size = 0;
		for (uint i = 0; i < uNumActors; ++i)
		{
			Actor* actor = &pActors[i];
			
			actor->ResetAlive();//~0x400
			if (!actor->CanAct())
			{
				actor->ResetActive();
				continue;
			}
			
			v22 = abs(pParty->vPosition.z - actor->vPosition.z);
			v21 = abs(pParty->vPosition.y - actor->vPosition.y);
			v1 = abs(pParty->vPosition.x - actor->vPosition.x);
			v7 = int_get_vector_length(v22, v21, v1);
			distance = v7 - actor->uActorRadius;
			if ( distance < 0 )
				distance = 0;
			
			if (distance < 5632)
			{
				actor->ResetHostile();
				if ( actor->ActorEnemy() || actor->GetActorsRelation(0) )
				{
					//v11 = (pParty->uFlags & 0x10) == 0;
					actor->uAttributes |= ACTOR_HOSTILE;
					if (distance < 5120 )
						pParty->SetYellowAlert();
					if (distance < 307)
						pParty->SetRedAlert();
				}
				actor->uAttributes |= ACTOR_ACTIVE;
				ai_near_actors_distances[ai_arrays_size] = distance;
				ai_near_actors_ids[ai_arrays_size++] = i;
			}
			else
				actor->ResetActive();
		}*/
		
		/*
  result = v27;
  if ( v27 > 0 )
  {
    v14 = 0;
    v15 = 1;
    v26 = 1;
    do
    {
      while ( 1 )
      {
        v24 = v15;
        if ( v15 >= result )
          break;
        v16 = ai_near_actors_distances[v14];
        if ( v16 > ai_near_actors_distances[v15] )
        {
          v17 = &ai_near_actors_ids[v15];
          v18 = ai_near_actors_ids[v14];
          ai_near_actors_ids[v14] = *v17;
          *v17 = v18;
          v15 = v24;
          ai_near_actors_distances[v14] = ai_near_actors_distances[v24];
          ai_near_actors_distances[v24] = v16;
        }
        result = v27;
        ++v15;
      }
      ++v14;
      v15 = v26 + 1;
      v26 = v15;
    }
    while ( v15 - 1 < result );
  }*/
		
		/*for (uint i = 0; i < ai_arrays_size; ++i)
			for (uint j = 0; j < i; ++j)
				if (ai_near_actors_distances[j] > ai_near_actors_distances[i])
			{
				int tmp = ai_near_actors_distances[j];
				ai_near_actors_distances[j] = ai_near_actors_distances[i];
				ai_near_actors_distances[i] = tmp;
				
				tmp = ai_near_actors_ids[j];
				ai_near_actors_ids[j] = ai_near_actors_ids[i];
				ai_near_actors_ids[i] = tmp;
			}
		
		
		if (ai_arrays_size > 30)
			ai_arrays_size = 30;
		
		for (uint i = 0; i < ai_arrays_size; ++i)
			pActors[ai_near_actors_ids[i]].uAttributes |= ACTOR_ALIVE;//0x400*/
	}
}
