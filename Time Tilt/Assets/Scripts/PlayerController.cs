using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	private float moveVelocity;
	public float diveSpeed;
	public float still;
	public int facingDirection;// 0 = left, 1 = right //probably want to add a facing direction for up and down if needed
	public bool facingUp;
	public bool facingDown;

	private Transform lance;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool grounded;
	public bool onPlatform;

	public string flapbutton; //Fire1
	public float flapforce; 
	public ForceMode2D forceMode = ForceMode2D.Impulse;

	public float stopVelocity; //used for momentum

	private bool isDiving;
	public float counterForce;//determines the power of the flap when cancelling a dive

	//for knockback and I-state
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public int knockFromWhere; // 0 - left, 1 - right, 2 - up, 3 - down;

	//Gun control vars
	public int gunNumber; //used to check what gun is active and enabled
	public GameObject gun1;
	public GameObject gun2;
	public GameObject gun3;
	public GameObject gun4;

	public int bulletCounter; //current amount of bullets. When zero set gunNumber to zero; Set from pickup 
	public int currentMaxBullets;

	public GameObject bullet;
	public GameObject strongBullet;
	public GameObject shotgunBullet;
	public GameObject sniperBullet;

	public Transform firepoint;
	public Transform firepointUp;
	public Transform firepointDown;

	public float gun1FireRate;
	private float gun1NextFire;

	public float gun2FireRate;
	private float gun2NextFire;

	public float gun3FireRate;
	private float gun3NextFire;

	public float gun4FireRate;
	private float gun4NextFire;

	private Gun1Pickup gun1PickUp;
	private Gun2Pickup gun2PickUp;
	private Gun3Pickup gun3PickUp;
	private Gun4Pickup gun4PickUp;

	public float recoveryRate; //time unable to be hit 

	private Animator anim;

	private bool aiming;

	// Use this for initialization
	void Start () {
		isDiving = false;
		gunNumber = 0;

		anim = GetComponent<Animator>();
	}

//	void FixedUpdate () { //used for physics
//
//		//grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
//	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(onPlatform);
		//Debug.Log(aiming);


		if((Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) < 0.5f) && (aiming == true) && (onPlatform == false)){
			grounded = false;

		}
		else if((Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) < 0.5f) || (onPlatform == true)){
			grounded = true;
			isDiving = false;
			aiming = false;

		}
		else
			grounded = false;

		//Input for flap
		if(Input.GetButtonDown(flapbutton) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown (KeyCode.U))
		{
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapforce, forceMode);
		}

		//Face Left
		if((Input.GetKeyDown (KeyCode.LeftArrow) || (Input.GetKeyDown (KeyCode.UpArrow) && Input.GetKeyDown (KeyCode.LeftArrow))) && !Input.GetKey(KeyCode.DownArrow)){
			//transform.localScale = new Vector3(-1f, 1f, 1f);
			if(facingDirection == 1){
				transform.localScale = new Vector3(((GetComponent<Transform>().localScale.x)*-1), 1f, 1f);
			}
			else // might need a direction check if it clashes with how stuff works midair 
				transform.localScale = new Vector3(GetComponent<Transform>().localScale.x, 1f, 1f);

			facingDirection = 0;
		}
		
		//Face Right
		if((Input.GetKeyDown (KeyCode.RightArrow) || (Input.GetKeyDown (KeyCode.UpArrow) && Input.GetKeyDown (KeyCode.RightArrow))) && !Input.GetKey(KeyCode.DownArrow)){
			//transform.localScale = new Vector3(1f, 1f, 1f);

			if(facingDirection == 0){
				transform.localScale = new Vector3(((GetComponent<Transform>().localScale.x)*-1), 1f, 1f);
			}
			else // might need a direction check if it clashes with how stuff works midair 
				transform.localScale = new Vector3(GetComponent<Transform>().localScale.x, 1f, 1f);

			facingDirection = 1;
		}

		//Momentum after landing
		if(moveVelocity > 0.1f || moveVelocity < -0.1f){
			if(!Input.GetKey (KeyCode.LeftArrow)&& !Input.GetKey (KeyCode.RightArrow)){
				if(facingDirection == 0){
					moveVelocity += stopVelocity;
				}
				if(facingDirection == 1){
					moveVelocity += -stopVelocity;
				}
			}
		}

		//Movement Left and Right
		if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && facingDirection == 0) 
		{
			//MoveLeft
			moveVelocity = -speed;
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
		} 
		
		if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && facingDirection == 1) 
		{
			//MoveRight
			
			moveVelocity = speed;
			//GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if(knockbackCount <=  0){
			anim.SetBool("knockBack" , false);
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);//Runs every frame not knocked back for regualr movement control
			
		}
		else {
			if(knockFromWhere == 0){//enemy is on the right 
				GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, GetComponent<Rigidbody2D>().velocity.y);
			}
			if(knockFromWhere == 1){ //enemy is on the left
				GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, GetComponent<Rigidbody2D>().velocity.y);
			}
			if(knockFromWhere == 2){ //enemy is above the player
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -knockback);
			}
			if(knockFromWhere == 3){ //enemy is below the player
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, knockback);
			}
			knockbackCount -= Time.deltaTime;
			anim.SetBool("knockBack" , true);
		}

		//Dive Cancel
		if(isDiving){ 
			if(facingDirection == 0)
				transform.localEulerAngles = new Vector3 (0, 0, 90);
			else if(facingDirection == 1)
				transform.localEulerAngles = new Vector3 (0, 0, 270);

			if(Input.GetButtonDown(flapbutton) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown (KeyCode.U)){
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, counterForce);
				isDiving = false;
				transform.localEulerAngles = new Vector3 (0, 0, 0);
			}
		}

		//Lance Aiming and Dive Bomb
		if(Input.GetKey(KeyCode.DownArrow) && grounded == false){
			aiming = true;
			facingDown = true;
			facingUp = false;
			if(facingDirection == 0)
				transform.localEulerAngles = new Vector3 (0, 0, 90);
			else if(facingDirection == 1)
				transform.localEulerAngles = new Vector3 (0, 0, 270);
			if(Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown(KeyCode.I)){
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, diveSpeed);
				isDiving = true;
			}
		}

		else if(Input.GetKey (KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow) && grounded == false){
			facingDown = false;
			facingUp = true;
			aiming = true;
			if(facingDirection == 0)
				transform.localEulerAngles = new Vector3 (0, 0, 270);
			else if(facingDirection == 1)
				transform.localEulerAngles = new Vector3 (0, 0, 90);
		}
		else{
			transform.localEulerAngles = new Vector3 (0, 0, 0);
			facingDown = false;
			facingUp = false;
			aiming = false;
		}

		anim.SetFloat("xSpeed" , Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		anim.SetFloat("ySpeed" , Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));


		EquipWhatGun(gunNumber); // renders proper weapon

		//Shooting controls
		if(gunNumber == 1){ //semiauto
			if(bulletCounter > 0){
				if((Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown(KeyCode.I)) && Time.time > gun1NextFire){ //semi auto
					gun1NextFire = Time.time + gun1FireRate;
					Instantiate (strongBullet, firepoint.position, firepoint.rotation);
					BulletController.firedFromPlayer1 = true;
					GetComponent<AudioSource>().Play ();
					bulletCounter--;
				}
			}
			else{
				gunNumber = 0;
			}
		}
		if(gunNumber == 2){ //automatic
			if(bulletCounter > 0){
				if((Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown(KeyCode.I)) && Time.time > gun2NextFire){ //rapid fire
					gun2NextFire = Time.time + gun2FireRate;
					Instantiate (bullet, firepoint.position, firepoint.rotation);
					BulletController.firedFromPlayer1 = true;
					GetComponent<AudioSource>().Play ();
					bulletCounter--;
				}
			}
			else{
				gunNumber = 0;
			}
		}
		if(gunNumber == 3){ //shotgun
			if(bulletCounter > 0){
				if((Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown(KeyCode.I)) && Time.time > gun3NextFire){ //rapid fire
					gun3NextFire = Time.time + gun3FireRate;
					Instantiate (shotgunBullet, firepoint.position, firepoint.rotation);
					Instantiate (shotgunBullet, firepointUp.position, firepointUp.rotation);
					Instantiate (shotgunBullet, firepointDown.position, firepointDown.rotation);
					BulletController.firedFromPlayer1 = true;
					GetComponent<AudioSource>().Play ();
					bulletCounter--;
				}
			}
			else{
				gunNumber = 0;
			}
		}
		if(gunNumber == 4){ //sniper
			if(bulletCounter > 0){
				if((Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown(KeyCode.I)) && Time.time > gun4NextFire){ //rapid fire
					gun4NextFire = Time.time + gun4FireRate;
					Instantiate (sniperBullet, firepoint.position, firepoint.rotation);
					BulletControllerSniper.firedFromPlayer1 = true;
					GetComponent<AudioSource>().Play ();
					bulletCounter--;
				}
			}
			else{
				gunNumber = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Platform"){
			onPlatform = true;
		}
		else {
			onPlatform = false;
		}
		
		//enemy bullet damage applied here
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Platform"){
			onPlatform = false;
		}
	}

	public void EquipWhatGun(int gun){ //sets what is enabled; no firing functionality
		switch(gun){
		case 1://gun1 functionality
			//Debug.Log ("has gun");
			gun1.SetActive(true);
			gun2.SetActive(false);
			gun3.SetActive(false);
			gun4.SetActive(false);
			break;
		case 2:
			//Debug.Log ("has gun 2");
			gun1.SetActive(false);
			gun2.SetActive(true);
			gun3.SetActive(false);
			gun4.SetActive(false);
			break;
		case 3:
			gun1.SetActive(false);
			gun2.SetActive(false);
			gun3.SetActive(true);
			gun4.SetActive(false);
			break;
		case 4: 
			gun1.SetActive(false);
			gun2.SetActive(false);
			gun3.SetActive(false);
			gun4.SetActive(true);
			break;
		default: //disable all guns
			gun1.SetActive(false);
			gun2.SetActive(false);
			gun3.SetActive(false);
			gun4.SetActive(false);
			break;
		}
	}
}
