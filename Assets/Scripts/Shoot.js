#pragma strict

var Arrow : GameObject; //Префаб стрелы/пули
private var Timer : float; //таймер который позволяет стрелять
var Reload : float; //время перезарядкы

function Start () {
	 Cursor.visible = false; //скрыть курсор 
}

function Update () {
	Timer -= Time.deltaTime; //таймер перезарядки
	if (Input.GetKey(KeyCode.Q) && Timer <= 0) { //нажатия Q
		//rans.rotation = transform.rotation;
		transform.rotation.y = transform.rotation.y+90.0f;
 		var Arrov =  Instantiate(Arrow,transform.position,transform.rotation); //Создаем префаб стрелы в позиции обэкта на котором скрипт
 		//GameObject.Find("Arrov").GetComponent<Transform>().rotation = new Quaternion(0,180,0,0);
		Arrov.GetComponent.<Rigidbody>().AddForce(transform.forward* 10000); //придаем стреле ускорение вперед
		Timer = Reload; //устанавливаем таймер например на 2 сек
	}
}