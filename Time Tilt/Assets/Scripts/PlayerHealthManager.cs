using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

	private LevelManager levelManager;

	public static int playerHealth;
	public int maxPlayerHealth;

	public static int playerLives;
	public int initialLives;

	public bool isDead;

	private string whichPlayer;


	public static float takeDamageAgain; //how long until they can be hit again
	public static bool recovering;

	public AudioSource[] audioSources;
	public static AudioSource hit1;
	public static AudioSource hit2;
	public static AudioSource hit3;


	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();

		playerHealth = maxPlayerHealth;

		//playerLives = initialLives;
		playerLives = PlayerPrefs.GetInt ("Player1Lives");

		isDead = false;

		recovering = false;
		takeDamageAgain = 0;

		whichPlayer = "player1";

		audioSources = GetComponents<AudioSource>();
		hit1 = audioSources[1];
		hit2 = audioSources[2];
		hit3 = audioSources[3];
	}
	
	// Update is called once per frame
	void Update () {
		if(playerLives > -1 && isDead == false){
			if(playerHealth <= 0){ 
				playerHealth = 0;
				RemoveLife ();
				levelManager.RespawnPlayer(whichPlayer); //player dies and respawns from the same function
				GetComponent<AudioSource>().Play (); //plays death sound effect
				isDead = true;
			}
		}
		else if (playerLives == -1 && isDead == false){
			//possibly disable renders
			isDead = true;
		}

		if(isDead == true){
			levelManager.RespawnPlayer(whichPlayer);
		}

		if(recovering == true && Time.time > takeDamageAgain){
			recovering = false;
		}
	}

	public static void HurtPlayer(int damage){

		var player = FindObjectOfType<PlayerController>();

		if(recovering == false){
			playerHealth -= damage; //actual damage
			if(damage == 1){
				hit1.Play();
			}
			else if(damage == 2){
				hit2.Play();
			}
			else if(damage == 3){
				hit3.Play();
			}

			takeDamageAgain = Time.time +  player.recoveryRate;
			recovering = true;
		}
			
	}

	public static void BouncePlayer(Collider2D avatar, GameObject enemy){
		//knockback control
		var player = avatar.GetComponentInParent<PlayerController>();
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
		playerLives++;
		PlayerPrefs.SetInt("Player1Lives", playerLives);
	}

	public static void RemoveLife(){
		playerLives--;
		PlayerPrefs.SetInt("Player1Lives", playerLives);
	}
}
