#pragma strict
var cornr_UL_Texture : Texture;		//32х32
var cornr_UR_Texture : Texture;
var cornr_LL_Texture : Texture;
var cornr_LR_Texture : Texture;

var Edge_Top_Texture : Texture;		//512x8
var Edge_Right_Texture : Texture;	//8x512
var Edge_Bottom_Texture : Texture;	//512x8
var Edge_Left_Texture : Texture;	//8x512

var Party_Panel_Texture : Texture;	//512x128
var Right_Panel_Texture : Texture;	//128x512
var Map_Panel_Texture : Texture;	//128x128



function OnGUI(){

	//Углы
	GUI.DrawTexture(new Rect(0,0,32,32), cornr_UL_Texture);
	GUI.DrawTexture(new Rect(Screen.width-32,0,32,32), cornr_UR_Texture);
	GUI.DrawTexture(new Rect(0,Screen.height-32,32,32), cornr_LL_Texture);
	GUI.DrawTexture(new Rect(Screen.width-32,Screen.height-32,32,32), cornr_LR_Texture);

	//линии рамки
	GUI.DrawTexture(new Rect(32,0,Screen.width-62,8), Edge_Top_Texture);
	GUI.DrawTexture(new Rect(Screen.width-10,32,10,Screen.height-64), Edge_Right_Texture);
	GUI.DrawTexture(new Rect(32,Screen.height-10,Screen.width-64,10), Edge_Bottom_Texture);
	GUI.DrawTexture(new Rect(0,32,10,Screen.height-64), Edge_Left_Texture);

	//Панель персонажей
	//GUI.DrawTexture(new Rect(Screen.width-(512+128+4),Screen.height-(128+4),512,128), Party_Panel_Texture);
	//GUI.DrawTexture(new Rect((Screen.width/2)-256,Screen.height-(128+8),512,128), Party_Panel_Texture);//background

	//Панель карты
	//GUI.DrawTexture(new Rect(Screen.width-(128+4),Screen.height-(512+4),128,128), Map_Panel_Texture);

	//Правая панель
	GUI.DrawTexture(new Rect(Screen.width-(170+4),Screen.height-(512+4),170,512), Right_Panel_Texture);


}