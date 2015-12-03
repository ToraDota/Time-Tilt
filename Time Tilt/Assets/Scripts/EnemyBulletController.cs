using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

	public float speed;
	public int damage;

	private float distanceTraveled;
	public float maxDistance;

	private bool facingRight;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(facingRight == true){
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
		}

		distanceTraveled += speed;
		
		if(distanceTraveled >= maxDistance || distanceTraveled <= -maxDistance){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Player"){
			PlayerHealthManager.HurtPlayer(damage);
			PlayerHealthManager.BouncePlayer(other, gameObject);
			
			Destroy (gameObject);
			
		}

		else if(other.tag == "Player2"){
			PlayerTwoHealthManager.HurtPlayer(damage);
			PlayerTwoHealthManager.BouncePlayer(other, gameObject);
			
			Destroy (gameObject);
		}

		if(other.tag == "TopWall" || other.tag == "Platform" || other.tag == "Hazard"){
			Destroy (gameObject);
		}
	}

	public void IsFacingRight(bool passedInFacingRight){
		facingRight = passedInFacingRight;
	}
}
