using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;

	public GameObject orb;
	public GameObject gun1;
	public GameObject gun2;
	public GameObject life;

	public float orbChance;
	public float gun1Chance;
	public float gun2Chance;
	public float lifeChance;


	private int chanceNumber; //used as RNG for dropping items

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0){
			//Instantiate (orb, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
			chanceNumber = Random.Range (0,99); //100 values can be rolled for here.
			DropSomething(chanceNumber);
			Destroy (gameObject);
		}
	}

	public void HurtEnemy(int damage){
		enemyHealth -= damage;

		//enemy bounce back here. probably clean up enemy movement then do this.
		//Debug.Log("Enemy Health " + enemyHealth);
	}

	public void knockBackEnemySides(Collider2D avatar, GameObject player){ //collider is whatever triggers this to occur //player is the player character controller
		var enemy = avatar.GetComponentInParent<EnemyController>(); //might need to getcomponent instead
		enemy.knockbackCount = enemy.knockbackLength;
		
		if(avatar.transform.position.x < player.gameObject.transform.position.x){ //can add plus or minus a few values to add leeway 
			enemy.knockFromRight = true;
		}
		else
			enemy.knockFromRight = false;
	}

	public void DropSomething(int chanceNumber){ 
		if(chanceNumber < gun2Chance){ //lowest chance - start with 10 percent; 0-9. Gun2
			Instantiate (gun2, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
		else if(chanceNumber >= gun2Chance && chanceNumber < gun1Chance){ // 25% 10-34 Gun1
			Instantiate (gun1, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
		else if(chanceNumber >= gun1Chance && chanceNumber < orbChance){ // 35-84
			Instantiate (orb, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
		else if(chanceNumber >= orbChance){
			Instantiate (life, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}
	}
}

