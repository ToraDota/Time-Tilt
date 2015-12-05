using UnityEngine;
using System.Collections;

public class NonLethalHazard : MonoBehaviour {

	public int hazardDamage;
	private PlayerHealthManager health;
	private PlayerTwoHealthManager health2;
	private EnemyHealthManager enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Player"){
			PlayerHealthManager.HurtPlayer(hazardDamage);
			PlayerHealthManager.BouncePlayer(other, gameObject);
			GetComponent<AudioSource>().Play();
		}

		if (other.tag == "Player2"){
			PlayerTwoHealthManager.HurtPlayer(hazardDamage);
			PlayerTwoHealthManager.BouncePlayer(other, gameObject);
			GetComponent<AudioSource>().Play();
		}
		//Debug.Log("sajldhlakjsd");
	}
}
