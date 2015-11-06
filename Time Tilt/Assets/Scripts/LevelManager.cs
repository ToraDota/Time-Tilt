using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	private PlayerController player;
	private PlayerController2 player2;
	private PlayerHealthManager health;
	private PlayerTwoHealthManager health2;

	public GameObject secondPlayer;
	public GameObject player2Canvas;

	public float respawnDelay;
	public Transform respawnLocation;

	//renders to disable for player 1
	public GameObject body;
	public GameObject head;
	public GameObject lance;
	public GameObject bottom;
	public GameObject gun1;
	public GameObject gun2;

	//renders to disable for player 2
	public GameObject body2;
	public GameObject head2;
	public GameObject lance2;
	public GameObject bottom2;
	public GameObject gun1_2;
	public GameObject gun2_2;

	//Wave control
	public int waveCount;
	public float timeTillNextWave;
	public bool waveCompleted;
	private bool hasWaveStarted; //start spawning in enemies if the wave has started
	public EnemyController[] enemyCount; //array to count how many enemies are present
	public GameObject enemy;

	//places the enemy can spawn and the place the enemy will spawn after a random roll
	public Transform spawnPoint1;
	public Transform spawnPoint2;
	public Transform spawnPoint3;
	private Transform enemySpawnHere;	

	//rates determining enemy spawn rate
	public float enemySpawnRate;//these two timers might just add together
	private float nextEnemySpawn; // onces this hits a certain time, enemies can spawn again
	public float spawnDelay;//these two timers might just add together

	//tracks the amount of enemies left needed to spawn per wave
	public int[] enemiesToSpawn;
	public bool anEnemyHasSpawned;
	
	//Platforms to possibly destroyed. Insert empty object to destroy to fill slot if 4 aren't going to be used. 
	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	public GameObject platform4;
	public GameObject hazard;

	public string levelToLoad;
	public float timeTillNextLevel;

	private int oldRnd;
	private int rnd;

	private bool playerTwoHasSpawned;

	private bool gameOver;
		
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		health = FindObjectOfType<PlayerHealthManager>();
		player2 = FindObjectOfType<PlayerController2>();
		health2 = FindObjectOfType<PlayerTwoHealthManager>();

		hasWaveStarted = false;
		waveCompleted = false;
		anEnemyHasSpawned = false;
		playerTwoHasSpawned = false;
		gameOver = false;
		CallDelayLevelStart();
	}
	
	// Update is called once per frame
	void Update () {

		enemyCount = FindObjectsOfType<EnemyController>();//checks how many enemies are on the screen at any given time

		switch(waveCount){
		case 1:
			if(enemiesToSpawn[0] > 1 && Time.time > nextEnemySpawn){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}

			if(enemyCount.Length > 0){
				hasWaveStarted = true;
				anEnemyHasSpawned = true;
			}

			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted && anEnemyHasSpawned){
				//end the wave - some graphic might want to pop up here - just enable then disable it from the EndWave function
				Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		case 2:
			if(!hasWaveStarted){
				CreateHazard(platform1);
				hasWaveStarted = true;
			}

			if(enemiesToSpawn[1] > 1 && Time.time > nextEnemySpawn ){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}

			if(enemyCount.Length > 0){
				anEnemyHasSpawned = true;
			}
			
			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted && anEnemyHasSpawned){
				//end the wave
				//Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		case 3:
			if(!hasWaveStarted){
				DestroyPlatform(platform2);
				hasWaveStarted = true;
			}

			if(enemiesToSpawn[2] > 1 && Time.time > nextEnemySpawn){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}

			if(enemyCount.Length > 0){
				anEnemyHasSpawned = true;
			}
			
			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted && anEnemyHasSpawned){
				//end the wave
				//Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		case 4:
			if(!hasWaveStarted){
				CreateHazard(platform3);
				hasWaveStarted = true;
			}

			if(enemiesToSpawn[3] > 1 && Time.time > nextEnemySpawn){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}

			if(enemyCount.Length > 0){
				anEnemyHasSpawned = true;
			}
			
			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted && anEnemyHasSpawned){
				//end the wave
				//Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		case 5:
			if(!hasWaveStarted){
				DestroyPlatform(platform4);
				hasWaveStarted = true;
			}

			if(enemiesToSpawn[4] > 1 && Time.time > nextEnemySpawn){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}

			if(enemyCount.Length > 0){
				anEnemyHasSpawned = true;
			}
			
			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted && anEnemyHasSpawned){
				//end the wave
				//Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		case 6: //once reaching this the next level is called
				if(!hasWaveStarted && !waveCompleted)
				{
				CallNextLevel();
				hasWaveStarted = true;
				waveCompleted = true;
				}
			break;
		}
		//spawnplayer two check
		if(playerTwoHasSpawned == false && Input.GetKeyDown (KeyCode.Alpha2)){
			Instantiate (secondPlayer, respawnLocation.position, respawnLocation.rotation);
			player2Canvas.SetActive(true);
			body2 = GameObject.FindGameObjectWithTag("P2Body");
			lance2 = GameObject.FindGameObjectWithTag("P2Lance");
			bottom2 = GameObject.FindGameObjectWithTag("P2Bottom");
			head2 = GameObject.FindGameObjectWithTag("P2Head");
			gun1_2 = GameObject.FindGameObjectWithTag("P2Gun1");
			gun2_2 = GameObject.FindGameObjectWithTag("P2Gun2");
			playerTwoHasSpawned = true;
		}

		//Game Over function
		if(gameOver == false && playerTwoHasSpawned == false && PlayerHealthManager.playerLives < 0){//only for player 1

		}
		else if(gameOver == false && playerTwoHasSpawned == true && PlayerHealthManager.playerLives < 0 && PlayerTwoHealthManager.player2Lives < 0){//when two players exist

		}
	}

	public void RespawnPlayer(string whichPlayer){
		if(whichPlayer == "player1"){
			StartCoroutine("RespawnPlayer1");
		}
		if(whichPlayer == "player2"){
			StartCoroutine ("RespawnPlayer2");
		}
	}

	public IEnumerator RespawnPlayer1(){
		//Debug.Log ("Dead");
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //haults movement
		body.SetActive(false);
		head.SetActive(false);
		lance.SetActive(false);
		bottom.SetActive(false);
		gun1.SetActive(false);
		gun2.SetActive(false);
		//Debug.Log ("Waiting to Respawn");
		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = respawnLocation.transform.position;
		GetComponent<AudioSource>().Play ();//plays on respawn
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		player.knockbackCount = 0;
		player.knockFromWhere = -1;
		player.bulletCounter = 0;
		player.gunNumber = 0;
		GetComponent<AudioSource>().Play(); // play respawn sound
		body.SetActive(true);
		head.SetActive(true);
		lance.SetActive(true);
		bottom.SetActive(true);
		PlayerHealthManager.playerHealth = health.maxPlayerHealth;
		health.isDead = false;
	}

	public IEnumerator RespawnPlayer2(){
		//Debug.Log ("Dead");
		player2.enabled = false;
		player2.GetComponent<Renderer>().enabled = false;
		player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //haults movement
		body2.SetActive(false);
		head2.SetActive(false);
		lance2.SetActive(false);
		bottom2.SetActive(false);
		gun1_2.SetActive(false);
		gun2_2.SetActive(false);
		//Debug.Log ("Waiting to Respawn");
		yield return new WaitForSeconds (respawnDelay);
		player2.transform.position = respawnLocation.transform.position;
		GetComponent<AudioSource>().Play ();//plays on respawn
		player2.enabled = true;
		player2.GetComponent<Renderer>().enabled = true;
		player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		player2.knockbackCount = 0;
		player2.knockFromWhere = -1;
		player2.bulletCounter = 0;
		player2.gunNumber = 0;
		GetComponent<AudioSource>().Play(); // play respawn sound
		body2.SetActive(true);
		head2.SetActive(true);
		lance2.SetActive(true);
		bottom2.SetActive(true);
		PlayerTwoHealthManager.player2Health = health2.maxPlayerHealth;
		health2.isDead = false;
	}


	public void ChangeRespawnLocation(){

	}


	public void CallSpawnEnemy(){
		StartCoroutine("SpawnEnemy");
	}
	public IEnumerator SpawnEnemy(){
		yield return new WaitForSeconds (spawnDelay);
		oldRnd = rnd;
		rnd = Random.Range(0,3); //0 1 or 2
		if(rnd == 0 && oldRnd != 0){
			enemySpawnHere = spawnPoint1;
		}
		else if(rnd == 1 && oldRnd != 1){
			enemySpawnHere = spawnPoint2;
		}
		else if(rnd == 2 && oldRnd != 2){
			enemySpawnHere = spawnPoint3;
		}
		else
			enemySpawnHere = spawnPoint1;

		Instantiate (enemy, enemySpawnHere.position, enemySpawnHere.rotation);
		Debug.Log ("Enemy Spawned");
		enemiesToSpawn[waveCount - 1]--;
	}

	public void CallEndWave(){
		StartCoroutine("EndWave");
	}
	public IEnumerator EndWave(){
		yield return new WaitForSeconds (timeTillNextWave);
		Debug.Log ("New Wave Starting");
		hasWaveStarted = false;
		waveCompleted = false;
		anEnemyHasSpawned = false;
		PlayerHealthManager.playerHealth = health.maxPlayerHealth;
		waveCount++;
	}

	public void CallNextLevel(){
		StartCoroutine("NextLevel");
	}
	public IEnumerator NextLevel(){ //calls the next level
		yield return new WaitForSeconds (timeTillNextLevel);
		Application.LoadLevel(levelToLoad);
	}

	public void DestroyPlatform(GameObject plat){
		plat.SetActive(false);
	}

	public void CreateHazard (GameObject plat){
		Instantiate (hazard, plat.transform.position, plat.transform.rotation);
		plat.SetActive(false);
	}

	public void CallDelayLevelStart(){
		StartCoroutine("DelayLevelStart");
	}

	public IEnumerator DelayLevelStart(){
		yield return new WaitForSeconds(5.0f);
		waveCount = 1;
	}
}
