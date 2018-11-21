//Меню
var new_game = false;
var load_game = false;
var creators = false;
var quit_game = false;


//Камеры
var camera1 : Camera;
var camera2 : Camera;
var camera3 : Camera;

//Меню настроек
var load = false;
var cancel = false;

var cancel_creation = false;
var reset_creation = false;
var OK_creation = false;
/*//Графика
var Low = false;
var Medium = false;
var High = false;
var Fantastic = false;

var BackM = false;*/

function OnMouseEnter() {
	  GetComponent.<Renderer>().enabled = true;
}

function OnMouseExit() {
	GetComponent.<Renderer>().enabled = false;
}

function OnMouseUp() {
	if(new_game == true) {
		//Application.LoadLevel(1);
		camera1.enabled = false;
	    camera2.enabled = false;
		camera3.enabled = true;		
	}
	if(load_game == true) {
		camera1.enabled = false;
		camera2.enabled = true;
		camera3.enabled = false;
	}
	/*if(creators == true) {
		Application.LoadLevel(2);
	}*/
	if(quit_game == true) {
		Application.Quit();
	}
	//===============
	if(cancel == true) {
		camera1.enabled = true;
		camera2.enabled = false;
	}
	//===============
	if(OK_creation == true) {
		Application.LoadLevel(1);
	}
}
function Update () {
  if (Input.GetKeyDown(KeyCode.Escape)){
   		camera1.enabled = true;
		camera2.enabled = false;
		camera3.enabled = false;
  }

}