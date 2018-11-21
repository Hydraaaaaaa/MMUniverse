using UnityEngine;
using System.Collections;

public class HP_SP_bar : MonoBehaviour
{
    public bool debug_flag;
    public GUISkin myGUI;
    public float curHP = 0;
    public float maxHP = 0;
    public float curHP2 = 0;
    public float maxHP2 = 0;
    public float curHP3 = 0;
    public float maxHP3 = 0;
    public float curHP4 = 0;
    public float maxHP4 = 0;
    public float curSP = 0;
    public float maxSP = 0;
    public float curSP2 = 0;
    public float maxSP2 = 0;
    public float curSP3 = 0;
    public float maxSP3 = 0;
    public float curSP4 = 0;
    public float maxSP4 = 0;

    void Update()
    {
        GameObject.Find("Player0").GetComponent<PlayerStats>().MaxHealth = GameObject.Find("FPSController").GetComponent<Party>().GetMaxHealth(0);
        curHP = (float)GameObject.Find("Player0").GetComponent<PlayerStats>().sHealth;
        maxHP = (float)(GameObject.Find("Player0").GetComponent<PlayerStats>().MaxHealth);
        if (maxHP < curHP) curHP = maxHP;
        if (curHP < 0) curHP = 0;
        GameObject.Find("Player1").GetComponent<PlayerStats>().MaxHealth = GameObject.Find("FPSController").GetComponent<Party>().GetMaxHealth(1);
        curHP2 = (float)GameObject.Find("Player1").GetComponent<PlayerStats>().sHealth;
        maxHP2 = (float)(GameObject.Find("Player1").GetComponent<PlayerStats>().MaxHealth);
        if (maxHP2 < curHP2) curHP2 = maxHP2;
        if (curHP2 < 0) curHP2 = 0;
        GameObject.Find("Player2").GetComponent<PlayerStats>().MaxHealth = GameObject.Find("FPSController").GetComponent<Party>().GetMaxHealth(2);
        curHP3 = (float)GameObject.Find("Player2").GetComponent<PlayerStats>().sHealth;
        maxHP3 = (float)(GameObject.Find("Player2").GetComponent<PlayerStats>().MaxHealth);
        if (maxHP3 < curHP3) curHP3 = maxHP3;
        if (curHP3 < 0) curHP3 = 0;
        GameObject.Find("Player3").GetComponent<PlayerStats>().MaxHealth = GameObject.Find("FPSController").GetComponent<Party>().GetMaxHealth(3);
        curHP4 = (float)GameObject.Find("Player3").GetComponent<PlayerStats>().sHealth;
        maxHP4 = (float)(GameObject.Find("Player3").GetComponent<PlayerStats>().MaxHealth);
        if (maxHP4 < curHP4) curHP4 = maxHP4;
        if (curHP4 < 0) curHP4 = 0;

        GameObject.Find("Player0").GetComponent<PlayerStats>().MaxMana = GameObject.Find("FPSController").GetComponent<Party>().GetMaxMana(0);
        curSP = (float)GameObject.Find("Player0").GetComponent<PlayerStats>().sMana;
        maxSP = (float)(GameObject.Find("Player0").GetComponent<PlayerStats>().MaxMana);
        if (maxSP < curSP) curSP = maxSP;
        if (curSP < 0) curSP = 0;
        GameObject.Find("Player1").GetComponent<PlayerStats>().MaxMana = GameObject.Find("FPSController").GetComponent<Party>().GetMaxMana(1);
        curSP2 = (float)GameObject.Find("Player1").GetComponent<PlayerStats>().sMana;
        maxSP2 = (float)(GameObject.Find("Player1").GetComponent<PlayerStats>().MaxMana);
        if (maxSP2 < curSP2) curSP2 = maxSP2;
        if (curSP2 < 0) curSP2 = 0;
        GameObject.Find("Player2").GetComponent<PlayerStats>().MaxMana = GameObject.Find("FPSController").GetComponent<Party>().GetMaxMana(2);
        curSP3 = (float)GameObject.Find("Player2").GetComponent<PlayerStats>().sMana;
        maxSP3 = (float)(GameObject.Find("Player2").GetComponent<PlayerStats>().MaxMana);
        if (maxSP3 < curSP3) curSP3 = maxSP3;
        if (curSP3 < 0) curSP3 = 0;
        GameObject.Find("Player3").GetComponent<PlayerStats>().MaxMana = GameObject.Find("FPSController").GetComponent<Party>().GetMaxMana(3);
        curSP4 = (float)GameObject.Find("Player3").GetComponent<PlayerStats>().sMana;
        maxSP4 = (float)(GameObject.Find("Player3").GetComponent<PlayerStats>().MaxMana);
        if (maxSP4 < curSP4) curSP4 = maxSP4;
        if (curSP4 < 0) curSP4 = 0;

        if (debug_flag)
        {
            maxHP = 30;
            curHP = 30;
            maxHP2 = 30;
            curHP2 = 30;
            maxHP3 = 30;
            curHP3 = 30;
            maxHP4 = 30;
            curHP4 = 30;

            curSP = 0;
            maxSP = 0;
            curSP2 = 0;
            maxSP2 = 0;
            curSP3 = 30;
            maxSP3 = 30;
            curSP4 = 30;
            maxSP4 = 30;
        }
    }

    void OnGUI()
    {
        GUI.skin = myGUI;
        float HPLen = curHP / maxHP;
        if (HPLen > 0)
        GUI.Box(new Rect((Screen.width / 2) - 211, Screen.height - 25, 4, -48 * HPLen), "", GUI.skin.GetStyle("HPbar"));
        HPLen = curHP2 / maxHP2;
        if (HPLen > 0)
        GUI.Box(new Rect((Screen.width / 2) - 96, Screen.height - 25, 4, -48 * HPLen), "", GUI.skin.GetStyle("HPbar"));
        HPLen = curHP3 / maxHP3;
        if (HPLen > 0)
        GUI.Box(new Rect((Screen.width / 2) + 19, Screen.height - 25, 4, -48 * HPLen), "", GUI.skin.GetStyle("HPbar"));
        HPLen = curHP4 / maxHP4;
        if (HPLen > 0)
        GUI.Box(new Rect((Screen.width / 2) + 134, Screen.height - 25, 4, -48 * HPLen), "", GUI.skin.GetStyle("HPbar"));

        float SPLen = curSP / maxSP;
        if (SPLen > 0)
        GUI.Box(new Rect((Screen.width / 2) - 132, Screen.height - 25, 4, -48 * SPLen), "", GUI.skin.GetStyle("SPbar"));
        SPLen = curSP2 / maxSP2;
        if (SPLen > 0)
        GUI.Box(new Rect((Screen.width / 2) - 17, Screen.height - 25, 4, -48 * SPLen), "", GUI.skin.GetStyle("SPbar"));
        SPLen = curSP3 / maxSP3;
        if (SPLen > 0)
        GUI.Box(new Rect((Screen.width / 2) + 98, Screen.height - 25, 4, -48 * SPLen), "", GUI.skin.GetStyle("SPbar"));
        SPLen = curSP4 / maxSP4;
        if (SPLen > 0)
        GUI.Box(new Rect((Screen.width / 2) + 213, Screen.height - 25, 4, -48 * SPLen), "", GUI.skin.GetStyle("SPbar"));
    }
}
