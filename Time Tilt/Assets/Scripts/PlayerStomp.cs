using UnityEngine;
using System.Collections;

public class PlayerStomp : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "EnemyHead"){
			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(1);
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
			PlayerHealthManager.BouncePlayer(this.GetComponent<Collider2D>(), other.gameObject);

			//Debug.Log ("worked");
		}
	}
	
}

