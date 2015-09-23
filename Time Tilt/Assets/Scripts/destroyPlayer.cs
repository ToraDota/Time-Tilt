using UnityEngine;
using System.Collections;

public class destroyPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name == "enemy01") {
			Destroy (GameObject.FindWithTag("Player"));
		}
	} 
}