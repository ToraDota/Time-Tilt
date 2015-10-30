using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	private PlayerHealthManager health;

	// Use this for initialization
	void Start () {
		health = FindObjectOfType<PlayerHealthManager>();
		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Player"){
			if(PlayerHealthManager.playerHealth < health.maxPlayerHealth){

				PlayerHealthManager.playerHealth++;
			}
			Destroy (gameObject);
		}
	}
}
