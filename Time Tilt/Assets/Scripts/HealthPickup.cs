using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	private PlayerHealthManager health;

	private bool canPickUp;

	// Use this for initialization
	void Start () {
		health = FindObjectOfType<PlayerHealthManager>();
		GetComponent<AudioSource>().Play ();
		canPickUp = false;
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
				if (PlayerHealthManager.playerHealth < health.maxPlayerHealth) {

					PlayerHealthManager.playerHealth++;
				}
				Destroy (gameObject);
			}

			if (other.tag == "Player2") {
				if (PlayerTwoHealthManager.player2Health < health.maxPlayerHealth) {
					
					PlayerTwoHealthManager.player2Health++;
				}
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (canPickUp == true) {
			if (other.tag == "Player") {
				if (PlayerHealthManager.playerHealth < health.maxPlayerHealth) {
					
					PlayerHealthManager.playerHealth++;
				}
				Destroy (gameObject);
			}
			
			if (other.tag == "Player2") {
				if (PlayerTwoHealthManager.player2Health < health.maxPlayerHealth) {
					
					PlayerTwoHealthManager.player2Health++;
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
