using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

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


	// Use this for initialization
	void Start () {
		//Initialize random numbers for facing direciton
		random = Random.Range(0,2);
		if(random == 0){
			facingRight = false;
		}
		else
			facingRight = true;
	}

	void FixedUpdate () { //used for physics
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {

		if(knockbackCount <=  0){
			if(facingRight){ //move right
				this.transform.localScale = new Vector3(-0.8068709f, 0.8068709f, 0.8068709f);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (enemySpeed, GetComponent<Rigidbody2D>().velocity.y);
			}
			else{ //move left
				transform.localScale = new Vector3(0.8068709f, 0.8068709f, 0.8068709f);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-enemySpeed, GetComponent<Rigidbody2D>().velocity.y);
			}
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

		//change depending on what it hits. Random the direction on start up those

		if(grounded){ //run something to attempt to flap. Run this every few second while grounded, or atleast only allow it to be thought about.
			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, flapForce);
			if(Time.time > timeTillNextAction){
				timeTillNextAction = Time.time + actionRate;
				int random = Random.Range(0,3);
				if(random >  1){
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, flapForce);
				}
			}
		}
		if(!grounded){
			if(Time.time > inAirNextAction){
				inAirNextAction = Time.time + inAirActionRate;
				int random = Random.Range(0,3); //toy with this
				if(random >  1){
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, flapForce);
				}
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.name == "SideCheck"){
			facingRight = !facingRight; //when hitting a platform for other enemy switch directions
		}
		if(other.tag == "Enemy"){
			facingRight = !facingRight;
			other.GetComponent<EnemyHealthManager>().knockBackEnemySides(other, gameObject);
		}
	}
	
}

	
