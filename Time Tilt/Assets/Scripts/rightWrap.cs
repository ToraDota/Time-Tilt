using UnityEngine;
using System.Collections;

public class rightWrap : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" || other.tag == "Enemy") {	
			other.gameObject.transform.position = new Vector3 (-7.3f, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
		

		}
	}





}
