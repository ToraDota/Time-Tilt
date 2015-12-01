﻿using UnityEngine;
using System.Collections;

public class PlayerStomp2 : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "EnemyHead"){
			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(1);
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
			PlayerTwoHealthManager.BouncePlayer(this.GetComponent<Collider2D>(), other.gameObject);
			
			//Debug.Log ("worked");
		}
	}
}
