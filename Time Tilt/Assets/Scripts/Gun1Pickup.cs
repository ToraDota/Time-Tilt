using UnityEngine;
using System.Collections;

public class Gun1Pickup : MonoBehaviour {

	public int pointsWorth;
	public int bullets;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			GetComponent<AudioSource>().Play ();
			GetComponent<Renderer>().enabled = false;
			GetComponent<Collider2D>().enabled = false;
			var player = other.GetComponent<PlayerController>();

			ScoreManager.UpScore(pointsWorth);

			if(player.gunNumber > 1){
				//Ignores this object and just destroys it
				Destroy (gameObject);
			}
			else if(player.gunNumber < 1){

				player.gunNumber = 1;
				player.bulletCounter = bullets;

			}
			else{
				player.bulletCounter = bullets;

			}
			Destroy (gameObject,.5f);
		}
	}
}
