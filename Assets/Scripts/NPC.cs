﻿/// <summary>
/// Player stats.
/// Хранит данные о NPC
/// Вешать на игрока
/// </summary>
using UnityEngine;
using System.Collections;

public class NPC
{
    enum NPCProf
    {
        Smith = 1,           // GM Weapon Repair;
        Armorer = 2,         // GM Armor Repair;
        Alchemist = 3,       // GM Potion Repair;
        Scholar = 4,         // GM Item ID;               Learning: +5
        Guide = 5,           // Travel by foot: -1 day;
        Tracker = 6,         // Travel by foot: -2 days;
        Pathfinder = 7,      // Travel by foot: -3 days;
        Sailor = 8,          // Travel by sea: -2 days;
        Navigator = 9,       // Travel by sea: -3 days;
        Healer = 10,
        ExpertHealer = 11,
        MasterHealer = 12,
        Teacher = 13,        // Learning: +10;
        Instructor = 14,     // Learning: +15;
        Armsmaster = 15,     // Armsmaster: +2;
        Weaponsmaster = 16,  // Armsmaster: +3;
        Apprentice = 17,     // Fire: +2;         Air: +2;    Water: +2;   Earth: +2;
        Mystic = 18,         // Fire: +3;         Air: +3;    Water: +3;   Earth: +3;
        Spellmaster = 19,    // Fire: +4;         Air: +4;    Water: +4;   Earth: +4;
        Trader = 20,         // Merchant: +4;
        Merchant = 21,       // Merchant: +6;
        Scout = 22,          // Perception: +6;
        Herbalist = 23,      // Alchemy: +4;
        Apothecary = 24,     // Alchemy: +8;
        Tinker = 25,         // Traps: +4;
        Locksmith = 26,      // Traps: +6;
        Fool = 27,           // Luck: +5;
        ChimneySweep = 28,   // Luck: +20;
        Porter = 29,         // Food for rest: -1;
        QuarterMaster = 30,  // Food for rest: -2;
        Factor = 31,         // Gold finds: +10%;
        Banker = 32,         // Gold finds: +20%;
        Cook = 33,
        Chef = 34,
        Horseman = 35,       // Travel by foot: -2 days;
        Bard = 36,
        Enchanter = 37,      // Resist All: +20;
        Cartographer = 38,   // Wizard Eye level 2;
        WindMaster = 39,
        WaterMaster = 40,
        GateMaster = 41,
        Acolyte = 42,
        Piper = 43,
        Explorer = 44,       // Travel by foot -1 day;     Travel by sea: -1 day;
        Pirate = 45,         // Travel by sea: -2 days;    Gold finds: +10%;      Reputation: +5;
        Squire = 46,
        Psychic = 47,        // Perception: +5;            Luck: +10;
        Gypsy = 48,          // Food for rest: -1;         Merchant: +3;          Reputation: +5;
        Diplomat = 49,
        Duper = 50,          // Merchant: +8;              Reputation: +5;
        Burglar = 51,        // Traps: +8;                 Stealing: +8;          Reputation: +5;
        FallenWizard = 52,   // Reputation: +5;
        Acolyte2 = 53,       // Spirit: +2;                Mind: +2;              Body: +2;
        Initiate = 54,       // Spirit: +3;                Mind: +3;              Body: +3;
        Prelate = 55,        // Spirit: +4;                Mind: +4;              Body: +4;
        Monk = 56,           // Unarmed: +2;               Dodge: +2;
        Sage = 57,           // Monster ID: +6
        Hunter = 58          // Monster ID: +6
    };
    //----- (00476395) --------------------------------------------------------
//0x26 Wizard eye at skill level 2
    /*public bool  CheckHiredNPCSpeciality(uint uProfession)
    {

    if ( bNoNPCHiring == 1 )
        return 0;

    for (uint i=0; i<pNPCStats->uNumNewNPCs; ++i )
        {
        if ( pNPCStats->pNewNPCData[i].uProfession == uProfession && 
            (pNPCStats->pNewNPCData[i].uFlags & 0x80) )//Uninitialized memory access
            return true;
        }
    if ( pParty->pHirelings[0].uProfession == uProfession ||
         pParty->pHirelings[1].uProfession == uProfession)
        return true;
    else
        return false;

    }*/
}
