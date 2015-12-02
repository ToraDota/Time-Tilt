using UnityEngine;
using System.Collections;

public class EnemyStomp : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "Head"){ // hits the players head but only does one damage
			PlayerHealthManager.HurtPlayer (1);
			PlayerHealthManager.BouncePlayer(other, gameObject);
			GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(this.GetComponent<Collider2D>(), other.gameObject.transform);
			//Debug.Log("Head");
		}

		if(other.name == "Head2"){
			PlayerTwoHealthManager.HurtPlayer(1);
			PlayerTwoHealthManager.BouncePlayer(other, gameObject);
			GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(this.GetComponent<Collider2D>(), other.gameObject.transform);
		}
	}
}
