/// <summary>
/// Player bar display.
/// Выводит на экран бары игрока
/// Вешать на игрока
/// </summary>
using UnityEngine;
using System.Collections;

public class PlayerBarDisplay : MonoBehaviour {
	//playerBar разделительные линии панели здоровья и маны
	//HealthBar полоса здоровья игрока
	//ManaBar Полоса маны игрока
	//Bar фон панели
	public GUISkin mySkin; // Скин где хранятся текстуры баров
	public PlayerStats Char; // Объект на котором висят статы
	public bool Visible = true; //Видимость бара

	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI () {
		if(Visible)
		{
			//назначаем mySkin текущим скином для GUI
			GUI.skin = mySkin;
			//получаем переменную PlayerSt компонент PlayerStats
			//В инспекторе в Unity нужно указать на игрока
			PlayerStats PlayerSt = (PlayerStats)Char.GetComponent("PlayerStats");
			//получаем значения
			float MaxHealth = (float)PlayerSt.MaxHealth;
			float CurHealth = (float)PlayerSt.CurHealth;
			float MaxMana = (float)PlayerSt.MaxMana;
			float CurMana = (float)PlayerSt.CurMana;
			//расчитываем коэффицент длинны полосы здоровья
			float HealthBarLen = CurHealth/MaxHealth; //если умножить на сто то будут проценты
			//расчитываем коэффицент длинны полосы маны
			float ManaBarLen = CurMana/MaxMana; //если умножить на сто то будут проценты
			
			//рисуем общий фон панели здоровья и маны
			GUI.Box(new Rect(10,10,254,64), " ", GUI.skin.GetStyle("Bar"));
			
			//полоса здоровья игрока
			GUI.Box(new Rect(10,10,254*HealthBarLen,64), " ", GUI.skin.GetStyle("HealthBar")); 
			//полоса маны игрока
			GUI.Box(new Rect(10,10,254*ManaBarLen,64), " ", GUI.skin.GetStyle("ManaBar"));
			
			//рисуем разделительные линии панели здоровья и маны
			GUI.Box(new Rect(10,10,254,64), " ", GUI.skin.GetStyle("PlayerBar"));
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
