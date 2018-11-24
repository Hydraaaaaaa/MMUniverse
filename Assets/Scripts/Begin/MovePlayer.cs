using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	[SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
	//[SerializeField] public float m_StepInterval = 0.5f;
	[SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
	[SerializeField] private AudioClip m_LandSound;
	
    private float speed = 6.0F;
	public float speedStep = 6.0f;
	public float speedShift = 9.0f;
    public float gravity = 20.0F;
	public float jump1 = 8;
    private Vector3 moveDirection = Vector3.zero;
	private bool is_walk;
	private bool is_run;
	private float walk_sound_timer = 0f;
	private bool m_Jumping;
	private AudioSource m_AudioSource;
	
	private CharacterController controller;
	
	public KeyCode forward;			//ВПЕРЕД
	public KeyCode backward;		//НАЗАД
	public KeyCode left;			//ВЛЕВО
	public KeyCode right;			//ВПРАВО
	public KeyCode strafe_left;		//ВЫДВИНУТЬСЯ ПЛЕВО
	public KeyCode strafe_right;	//ВЫДВИНУТЬСЯ ВПРАВО
	public KeyCode look_up;			//СМОТРЕТЬ ВВЕРХ
	public KeyCode look_down;		//СМОТРЕТЬ ВНИЗ
	public KeyCode look_center;		//СМОТРЕТЬ В ЦЕНТР
	public KeyCode run_walk;		//БЕГ/ХОДЬБА
	public KeyCode jump;			//ПРЫЖОК
	public KeyCode fly_up;			//ПОЛЕТ ВВЕРХ
	public KeyCode fly_down;		//ПОЛЕТ ВНИЗ
	public KeyCode landing;			//ПРИЗЕМЛЕНИЕ
	
	private bool _visible;
	
	void Start () {
		controller = GetComponent<CharacterController>();
		m_AudioSource = GetComponent<AudioSource>();
		is_walk = false;
		is_run = false;
		m_Jumping = false;
	}
	
    void Update() {
        float old_x = transform.position.x;
        float old_y = transform.position.y;
        float old_z = transform.position.z;


		if ( is_walk)//timer update
		{
			if(walk_sound_timer>0f){
				if (walk_sound_timer >= Time.deltaTime)
					walk_sound_timer -= Time.deltaTime;
				else
					walk_sound_timer = 0;
			}
		}

        if (controller.isGrounded) {
			int x = 0;
			int y = 0;
			
			if(Input.GetKey(forward)){
				x = 1;
				is_walk=true;
			}
			else if(Input.GetKey(backward)){
				x = -1;
				is_walk = true;
			}
			else{ 
				x = 0;
				is_walk = false;
			}
			
			if(Input.GetKey(strafe_left))
				y = -1;
			else if(Input.GetKey(strafe_right))
				y = 1;
			else
				y = 0;
		
            moveDirection = new Vector3(y, 0, x);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
			
			if (Input.GetKey(run_walk)){//БЕГ/ХОДЬБА
				is_run = true;
				speed = speedShift;
			}
			else{ 
				is_run = false;
				speed = speedStep;
			}
			
			if(Input.GetKeyDown(jump))//ПРЫЖОК
			{
				moveDirection += Vector3.up * jump1;
				PlayJumpSound();
				m_Jumping = true;
			}
			if (is_walk && !m_Jumping){
				PlayFootStepAudio();
			}
        }
		
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

		if (Input.GetKey (left))
			transform.Rotate (0, -(100 * Time.deltaTime), 0);
		else if (Input.GetKey (right))
			transform.Rotate (0, 100 * Time.deltaTime, 0);
		
		if (Input.GetKey (look_down)) {
			transform.Rotate ( 100 * Time.deltaTime, 0, 0);
			if (transform.eulerAngles.x > 45 && transform.eulerAngles.z == 0)
				transform.rotation = Quaternion.Euler(45, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		if (Input.GetKey (look_up)) {
			transform.Rotate ( -(100 * Time.deltaTime), 0, 0);
			if (transform.eulerAngles.x > 270 && transform.eulerAngles.z == 180)
				transform.rotation = Quaternion.Euler(270, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		if (Input.GetKey (look_center)) {
			transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		if( m_Jumping && controller.isGrounded){
			PlayLandingSound();
			m_Jumping = false;
		}
        if ((Application.loadedLevelName == "emerald_01" || Application.loadedLevelName == "Daggerwound Island"
            || Application.loadedLevelName == "new_sorpigal") && transform.position.y <= -0.5)// for water
        {
            transform.position = new Vector3(old_x, old_y, old_z);
            return;	
        }

             //if(Input.GetKeyDown(KeyCode.Escape))//ДЛЯ МЕНЮ KEY OPTIONS
             //_visible = !_visible;
    }

	//Звук прыжка
	private void PlayJumpSound()
	{
		m_AudioSource.clip = m_JumpSound;
		m_AudioSource.PlayOneShot(m_AudioSource.clip);
	}

	private void PlayLandingSound()
	{
		m_AudioSource.clip = m_LandSound;
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        //m_NextStep = m_StepCycle + .5f;
    }

	//Звуки ходьбы
	private void PlayFootStepAudio()
	{
		if (!controller.isGrounded)
		{
			return;
		}
		if (is_walk && (walk_sound_timer <= 0f)) {
			// pick & play a random footstep sound from the array,
			// excluding sound at index 0
			int n = Random.Range (1, m_FootstepSounds.Length);
			m_AudioSource.clip = m_FootstepSounds [n];
			m_AudioSource.PlayOneShot (m_AudioSource.clip);
			// move picked sound to index 0 so it's not picked next time
			m_FootstepSounds [n] = m_FootstepSounds [0];
			m_FootstepSounds [0] = m_AudioSource.clip;

            //walk_sound_timer = m_StepInterval;
            walk_sound_timer = 0.5f;
			if(is_run)
				walk_sound_timer = walk_sound_timer / 2;
		}
	}
	
	/*void OnGUI () {
		if(_visible)
		{
			GUI.Box(new Rect((Screen.width - 500)/2, (Screen.height - 500)/2, 500, 500), "Смена управления");
			
			GUI.Label(new Rect((Screen.width - 500)/2 + 20, (Screen.height - 500)/2 + 20, 200, 30), "Вперед - " + up.ToString());
			if(forward != KeyCode.None)
			{
				if(GUI.Button(new Rect((Screen.width - 500)/2 + 220, (Screen.height - 500)/2 + 20, 100, 20), "Изменить"))
				{
					forward = KeyCode.None;
				}
			} else {
				if(Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
				{
					forward = Event.current.keyCode;
				}
			}
			
			GUI.Label(new Rect((Screen.width - 500)/2 + 20, (Screen.height - 500)/2 + 50, 200, 30), "Назад - " + down.ToString());
			if(backward != KeyCode.None)
			{
				if(GUI.Button(new Rect((Screen.width - 500)/2 + 220, (Screen.height - 500)/2 + 50, 100, 20), "Изменить"))
				{
					backward = KeyCode.None;
				}
			} else {
				if(Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
				{
					backward = Event.current.keyCode;
				}
			}
			
			GUI.Label(new Rect((Screen.width - 500)/2 + 20, (Screen.height - 500)/2 + 80, 200, 30), "Влево - " + left.ToString());
			if(left != KeyCode.None)
			{
				if(GUI.Button(new Rect((Screen.width - 500)/2 + 220, (Screen.height - 500)/2 + 80, 100, 20), "Изменить"))
				{
					left = KeyCode.None;
				}
			} else {
				if(Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
				{
					left = Event.current.keyCode;
				}
			}
			
			GUI.Label(new Rect((Screen.width - 500)/2 + 20, (Screen.height - 500)/2 + 110, 200, 30), "Вправо - " + right.ToString());
			if(right != KeyCode.None)
			{
				if(GUI.Button(new Rect((Screen.width - 500)/2 + 220, (Screen.height - 500)/2 + 110, 100, 20), "Изменить"))
				{
					right = KeyCode.None;
				}
			} else {
				if(Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
				{
					right = Event.current.keyCode;
				}
			}
			
			GUI.Label(new Rect((Screen.width - 500)/2 + 20, (Screen.height - 500)/2 + 140, 200, 30), "Ускорение - " + shift.ToString());
			if(run_walk != KeyCode.None)
			{
				if(GUI.Button(new Rect((Screen.width - 500)/2 + 220, (Screen.height - 500)/2 + 140, 100, 20), "Изменить"))
				{
					run_walk = KeyCode.None;
				}
			} else {
				if(Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
				{
					run_walk = Event.current.keyCode;
				}
				if(Event.current.modifiers == EventModifiers.Shift)
				{
					run_walk = KeyCode.LeftShift;
				}
			}
			
			GUI.Label(new Rect((Screen.width - 500)/2 + 20, (Screen.height - 500)/2 + 170, 200, 30), "Прыжок - " + jump.ToString());
			if(jump != KeyCode.None)
			{
				if(GUI.Button(new Rect((Screen.width - 500)/2 + 220, (Screen.height - 500)/2 + 170, 100, 20), "Изменить"))
				{
					jump = KeyCode.None;
				}
			} else {
				if(Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
				{
					jump = Event.current.keyCode;
				}
			}
		}
	}*/
}