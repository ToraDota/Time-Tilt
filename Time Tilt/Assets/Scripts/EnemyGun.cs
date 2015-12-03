using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

	public float fireRecoverRate;
	private float nextFireAction;

	public GameObject firePoint;
	public GameObject enemyBullet;
	//public GameObject justFiredBullet;

	public float shotDelay;
	public float pushBackDistance;

	private bool facingDirection;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if((other.tag == "Player" || other.tag == "Player2") && (Time.time > nextFireAction)){
			nextFireAction = Time.time + fireRecoverRate; //FireRecoverRate determines the amount of time converted to seconds till the following function can be called again
			CallFireDelay();
		}
	}

	public void CallFireDelay(){
		StartCoroutine("FireDelay");
	}

	public IEnumerator FireDelay(){
		yield return new WaitForSeconds (shotDelay);

		var justFiredBullet = (GameObject)Instantiate (enemyBullet, firePoint.transform.position, firePoint.transform.rotation);

		facingDirection = GetComponentInParent<EnemyController>().GetFacingRight();

		justFiredBullet.GetComponent<EnemyBulletController>().IsFacingRight(facingDirection);

		if(facingDirection == true){//meaning the enemy is facing right. Apply force pushing them left.
			GetComponentInParent<Rigidbody2D>().velocity = new Vector2 (-pushBackDistance, GetComponentInParent<Rigidbody2D>().velocity.y);
		}
		else{
			GetComponentInParent<Rigidbody2D>().velocity = new Vector2 (pushBackDistance, GetComponentInParent<Rigidbody2D>().velocity.y);
		}
	}
}
