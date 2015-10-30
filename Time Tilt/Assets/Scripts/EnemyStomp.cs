using UnityEngine;
using System.Collections;

public class EnemyStomp : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "Head"){ // hits the players head but only does one damage
			PlayerHealthManager.HurtPlayer (1);
			PlayerHealthManager.BouncePlayer(other, gameObject);
			//Debug.Log("Head");
		}

//		if(other.name == "Enemy"){
//			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(1);
//			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
//			Debug.Log ("worked");
//		}
	}

}
