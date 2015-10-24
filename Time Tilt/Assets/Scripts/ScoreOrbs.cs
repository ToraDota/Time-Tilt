using UnityEngine;
using System.Collections;

public class ScoreOrbs : MonoBehaviour {

	public int pointsWorth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			ScoreManager.UpScore(pointsWorth);
			Destroy (gameObject);
		}
	}
}
