using UnityEngine;
using System.Collections;

public class Gun2Pickup : MonoBehaviour {

	public int pointsWorth;
	public int bullets;
	public AudioClip powerup;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){

			var player = other.GetComponent<PlayerController>();

			ScoreManager.UpScore(pointsWorth);
			
			if(player.gunNumber > 2){
				//Ignores this object and just destroys it
				Destroy (gameObject);
			}
			else if(player.gunNumber < 2){
				player.gunNumber = 2;
				player.bulletCounter = bullets;
			}
			else{
				player.bulletCounter = bullets;
			}
			Destroy (gameObject);
		}

	}
}
