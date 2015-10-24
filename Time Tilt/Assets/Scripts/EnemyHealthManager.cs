using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0){
			Destroy (gameObject);
		}
	}

	public void HurtEnemy(int damage){
		enemyHealth -= damage;
		Debug.Log("Enemy Health " + enemyHealth);
	}
}
