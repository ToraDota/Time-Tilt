using UnityEngine;
using System.Collections;

public class PlayerLance : MonoBehaviour {

	private EnemyHealthManager enemyHealth;//Wouldnt want to do this because this grabs the entire script/class rather than the individual health componenet of the object the script is on.

	public int bodyDamage;
	public int headDamage;
	public int bottomDamage;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "EnemyBody"){
			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(bodyDamage);//GetComponenetInParent grabs the actual enemy game object rather than the individual hit boxes
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
			GetComponent<AudioSource>().Play ();
			//EnemyHealthManager.HurtEnemy(bodyDamage);
			//Debug.Log("Enemy Body");
		}
		
		else if(other.name == "EnemyHead"){
			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(headDamage);
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
			GetComponent<AudioSource>().Play ();
			//EnemyHealthManager.HurtEnemy(headDamage);
			//Debug.Log("Enemy Head");
		}
		
		else if(other.name == "EnemyBottom"){
			other.GetComponentInParent<EnemyHealthManager>().HurtEnemy(bottomDamage);
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
			GetComponent<AudioSource>().Play ();
			//Debug.Log ("Enemy Bottom");
		}
		else if(other.name == "EnemyLance"){
			//bounce back happens here
			other.GetComponentInParent<EnemyHealthManager>().knockBackEnemySides(other, gameObject.transform);
			GetComponent<AudioSource>().Play ();
		}
		else
			return;

	}

}
