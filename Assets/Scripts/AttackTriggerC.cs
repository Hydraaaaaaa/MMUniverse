using UnityEngine;
using System.Collections;

[RequireComponent (typeof (StatusC))]
[RequireComponent (typeof (StatusWindowC))]
[RequireComponent (typeof (HealthBarC))]
//[RequireComponent (typeof (PlayerAnimationC))]
[RequireComponent (typeof (PlayerInputControllerC))]
[RequireComponent (typeof (CharacterMotorC))]
[RequireComponent (typeof (InventoryC))]
[RequireComponent (typeof (QuestStatC))]
[RequireComponent (typeof (SkillWindowC))]
[RequireComponent (typeof (DontDestroyOnloadC))]

public class AttackTriggerC : MonoBehaviour {
	
	//private bool  masterNetwork = false;
	public GameObject mainModel;
	public Transform attackPoint;
	public Transform cameraZoomPoint;
	public Transform attackPrefab;
	public bool useMecanim = false;

	public enum whileAtk{
		MeleeFwd = 0,
		Immobile = 1,
		WalkFree = 2
	}
	public whileAtk whileAttack = whileAtk.MeleeFwd;
	
	public enum AimType{
		Normal = 0,
		Raycast = 1
	}
	public AimType aimingType = AimType.Normal;
	
	public Transform[] skillPrefab = new Transform[3];
	
	private bool  atkDelay = false;
	public bool  freeze = false;
	
	public Texture2D[] skillIcon = new Texture2D[3];
	public int skillIconSize = 80;
	
	public float attackSpeed = 0.15f;
	private float nextFire = 0.0f;
	public float atkDelay1 = 0.1f;
	public float skillDelay = 0.3f;
	
	public AnimationClip[] attackCombo = new AnimationClip[3];
	public float attackAnimationSpeed = 1.0f;
	public AnimationClip[] skillAnimation = new AnimationClip[3];
	public float skillAnimationSpeed = 1.0f;
	public int[] manaCost = new int[3];
	private AnimationClip hurt;
	
	
	private bool  meleefwd = false;
	[HideInInspector]
	public bool  isCasting = false;
	
	private int c = 0;
	private int conCombo = 0;
	
	public Transform Maincam;
	public GameObject MaincamPrefab;
	public GameObject attackPointPrefab;
	
	private int str = 0;
	private int matk = 0;
	
	public Texture2D aimIcon;
	public int aimIconSize = 40;

	[HideInInspector]
	public bool  flinch = false;
	private int skillEquip  = 0;
	private Vector3 knock = Vector3.zero;

	//----------Sounds-------------
	[System.Serializable]
	public class AtkSound {
		public AudioClip[] attackComboVoice = new AudioClip[3];
		public AudioClip magicCastVoice;
		public AudioClip hurtVoice;
	}
	public AtkSound sound;

	[HideInInspector]
	public GameObject pet;
	
	void  Awake (){
		if(!mainModel){
			mainModel = this.gameObject;
		}
		//Assign This mainModel to Status Script
		GetComponent<StatusC>().mainModel = mainModel;
		GetComponent<StatusC>().useMecanim = useMecanim;
		//Set tag to Player.
		gameObject.tag = "Player";

		GameObject[] cam = GameObject.FindGameObjectsWithTag("MainCamera"); 
		foreach(GameObject cam2 in cam) { 
			if(cam2){
				Destroy(cam2.gameObject);
			}
		}
		GameObject newCam = GameObject.FindWithTag ("MainCamera");
		newCam = Instantiate(MaincamPrefab, transform.position , transform.rotation) as GameObject;
		Maincam = newCam.transform;
		//Maincam.GetComponent<ARPGcameraC>().target = this.transform;
		// Set Target to ARPG Camera
    	if(!cameraZoomPoint || aimingType == AimType.Normal){
    		//cameraZoomPoint = this.transform;
    		Maincam.GetComponent<ARPGcameraC>().target = this.transform;
    	}else{
    		Maincam.GetComponent<ARPGcameraC>().target = cameraZoomPoint;
    	}
    	Maincam.GetComponent<ARPGcameraC>().targetBody = this.transform;

		str = GetComponent<StatusC>().addAtk;
		matk = GetComponent<StatusC>().addMatk;
		//Set All Attack Animation'sLayer to 15
		int animationSize = attackCombo.Length;
		int a = 0;
		if(animationSize > 0 && !useMecanim){
			while(a < animationSize && attackCombo[a]){
				mainModel.GetComponent<Animation>()[attackCombo[a].name].layer = 15;
				a++;
			}
		}

		//--------------------------------
		//Spawn new Attack Point if you didn't assign it.
		if(!attackPoint){
			if(!attackPointPrefab){
				print("Please assign Attack Point");
				freeze = true;
				return;
			}
			GameObject newAtkPoint = Instantiate(attackPointPrefab, transform.position , transform.rotation) as GameObject;
			newAtkPoint.transform.parent = this.transform;
			attackPoint = newAtkPoint.transform;	
		}

		if (!useMecanim){
			hurt = GetComponent<PlayerAnimationC> ().hurt;
		}
		if(aimingType == AimType.Raycast){//Auto Lock On for Raycast Mode
			Maincam.GetComponent<ARPGcameraC>().lockOn = true;
		}
		GameObject minimap = GameObject.FindWithTag("Minimap");
			if(minimap){
				GameObject mapcam = minimap.GetComponent<MinimapOnOffC>().minimapCam;
				mapcam.GetComponent<MinimapCameraC>().target = this.transform;
			}
	}
	
	
	void  Update (){
		StatusC stat = GetComponent<StatusC>();
		if(freeze || atkDelay || Time.timeScale == 0.0f || stat.freeze){
			return;
		}
		CharacterController controller = GetComponent<CharacterController>();
		if (flinch){
			controller.Move(knock * 6* Time.deltaTime);
			return;
		}
		
		if (meleefwd){
			Vector3 lui = transform.TransformDirection(Vector3.forward);
			controller.Move(lui * 5 * Time.deltaTime);
		}
		if(aimingType == AimType.Raycast){
			Aiming();
		}else{
			attackPoint.transform.rotation = Maincam.GetComponent<ARPGcameraC>().aim;
		}
		//----------------------------
		//Normal Trigger
		if (Input.GetButton("Fire1") && Time.time > nextFire && !isCasting) {
			if(Time.time > (nextFire + 0.5f)){
				c = 0;
			}
			//Attack Combo
			if(attackCombo.Length >= 1){
				conCombo++;
				//AttackCombo();
				StartCoroutine(AttackCombo());

			}
		}
		//Magic
		if (Input.GetButtonDown("Fire2") && Time.time > nextFire && !isCasting && skillPrefab[skillEquip] && !stat.silence) {
			//MagicSkill(skillEquip);
			StartCoroutine(MagicSkill(skillEquip));
		}
		if(Input.GetKeyDown("1") && !isCasting && skillPrefab[0]){
			skillEquip = 0;
		}
		if(Input.GetKeyDown("2") && !isCasting && skillPrefab[1]){
			skillEquip = 1;
		}
		if(Input.GetKeyDown("3") && !isCasting && skillPrefab[2]){
			skillEquip = 2;
		}
		
	}
	//Hit Bear :P
	void  OnGUI (){
		if(aimingType == AimType.Normal){
			GUI.DrawTexture ( new Rect(Screen.width/2 - 16,Screen.height/2 - 90,aimIconSize,aimIconSize), aimIcon);
		}
		if(aimingType == AimType.Raycast){
			GUI.DrawTexture ( new Rect(Screen.width/2 - 20,Screen.height/2 - 20,40,40), aimIcon);
		}
		
		
		if(skillPrefab[skillEquip] && skillIcon[skillEquip]){
			GUI.DrawTexture ( new Rect(Screen.width -skillIconSize - 28,Screen.height - skillIconSize - 20,skillIconSize,skillIconSize), skillIcon[skillEquip]);
		}
		if(skillPrefab[0] && skillIcon[0]){
			GUI.DrawTexture ( new Rect(Screen.width -skillIconSize -50,Screen.height - skillIconSize -50,skillIconSize /2,skillIconSize /2), skillIcon[0]);
		}
		if(skillPrefab[1] && skillIcon[1]){
			GUI.DrawTexture ( new Rect(Screen.width -skillIconSize -10,Screen.height - skillIconSize -60,skillIconSize /2,skillIconSize /2), skillIcon[1]);
		}
		if(skillPrefab[2] && skillIcon[2]){
			GUI.DrawTexture ( new Rect(Screen.width -skillIconSize +30 ,Screen.height - skillIconSize -50,skillIconSize /2,skillIconSize /2), skillIcon[2]);
		}
	}


	IEnumerator  AttackCombo (){
		float wait = 0.0f;
		if (attackCombo [c]) {
			str = GetComponent<StatusC>().addAtk;
			matk = GetComponent<StatusC>().addMatk;
			Transform bulletShootout;
			isCasting = true;
			// If Melee Dash
			if(whileAttack == whileAtk.MeleeFwd){
				GetComponent<CharacterMotorC>().canControl = false;
				//MeleeDash();
				StartCoroutine(MeleeDash());
			}
			// If Immobile
			if(whileAttack == whileAtk.Immobile){
				GetComponent<CharacterMotorC>().canControl = false;
			}

			if(sound.attackComboVoice.Length > c && sound.attackComboVoice[c]){
				GetComponent<AudioSource>().clip = sound.attackComboVoice[c];
				GetComponent<AudioSource>().Play();
			}
			
			while(conCombo > 0){
				if(!useMecanim){
					//For Legacy Animation
					if(c >= 1){
						mainModel.GetComponent<Animation>().PlayQueued(attackCombo[c].name, QueueMode.PlayNow).speed = attackAnimationSpeed;
					}else{
						mainModel.GetComponent<Animation>().PlayQueued(attackCombo[c].name, QueueMode.PlayNow).speed = attackAnimationSpeed;
					}
					
					wait = mainModel.GetComponent<Animation>()[attackCombo[c].name].length;
				}else{
					//For Mecanim Animation
					GetComponent<PlayerMecanimAnimationC>().AttackAnimation(attackCombo[c].name);
					float clip = GetComponent<PlayerMecanimAnimationC>().animator.GetCurrentAnimatorClipInfo(0).Length;
					wait = clip -0.3f;
				}
				
				yield return new WaitForSeconds(atkDelay1);
				c++;
				
				nextFire = Time.time + attackSpeed;
				bulletShootout = Instantiate(attackPrefab, attackPoint.transform.position , attackPoint.transform.rotation) as Transform;
				bulletShootout.GetComponent<BulletStatusC>().Setting(str , matk , "Player" , this.gameObject);
				conCombo -= 1;
				
				if(c >= attackCombo.Length){
					c = 0;
					atkDelay = true;
					yield return new WaitForSeconds(wait);
					atkDelay = false;
				}else{
					yield return new WaitForSeconds(attackSpeed);
				}
				
			}
			
			isCasting = false;
			GetComponent<CharacterMotorC>().canControl = true;
		} else {
			print ("Please assign attack animation in Attack Combo");
		}

	}

	
	IEnumerator  MeleeDash (){
		meleefwd = true;
		yield return new WaitForSeconds(0.2f);
		meleefwd = false;
		
	}
	
	//---------------------
	//-------
	IEnumerator  MagicSkill ( int skillID  ){
		float wait = 0.0f;
		if(skillAnimation[skillID]){
			str = GetComponent<StatusC>().addAtk;
			matk = GetComponent<StatusC>().addMatk;
			
			if(GetComponent<StatusC>().mana > manaCost[skillID] && !GetComponent<StatusC>().silence){
				if(sound.magicCastVoice){
					GetComponent<AudioSource>().clip = sound.magicCastVoice;
					GetComponent<AudioSource>().Play();
				}
				isCasting = true;
				GetComponent<CharacterMotorC>().canControl = false;

				if(!useMecanim){
					//For Legacy Animation
					mainModel.GetComponent<Animation>()[skillAnimation[skillID].name].layer = 16;
					mainModel.GetComponent<Animation>()[skillAnimation[skillID].name].speed = skillAnimationSpeed;
					mainModel.GetComponent<Animation>().Play(skillAnimation[skillID].name);

					wait = mainModel.GetComponent<Animation>()[skillAnimation[skillID].name].length -0.3f;
				}else{
					//For Mecanim Animation
					GetComponent<PlayerMecanimAnimationC>().AttackAnimation(skillAnimation[skillID].name);
					float clip = GetComponent<PlayerMecanimAnimationC>().animator.GetCurrentAnimatorClipInfo(0).Length;
					wait = clip -0.3f;
				}
				
				nextFire = Time.time + skillDelay;
				Maincam.GetComponent<ARPGcameraC>().lockOn = true;
				//Transform bulletShootout;

				yield return new WaitForSeconds(wait);
				if(aimingType == AimType.Normal){
					Maincam.GetComponent<ARPGcameraC>().lockOn = false;
				}
				Transform bulletShootout = Instantiate(skillPrefab[skillID], attackPoint.transform.position , attackPoint.transform.rotation) as Transform;
				bulletShootout.GetComponent<BulletStatusC>().Setting(str , matk , "Player" , this.gameObject);
				yield return new WaitForSeconds(skillDelay);
				isCasting = false;
				GetComponent<CharacterMotorC>().canControl = true;
				GetComponent<StatusC>().mana -= manaCost[skillID];
			}


		}else{
			print("Please assign skill animation in Skill Animation");
		}

	}
	
	public void  Flinch ( Vector3 dir  ){
		if(sound.hurtVoice && GetComponent<StatusC>().health >= 1){
			GetComponent<AudioSource>().clip = sound.hurtVoice;
			GetComponent<AudioSource>().Play();
		}
		knock = dir;
		GetComponent<CharacterMotorC>().canControl = false;
		//KnockBack();
		StartCoroutine(KnockBack());
		if(!useMecanim){
			//For Legacy Animation
			mainModel.GetComponent<Animation>().PlayQueued(hurt.name, QueueMode.PlayNow);
		}
		GetComponent<CharacterMotorC>().canControl = true;
	}
	
	IEnumerator  KnockBack (){
		flinch = true;
		yield return new WaitForSeconds(0.2f);
		flinch = false;
	}

	public void WhileAttackSet(int watk){
		if (watk == 2) {
			whileAttack = whileAtk.WalkFree;
		} else if (watk == 1) {
			whileAttack = whileAtk.Immobile;
		} else {
			whileAttack = whileAtk.MeleeFwd;
		}
	}
	
	void Aiming(){
		Ray ray = Maincam.GetComponent<Camera>().ViewportPointToRay (new Vector3(0.5f,0.5f,0.0f));
		// Do a raycast
		RaycastHit hit;
		//if (Physics.Raycast (ray, out hit) && hit.transform.tag == "Wall" || Physics.Raycast (ray, out hit) && hit.transform.tag == "Enemy"){
		if (Physics.Raycast (ray, out hit)){
			attackPoint.transform.LookAt(hit.point);
		}else{
			attackPoint.transform.rotation = Maincam.transform.rotation;
		}
}
	
			
}
