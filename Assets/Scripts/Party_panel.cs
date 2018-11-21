using UnityEngine;
using System.Collections;

public class Party_panel : MonoBehaviour {

 public Texture2D cornr_UL_Texture;		//32х32
 public Texture2D cornr_UR_Texture;
 public Texture2D cornr_LL_Texture;
 public Texture2D cornr_LR_Texture;

 public Texture2D Edge_Top_Texture;		//512x8
 public Texture2D Edge_Right_Texture;	//8x512
 public Texture2D Edge_Bottom_Texture;	//512x8
 public Texture2D Edge_Left_Texture;//8x512

 public Texture2D Party_Panel_Texture;	//512x128
 public Texture2D Right_Panel_Texture;	//128x512
 public Texture2D Map_Panel_Texture;	//128x128



    void OnGUI(){

	//Углы
	/*GUI.DrawTexture(new Rect(0,0,32,32), cornr_UL_Texture);
	GUI.DrawTexture(new Rect(Screen.width-32,0,32,32), cornr_UR_Texture);
	GUI.DrawTexture(new Rect(0,Screen.height-32,32,32), cornr_LL_Texture);
	GUI.DrawTexture(new Rect(Screen.width-32,Screen.height-32,32,32), cornr_LR_Texture);*/

	//линии рамки
	/*GUI.DrawTexture(new Rect(32,0,Screen.width-62,8), Edge_Top_Texture);
	GUI.DrawTexture(new Rect(Screen.width-10,32,10,Screen.height-64), Edge_Right_Texture);
	GUI.DrawTexture(new Rect(32,Screen.height-10,Screen.width-64,10), Edge_Bottom_Texture);
	GUI.DrawTexture(new Rect(0,32,10,Screen.height-64), Edge_Left_Texture);*/

	//Панель персонажей
        GUI.DrawTexture(new Rect(Screen.width / 2 - Party_Panel_Texture.width / 2, Screen.height - (Party_Panel_Texture.height + 4), Party_Panel_Texture.width, Party_Panel_Texture.height), Party_Panel_Texture);
	//GUI.DrawTexture(new Rect((Screen.width/2)-256,Screen.height-(128+8),512,128), Party_Panel_Texture);//background

	//Панель карты
	//GUI.DrawTexture(new Rect(Screen.width-(128+4),Screen.height-(512+4),128,128), Map_Panel_Texture);

	//Правая панель
    //GUI.DrawTexture(new Rect(Screen.width - (170 + 4), Screen.height - (512 + 4), Right_Panel_Texture.width, Right_Panel_Texture.height), Right_Panel_Texture);


}
}
