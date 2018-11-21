using UnityEngine;
using System.Collections;
using Engine;
using UnityEngine.UI;

public class Characters_panel : MonoBehaviour
{
    // Use this for initialization
    /*public Sprite img_green;
    public Sprite img_yellow;
    public Sprite img_red;*/
    public Texture2D[] img_green = new Texture2D[3];
    public Texture2D[] img_yellow = new Texture2D[3];
    public Texture2D[] img_red = new Texture2D[3];
    public Texture2D party_panel;
    public Texture2D active_character_oreol;
    public Texture2D active_character_indicator;
    private float indicator_timer;
    private float oreol_timer = 0f;
    private bool oreol_timer_flag;


    private int RandTemp;
    private int Id;
    private Texture2D Character1_face;
    public Texture2D[][] expression = new Texture2D[2][] { new Texture2D[7], new Texture2D[7] };
    public GameObject Party;
    private GameObject Player;
    public GameObject Person1;
    public GameObject Person2;
    public GameObject Person3;
    public GameObject Person4;

    public Texture2D[][] PC = new Texture2D[25][] {
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58], new Texture2D[58],
        new Texture2D[58]};
    public Texture2D[] PC01 = new Texture2D[58];
    public Texture2D[] PC02 = new Texture2D[58];
    public Texture2D[] PC03 = new Texture2D[58];
    public Texture2D[] PC04 = new Texture2D[58];
    public Texture2D[] PC05 = new Texture2D[58];
    public Texture2D[] PC06 = new Texture2D[58];
    public Texture2D[] PC07 = new Texture2D[58];
    public Texture2D[] PC08 = new Texture2D[58];
    public Texture2D[] PC09 = new Texture2D[58];
    public Texture2D[] PC10 = new Texture2D[58];
    public Texture2D[] PC11 = new Texture2D[58];
    public Texture2D[] PC12 = new Texture2D[58];
    public Texture2D[] PC13 = new Texture2D[58];
    public Texture2D[] PC14 = new Texture2D[58];
    public Texture2D[] PC15 = new Texture2D[58];
    public Texture2D[] PC16 = new Texture2D[58];
    public Texture2D[] PC17 = new Texture2D[58];
    public Texture2D[] PC18 = new Texture2D[58];
    public Texture2D[] PC19 = new Texture2D[58];
    public Texture2D[] PC20 = new Texture2D[58];
    public Texture2D[] PC21 = new Texture2D[58];
    public Texture2D[] PC22 = new Texture2D[58];
    public Texture2D[] PC23 = new Texture2D[58];
    public Texture2D[] PC24 = new Texture2D[58];
    public Texture2D[] PC25 = new Texture2D[58];

    public enum Condition : int
    {
        Cursed = 0,
        Weak = 1,
        Sleep = 2,
        Fear = 3,
        Drunk = 4,
        Insane = 5,
        Poison_weak = 6,
        Disease_weak = 7,
        Poison_medium = 8,
        Disease_medium = 9,
        Poison_severe = 10,
        Disease_severe = 11,
        Paralyzed = 12,
        Unconcious = 13,
        Dead = 14,
        Pertified = 15,
        Eradicated = 16,
        Zombie = 17,
        Good = 18
    }

    public GUISkin skin;
    public int Person1_ID;
    public int Person2_ID;
    public int Person3_ID;
    public int Person4_ID;
    public int Person1_expID;
    public int Person2_expID;
    public int Person3_expID;
    public int Person4_expID;
    private int Oreol_x;
    private int Oreol_y;
    public int person_oreol_ID;
    public bool Inventory_open;
    private Transform myTransform;
    public enum Indicator : int
    {
        green = 1,
        red = 2,
        yellow = 3,
    };
    public Indicator indicator;

    void Awake()
    {
        myTransform = transform;

    }

    void Start()
    {
        indicator = Indicator.green;
        RandTemp = -1;
        Faces_Init();
        Person1_ID = Person1.GetComponent<PlayerStats>().CurrentFace;
        Person2_ID = Person2.GetComponent<PlayerStats>().CurrentFace;
        Person3_ID = Person3.GetComponent<PlayerStats>().CurrentFace;
        Person4_ID = Person4.GetComponent<PlayerStats>().CurrentFace;
        person_oreol_ID = 1;
        Person1_expID = 0;
        Person2_expID = 0;
        Person3_expID = 0;
        Person4_expID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (oreol_timer > 0f)
            oreol_timer -= 0.1f;
        //Debug.Log(oreol_timer);
        /*indicator_timer += Time.deltaTime;
        if (indicator_timer > 3.0f)
            indicator_timer = 0.0f;
        int anim_num = (int)indicator_timer;*/
        UpdatePlayersAndHirelingsEmotions();

        switch (person_oreol_ID)
        {
            case 1:
                Oreol_x = 205;
                Oreol_y = 98;
                break;
            case 2:
                Oreol_x = 89;
                Oreol_y = 98;
                break;
            case 3:
                Oreol_x = -26;
                Oreol_y = 98;
                break;
            case 4:
                Oreol_x = -141;
                Oreol_y = 98;
                break;
        }

        /*if (!Temp.Player1CurentFacePath)
        {
            //fileName = "Faces/PC01";
            //Debug.Log (GetComponent<Party>().Players[0].CurrentFace+"");
            if (Temp.Player1fileName == "")
            {
                Character1_face = PC[Person1_ID][0];
                expression[0][0] = PC[Person1_ID][12];
                expression[0][1] = PC[Person1_ID][15];
                expression[0][2] = PC[Person1_ID][16];
                expression[0][3] = PC[Person1_ID][18];
                expression[0][4] = PC[Person1_ID][19];
                expression[0][5] = PC[Person1_ID][20];
                expression[0][6] = PC[Person1_ID][21];
            }
            else {
                //Character1_face = 
            }

            Temp.Player1CurentFacePath = true;
        }
        else if (Temp.Player1CurentFacePath && Temp.Player1fileName != "" && FaceAnimationTimer <= 0f)
        {
            int Rand = Random.Range(0, 7);
            if (RandTemp != Rand)
            {
                string text = "PC01";
                /*if (Rand == 1)
                    Id = 12;
                else if (Rand == 2)
                    Id = 15;
                else if (Rand == 3)
                    Id = 16;
                else if (Rand == 4)
                    Id = 18;
                else if (Rand == 5)
                    Id = 19;
                else if (Rand == 6)
                    Id = 20;
                else if (Rand == 7)
                    Id = 21;
                else
                    Id = 0;*/
        /*Character1_face = expression[0][Rand];
        RandTemp = Rand;
    }
    else {
        RandTemp = 0;
        //img.sprite = sprites[0];
    }
    FaceAnimationTimer = 10f;
}
else if (Id == 12)
{
    RandTemp = 0;
    //img.sprite = sprites[0];
    Character1_face = PC[Person1_ID][0];
}
else if (Id > 12)
{
    FaceAnimationTimer = 0.5f;
    Id = 0;
}*/

        Person1.GetComponent<PlayerStats>().ExpressionTimePassed -= Time.deltaTime;
        Person2.GetComponent<PlayerStats>().ExpressionTimePassed -= Time.deltaTime;
        Person3.GetComponent<PlayerStats>().ExpressionTimePassed -= Time.deltaTime;
        Person4.GetComponent<PlayerStats>().ExpressionTimePassed -= Time.deltaTime;
        SelectExpressionTexture();



        switch (indicator)
        {
            case Indicator.green:
                active_character_indicator = img_green[0];
                break;
            case Indicator.yellow:
                active_character_indicator = img_yellow[0];
                break;
            case Indicator.red:
                active_character_indicator = img_red[0];
                break;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {			//При нажатии на 1
            Temp.ActiveCharacter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Party.GetComponent<Party>().players_Count > 1)
        {			//При нажатии на 2
            Temp.ActiveCharacter = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && Party.GetComponent<Party>().players_Count > 2)
        {			//При нажатии на 3
            Temp.ActiveCharacter = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && Party.GetComponent<Party>().players_Count > 3)
        {			//При нажатии на 4
            Temp.ActiveCharacter = 4;
        }
    }
    public void Faces_Init()
    {
        for (int j = 0; j < 58; j++)
        {
            PC[0][j] = PC01[j];
            PC[1][j] = PC02[j];
            PC[2][j] = PC03[j];
            PC[3][j] = PC04[j];
            PC[4][j] = PC05[j];
            PC[5][j] = PC06[j];
            PC[6][j] = PC07[j];
            PC[7][j] = PC08[j];
            PC[8][j] = PC09[j];
            PC[9][j] = PC10[j];
            PC[10][j] = PC11[j];
            PC[11][j] = PC12[j];
            PC[12][j] = PC13[j];
            PC[13][j] = PC14[j];
            PC[14][j] = PC15[j];
            PC[15][j] = PC16[j];
            PC[16][j] = PC17[j];
            PC[17][j] = PC18[j];
            PC[18][j] = PC19[j];
            PC[19][j] = PC20[j];
            PC[20][j] = PC21[j];
            PC[21][j] = PC22[j];
            PC[22][j] = PC23[j];
            PC[23][j] = PC24[j];
            PC[24][j] = PC25[j];
        }
    }
    void OnGUI()
    {

        GUI.skin = skin;
        //панель
        GUI.DrawTexture(new Rect((Screen.width / 2) - (party_panel.width / 2), Screen.height - party_panel.height, party_panel.width, party_panel.height), party_panel);

        //партреты
        if (GUI.Button(new Rect((Screen.width / 2) - 198, Screen.height - 91, PC[Person1_ID][0].width, PC[Person1_ID][0].height), PC[Person1_ID][Person1_expID]))
        {
            if (person_oreol_ID != 1 && !Inventory_open || person_oreol_ID == 1 && !oreol_timer_flag)//не Золтан, не открыт инвент, флаг таймера ноль
            {
                person_oreol_ID = 1;
                Temp.ActiveCharacter = 1;
                oreol_timer = 1f;
                oreol_timer_flag = true;
            }
            else if (person_oreol_ID != 1 && Inventory_open)//не Золтан, открыт инвентарь
            {
                person_oreol_ID = 1;
                Temp.ActiveCharacter = 1;
                GameObject.Find("Player1").GetComponent<Inventory>().Inventory_open_flag = false;
                GameObject.Find("Player2").GetComponent<Inventory>().Inventory_open_flag = false;
                GameObject.Find("Player3").GetComponent<Inventory>().Inventory_open_flag = false;
                GameObject.Find("Player0").GetComponent<Inventory>().Inventory_open_flag = true;
            }
            else if (person_oreol_ID == 1 && oreol_timer > 0f && oreol_timer_flag)
            {
                GameObject.Find("Player0").GetComponent<Inventory>().Inventory_open_flag = true;
            }
            else if (person_oreol_ID == 1 && oreol_timer <= 0)
                oreol_timer_flag = false;

        }
        if (Party.GetComponent<Party>().players_Count > 1)
        {
            if (GUI.Button(new Rect((Screen.width / 2) - 83, Screen.height - 91, PC[Person1_ID][0].width, PC[Person1_ID][0].height), PC[Person2_ID][Person2_expID]))
            {
                if (person_oreol_ID != 2 && !Inventory_open || person_oreol_ID == 2 && !oreol_timer_flag)
                {
                    person_oreol_ID = 2;
                    Temp.ActiveCharacter = 2;
                    oreol_timer = 1f;
                    oreol_timer_flag = true;
                }
                else if (person_oreol_ID != 2 && Inventory_open)
                {
                    person_oreol_ID = 2;
                    Temp.ActiveCharacter = 2;
                    GameObject.Find("Player0").GetComponent<Inventory>().Inventory_open_flag = false;
                    GameObject.Find("Player2").GetComponent<Inventory>().Inventory_open_flag = false;
                    GameObject.Find("Player3").GetComponent<Inventory>().Inventory_open_flag = false;
                    GameObject.Find("Player1").GetComponent<Inventory>().Inventory_open_flag = true;
                }
                else if (person_oreol_ID == 2 && oreol_timer > 0f && oreol_timer_flag)
                {
                    GameObject.Find("Player1").GetComponent<Inventory>().Inventory_open_flag = true;
                }
                else if (person_oreol_ID == 2 && oreol_timer <= 0)
                    oreol_timer_flag = false;
            }
        }

        if (Party.GetComponent<Party>().players_Count > 2)
        {
            if (GUI.Button(new Rect((Screen.width / 2) + 32, Screen.height - 91, PC[Person1_ID][0].width, PC[Person1_ID][0].height), PC[Person3_ID][Person3_expID]))
            {
                if (person_oreol_ID != 3 && !Inventory_open || person_oreol_ID == 3 && !oreol_timer_flag)
                {
                    person_oreol_ID = 3;
                    Temp.ActiveCharacter = 3;
                    oreol_timer = 1f;
                    oreol_timer_flag = true;
                }
                else if (person_oreol_ID != 3 && Inventory_open)
                {
                    person_oreol_ID = 3;
                    Temp.ActiveCharacter = 3;
                    GameObject.Find("Player1").GetComponent<Inventory>().Inventory_open_flag = false;
                    GameObject.Find("Player0").GetComponent<Inventory>().Inventory_open_flag = false;
                    GameObject.Find("Player3").GetComponent<Inventory>().Inventory_open_flag = false;
                    GameObject.Find("Player2").GetComponent<Inventory>().Inventory_open_flag = true;
                }
                else if (person_oreol_ID == 3 && oreol_timer > 0f && oreol_timer_flag)
                {
                    GameObject.Find("Player2").GetComponent<Inventory>().Inventory_open_flag = true;
                }
                else if (person_oreol_ID == 3 && oreol_timer <= 0)
                    oreol_timer_flag = false;
            }
        }
    
        if (Party.GetComponent<Party>().players_Count > 3) {
            if (GUI.Button(new Rect((Screen.width / 2) + 147, Screen.height - 91, PC[Person1_ID][0].width, PC[Person1_ID][0].height), PC[Person4_ID][Person4_expID]))
            {
                if (person_oreol_ID != 4 && !Inventory_open || person_oreol_ID == 4 && !oreol_timer_flag)
                {
                    person_oreol_ID = 4;
                    Temp.ActiveCharacter = 4;
                    oreol_timer = 1f;
                    oreol_timer_flag = true;
                }
                else if (person_oreol_ID != 4 && Inventory_open)
                {
                    person_oreol_ID = 4;
                    Temp.ActiveCharacter = 4;
                    GameObject.Find("Player1").GetComponent<Inventory>().Inventory_open_flag = false;
                    GameObject.Find("Player2").GetComponent<Inventory>().Inventory_open_flag = false;
                    GameObject.Find("Player0").GetComponent<Inventory>().Inventory_open_flag = false;
                    GameObject.Find("Player3").GetComponent<Inventory>().Inventory_open_flag = true;
                }
                else if (person_oreol_ID == 4 && oreol_timer > 0f && oreol_timer_flag)
                {
                    GameObject.Find("Player3").GetComponent<Inventory>().Inventory_open_flag = true;
                }
                else if (person_oreol_ID == 4 && oreol_timer <= 0)
                    oreol_timer_flag = false;
            }
        }
        //индикаторы
        GUI.DrawTexture(new Rect((Screen.width / 2) - 204, Screen.height - 94, active_character_indicator.width, active_character_indicator.height), active_character_indicator);
        if (Party.GetComponent<Party>().players_Count > 1)
        {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 89, Screen.height - 94, active_character_indicator.width, active_character_indicator.height), active_character_indicator);
        }
        if (Party.GetComponent<Party>().players_Count > 2)
        {
            GUI.DrawTexture(new Rect((Screen.width / 2) + 26, Screen.height - 94, active_character_indicator.width, active_character_indicator.height), active_character_indicator);
        }
        if (Party.GetComponent<Party>().players_Count > 3)
        {
            GUI.DrawTexture(new Rect((Screen.width / 2) + 141, Screen.height - 94, active_character_indicator.width, active_character_indicator.height), active_character_indicator);
        }

        //ореол

        GUI.DrawTexture(new Rect((Screen.width / 2) - Oreol_x, Screen.height - Oreol_y, 69, 91), active_character_oreol);
    }
    public void SelectExpressionTexture()
    {
        int temp_ID = 0;
        GameObject CurrentPlayer = null;
        for (int i = 0; i < 4; ++i)
        {
            switch (i)
            {
                case 0:
                    CurrentPlayer = Person1;
                    break;
                case 1:
                    CurrentPlayer = Person2;
                    break;
                case 2:
                    CurrentPlayer = Person3;
                    break;
                case 3:
                    CurrentPlayer = Person4;
                    break;
            }
            if (CurrentPlayer.GetComponent<PlayerStats>().sHealth <= 0)
                CurrentPlayer.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_UNCONCIOUS;
            if (CurrentPlayer.GetComponent<PlayerStats>().sHealth <= -10)
                CurrentPlayer.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DEAD;
            switch (CurrentPlayer.GetComponent<PlayerStats>().expression)
            {
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_AGRESSOR:
                    temp_ID = 53;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_ANGER:
                    temp_ID = 43;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_APATHY:
                    temp_ID = 47;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_DOWN:
                    temp_ID = 30;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_LEFT:
                    temp_ID = 29;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_RIGHT:
                    temp_ID = 25;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_UP:
                    temp_ID = 33;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BLINKED:
                    temp_ID = 14;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_CENTER:
                    temp_ID = 27;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_CLOSED_EYES:
                    temp_ID = 13;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_CRY:
                    temp_ID = 49;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_CURSED:
                    temp_ID = 2;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DEAD:
                    temp_ID = 57;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DISEASED:
                    temp_ID = 9;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MAJOR:
                    temp_ID = 39;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MINOR:
                    temp_ID = 37;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MODERATE:
                    temp_ID = 38;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DRUNK:
                    temp_ID = 6;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_ERADICATED:
                    temp_ID = 58;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_EUREKA:
                    temp_ID = 50;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_FALLING:
                    temp_ID = 58;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_FEAR:
                    temp_ID = 5;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_INSANE:
                    temp_ID = 7;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_INVALID:
                    temp_ID = 1;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_LAUGH:
                    temp_ID = 41;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_NORMAL:
                    temp_ID = 1;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_OPENED_MOUTH1:
                    temp_ID = 15;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_OPENED_MOUTH2:
                    temp_ID = 16;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_PARALYZED:
                    temp_ID = 10;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_PERTIFIED:
                    temp_ID = 12;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_POISONED:
                    temp_ID = 8;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_RAISED_EYEBROW_BIG:
                    temp_ID = 51;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_RAISED_EYEBROW_SMAL:
                    temp_ID = 52;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_RED:
                    temp_ID = 54;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SADNESS:
                    temp_ID = 42;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SCARED:
                    temp_ID = 56;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SHAME:
                    temp_ID = 45;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SHOCK:
                    temp_ID = 44;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SLEEP:
                    temp_ID = 4;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_DOWN:
                    temp_ID = 31;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_LEFT:
                    temp_ID = 28;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_RIGHT:
                    temp_ID = 26;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_UP:
                    temp_ID = 32;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SMILE:
                    temp_ID = 40;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SMIRK:
                    temp_ID = 48;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SQUATTING_BIG:
                    temp_ID = 36;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SQUATTING_MEDIUM:
                    temp_ID = 35;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SQUATTING_SMALL:
                    temp_ID = 34;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SURPRISE1:
                    temp_ID = 21;//21-24
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_TENDER:
                    temp_ID = 46;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_TIPSY:
                    temp_ID = 55;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_UNCONCIOUS:
                    temp_ID = 11;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_VIEWDOWN:
                    temp_ID = 20;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_VIEWLEFT:
                    temp_ID = 19;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_VIEWRIGHT:
                    temp_ID = 18;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_VIEWUP:
                    temp_ID = 17;
                    break;
                case PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_WEAK:
                    temp_ID = 3;
                    break;
                default:
                    Debug.Log("Отсутствует мимика для данного состояния");
                    break;
            }
            if (i == 0)
                Person1_expID = temp_ID - 1;
            else if (i == 1)
                Person2_expID = temp_ID - 1;
            else if (i == 2)
                Person3_expID = temp_ID - 1;
            else
                Person4_expID = temp_ID - 1;
        }
    }
    //----- (004909F4) --------------------------------------------------------
    void UpdatePlayersAndHirelingsEmotions()
    {
        int v4; // edx@27

        for (int i = 0; i < 4; ++i)
        {
            /*Player* player = &pPlayers[i];
            player->uExpressionTimePassed += (unsigned short)pMiscTimer->uTimeElapsed;*/

            switch (i)
            {
                case 0:
                    Player = Person1;
                    break;
                case 1:
                    Player = Person2;
                    break;
                case 2:
                    Player = Person3;
                    break;
                case 3:
                    Player = Person4;
                    break;
            }

            Condition condition = (Condition)Party.GetComponent<Party>().GetMajorConditionIdx(i);
            if (condition == Condition.Good || condition == Condition.Zombie)
            {
                /*if (player->uExpressionTimePassed < player->uExpressionTimeLength)
                    continue;*/
                if (Player.GetComponent<PlayerStats>().ExpressionTimePassed <= 0f)
                {
                    Player.GetComponent<PlayerStats>().ExpressionTimePassed = 0;
                    if (Player.GetComponent<PlayerStats>().expression != PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_NORMAL
                        || Random.Range(0, 10) == 2)
                    {
                        Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_NORMAL;
                        Player.GetComponent<PlayerStats>().ExpressionTimePassed = (float)(Random.Range(0, 8) + 8);//rand() % 256 + 32;
                    }
                    else
                    {
                        v4 = Random.Range(0, 100);
                        if (v4 < 25) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_CLOSED_EYES;
                        else if (v4 < 31) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BLINKED;
                        else if (v4 < 37) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_OPENED_MOUTH1;
                        else if (v4 < 43) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_OPENED_MOUTH2;
                        else if (v4 < 46) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_VIEWUP;
                        else if (v4 < 52) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_VIEWRIGHT;
                        else if (v4 < 58) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_VIEWLEFT;
                        else if (v4 < 64) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_VIEWDOWN;
                        else if (v4 < 70) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_RIGHT;
                        else if (v4 < 76) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_RIGHT;
                        else if (v4 < 82) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_UP;
                        else if (v4 < 88) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_LEFT;
                        else if (v4 < 94) Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_LEFT;
                        else Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_DOWN;
                        Player.GetComponent<PlayerStats>().ExpressionTimePassed = 0.5f;
                    }
                }
                /*for (unsigned int j = 0; j < pPlayerFrameTable->uNumFrames; ++j)
                {
                    PlayerFrame* frame = &pPlayerFrameTable->pFrames[j];
                    if (frame->expression == player->expression)
                    {
                        player->uExpressionTimeLength = 8 * frame->uAnimLength;
                        break;
                    }
                }*/
            }
            else if (Player.GetComponent<PlayerStats>().expression != PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MINOR &&
                     Player.GetComponent<PlayerStats>().expression != PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MODERATE &&
                     Player.GetComponent<PlayerStats>().expression != PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MAJOR)
            {
                //player->uExpressionTimeLength = 0;
                //player->uExpressionTimePassed = 0;

                switch (condition)
                {
                    case Condition.Dead: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DEAD; break;
                    case Condition.Pertified: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_PERTIFIED; break;
                    case Condition.Eradicated: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_ERADICATED; break;
                    case Condition.Cursed: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_CURSED; break;
                    case Condition.Weak: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_WEAK; break;
                    case Condition.Sleep: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_SLEEP; break;
                    case Condition.Fear: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_FEAR; break;
                    case Condition.Drunk: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DRUNK; break;
                    case Condition.Insane: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_INSANE; break;
                    case Condition.Poison_weak:
                    case Condition.Poison_medium:
                    case Condition.Poison_severe: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_POISONED; break;
                    case Condition.Disease_weak:
                    case Condition.Disease_medium:
                    case Condition.Disease_severe: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DISEASED; break;
                    case Condition.Paralyzed: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_PARALYZED; break;
                    case Condition.Unconcious: Player.GetComponent<PlayerStats>().expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_UNCONCIOUS; break;
                    default:
                        Debug.Log("Invalid condition");
                        break;
                }
            }
        }

        /*for (int i = 0; i< 2; ++i)
        {
          NPCData* hireling = &pParty->pHirelings[i];
          if (!hireling->evt_C)
            continue;

          hireling->evt_B += pMiscTimer->uTimeElapsed;
          if (hireling->evt_B >= hireling->evt_C)
          {
            hireling->evt_A = 0;
            hireling->evt_B = 0;
            hireling->evt_C = 0;

            Assert(sizeof(NPCData) == 0x4C);
            memset(hireling, 0, sizeof(*hireling));

            pParty->hirelingScrollPosition = 0;
            pParty->CountHirelings();
          viewparams->bRedrawGameUI = true;
          }
        }*/
    }

}