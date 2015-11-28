using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;

	public GameObject orb;
	public GameObject gun1;
	public GameObject gun2;
	public GameObject gun3;
	public GameObject gun4;
	public GameObject life;
	public GameObject health;

	public float lifeChance;

	public float gun4Chance;
	public float gun3Chance;
	public float gun2Chance;
	public float gun1Chance;

	public float healthChance;
	public float orbChance;

	private int chanceNumber; //used as RNG for dropping items

	public float recoveryRate;
	private float takeDamageAgain; //how long until they can be hit again
	public bool recovering;

	public GameObject enemyLance;

	// Use this for initialization
	void Start () {
		recovering = false;
		takeDamageAgain = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0){
			//Instantiate (orb, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
			GetComponent<AudioSource>().Play ();
			chanceNumber = Random.Range (1,100); //100 values can be rolled for here.
			DropSomething(chanceNumber);
			Destroy (gameObject);
		}

		if(recovering == true && Time.time > takeDamageAgain){
			recovering = false;
			//anim.SetBool ("takingDamage", true);
			enemyLance.SetActive(false);
		}
		else{
			//anim.SetBool("takingDamage", false);
			enemyLance.SetActive(true);
		}

	}

	public void HurtEnemy(int damage){

		if(recovering == false){
			enemyHealth -= damage;
			takeDamageAgain = Time.time + recoveryRate;
			recovering = true;
		}
		//enemy bounce back here. probably clean up enemy movement then do this.
		//Debug.Log("Enemy Health " + enemyHealth);
	}

	public void knockBackEnemySides(Collider2D avatar, Transform playerPosition){ //collider is whatever triggers this to occur //player is the player character controller
		var enemy = avatar.GetComponentInParent<EnemyController>(); //might need to getcomponent instead
		enemy.knockbackCount = enemy.knockbackLength;
		
		if(avatar.transform.position.x < playerPosition.position.x){ //can add plus or minus a few values to add leeway 
			enemy.knockFromRight = true;
		}
		else
			enemy.knockFromRight = false;
	}

	public void DropSomething(int chanceNumber){  
		//example of how chance values are determined: gun2Chance - life chance aka (15 - 5) = 10 => gun2Chance is 10% to drop
		//gun1Chance - gun2Chance = 15 so gun1Chance is 15%
		if(chanceNumber <= lifeChance){ //Lives 5% 1-5
			Instantiate (life, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
		else if(chanceNumber > lifeChance && chanceNumber <= gun4Chance){ // gun4 - 5% 6 - 10
			Instantiate (gun4, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
		else if(chanceNumber > gun4Chance && chanceNumber <= gun3Chance){ // gun3 - 8% 11 - 18
			Instantiate (gun3, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
		else if(chanceNumber > gun3Chance && chanceNumber <= gun2Chance){ // gun2 - 12% 19 - 30
			Instantiate (gun2, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
		else if(chanceNumber > gun2Chance && chanceNumber <= gun1Chance){ // gun1 - 15% 31 - 45
			Instantiate (gun1, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
		else if(chanceNumber > gun1Chance && chanceNumber <= healthChance){ // Health - 20% 46 - 65
			Instantiate (health, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
		else if(chanceNumber > healthChance && chanceNumber <= orbChance){ //Scorbs  45 % 65 - 99
			Instantiate (orb, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
	}
}

