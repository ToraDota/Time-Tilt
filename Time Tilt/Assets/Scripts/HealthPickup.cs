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
		else {
			Physics2D.IgnoreLayerCollision(0, 8, true);
		}
	}

	public void CallTouchDelay(){
		StartCoroutine ("TouchDelay");
	}
	
	public IEnumerator TouchDelay(){
		yield return new WaitForSeconds(2.0f);
		canPickUp = true;
		Physics2D.IgnoreLayerCollision(0, 8, false);
	}
}
