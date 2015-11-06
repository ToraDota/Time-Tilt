﻿using UnityEngine;
using System.Collections;

public class Gun1Pickup : MonoBehaviour {

	public int pointsWorth;
	public int bullets;

	private AudioSource noise;

	// Use this for initialization
	void Start () {
		//GetComponent<AudioSource>().Play ();
		noise = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
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
			Destroy (gameObject);
		}

		if(other.tag == "Player2"){
			var player = other.GetComponent<PlayerController2>();
			
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
			Destroy (gameObject);
		}
	}
}
