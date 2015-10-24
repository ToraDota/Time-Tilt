using UnityEngine;
using System.Collections;

public class PlayerBody : MonoBehaviour {

	private DamagePlayer damage;

	// Use this for initialization
	void Start () {
		damage = FindObjectOfType<DamagePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OntriggerEnter2D(Collider other){
		if(other.name == "EnemyLance"){ //or whatever else they shoot out
			PlayerHealthManager.playerHealth -= 2; // static damage given to player when hit by an enemy lance in the body.
			//write function for invincibility state
		}
	}
}
