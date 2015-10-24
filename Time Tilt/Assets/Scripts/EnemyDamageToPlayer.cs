using UnityEngine;
using System.Collections;

public class EnemyDamageToPlayer : MonoBehaviour {

	private PlayerHealthManager health;
	
	// Use this for initialization
	void Start () {
		//health = FindObjectOfType<PlayerHealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//This is on the enemies Lance
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "Body"){
			PlayerHealthManager.HurtPlayer(2);
			Debug.Log("Body");
		}

		else if(other.name == "Head"){
			PlayerHealthManager.HurtPlayer (4);
			Debug.Log("Head");
		}

		else if(other.name == "Bottom"){
			PlayerHealthManager.HurtPlayer (1);
			Debug.Log ("Bottom");
		}
		else if(other.name == "Lance"){
			//bounce back happens here
		}
	}
}
