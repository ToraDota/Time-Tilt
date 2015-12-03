using UnityEngine;
using System.Collections;

public class EnemyShootController : MonoBehaviour {

	public float enemySpeed;
	public bool facingRight;
	
	private int random;
	
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool grounded;
	
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;
	
	public float actionRate;
	private float timeTillNextAction;
	
	public float inAirActionRate;
	private float inAirNextAction;

	public float flapForce;
	public ForceMode2D forceMode = ForceMode2D.Impulse;
	
	private Animator anim;
	
	
	// Use this for initialization
	void Start () {
		//Initialize random numbers for facing direciton
		random = Random.Range(0,2);
		if(random == 0){
			facingRight = false;
		}
		else
			facingRight = true;
		
		anim = GetComponent<Animator>();
	}
	
	void FixedUpdate () { //used for physics
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		
		//change depending on what it hits. Random the direction on start up those
		
		if(grounded){ //run something to attempt to flap. Run this every few second while grounded, or atleast only allow it to be thought about.
			anim.SetBool("isGrounded", true); // move animation along the ground should play
			
			if(Time.time > timeTillNextAction){
				timeTillNextAction = Time.time + actionRate;
				int random = Random.Range(0,5);
				if(random >  2){
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, flapForce);
					anim.SetBool("isFlapping", true);
				}
				else
					anim.SetBool ("isFlapping", false);
			}
		}
		if(!grounded){
			anim.SetBool ("isGrounded", false);
			if(Time.time > inAirNextAction){
				inAirNextAction = Time.time + inAirActionRate;
				int random = Random.Range(0,4); //toy with this
				if(random >=  1){ //<--Change this, the random, or InAirActionRate to tune and balance
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, flapForce);
					anim.SetBool("isFlapping", true);
				}
				else
					anim.SetBool ("isFlapping", false);
			}
		}
		
		if(knockbackCount <=  0){ //Regular movement
			anim.SetBool("knockedBack", false);
			if(facingRight){ //move right
				this.transform.localScale = new Vector3(-1f, 1f, 1f);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (enemySpeed, GetComponent<Rigidbody2D>().velocity.y);
			}
			else{ //move left
				transform.localScale = new Vector3(1f, 1f, 1f);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-enemySpeed, GetComponent<Rigidbody2D>().velocity.y);
			}
		}
		else{
			anim.SetBool("knockedBack", true);
			if(knockFromRight){
				GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, GetComponent<Rigidbody2D>().velocity.y);
			}
			if(!knockFromRight){
				GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, GetComponent<Rigidbody2D>().velocity.y);
			}
			knockbackCount -= Time.deltaTime;
		}
	}
	
	public void OnTriggerEnter2D(Collider2D other){
		if(other.name == "SideCheck"){
			facingRight = !facingRight; //when hitting a platform for other enemy switch directions
		}
		if(other.tag == "Enemy"){
			facingRight = !facingRight;
			other.GetComponent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
		}
		if(other.tag == "TopWall"){ //enemy falls for longer before being able to flap again.
			inAirNextAction = Time.time + inAirActionRate + 0.6f;
		}
	}

	public bool GetFacingRight(){
		return facingRight;
	}

}
