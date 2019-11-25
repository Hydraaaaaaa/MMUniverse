using UnityEngine;
using System.Collections;

public class HealthBarC : MonoBehaviour {
	
	public Texture2D maxHpBar;
	public Texture2D hpBar;
	public Texture2D mpBar;
	public Texture2D expBar;
	public Vector2 maxHpBarPosition = new Vector2(20,20);
	public Vector2 hpBarPosition = new Vector2(152,48);
	public Vector2 mpBarPosition = new Vector2(152,71);
	public Vector2 expBarPosition = new Vector2(152,94);
	public Vector2 levelPosition = new Vector2(28,86);
	public int maxHpBarWidth = 310;
	public int maxHpBarHeigh = 115;
	public int barHeight = 19;
	public int expBarHeight = 8;
	public GUIStyle textStyle;
	public GUIStyle hpTextStyle;

    public Vector2 active_character_indicator_xy = new Vector2(42, 21);
    public int active_character_indicator_height = 100;
    public int active_character_indicator_width = 127;

    public Vector2 PC_xy = new Vector2(42, 21);
    public int PC_height = 100;
    public int PC_width = 127;

    public Vector2 Oreol_xy = new Vector2(40, 21);
    public int Oreol_width = 111;
    public int Oreol_height = 103;

    public Texture2D active_character_oreol;
    public Texture2D active_character_indicator;
    private float indicator_timer;
    private float oreol_timer = 0f;
    private bool oreol_timer_flag;
    public Texture2D[] img_green = new Texture2D[3];
    public Texture2D[] img_yellow = new Texture2D[3];
    public Texture2D[] img_red = new Texture2D[3];

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
    public StatusC status;
    int ExpirionsId = 0;

    public GUISkin skin;
    public int person_oreol_ID;

    public enum Indicator : int
    {
        green = 1,
        red = 2,
        yellow = 3,
    };
    public Indicator indicator = Indicator.green;

    public float barMultiply = 1.6f;
	
	public GameObject player;
	private float hptext = 100;
	
	void  Awake (){
		if(!player){
			player = GameObject.FindWithTag("Player");
		}
		hptext = 100 * barMultiply;
        Faces_Init();
        status = player.GetComponent<StatusC>();
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
    void Update()
    {
        if (oreol_timer > 0f)
            oreol_timer -= 0.1f;

        UpdatePlayersEmotions();

        status.ExpressionTimePassed -= Time.deltaTime;
        SelectExpressionTex();



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
    }

    public void SelectExpressionTex()
    {
        int temp_ID = 0;
        if (status.health <= 0)
           status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_UNCONCIOUS;
        if (status.health <= -10)
           status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DEAD;
        switch (status.expression)
        {
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_AGRESSOR:
                    temp_ID = 53;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_ANGER:
                    temp_ID = 43;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_APATHY:
                    temp_ID = 47;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_DOWN:
                    temp_ID = 30;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_LEFT:
                    temp_ID = 29;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_RIGHT:
                    temp_ID = 25;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_UP:
                    temp_ID = 33;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BLINKED:
                    temp_ID = 14;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_CENTER:
                    temp_ID = 27;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_CLOSED_EYES:
                    temp_ID = 13;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_CRY:
                    temp_ID = 49;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_CURSED:
                    temp_ID = 2;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DEAD:
                    temp_ID = 57;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DISEASED:
                    temp_ID = 9;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MAJOR:
                    temp_ID = 39;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MINOR:
                    temp_ID = 37;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MODERATE:
                    temp_ID = 38;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DRUNK:
                    temp_ID = 6;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_ERADICATED:
                    temp_ID = 58;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_EUREKA:
                    temp_ID = 50;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_FALLING:
                    temp_ID = 58;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_FEAR:
                    temp_ID = 5;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_INSANE:
                    temp_ID = 7;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_INVALID:
                    temp_ID = 1;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_LAUGH:
                    temp_ID = 41;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_NORMAL:
                    temp_ID = 1;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_OPENED_MOUTH1:
                    temp_ID = 15;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_OPENED_MOUTH2:
                    temp_ID = 16;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_PARALYZED:
                    temp_ID = 10;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_PERTIFIED:
                    temp_ID = 12;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_POISONED:
                    temp_ID = 8;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_RAISED_EYEBROW_BIG:
                    temp_ID = 51;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_RAISED_EYEBROW_SMAL:
                    temp_ID = 52;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_RED:
                    temp_ID = 54;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SADNESS:
                    temp_ID = 42;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SCARED:
                    temp_ID = 56;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SHAME:
                    temp_ID = 45;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SHOCK:
                    temp_ID = 44;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SLEEP:
                    temp_ID = 4;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_DOWN:
                    temp_ID = 31;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_LEFT:
                    temp_ID = 28;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_RIGHT:
                    temp_ID = 26;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_UP:
                    temp_ID = 32;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SMILE:
                    temp_ID = 40;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SMIRK:
                    temp_ID = 48;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SQUATTING_BIG:
                    temp_ID = 36;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SQUATTING_MEDIUM:
                    temp_ID = 35;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SQUATTING_SMALL:
                    temp_ID = 34;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SURPRISE1:
                    temp_ID = 21;//21-24
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_TENDER:
                    temp_ID = 46;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_TIPSY:
                    temp_ID = 55;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_UNCONCIOUS:
                    temp_ID = 11;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_VIEWDOWN:
                    temp_ID = 20;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_VIEWLEFT:
                    temp_ID = 19;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_VIEWRIGHT:
                    temp_ID = 18;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_VIEWUP:
                    temp_ID = 17;
                    break;
                case StatusC.Player_expression_ID.CHARACTER_EXPRESSION_WEAK:
                    temp_ID = 3;
                    break;
                default:
                    Debug.Log("Отсутствует мимика для данного состояния");
                    break;
        }
        ExpirionsId = temp_ID-1;
    }

    void UpdatePlayersEmotions()
    {
        int rand; 
        Condition condition = (Condition)status.GetMajorConditionIdx();
        if (condition == Condition.Good || condition == Condition.Zombie)
        {
            if (status.ExpressionTimePassed <= 0f)
            {
                status.ExpressionTimePassed = 0;
                if (status.expression != StatusC.Player_expression_ID.CHARACTER_EXPRESSION_NORMAL
                        || Random.Range(0, 10) == 2)
                {
                  status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_NORMAL;
                  status.ExpressionTimePassed = (float)(Random.Range(0, 8) + 8);//rand() % 256 + 32;
                }
                else
                {
                    rand = Random.Range(0, 100);
                    if (rand < 25) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_CLOSED_EYES;
                        else if (rand < 31) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BLINKED;
                        else if (rand < 37) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_OPENED_MOUTH1;
                        else if (rand < 43) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_OPENED_MOUTH2;
                        else if (rand < 46) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_VIEWUP;
                        else if (rand < 52) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_VIEWRIGHT;
                        else if (rand < 58) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_VIEWLEFT;
                        else if (rand < 64) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_VIEWDOWN;
                        else if (rand < 70) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_RIGHT;
                        else if (rand < 76) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_RIGHT;
                        else if (rand < 82) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_UP;
                        else if (rand < 88) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SMALL_TURN_LEFT;
                        else if (rand < 94) status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_LEFT;
                        else status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_BIG_TURN_DOWN;
                        status.ExpressionTimePassed = 0.5f;
                }
            }
        }
        else if (status.expression != StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MINOR &&
                     status.expression != StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MODERATE &&
                     status.expression != StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MAJOR)
        {
           switch (condition)
           {
                    case Condition.Dead: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DEAD; break;
                    case Condition.Pertified: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_PERTIFIED; break;
                    case Condition.Eradicated: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_ERADICATED; break;
                    case Condition.Cursed: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_CURSED; break;
                    case Condition.Weak: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_WEAK; break;
                    case Condition.Sleep: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_SLEEP; break;
                    case Condition.Fear: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_FEAR; break;
                    case Condition.Drunk: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DRUNK; break;
                    case Condition.Insane: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_INSANE; break;
                    case Condition.Poison_weak:
                    case Condition.Poison_medium:
                    case Condition.Poison_severe: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_POISONED; break;
                    case Condition.Disease_weak:
                    case Condition.Disease_medium:
                    case Condition.Disease_severe: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_DISEASED; break;
                    case Condition.Paralyzed: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_PARALYZED; break;
                    case Condition.Unconcious: status.expression = StatusC.Player_expression_ID.CHARACTER_EXPRESSION_UNCONCIOUS; break;
                    default:
                        Debug.Log("Invalid condition");
                        break;
           }
       }
    }

     void  OnGUI (){
		if(!player){
			return;
		}
		float maxHp = player.GetComponent<StatusC>().maxHealth;
		float hp = player.GetComponent<StatusC>().health * 100 / maxHp *barMultiply;
		float maxMp = player.GetComponent<StatusC>().maxMana;
		float mp = player.GetComponent<StatusC>().mana * 100 / maxMp *barMultiply;
		float maxExp = player.GetComponent<StatusC>().maxExp;
		float exp = player.GetComponent<StatusC>().exp * 100 / maxExp *barMultiply;
		float lv = player.GetComponent<StatusC>().level;
		
		int currentHp = player.GetComponent<StatusC>().health;
		int currentMp = player.GetComponent<StatusC>().mana;

        GUI.DrawTexture(new Rect(active_character_indicator_xy.x, active_character_indicator_xy.y, active_character_indicator_width, active_character_indicator_height), active_character_indicator);//Indicator		
        GUI.DrawTexture( new Rect(maxHpBarPosition.x ,maxHpBarPosition.y ,maxHpBarWidth,maxHpBarHeigh), maxHpBar);//Bar
        GUI.DrawTexture(new Rect(PC_xy.x, PC_xy.y, PC_width, PC_height), PC[4][ExpirionsId]);//portraits

        GUI.DrawTexture(new Rect(Oreol_xy.x, Oreol_xy.y, Oreol_width, Oreol_height), active_character_oreol);

        GUI.DrawTexture( new Rect(hpBarPosition.x ,hpBarPosition.y ,hp,barHeight), hpBar);
		GUI.DrawTexture( new Rect(mpBarPosition.x ,mpBarPosition.y ,mp,barHeight), mpBar);
		GUI.DrawTexture( new Rect(expBarPosition.x ,expBarPosition.y ,exp,expBarHeight), expBar);
		
		GUI.Label ( new Rect(levelPosition.x, levelPosition.y, 50, 50), lv.ToString() , textStyle);
		GUI.Label ( new Rect(hpBarPosition.x, hpBarPosition.y, hptext, barHeight), currentHp.ToString() + "/" + maxHp.ToString() , hpTextStyle);
		GUI.Label ( new Rect(mpBarPosition.x, mpBarPosition.y, hptext, barHeight), currentMp.ToString() + "/" + maxMp.ToString() , hpTextStyle);
	 }
	
}
