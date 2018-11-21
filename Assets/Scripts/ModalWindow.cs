using UnityEngine;
using System.Collections;

public class ModalWindow : MonoBehaviour {
    public Texture GUITextureBackground;
    public Texture2D tex_horizontal_top;
    public Texture2D tex_horizontal_btm;
    public Texture2D tex_vertical_left;
    public Texture2D tex_vertical_right;
    public Texture2D tex_left_up;
    public Texture2D tex_right_up;
    public Texture2D tex_left_bottom;
    public Texture2D tex_right_bottom;
    public Texture2D Item_texture;
    public GUISkin skinTemp;
    public bool flag = false;
    public float x;
    public float y;
    public string text;
    public string Topic;
    public string Item_type;
    public string Item_mod;
    public uint price;
    public int curlegth;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        if (flag)
            OnGUIHint( x, y, text, curlegth);
    }
    public void OnGUIHint(float x, float y, string text, int curlegth)
    {
        //fadeColor.a = 0.8f;
        //GUI.color = fadeColor;
        //GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), nullTexture, ScaleMode.StretchToFill, true);
        if (text == "")
        {
            //MessageBoxW(nullptr, L"Invalid string passed !", L"E:\\WORK\\MSDEV\\MM7\\MM7\\Code\\Font.cpp:445", 0);
            Debug.Log("Строка пуста");
            return;
        }

        int uInStrLen = text.Length;
        int InStrLen = text.Length;//Узнать длину строки
        if (curlegth == 0)
            curlegth = 70;
        int num_line = uInStrLen / curlegth;

        double ir;
        int line = 0;
        int vline = 0;

        if (uInStrLen < 35)
            line = 8;
        if (num_line > 0)
            vline = 18;
        //получить длину строки
        if (uInStrLen > curlegth)
            uInStrLen = curlegth;
        ir = uInStrLen * 0.78;
        //Debug.Log( ir );
        int w = uInStrLen * 9;
        int z = (num_line * 20) + 32;
        if (Item_texture.height + 32 > z)
        {
            z = Item_texture.height + 32;
            //подложка
            GUI.DrawTexture(new Rect((Screen.width / 2) - x, (Screen.height / 2) - y, w + Item_texture.width, z), GUITextureBackground);
            //рамка
            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) - 4, ((Screen.height / 2) - y) - 4, 32, 32), tex_left_up);//верхний левый угол
            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) + 28, ((Screen.height / 2) - y) - 4, ((w + Item_texture.width) - (int)ir) - line, 8), tex_horizontal_top);//верхняя горизонтальная полоса
            GUI.DrawTexture(new Rect((((Screen.width / 2) - x) + w + Item_texture.width) - 28, ((Screen.height / 2) - y) - 4, 32, 32), tex_right_up);//верхний правый угол

            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) - 4, ((Screen.height / 2) - y) + 28, 8, z - 32/*(vline * num_line)*/), tex_vertical_left);//вертикальная левая полоса

            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) - 4, (((Screen.height / 2) - y) + z) - 28, 32, 32), tex_left_bottom);//нижний левый угол
            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) + 28, ((Screen.height / 2) - y) + z - 4, ((w + Item_texture.width) - (int)ir) - line, 8), tex_horizontal_btm);//нижняя горизонтальная полоса
            GUI.DrawTexture(new Rect((((Screen.width / 2) - x) + w + Item_texture.width) - 28, (((Screen.height / 2) - y) + z) - 28, 32, 32), tex_right_bottom);//нижний правый угол

            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) + (w + Item_texture.width) - 4, ((Screen.height / 2) - y) + 28, 8, z - 32/*(vline * num_line)*/), tex_vertical_right);

            //цена вещи
            GUI.Label(new Rect((Screen.width / 2) - (x - (Item_texture.width + 64)), (((Screen.height / 2) - y) + z) - 24, w - 64, z), "Реальная цена: " + price);
        }
        else
        {
            //подложка
            GUI.DrawTexture(new Rect((Screen.width / 2) - x, (Screen.height / 2) - y, w + Item_texture.width, z + 64), GUITextureBackground);
            //рамка
            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) - 4, ((Screen.height / 2) - y) - 4, 32, 32), tex_left_up);//верхний левый угол
            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) + 28, ((Screen.height / 2) - y) - 4, ((w + Item_texture.width) - (int)ir) - line, 8), tex_horizontal_top);//верхняя горизонтальная полоса
            GUI.DrawTexture(new Rect((((Screen.width / 2) - x) + w + Item_texture.width) - 28, ((Screen.height / 2) - y) - 4, 32, 32), tex_right_up);//верхний правый угол

            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) - 4, ((Screen.height / 2) - y) + 28, 8, (z+64) - 32/*(vline * num_line)*/), tex_vertical_left);//вертикальная левая полоса

            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) - 4, (((Screen.height / 2) - y) + (z+64)) - 28, 32, 32), tex_left_bottom);//нижний левый угол
            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) + 28, ((Screen.height / 2) - y) + (z+64) - 4, ((w + Item_texture.width) - (int)ir) - line, 8), tex_horizontal_btm);//нижняя горизонтальная полоса
            GUI.DrawTexture(new Rect((((Screen.width / 2) - x) + w + Item_texture.width) - 28, (((Screen.height / 2) - y) + (z+64)) - 28, 32, 32), tex_right_bottom);//нижний правый угол

            GUI.DrawTexture(new Rect(((Screen.width / 2) - x) + (w + Item_texture.width) - 4, ((Screen.height / 2) - y) + 28, 8, (z+64) - 32/*(vline * num_line)*/), tex_vertical_right);
            
            //цена вещи
            GUI.Label(new Rect((Screen.width / 2) - (x - (Item_texture.width + 64)), (((Screen.height / 2) - y) + (z + 64)) - 24, w - 64, z + 64), "Реальная цена: " + price);
        }
        //картинка вещи
        GUI.DrawTexture(new Rect((Screen.width / 2) - (x-32), (Screen.height / 2) - (y-16), Item_texture.width, Item_texture.height), Item_texture);
        
        //Заголовок

        
        GUI.skin = skinTemp;
        //Заголовок
        GUI.color = new Color(209, 187, 0/*97*/, 1);
        GUI.skin.label.fontSize = 16;
        GUI.Label(new Rect((Screen.width / 2) - (x - (Item_texture.width + 64)), (Screen.height / 2) - y, w - 64, z), Topic);
        GUI.color = Color.white;
        GUI.skin.label.fontSize = 12;
        GUI.Label(new Rect((Screen.width / 2) - (x - (Item_texture.width + 64)), (Screen.height / 2) - (y-32), w - 64, z), "Тип: "+Item_type);
        //текст описания
        GUI.TextArea(new Rect((Screen.width / 2) - (x-(Item_texture.width+64)), (Screen.height / 2) - (y-64), w-64, z), text, InStrLen);

        //flag = false;
    }
}
