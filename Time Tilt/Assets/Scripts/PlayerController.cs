using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	private float moveVelocity;
	public float diveSpeed;
	public float still;
	public int facingDirection;// 0 = left, 1 = right

	private Transform lance;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	public string flapbutton; //Fire1
	public float flapforce; 
	public ForceMode2D forceMode = ForceMode2D.Impulse;

	public float stopVelocity; //used for momentum

	private bool isDiving;
	public float counterForce;//determines the power of the flap when cancelling a dive

	//for knockback and I state
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	// Use this for initialization
	void Start () {
		isDiving = false;
	}

	void FixedUpdate () { //used for physics
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {

		//Input for flap
		if(Input.GetButtonDown(flapbutton) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown (KeyCode.N))
		{
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapforce, forceMode);
		}

		//Face Left
		if(Input.GetKeyDown (KeyCode.A)){
			transform.localScale = new Vector3(-0.7628162f, 0.7628162f, 0.7628162f);
			facingDirection = 0;
		}
		
		//Face Right
		if(Input.GetKeyDown (KeyCode.D)){
			transform.localScale = new Vector3(0.7628162f, 0.7628162f, 0.7628162f);
			facingDirection = 1;
		}
	
		moveVelocity = 0f; // so that every frame you arent pressing something it does not move one way or the other.

		//Movement Left and Right
		if (Input.GetKey (KeyCode.A) && !Input.GetKey(KeyCode.S)) 
		{
			//MoveLeft
			moveVelocity = -speed;
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
		} 

		if (Input.GetKey (KeyCode.D) && !Input.GetKey(KeyCode.S)) 
		{
			//MoveRight
			moveVelocity = speed;
			//GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		} 

		if(knockbackCount <=  0){
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		}
		else{
			if(knockFromRight){
				GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, GetComponent<Rigidbody2D>().velocity.y);
			}
			if(!knockFromRight){
				GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, GetComponent<Rigidbody2D>().velocity.y);
			}
			knockbackCount -= Time.deltaTime;
		}

		//Momentum after landing
		if(GetComponent<Rigidbody2D>().velocity.x > 0.2f || GetComponent<Rigidbody2D>().velocity.x < -0.2f && grounded){
			if(!Input.GetKey(KeyCode.A) && !Input.GetKey (KeyCode.D)){
				if(facingDirection == 0){
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + stopVelocity, GetComponent<Rigidbody2D>().velocity.y);
				}
				else if(facingDirection == 1){
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + -stopVelocity, GetComponent<Rigidbody2D>().velocity.y);
				}
			}
		}

		//Lance Aiming and Dive Bomb
		if(Input.GetKey (KeyCode.S) && !grounded){
			if(facingDirection == 0)
				transform.localEulerAngles = new Vector3 (0, 0, 90);
			else if(facingDirection == 1)
				transform.localEulerAngles = new Vector3 (0, 0, 270);
			if(Input.GetKey (KeyCode.K)){
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, diveSpeed);
				isDiving = true;
			}
		}
		else if(Input.GetKey (KeyCode.W) && !grounded){
			if(facingDirection == 0)
				transform.localEulerAngles = new Vector3 (0, 0, 270);
			else if(facingDirection == 1)
				transform.localEulerAngles = new Vector3 (0, 0, 90);
		}
		else 
			transform.localEulerAngles = new Vector3 (0,0,0);

		if(grounded)
			isDiving = false;

		//Dive Cancel
		if(isDiving){ 
			if(facingDirection == 0)
				transform.localEulerAngles = new Vector3 (0, 0, 90);
			else if(facingDirection == 1)
				transform.localEulerAngles = new Vector3 (0, 0, 270);

			if(Input.GetButtonDown(flapbutton) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown (KeyCode.N)){
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y + counterForce);
				isDiving = false;
			}
		}

	}	


}
