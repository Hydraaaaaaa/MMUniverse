var ButtonSkin_Empty : GUISkin;

public var paused : boolean = false; //объявляем булевую переменную паузы

public var aTexture : Texture;
public var Chest_tex : Texture;
public var nullTexture : Texture2D;
public var fadeColor : Color;

function Start () {

	//Cursor.visible = false;
	nullTexture = new Texture2D(1,1) as Texture2D;
	nullTexture.SetPixel(0,0, Color.black);
	nullTexture.Apply();
	fadeColor =  Color.black;
}

function Update () {

	//При нажатии ескепи
	if(Input.GetKeyDown(KeyCode.Escape)){					//Экран свободен от других окон
		if(!GetComponent("MouseSelect").chest_flag
		&& !GetComponent("MouseSelect").weaponsmith_door_flag
		&& !GetComponent("MouseSelect").armor_door_flag
		&& !GetComponent("MouseSelect").tavern_door_flag
		&& !GetComponent("MouseSelect").home1_door_flag){
			if(!paused){
				Time.timeScale=0;
				paused = true;
				//Cursor.visible=true;
				//GetComponent("FirstPersonController").enabled = false;
				GetComponent("MovePlayer").enabled = false;
				//GetComponent("Crosshair").enabled = false;
				GameObject.Find("Interface").GetComponent("AudioSource").Pause();
				GetComponent("MouseSelect").menu_flag = true;
			}
			else if(paused){
				Time.timeScale=1;
				paused = false;
				//Cursor.visible=false;
				GetComponent("MovePlayer").enabled = true;
				//GetComponent("Crosshair").enabled = true;
				GameObject.Find("Interface").GetComponent("AudioSource").Play();
				GetComponent("MouseSelect").menu_flag = false;
			}
		}
		else{															//имеются другие окна
			GetComponent("MouseSelect").chest_flag = false;
			GetComponent("MouseSelect").weaponsmith_door_flag = false;
			GetComponent("MouseSelect").armor_door_flag = false;
			GetComponent("MouseSelect").tavern_door_flag = false;
			GetComponent("MouseSelect").home1_door_flag = false;			
			Time.timeScale=1;
			//Cursor.visible=false;
			GetComponent("MovePlayer").enabled = true;
			//GetComponent("Crosshair").enabled = true;
		}
	}

}

function OnGUI(){

	if(GetComponent("MouseSelect").chest_flag){							//сундук
	
		fadeColor.a = 0.8;
		GUI.color = fadeColor;
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), nullTexture, ScaleMode.StretchToFill, true);
		
		GUI.color = Color.white;		
		GUI.DrawTexture(new Rect((Screen.width/2)-256,(Screen.height/2)-192,512,384), Chest_tex);
		Time.timeScale=0;
		//Cursor.visible=true;
		GetComponent("MovePlayer").enabled = false;
		//GetComponent("Crosshair").enabled = false;
	}
	else if(GetComponent("MouseSelect").weaponsmith_door_flag){			//оружейник
		//GUI.DrawTexture(new Rect((Screen.width/2)-256,(Screen.height/2)-128,512,384), Chest_tex);
		Time.timeScale=0;
		//Cursor.visible=true;
		GetComponent("MovePlayer").enabled = false;
		//GetComponent("Crosshair").enabled = false;
		GameObject.Find("for_events").GetComponent("Video_Player").video_number = 1;		
	}
	else if(GetComponent("MouseSelect").armor_door_flag){				//бронник
		//GUI.DrawTexture(new Rect((Screen.width/2)-256,(Screen.height/2)-128,512,384), Chest_tex);
		Time.timeScale=0;
		//Cursor.visible=true;
		GetComponent("MovePlayer").enabled = false;
		//GetComponent("Crosshair").enabled = false;
		GameObject.Find("for_events").GetComponent("Video_Player").video_number = 2;		
	}	
	else if(GetComponent("MouseSelect").tavern_door_flag){				//таверна
		//GUI.DrawTexture(new Rect((Screen.width/2)-256,(Screen.height/2)-128,512,384), Chest_tex);
		Time.timeScale=0;
		//Cursor.visible=true;
		GetComponent("MovePlayer").enabled = false;
		//GetComponent("Crosshair").enabled = false;
		GameObject.Find("for_events").GetComponent("Video_Player").video_number = 3;		
	}	
	else if(GetComponent("MouseSelect").home1_door_flag){				//дом1
		//GUI.DrawTexture(new Rect((Screen.width/2)-256,(Screen.height/2)-128,512,384), Chest_tex);
		Time.timeScale=0;
		//Cursor.visible=true;
		GetComponent("MovePlayer").enabled = false;
		//GetComponent("Crosshair").enabled = false;
		GameObject.Find("for_events").GetComponent("Video_Player").video_number = 4;		
	}		
	else if(paused==true){												//меню игры
		GetComponent("MovePlayer").enabled = false;
		//GameObject.Find("Interface").GetComponent("AudioSource").Pause();
		
		fadeColor.a = 0.8;
		GUI.color = fadeColor;
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), nullTexture, ScaleMode.StretchToFill, true);
		
		GUI.color = Color.white;
		GUI.DrawTexture(new Rect((Screen.width/2)-230,(Screen.height/2)-172,460,344), aTexture);

		GUILayout.BeginArea(new Rect((Screen.width/2)+5, (Screen.height/2)-23, 210, 344));
		
		GUI.skin = ButtonSkin_Empty;
		if(GUILayout.Button("Options",GUILayout.Width(300), GUILayout.Height(35))){
			//Application.LoadLevel(0);		
		}
		if(GUILayout.Button("Exit",GUILayout.Width(300), GUILayout.Height(35))){
			Application.LoadLevel("MM7_MainMenu");		
		}
		if(GUILayout.Button("Continue",GUILayout.Width(300), GUILayout.Height(35))){
			Time.timeScale=1;
			paused = false;
			//Cursor.visible=false;
			GetComponent("MovePlayer").enabled = true;
			//GetComponent("Crosshair").enabled = true;
			//GameObject.Find("Interface").GetComponent("AudioSource").Play();
		}

		GUILayout.EndArea();
	}
}