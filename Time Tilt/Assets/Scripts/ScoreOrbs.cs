using UnityEngine;
using System.Collections;

public class ScoreOrbs : MonoBehaviour {

	public int pointsWorth;

	private bool canPickUp;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().Play ();
		canPickUp = false;
		CallTouchDelay ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (canPickUp == true) {
			if (other.tag == "Player") {
				GetComponent<AudioSource> ().Play ();
				ScoreManager.UpScore (pointsWorth);
				Destroy (gameObject);
			}

			if (other.tag == "Player2") {
				GetComponent<AudioSource> ().Play ();
				ScoreManager.UpScore (pointsWorth);
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
