using UnityEngine;
using System.Collections;

public class OrbSpawn : MonoBehaviour 
{
	public Transform dropORB;

	

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.name == "Lance") {
			Instantiate (dropORB);
		}
	}



}
