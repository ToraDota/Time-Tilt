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
		
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		health = FindObjectOfType<PlayerHealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
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
		player.knockbackCount = 0;
		player.knockFromWhere = 0;
		player.bulletCounter = 0;
//		rendHead.enabled = true;
//		rendLance.enabled = true;
//		rendBottom.enabled = true;
//		rendBody.enabled = true;
		body.SetActive(true);
		head.SetActive(true);
		lance.SetActive(true);
		bottom.SetActive(true);
		PlayerHealthManager.playerHealth = health.maxPlayerHealth;
		health.isDead = false;
	}

	public void ChangeRespawnLocation(){

	}

	public void DestroyPlatform(GameObject plat){
		Destroy (plat);
	}

	public void CreateHazard (GameObject plat){

	}

}
