﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	public int thisBulletDamage;

	private PlayerController player;
	private PlayerController2 player2;
	private EnemyHealthManager enemy;

	private int directionWhenFired;

	private float distanceTraveled;
	public float maxDistance;

	public int firedFromWhere;

	private Transform playerPosition;

	public static bool firedFromPlayer1;

	// Use this for initialization
	void Start () {

		if (firedFromPlayer1) {
			player = FindObjectOfType<PlayerController> ();

			firedFromWhere = player.facingDirection; //0 left 1 right

			playerPosition = player.transform;

			if(player.transform.localScale.x < 0 && !player.facingUp && !player.facingDown){ //player is facing left so the object should fire left & player is not facing up or down
				speed = -speed;
				directionWhenFired = 1;
			}
			else if(player.transform.localScale.x > 0 && !player.facingUp && !player.facingDown){
				directionWhenFired = 1;
			}
			else if(player.facingDown){
				speed = -speed;
				directionWhenFired = 2;
			}
			else if(player.facingUp){
				directionWhenFired = 2;
			}
		} 
		else {
			player2 = FindObjectOfType<PlayerController2> ();

			firedFromWhere = player2.facingDirection; //0 left 1 right
			
			playerPosition = player2.transform;

			if(player2.transform.localScale.x < 0 && !player2.facingUp && !player2.facingDown){ //player is facing left so the object should fire left & player is not facing up or down
				speed = -speed;
				directionWhenFired = 1;
			}
			else if(player2.transform.localScale.x > 0 && !player2.facingUp && !player2.facingDown){
				directionWhenFired = 1;
			}
			else if(player2.facingDown){
				speed = -speed;
				directionWhenFired = 2;
			}
			else if(player2.facingUp){
				directionWhenFired = 2;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		//determines whether the bullet needs to fire up or down.
		if(directionWhenFired == 1){
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else if(directionWhenFired == 2){
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed);
		}

		//keeps track of how far the bullet has traveled;
		distanceTraveled += speed;

		if(distanceTraveled >= maxDistance || distanceTraveled <= -maxDistance){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Enemy"){
			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(thisBulletDamage);
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, playerPosition);

			Destroy (gameObject);

		}
		if(other.tag == "TopWall" || other.tag == "Platform" || other.tag == "Hazard"){
			Destroy (gameObject);
		}
	}
}
