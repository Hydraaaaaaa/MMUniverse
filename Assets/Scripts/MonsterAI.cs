/// <summary>
/// 
/// </summary>
using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

	public Transform target;
    public GameObject oreol;   
	public int moveSpeed;       
	public int rotationSpeed;   
	public float maxDistance;
    public float lookDistance;
    private float curDistance; 
	public int ReactionDistance; 
    public float range_trips;
    public float m_height;
    private float PointDistance; 
	public GameObject ObjPoint; 
	private Transform Point; 
    public Terrain terra;
    private float M_Time;
    private Transform myTransform;
    Vector3 moveDirection;

    public bool a_Idle;
	public bool a_Walk;

    public float a_IdleSpeed = 1;

    public float a_WalkSpeed = 1;
    public Animator anim;

    public bool monster_atack;
    public float next_atack_timer;
    public float wound_timer;
    private AudioSource m_AudioSource;
    public AudioClip[] atack_sounds = new AudioClip[2];

    public enum MonsterStat 
   	{
    	idle,
		walkPlayer,
		walkPoint
   	}
	
	private MonsterStat _monsterStat;
    public enum AIState : int
    {
        Standing = 0,
        Tethered = 1,
        AttackingMelee = 2,
        AttackingRanged1 = 3,
        Dying = 4,
        Dead = 5,
        Pursuing = 6,
        Fleeing = 7,
        Stunned = 8,
        Fidgeting = 9,
        Interacting = 10,
        Removed = 11,
        AttackingRanged2 = 12,
        AttackingRanged3 = 13,
        Stoned = 14,
        Paralyzed = 15,
        Resurrected = 16,
        Summoned = 17,
        AttackingRanged4 = 18,
        Disabled = 19,
    };
    public AIState uAIState = AIState.Standing;

    public enum HostilityRadius : int
    {
        Hostility_Friendly = 0,
        Hostility_Close = 1,
        Hostility_Short = 2,
        Hostility_Medium = 3,
        Hostility_Long = 4
    };
    public HostilityRadius uHostilityType;
    void Awake(){
		myTransform = transform;
		
	}

	// Use this for initialization
	void Start () {
        m_AudioSource = GetComponent<AudioSource>();

        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
		Point = ObjPoint.transform;
		PointDistance = 0.0f;
        anim = GetComponent<Animator>();

        if (maxDistance == null)
            maxDistance = 3;
	}
    /*void FixedUpdate()
    {
        if (GetComponent<Actors>().sCurrentHP <= 0)// жив ли актор?
        {
            anim.SetBool("anim_die", true);
            anim.SetBool("monster_walk1", false);
            uAIState = AIState.Dead;
        }
            if (uAIState == AIState.Dead)
            {
                anim.SetBool("anim_die", true);
                anim.SetBool("monster_walk1", false);
            }
    }*/
        // Update is called once per frame
    void FixedUpdate()
    {
        curDistance = Vector3.Distance(target.position, myTransform.position);//определение дистанции между персонажем и актором
        if (lookDistance > curDistance)
        {
            if (wound_timer > 0f)
                wound_timer -= 0.1f;
            if (wound_timer <= 0)
            {
                anim.SetBool("anim_wound", false);
                if (next_atack_timer > 0f)
                    next_atack_timer -= 0.1f;
                if (monster_atack && next_atack_timer <= 0f)
                {
                    ActorAtack();
                    next_atack_timer = 9f;
                }
                if (GetComponent<Actors>().sCurrentHP <= 0)// жив ли актор?
                {
                    anim.SetBool("anim_die", true);
                    anim.SetBool("monster_walk1", false);
                    uAIState = AIState.Dead;
                    //oreol.GetComponent<Characters_panel>().indicator = Characters_panel.Indicator.green;

                }
                if (uAIState == AIState.Dead)
                {
                    anim.SetBool("anim_die", true);
                    anim.SetBool("monster_walk1", false);
                    //oreol.GetComponent<Characters_panel>().indicator = Characters_panel.Indicator.green;
                }
                if (Time.timeScale == 0)
                    return;
                
                PointDistance = Vector3.Distance(Point.position, myTransform.position);//определение дистанции между актором и точкой респавна
                Quaternion temp_rot = transform.rotation;
                transform.LookAt(GameObject.Find("FPSController").transform);// поворот спрайта лицом к персонажу
                temp_rot.x = 0;
                temp_rot.y = transform.rotation.y;
                temp_rot.z = transform.rotation.z;
                transform.rotation = temp_rot;

                //transform.Rotate(temp_rot.x, temp_rot.y, temp_rot.z, Space.World);
                if (CanAct())//проверка активен ли актор
                {
                    int Cur_HP = GetComponent<Actors>().sCurrentHP;

                    if (GetComponent<Actors>().sCurrentHP > 0)// жив ли актор?
                    {
                        if (uHostilityType == HostilityRadius.Hostility_Friendly)// проверка дружественности актора
                        {
                            if (PointDistance > range_trips)//текущая дистанция от актора до точки респавна больше ли значения range_trips
                            {
                                //движение к точке респавна
                                M_Time = 30;// 5 секунд
                                _monsterStat = MonsterStat.walkPoint;//флаг движения к точке
                                anim.SetBool("monster_walk1", true);//флаг движения
                                int num = SelectAnimWalk(Point.position, myTransform.position); //определение номера анимации
                                anim.SetInteger("anim_num", num);//задать номер анимации движения
                            }
                            else
                            {
                                if (AI_StandOrBored())//случайный выбор стоять или идти
                                {
                                    //стоим
                                    if (M_Time <= 0 && (_monsterStat == MonsterStat.walkPlayer || _monsterStat == MonsterStat.walkPoint))//проверка движемся и анимация окончена
                                    {
                                        M_Time = 30;// 5 секунд
                                        _monsterStat = MonsterStat.idle;
                                        anim.SetBool("monster_walk1", false);//stand
                                    }
                                }
                                else if (M_Time <= 0 && _monsterStat == MonsterStat.idle)//идем
                                {
                                    //выбор случайного направления
                                    float rnd = Random.Range(0, 2);
                                    rnd = (rnd > 0) ? 0.1f : -0.1f;
                                    float rnd1 = Random.Range(0, 2);
                                    rnd1 = (rnd > 0) ? 0.1f : -0.1f;
                                    moveDirection = new Vector3(rnd, 0f, rnd1);

                                    //выравнивание по высоте с землёй
                                    Vector3 pos = transform.position;
                                    pos.y = terra.SampleHeight(transform.position) - m_height;
                                    transform.position = pos;

                                    Vector3 new_pos = transform.position;
                                    if (new_pos.y > -0.8f)//ограничить вход актора в глубину
                                    {
                                        new_pos += moveSpeed * moveDirection * Time.deltaTime;
                                        int num = SelectAnimWalk(new_pos, myTransform.position);
                                        myTransform.position = new_pos;
                                        _monsterStat = MonsterStat.walkPlayer;
                                        if (anim.GetBool("monster_walk1") == false)
                                        {
                                            anim.SetBool("monster_walk1", true);//walk

                                            anim.SetInteger("anim_num", num);
                                        }
                                        M_Time = 30;// 5 секунд
                                    }
                                }
                                //убегание от агрессора
                            }
                            if (M_Time > 0)//время проигрывания анимации не закончилось
                            {
                                M_Time -= Time.deltaTime;//уменьшить время анимации
                                if (_monsterStat == MonsterStat.walkPlayer)//актор движется в произвольном направлении
                                {
                                    Vector3 pos = transform.position;
                                    pos.y = terra.SampleHeight(transform.position) - m_height;
                                    transform.position = pos;
                                    Vector3 new_pos = transform.position;
                                    if (new_pos.y > -0.8f)
                                    {
                                        new_pos += moveSpeed * moveDirection * Time.deltaTime;
                                        int num = SelectAnimWalk(new_pos, myTransform.position);
                                        myTransform.position = new_pos;
                                        anim.SetInteger("anim_num", num);
                                    }
                                }
                                else if (_monsterStat == MonsterStat.walkPoint)//актор движется к точке респавна
                                {
                                    Vector3 pos = transform.position;
                                    pos.y = terra.SampleHeight(transform.position) - m_height;
                                    transform.position = pos;
                                    myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(Point.position - myTransform.position), rotationSpeed * Time.deltaTime);
                                    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                                    int num = SelectAnimWalk(Point.position, myTransform.position);
                                    anim.SetInteger("anim_num", num);
                                }
                                //убегание от агрессора
                            }
                        }
                        else
                        {//не дружественный актор
                            if ((curDistance >= maxDistance) && (curDistance <= ReactionDistance))//текущая дистанция больше ближнего расстояния и меньше расстояния реакции
                            {//время приближения
                                _monsterStat = MonsterStat.walkPlayer;
                                //oreol.GetComponent<Characters_panel>().indicator = Characters_panel.Indicator.yellow;
                            }
                            else if ((curDistance > ReactionDistance) && (PointDistance > range_trips) && oreol.GetComponent<Characters_panel>().indicator != Characters_panel.Indicator.red && oreol.GetComponent<Characters_panel>().indicator != Characters_panel.Indicator.yellow)//текущая дистанция больше растояния реакции
                            {//возврат к точке
                                _monsterStat = MonsterStat.walkPoint;
                                //oreol.GetComponent<Characters_panel>().indicator = Characters_panel.Indicator.green;
                            }
                            else if ((curDistance < maxDistance))
                            {//близкий бой
                                _monsterStat = MonsterStat.idle;
                                //oreol.GetComponent<Characters_panel>().indicator = Characters_panel.Indicator.red;
                            }
                            else if (oreol.GetComponent<Characters_panel>().indicator != Characters_panel.Indicator.red && oreol.GetComponent<Characters_panel>().indicator != Characters_panel.Indicator.yellow)
                            {
                                _monsterStat = MonsterStat.idle;
                                //oreol.GetComponent<Characters_panel>().indicator = Characters_panel.Indicator.green;
                            }

                            switch (_monsterStat)
                            {
                                case MonsterStat.idle:

                                    //Debug.DrawLine(target.position, myTransform.position, Color.yellow);
                                    //GetComponent<Animation>().CrossFade("Idle1");
                                    anim.SetBool("monster_walk1", false);
                                    uAIState = AIState.AttackingMelee;
                                    monster_atack = true;
                                    break;

                                case MonsterStat.walkPlayer:
                                    monster_atack = false;
                                    //Debug.DrawLine(target.position, myTransform.position, Color.red);
                                    //Vector3 pos = terra.GetPosition();
                                    if (!GetComponent<Actors>().Actor_fly)
                                    {
                                        Vector3 pos = transform.position;
                                        pos.y = terra.SampleHeight(transform.position) - m_height;
                                        transform.position = pos;
                                    }

                                    myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);


                                    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                                    //var point = new Vector3(myTransform.position.x, 0, myTransform.position.z);
                                    //myTransform.position = new Vector3(myTransform.position.x, Terrain.activeTerrain.SampleHeight(point), myTransform.position.z);

                                    //GetComponent<Animation>().CrossFade("walk2");
                                    anim.SetBool("monster_walk1", true);
                                    break;

                                case MonsterStat.walkPoint:
                                    monster_atack = false;
                                    //Debug.DrawLine(Point.position, myTransform.position, Color.green);
                                    //Debug.DrawLine(target.position, myTransform.position, Color.yellow);


                                    myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(Point.position - myTransform.position), rotationSpeed * Time.deltaTime);

                                    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

                                    //GetComponent<Animation>().CrossFade("walk2");
                                    anim.SetBool("monster_walk1", true);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        anim.SetBool("anim_die", true);
                        anim.SetBool("monster_walk1", false);
                        uAIState = AIState.Dead;
                    }
                }
            }
        }
	}
    public void ActorAtack()
    {
        if (Time.timeScale == 0)
            return;
        //int atack = Random.Range(0, 4);
        //if (atack >= 1) {
            Collider[] cols = Physics.OverlapSphere(myTransform.position, 4f);
            foreach (Collider col in cols)
            {
                if (col.tag == "Party")
                {
                    int id = Random.Range(0, 4);
                    if (col.GetComponent<Party>().Players[id].sHealth > -20)
                        col.GetComponent<Party>().Players[id].sHealth -= 5;
                    else if (col.GetComponent<Party>().Players[id].sHealth <= 0 && col.GetComponent<Party>().Players[id].sHealth > -10)
                    {
                        col.GetComponent<Party>().Players[id].Conditions[(int)PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_UNCONCIOUS] = true;
                    }
                    else if (col.GetComponent<Party>().Players[id].sHealth <= -10)
                    {
                        col.GetComponent<Party>().Players[id].Conditions[(int)PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_ERADICATED] = true;
                    }
                    m_AudioSource.PlayOneShot(atack_sounds[0]);
                    if (col.GetComponent<Party>().Players[id].sHealth > 0)
                    {
                        int face = Random.Range(1, 3);
                        switch (face) {
                            case 1:
                                col.GetComponent<Party>().Players[id].expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MINOR;
                                break;
                            case 2:
                                col.GetComponent<Party>().Players[id].expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MODERATE;
                                break;
                            case 3:
                                col.GetComponent<Party>().Players[id].expression = PlayerStats.Character_expression_ID.CHARACTER_EXPRESSION_DMGRECVD_MAJOR;
                                break;
                        }
                        col.GetComponent<Party>().Players[id].ExpressionTimePassed = 0.5f;
                    }
                }
            }
        //}
        monster_atack = false;
    }
    void OnBecameVisible()
    {
        GetComponent<Actors>().Actor_visible = true;
    }
    void OnBecameInvisible()
    {
        GetComponent<Actors>().Actor_visible = false;
    }
    //----- (0040894B) --------------------------------------------------------
    private bool CanAct()
    {
        bool result;
        //bool isparalyzed; // esi@1
        //bool isstoned; // edi@2

        //isstoned = this.ActorBuffs[ACTOR_BUFF_STONED].uExpireTime > 0;// stoned

        //isparalyzed = (signed __int64)this->pActorBuffs[ACTOR_BUFF_PARALYZED].uExpireTime > 0;// paralyzed
        result = !(/*isstoned || isparalyzed ||*/ uAIState == AIState.Dying || uAIState == AIState.Dead
                          || uAIState == AIState.Removed || uAIState == AIState.Summoned || uAIState == AIState.Disabled);

        return result;
    }
    private bool AI_StandOrBored()
    {
        int rand;
        rand = (Random.Range(1, 3));
        if (rand == 1)//0 or 1
            return true;
        else
            return false;
    }
    private int SelectAnimWalk(Vector3 a, Vector3 b) {
        int result;
        Vector2 pointOnScreen_now;
        Vector2 pointOnScreen_next;
        bool move_approach = false;//приближается
        bool move_toward = false;//в сторону(не удаляется/не приближается)
        bool move_leave = false;//удаляется

        bool move_left = false;
        bool move_center = false;
        bool move_right = false;

        /*
        move_approach_left = 1; //приближается влево
        move_toward_left = 2; //в сторону влево
        move_leave_left = 3; //удаляется влево

        move_approach_center = 4; //ровно приближается
        move_leave_center; = 5; //ровно удаляетя

        move_approach_right = 6; //приближается вправо 
        move_toward_right = 7; //в сторону вправо
        move_leave_right = 8; //удаляется вправо

        */
        result = 0;

        float dist = Vector3.Distance(a, target.position);
        if (curDistance-0.005f > dist)
            move_approach = true;
        else if (curDistance+0.005f < dist)
            move_leave = true;
        else
            move_toward = true;

        pointOnScreen_now = Camera.main.WorldToScreenPoint(a);
        pointOnScreen_next = Camera.main.WorldToScreenPoint(b);

        bool center_right = false;
        if (pointOnScreen_now.x > pointOnScreen_next.x)
            center_right = true;
        else if (pointOnScreen_now.x < pointOnScreen_next.x)
            center_right = false;

        if (pointOnScreen_now.x - 0.1f > pointOnScreen_next.x)
            move_left = true;
        else if (pointOnScreen_now.x + 0.1f < pointOnScreen_next.x)
            move_right = true;
        else
            move_center = true;

        if (move_approach && move_left)
            result = 6;
        else if (move_toward && move_left)
            result = 7;
        else if (move_leave && move_left)
            result = 8;
        else if (move_approach && move_center)
            result = 4;
        else if (move_leave && move_center)
            result = 5;
        else if (move_approach && move_right)
            result = 1;
        else if (move_toward && move_right)
            result = 2;
        else if (move_leave && move_right)
            result = 3;
        else if (move_toward && center_right)
            result = 2;
        else
            result = 7;
            //Debug.Log("Error");

        return result;
    }
}