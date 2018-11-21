using UnityEngine;

public class Creators : MonoBehaviour {

	string output;
	Vector2 sliderPos;
	int i;
	public bool flag = false;
	public GUISkin skin;

	string[] text = {
		"_Создатель игры:",
			"Jon Van Caneghem",
				"",
				"_Исполнительный продюсер:",
				"Mark Caldwell",
				"",
				"_Продюсер:",
				"Peter Ryu",
				"",
				"_Директор:",
				"Keith Francart",
				"",
				"_Дизайнеры:",
				"Jon Van Caneghem",
				",Paul Rattner",
				"Bryan Farina",
				"James Dickinson",
				"",
				"_Ведущий программист:",
				"Robert Young",
				"",
				"_Программисты:",
				"Ian Bullard",
				"Alex Sherman",
				"L. Dean Gibson II",
				"John Mac Machin",
				"",
				"_Разработка уровней:",
				"David Vela",
				"Joel Kelly",
				"Ken Spencer",
				"Riki Corredera",
				"Tim Lang",
				"",
				"_Главный художник:",
				"John Slowsky",
				"",
				"_Художники New World Computing:",
				"Adam McCarthy",
				"April Lee",
				"Bill Nesemeier",
				"Bonita Long-Hemsath",
				"Brian DeMetz",
				"Brian Kemper",
				"Carl Pinder",
				"Charles Zilm",
				"Chris Rock",
				"George Almond",
				"Jeff Bigman",
				"John Gibson",
				"Julia Ulano",
				"Ken Thomson",
				"Kurt McKeever",
				"Lou Henderson",
				"Rebecca Christel",
				"Scott White",
				"Steve Wasaff",
				"Steve Jasper",
				"Tracy Iwata",
				"",
				"_Художники Hypnotix Inc.",
				"Mike Taramykin",
				"Jason Shenkman",
				"John Philip Sousa",
				"Michael Caydado",
				"William John Dwyer",
				"Jason Vaughn",
				"R. Scott Quick",
				"Marc Tattersall",
				"Robert Santiago",
				"Jason J. Timmons",
				"John Amos",
				"Matthew Cornelius",
				"Chris Okun",
				"Anthony Pereira",
				"Kyle Vannoy",
				"Vivek Saigal",
				"Peter Sfat",
				"John Trumbull",
				"",
				"_Художники 3DO:",
				"Andrew Gilmour",
				"Carlos Hernandez",
				"Chris Donovan",
				"Derek Hauffe",
				"Kelly Turner.",
				"Kudo Tsunoda",
				"Mike Janov",
				"Mike Marsicano",
				"Mike O'Rourke",
"Ryan Paul",
"Steve Tang",
"",
"_Звукорежиссер:",
"Rob King",
"",
"_Композитор:",
"Paul Romero",
"",
"_Звукооператоры:",
"Rob King и Steve Baca",
"",
"_Дополнительная обработка звука:",
"Chuck Russom",
"",
"_Режиссер озвучания:",
"Rob King",
"",
"_Персонажи озвучивали:",
"Mike Sorich",
"Catherine Battistone",
"Dan Warren",
"Barry Stigler",
"Richard Epcar",
"Brian Cooper",
"Rob King",
"Mari Devon",
"Barbara Goodson",
"Rebecca Fourstadt",
"Laird McCintosh",
"Sara Wallace",
"Lex Lang",
"Mike McConnohie",
"Melodee Spevack",
"Brianne Sidall",
"Sy Prescott",
"Malora Harte",
"Steve Kramer",
"Joe Romersa",
"Mark Arnoutt",
"Holly Willard",
"Danny FehsenFeld",
"Doug Stone",
"Stephanie Shane",
"Janna Knudson",
"",
"_Студия звукозаписи:",
"Green Street Studios, Pasadena Ca",
"",
"_Контроль качества:",
"Chris Miller",
"David Botan",
"David Casso",
"David Engberg",
"Derek Chester",
"Devin Chapman",
"Eric Williamson",
"Jennifer Bullard",
"John Castillo",
"Karl Drown",
"Karl Fischer",
"Marcus Pregent",
"Michael Calica",
"Michael Wolf",
"Richard Campbell",
"Randy Ruckel",
"Ryan Den",
"Tom Zeliff",
"Tony Evans",

"_Отдельно благодарим:",
"Debbie Van Caneghem",
"3Dfx",
"3Dlabs",
"AMD",
"ATI Technologies",
"Aureal",
"Creative Labs",
"Cyrix",
"Mars Publishing",
"Matrox",
"nVidia",
"Rad Game Tools",
"Scott McDaniel",
"Chris Bates",
"King Louie",
"... и всех остальных  за понимание и поддержку нас, геймеров...",

"_Веб-мастер:",
"Joshua ","Guthwolf"," Milligan",
"",
"_Веб-дизайнер:",
"Aaron Castro",
"",
"_Веб-программисты:",
"Robert Belknap",
"Peter Hillier",
"",
"_Посетите наш сайт в интернете:",
"www.3do.com",
"",
"_Локализация выполнена Home Systems, Inc. по заказу компании Бука.",
		/*
_Home Systems, Inc.

_Продюсер:
Филимонов Михаил

_Ведущий программист:
Перрухин Алексей

_Технический продюсер:
Борисов Андрей

_Художники-дизайнеры:
Лазарев Николай
Смирнова Ирина

_Перевод аудио файлов и анимации:
Комарова Ольга

_Звукооператор:
Жучков Андрей

_Персонажи озвучивали:
Лазарев Николай
Денискин Костантин
Пожарский Вадим
Чудко Александр
Морозова Татьяна
Абрашин Николай
Попова Вера
Цибуленкова Юля
Дергач Юрий
Доронин Александр
Блохин Алексей
Морозов Степан
Рябцев Сергей
Пикалов Сергей
Пахомов Александр
Кулаков Евгений
Ходченков Александр
Стёпин Сергей
Морозов Олег
Перевозчикова Катя
Гришин Александр
Ярославцев Андрей
Казакова Лариса
Фищук Наталья

_Тексты переведены бюро переводов "Папирус".

_Бюро переводов "Папирус"

_Координатор:
Павел Ляховский

_Переводчики:
Денис Хорошавчев
Денис Кугай
Олег Исаев
Павел Ляховский

_Редактор:
Игорь Исаев

_Компания "Бука"

_Лицензирование:
Владимир Миняев

_Менеджер по локализации:
Екатерина Функ

_Ассистент менеджера по локализации:
Алла Колобекова

_Менеджер по рекламе и PR:
Марина Белобородова

_Product менеджер:
Алексей Писклюков

_Редактор
Илья Ченцов

_Художник-дизайнер:
Елена Седова

_Выпускающий продюсер:
Александр Пак

_Старший тестер:
Вячеслав Алпатов

_Техническая поддержка:
Сергей  Богомягков

_Большое спасибо:
Игорь Устинов
Олег Белобородов
Татьяна Устинова
Марина Равун
Александр Михайлов
Алексей Громов
Максим Н. Михалев
Георгий Виталиев
Руслан Шелехов
Роман Потапкин

_Тестеры проекта:
Алексей Громов
Максим Соломатин
Алексей Пешехонов
Алексей Чеботарев
Иван Райнов
Олег Бирюков
Екатерина Мышенко
Владислав Жевнов
Андрей Дорофеев
Александр Горбань
Николай Судариков
Артем Соловьев
Покровский Игорь*/
"_",
"",
"_",
"",
"_",
"",
"_",
"",
"_",
"",
"_",
"",
"_",
"",
"_",
"",
"_",
"",
"_"
	};
	int p;
	public Texture2D aTexture4;

	void Start()
	{
		output = string.Empty;
		p=0;
	}
	
	void Update()
	{
		if(flag){
			sliderPos.y = float.MaxValue;
			System.Threading.Thread.Sleep (150);//пауза на каждом кадре
			output += text[i++]+"\n";
			//input = string.Empty;
			p += 15;
			Debug.Log( i );
			if (i==text.Length){
				System.Threading.Thread.Sleep (300);
				flag = false;
				i=0;
				output = string.Empty;
				p=0;
				Application.LoadLevel("MM7_MainMenu");
			}
			if(Input.GetKeyDown(KeyCode.Escape)){
				flag = false;	
				i=0;
				output = string.Empty;
				p=0;
			}	
		}
	}
	
	void OnGUI()
	{ 
		if(flag){

			GUI.DrawTexture(new Rect((Screen.width/2)-320,(Screen.height/2)-240,640,480), aTexture4);

			GUI.BeginGroup (new Rect((Screen.width / 2)+100, Screen.height/2 -200, 220,  410));
			GUILayout.BeginArea(new Rect(0, ((Screen.height/2)+200) - p, 400, p));
			GUI.skin = skin;
			GUILayout.Label(output);
			GUILayout.EndArea();
			GUI.EndGroup ();
		}
	}
}
