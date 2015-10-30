using UnityEngine;
using System.Collections;

public class LifePickup : MonoBehaviour {

	private PlayerHealthManager health;
	public int pointsWorth;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			PlayerHealthManager.AddLife();
			ScoreManager.UpScore(pointsWorth);
			Destroy (gameObject);
		}
	}
}
