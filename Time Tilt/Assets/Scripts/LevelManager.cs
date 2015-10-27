using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	private PlayerController player;
	private PlayerHealthManager health;

	public float respawnDelay;
	public Transform respawnLocation;

	//Individual Sprite Renders; Uncessessary upon sprite implementation most likely;
	public Renderer rendHead;
	public Renderer rendBottom;
	public Renderer rendLance;
	public Renderer rendBody;

	public GameObject body;
	public GameObject head;
	public GameObject lance;
	public GameObject bottom;
	public GameObject gun1;
	public GameObject gun2;

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
	
	//Platforms to possibly destroyed. Insert empty object to destroy to fill slot if 4 aren't going to be used. 
	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	public GameObject platform4;
	public GameObject hazard;

	public string levelToLoad;
	public float timeTillNextLevel;

		
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		health = FindObjectOfType<PlayerHealthManager>();
		hasWaveStarted = false;
		waveCompleted = false;
	}
	
	// Update is called once per frame
	void Update () {

		enemyCount = FindObjectsOfType<EnemyController>();//checks how many enemies are on the screen at any given time

		switch(waveCount){
		case 1:
			//Debug.Log (enemiesToSpawn[0]);
			if(!hasWaveStarted){
				//no platforms to change in wave 1
			}

			if(enemiesToSpawn[0] > 1 && Time.time > nextEnemySpawn){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}

			if(enemyCount.Length > 0){
				hasWaveStarted = true;
			}

			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted){
				//end the wave - some graphic might want to pop up here - just enable then disable it from the EndWave function
				Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		case 2:
			if(!hasWaveStarted){
				//DestroyPlatform(platform1);
				CreateHazard(platform1);
			}

			if(enemiesToSpawn[1] > 1 && Time.time > nextEnemySpawn){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}
			
			if(enemyCount.Length > 0){
				hasWaveStarted = true;
			}
			
			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted){
				//end the wave
				Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		case 3:
			if(!hasWaveStarted){
				DestroyPlatform(platform2);
			}

			if(enemiesToSpawn[2] > 1 && Time.time > nextEnemySpawn){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}
			
			if(enemyCount.Length > 0){
				hasWaveStarted = true;
			}
			
			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted){
				//end the wave
				Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		case 4:
			if(!hasWaveStarted){
				//DestroyPlatform(platform3);
				CreateHazard(platform3);
			}

			if(enemiesToSpawn[3] > 1 && Time.time > nextEnemySpawn){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}
			
			if(enemyCount.Length > 0){
				hasWaveStarted = true;
			}
			
			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted){
				//end the wave
				Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		case 5:
			if(!hasWaveStarted){
				DestroyPlatform(platform1);
			}

			if(enemiesToSpawn[4] > 1 && Time.time > nextEnemySpawn){ //spawns in enemies
				nextEnemySpawn = Time.time + enemySpawnRate;
				CallSpawnEnemy();
			}
			
			if(enemyCount.Length > 0){
				hasWaveStarted = true;
			}
			
			if(enemyCount.Length < 1 && hasWaveStarted && !waveCompleted){
				//end the wave
				Debug.Log("Wave Completed");
				waveCompleted = true;
				CallEndWave (); //called once, as the last enemy dies
			}
			break;
		default: //once reaching this the next level is called
				if(!hasWaveStarted && !waveCompleted)
				{
				CallNextLevel();
				hasWaveStarted = true;
				waveCompleted = true;
				}
			break;

		}
	
	}

	public void RespawnPlayer(){
		StartCoroutine("Respawn");
	}

	public IEnumerator Respawn(){
		//Debug.Log ("Dead");
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //haults movement
//		rendHead.enabled = false;
//		rendLance.enabled = false;
//		rendBottom.enabled = false;
//		rendBody.enabled = false;
		body.SetActive(false);
		head.SetActive(false);
		lance.SetActive(false);
		bottom.SetActive(false);
		gun1.SetActive(false);
		gun2.SetActive(false);
		//Debug.Log ("Waiting to Respawn");
		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = respawnLocation.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		player.knockbackCount = 0;
		player.knockFromWhere = 0;
		player.bulletCounter = 0;
		player.gunNumber = 0;
//		rendHead.enabled = true;
//		rendLance.enabled = true;
//		rendBottom.enabled = true;
//		rendBody.enabled = true;
		GetComponent<AudioSource>().Play ();
		body.SetActive(true);
		head.SetActive(true);
		lance.SetActive(true);
		bottom.SetActive(true);
		PlayerHealthManager.playerHealth = health.maxPlayerHealth;
		health.isDead = false;
	}

	public void ChangeRespawnLocation(){

	}


	public void CallSpawnEnemy(){
		StartCoroutine("SpawnEnemy");
	}
	public IEnumerator SpawnEnemy(){
		yield return new WaitForSeconds (spawnDelay);
		int rnd = Random.Range(0,3);
		if(rnd == 0){
			enemySpawnHere = spawnPoint1;
		}
		else if(rnd == 1){
			enemySpawnHere = spawnPoint2;
		}
		else
			enemySpawnHere = spawnPoint3;
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

}
