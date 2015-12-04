using UnityEngine;
using System.Collections;

public class PlayerTwoHealthManager : MonoBehaviour {
	
	private LevelManager levelManager;
	
	public static int player2Health;
	public int maxPlayerHealth;
	
	public static int player2Lives;
	public int initialLives;
	
	public bool isDead;

	public static float takeDamageAgain; //how long until they can be hit again
	public static bool recovering;

	private string whichPlayer;
	
	
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		
		player2Health = maxPlayerHealth;
		
		player2Lives = PlayerPrefs.GetInt("Player2Lives");
		
		isDead = false;
		
		recovering = true;
		takeDamageAgain = 2; //change this to change initial invincibilty 

		whichPlayer = "player2";
	}
	
	// Update is called once per frame
	void Update () {
		if(player2Lives > -1 && !isDead){
			if(player2Health <= 0){ 
				player2Health = 0;
				RemoveLife ();
				levelManager.RespawnPlayer(whichPlayer); //player dies and respawns from the same function
				GetComponent<AudioSource>().Play (); //plays death sound effect
				isDead = true;
			}
		}
		else if (player2Lives == -1 && !isDead){
			isDead = true;
		}
		
		if(recovering == true && Time.time > takeDamageAgain){
			recovering = false;
		}
	}
	
	public static void HurtPlayer(int damage){
		
		var player = FindObjectOfType<PlayerController2>();
		
		if(recovering == false){
			player2Health -= damage; //actual damage
			takeDamageAgain = Time.time +  player.recoveryRate;
			recovering = true;
		}
		
	}
	
	public static void BouncePlayer(Collider2D avatar, GameObject enemy){
		//knockback control
		var player = avatar.GetComponentInParent<PlayerController2>();
		player.knockbackCount = player.knockbackLength;
		
		if(player.grounded == true){
			if(player.gameObject.transform.position.x < enemy.gameObject.transform.position.x){
				player.knockFromWhere = 0;
			}
			if(player.gameObject.transform.position.x > enemy.gameObject.transform.position.x){
				player.knockFromWhere = 1;
			}
		}
		
		else if(player.grounded == true && player.GetComponent<Rigidbody2D>().velocity.x == player.GetComponent<Rigidbody2D>().velocity.y){ //Not moving
			if(player.gameObject.transform.position.x < enemy.gameObject.transform.position.x){
				player.knockFromWhere = 0;
			}
			if(player.gameObject.transform.position.x > enemy.gameObject.transform.position.x){
				player.knockFromWhere = 1;
			}
		}
		
		else if(player.grounded == false){ 
			if(player.transform.position.y < enemy.gameObject.transform.position.y){
				player.knockFromWhere = 2;
			}
			if(player.transform.position.y > enemy.gameObject.transform.position.y){
				player.knockFromWhere = 3;
			}
		}
		
		else if(player.grounded == false && Mathf.Abs (player.GetComponent<Rigidbody2D>().velocity.x) + 2 > Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.y)){
			if(player.transform.position.x < enemy.gameObject.transform.position.x){
				player.knockFromWhere = 0;
			}
			else{
				player.knockFromWhere = 1;
			}
		}
	}
	
	public static void AddLife(){
		player2Lives++;
		PlayerPrefs.SetInt("Player2Lives", player2Lives);
	}
	
	public static void RemoveLife(){
		player2Lives--;
		PlayerPrefs.SetInt("Player2Lives", player2Lives);
	}
}
