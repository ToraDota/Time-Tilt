using UnityEngine;
using System.Collections;

public class PlayerLance : MonoBehaviour {

	public int bodyDamage;
	public int headDamage;
	//public int bottomDamage;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "EnemyBody"){
			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(bodyDamage);//GetComponenetInParent grabs the actual enemy game object rather than the individual hit boxes
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
			//GetComponent<AudioSource>().Play ();
			PlayerHealthManager.BouncePlayer(this.GetComponent<Collider2D>(), other.gameObject);

			//Debug.Log("Enemy Body");
		}
		
		else if(other.name == "EnemyHead"){
			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(headDamage);
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
			//GetComponent<AudioSource>().Play ();
			PlayerHealthManager.BouncePlayer(this.GetComponent<Collider2D>(), other.gameObject);
			//Debug.Log("Enemy Head");
		}
		
//		else if(other.name == "EnemyBottom"){
//			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(bottomDamage);
//			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
//			GetComponent<AudioSource>().Play ();
//			//Debug.Log ("Enemy Bottom");
//		}

		else if(other.name == "EnemyLance"){
			//bounce back happens here
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
			GetComponent<AudioSource>().Play ();
		}
	}
}
