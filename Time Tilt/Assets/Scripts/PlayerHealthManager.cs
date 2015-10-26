using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

	private LevelManager levelManager;

	public static int playerHealth;
	public int maxPlayerHealth;

	public static int playerLives;
	public int initialLives;

	public bool isDead;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();

		playerHealth = maxPlayerHealth;

		playerLives = initialLives;

		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerLives > -1 && !isDead){
			if(playerHealth <= 0){ 
				playerHealth = 0;
				levelManager.RespawnPlayer(); //player dies and respawns from the same function
				RemoveLife ();
				isDead = true;
			}
		}
		else if (playerLives == -1 && !isDead){
			Debug.Log ("Game Over");//Run some sort of function from the level manager to remove character. Game over should run somewhere in the level Manager not here.
			isDead = true;
		}
	}

	public static void HurtPlayer(int damage, Collider2D avatar, GameObject enemy){
		playerHealth -= damage; //actual damage

		//knockback control
		var player = avatar.GetComponentInParent<PlayerController>();
		player.knockbackCount = player.knockbackLength;

//		if(Mathf.Abs(avatar.transform.parent.position.x) - Mathf.Abs(enemy.gameObject.transform.parent.position.x)
//		   >  //if this is true then perform x bounces; else do y bounces
//		   Mathf.Abs(avatar.transform.parent.position.y) - Mathf.Abs(enemy.gameObject.transform.parent.position.y))

		if(player.grounded && Mathf.Abs (player.GetComponent<Rigidbody2D>().velocity.x) == Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.y)){
			if(avatar.transform.position.x < enemy.gameObject.transform.position.x){
				player.knockFromWhere = 0;
			}
			else{
				player.knockFromWhere = 1;
			}
		}
		if(!player.grounded){ 
			if(avatar.transform.position.y < enemy.gameObject.transform.position.y){
				player.knockFromWhere = 2;
			}
			else{
				player.knockFromWhere = 3;
			}
		}
		if(!player.grounded && Mathf.Abs (player.GetComponent<Rigidbody2D>().velocity.x) + 2 > Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.y)){
			if(avatar.transform.position.x < enemy.gameObject.transform.position.x){
				player.knockFromWhere = 0;
			}
			else{
				player.knockFromWhere = 1;
			}
		}
	}

	public static void AddLife(){
		playerLives++;
	}

	public static void RemoveLife(){
		playerLives--;
	}
}
