using UnityEngine;
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
		
		//put this on enemy bullets? just have this be else .

			if(other.name == "Body"){
				PlayerHealthManager.HurtPlayer(2);
				PlayerHealthManager.BouncePlayer(other, gameObject);
				GetComponent<AudioSource>().Play();
				//Debug.Log("Body");
			}

			if(other.name == "Head"){
				PlayerHealthManager.HurtPlayer (3);
				PlayerHealthManager.BouncePlayer(other, gameObject);
				GetComponent<AudioSource>().Play();
				//Debug.Log("Head");
			}

			if(other.name == "Bottom"){
				PlayerHealthManager.HurtPlayer (1);
				PlayerHealthManager.BouncePlayer(other, gameObject);
				GetComponent<AudioSource>().Play();
					//Debug.Log ("Bottom");
			}
			if(other.name == "Lance"){
				//bounce back happens here; no damage
				PlayerHealthManager.BouncePlayer(other, gameObject);
				GetComponent<AudioSource>().Play(); //plays bounceback when the player clashes with the enemy lance
			}
	}
}
