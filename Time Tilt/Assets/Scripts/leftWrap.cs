using UnityEngine;
using System.Collections;

public class leftWrap : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" || other.tag == "Enemy") {		
			other.gameObject.transform.position = new Vector3 (8.7f, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
		}
    }


}
