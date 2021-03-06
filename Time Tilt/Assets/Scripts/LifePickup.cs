﻿using UnityEngine;
using System.Collections;

public class LifePickup : MonoBehaviour {

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
		if(canPickUp == false){
			Physics2D.IgnoreLayerCollision(0, 8, true);
			Physics2D.IgnoreLayerCollision(8, 14, true);
		}
		else{
			Physics2D.IgnoreLayerCollision(0, 8, false);
			Physics2D.IgnoreLayerCollision(8, 14, false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (canPickUp == true) {
			if (other.tag == "Player") {
				PlayerHealthManager.AddLife ();
				ScoreManager.UpScore (pointsWorth);
				Destroy (gameObject);
			}

			if (other.tag == "Player2") {
				PlayerTwoHealthManager.AddLife ();
				ScoreManager.UpScore (pointsWorth);
				Destroy (gameObject);
			}
		} 
	}

//	void OnTriggerStay2D(Collider2D other){
//		if (canPickUp == true) {
//			if (other.tag == "Player") {
//				PlayerHealthManager.AddLife ();
//				ScoreManager.UpScore (pointsWorth);
//				Destroy (gameObject);
//			}
//			
//			if (other.tag == "Player2") {
//				PlayerTwoHealthManager.AddLife ();
//				ScoreManager.UpScore (pointsWorth);
//				Destroy (gameObject);
//			}
//		} 
//	}

	public void CallTouchDelay(){
		StartCoroutine ("TouchDelay");
	}
	
	public IEnumerator TouchDelay(){
		yield return new WaitForSeconds(0.5f);
		canPickUp = true;
		Physics2D.IgnoreLayerCollision(0, 8, false);
	}
}
