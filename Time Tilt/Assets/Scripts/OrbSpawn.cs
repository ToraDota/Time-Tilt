using UnityEngine;
using System.Collections;

public class OrbSpawn : MonoBehaviour 
{
	//public Transform dropORB;
	public GameObject orb;

	void OnTriggerEnter2D (Collider2D coll)
	{
		/*if (coll.name == "Lance") { //this would probably need to be changed to on some form of enemy death check, and the thing that drops be random
			Instantiate (orb, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		}*/
	}



}
