using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	public GameObject orb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0){
			Instantiate (orb, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
			Destroy (gameObject);
		}
	}

	public void HurtEnemy(int damage){
		enemyHealth -= damage;

		//enemy bounce back here. probably clean up enemy movement then do this.
		//Debug.Log("Enemy Health " + enemyHealth);
	}
}
