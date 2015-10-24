﻿using UnityEngine;
using System.Collections;

public class EnemyDamageToPlayer : MonoBehaviour {

	private PlayerHealthManager health;

	//this is on a lance
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//This is on the enemies Lance
	void OnTriggerEnter2D (Collider2D other)
	{
			if(other.name == "Body"){
				PlayerHealthManager.HurtPlayer(2, other, gameObject);
				//Debug.Log("Body");
			}

			if(other.name == "Head"){
				PlayerHealthManager.HurtPlayer (4, other, gameObject);
				//Debug.Log("Head");
			}

			if(other.name == "Bottom"){
				PlayerHealthManager.HurtPlayer (1, other, gameObject);
					//Debug.Log ("Bottom");
			}
			if(other.name == "Lance"){
			//bounce back happens here; no damage
				PlayerHealthManager.HurtPlayer (0, other, gameObject);
			}
	}
}