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

	public static void HurtPlayer(int damage){
		playerHealth -= damage;
		//Debug.Log("Health " + playerHealth);
		//Debug.Log ("Lives " + playerLives);
		//Debug.Log("hit");
	}

	public void AddLife(){
		playerLives++;
	}

	public void RemoveLife(){
		playerLives--;
	}
}
