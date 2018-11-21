/// <summary>
/// Skills.
/// Вешается на персонажа
/// Добавляет меню прокачки скилов
/// </summary>
using UnityEngine;
using System.Collections;

public class Skills : MonoBehaviour {
	
	public GUISkin mySkin;
	
	private int HP = 1;
	private int Power = 1;
	private int Mana = 1;
	private int Agility = 1;
	
	private int _curHP;
	private int _curPower;
	private int _curMana;
	private int _curAgility;
	
	public int Damage;
	public int Protection;
	public int Health;
	public int CMana;
	public int Endurance;
	public int Trade;
	
	public int skill;
	private int _curSkill;
	public int LVL;
	private int curLVL;
	
	private bool boolSkill;		// Кнопки прокачки
	private bool _visable = false;	//Окно прокачки
	
	private PlayerStats ps;

	// Use this for initialization
	void Start () {
		curLVL = LVL;
		
		_curAgility = Agility;
		_curHP = HP;
		_curMana = Mana;
		_curPower = Power;
		
		ps = GameObject.Find("FPSController").GetComponent<PlayerStats>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyUp(KeyCode.K)) _visable = true;
		
		if(curLVL != LVL) {
			skill += 5;	
			_curSkill = skill;
			curLVL = LVL;
		}
		
		if(skill != 0) boolSkill = true;
		
	
	}
	
	void OnGUI () {
		if(_visable){
		GUI.skin = mySkin;
		
		//фон
			GUI.Box(new Rect((Screen.width/2)-230,(Screen.height/2)-172,460,344), " ", GUI.skin.GetStyle("fon"));
		
		//надписи
		GUI.Label(new Rect(269,25,600,800), "Parameters");
		GUI.Label(new Rect(269,210,600,800), "Curent parameters");
			
		GUI.Label(new Rect(300,500,600,800), "Skills");
		GUI.Label(new Rect(350,500,600,800), skill.ToString());
		
		GUI.Label(new Rect(60,60,600,800), "HP");			// Здоровье
		GUI.Label(new Rect(60,100,600,800), "Power");		// Сила
		GUI.Label(new Rect(60,140,600,800), "Mana");		// Мана
		GUI.Label(new Rect(60,180,600,800), "Agility");		// Ловкость
		
		GUI.Label(new Rect(260,60,600,800), HP.ToString());			// Здоровье
		GUI.Label(new Rect(260,100,600,800), Power.ToString());		// Сила
		GUI.Label(new Rect(260,140,600,800), Mana.ToString());		// Мана
		GUI.Label(new Rect(260,180,600,800), Agility.ToString());	// Ловкость
		
		GUI.Label(new Rect(60,240,600,800), "Damage");		// Урон
		GUI.Label(new Rect(60,280,600,800), "Protection");	// Защита
		GUI.Label(new Rect(60,320,600,800), "Health");		// Здоровье
		GUI.Label(new Rect(60,360,600,800), "Mana");		// Мана
		GUI.Label(new Rect(60,400,600,800), "Endurance");	// Выносливость
		GUI.Label(new Rect(60,440,600,800), "Trade");		// Торговля
		
		Damage = Power*10 + Agility*5;
		Protection = Power*5 + Agility*2;
		Health = HP*30 + Agility*15;
		CMana = Mana*30;
		Endurance = Power*4 + HP*2;
		Trade = Agility*2;
				
		GUI.Label(new Rect(260,240,600,800), Damage.ToString());		// Урон
		GUI.Label(new Rect(260,280,600,800), Protection.ToString());	// Защита
		GUI.Label(new Rect(260,320,600,800), Health.ToString());		// Здоровье
		GUI.Label(new Rect(260,360,600,800), CMana.ToString());			// Мана
		GUI.Label(new Rect(260,400,600,800), Endurance.ToString());		// Выносливость
		GUI.Label(new Rect(260,440,600,800), Trade.ToString());			// Торговля
		
		//кнопки
		if (boolSkill) {
			// Здоровье
			if(skill != 0) {
				if(GUI.Button(new Rect(110,60,35,35), " ", GUI.skin.GetStyle("+"))) {
					skill -= 1;
					HP += 1;
				}
			}
			if(HP != _curHP) {
				if(GUI.Button(new Rect(150,60,35,35), " ", GUI.skin.GetStyle("-"))) {
					skill += 1;
					HP -= 1;
				}
			}
		
			// Сила
			if(skill != 0) {
				if(GUI.Button(new Rect(110,100,35,35), " ", GUI.skin.GetStyle("+"))) {
					skill -= 1;
					Power += 1;
				}
			}
			if(Power != _curPower) {
				if(GUI.Button(new Rect(150,100,35,35), " ", GUI.skin.GetStyle("-"))) {
					skill += 1;
					Power -= 1;
				}
			}
		
			//Мана
			if(skill != 0) {
				if(GUI.Button(new Rect(110,140,35,35), " ", GUI.skin.GetStyle("+"))) {
					skill -= 1;
					Mana += 1;
				}
			}
			if(Mana != _curMana) {
				if(GUI.Button(new Rect(150,140,35,35), " ", GUI.skin.GetStyle("-"))) {
					skill += 1;
					Mana -= 1;
				}
			}
		
			// Ловкость
			if(skill != 0) {
				if(GUI.Button(new Rect(110,180,35,35), " ", GUI.skin.GetStyle("+"))) {
					skill -= 1;
					Agility += 1;
				}
			}
			if(Agility != _curAgility) {
				if(GUI.Button(new Rect(150,180,35,35), " ", GUI.skin.GetStyle("-"))) {
					skill += 1;
					Agility -= 1;
				}
			}	
		}
		if(GUI.Button(new Rect(470,620,100,40), " ", GUI.skin.GetStyle("Ok"))) {
					_curAgility = Agility;
					_curHP = HP;
					_curMana = Mana;
					_curPower = Power;
					_curSkill = skill;
					if (ps != null)
     		 			{
         					ps.MaxHealth = Health; //
							ps.MaxMana = CMana; //
      					}
					_visable = false;
				}
		if(GUI.Button(new Rect(300,620,100,40), " ", GUI.skin.GetStyle("No"))) {
					Agility = _curAgility;
					HP = _curHP;
					Mana = _curMana;
					Power = _curPower;
					skill = _curSkill;
					_visable = false;
				}
		}
	}
}