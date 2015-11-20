using UnityEngine;
using System.Collections;

public class Gun3Pickup : MonoBehaviour {

	public int pointsWorth;
	public int bullets;
	
	private bool canPickUp;
	
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().Play ();
		canPickUp = false;
		CallTouchDelay();
	}
	
	// Update is called once per frame
	void Update () {
		if(canPickUp == false){
			Physics2D.IgnoreLayerCollision(0, 8, true);
		}
		else{
			Physics2D.IgnoreLayerCollision(0, 8, false);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (canPickUp == true) {
			if (other.tag == "Player") {
				var player = other.GetComponent<PlayerController> ();
				
				ScoreManager.UpScore (pointsWorth);

				if (player.gunNumber > 3) {
					//Ignores this object and just destroys it
					Destroy (gameObject);
				} else if (player.gunNumber < 3) {
					player.gunNumber = 3;
					player.bulletCounter = bullets;
				} else {
					player.bulletCounter = bullets;
				}
				Destroy (gameObject);
			}
			
			if (other.tag == "Player2") {
				var player = other.GetComponent<PlayerController2> ();
				
				ScoreManager.UpScore (pointsWorth);
				
				if (player.gunNumber > 3) {
					//Ignores this object and just destroys it
					Destroy (gameObject);
				} else if (player.gunNumber < 3) {
					player.gunNumber = 3;
					player.bulletCounter = bullets;
				} else {
					player.bulletCounter = bullets;
				}
				Destroy (gameObject);
			}
		} 
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (canPickUp == true) {
			if (other.tag == "Player") {
				var player = other.GetComponent<PlayerController> ();
				
				ScoreManager.UpScore (pointsWorth);

				if (player.gunNumber > 3) {
					//Ignores this object and just destroys it
					Destroy (gameObject);
				} else if (player.gunNumber < 3) {
					player.gunNumber = 3;
					player.bulletCounter = bullets;
				} else {
					player.bulletCounter = bullets;
				}
				Destroy (gameObject);
			}
			
			if (other.tag == "Player2") {
				var player = other.GetComponent<PlayerController2> ();
				
				ScoreManager.UpScore (pointsWorth);
				
				if (player.gunNumber > 3) {
					//Ignores this object and just destroys it
					Destroy (gameObject);
				} else if (player.gunNumber < 3) {
					player.gunNumber = 3;
					player.bulletCounter = bullets;
				} else {
					player.bulletCounter = bullets;
				}
				Destroy (gameObject);
			}
		} 
	}
	
	public void CallTouchDelay(){
		StartCoroutine ("TouchDelay");
	}
	
	public IEnumerator TouchDelay(){
		yield return new WaitForSeconds(0.5f);
		canPickUp = true;
		Physics2D.IgnoreLayerCollision(0, 8, false);
	}
}
