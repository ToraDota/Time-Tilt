using UnityEngine;
using System.Collections;

public class destroyPlayer : MonoBehaviour
{
	public Renderer rend;
	public Transform Respawn;
	public GameObject Player;
	int Lives = 3;
	int flag =1;

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Enemy") {
			Lives--;
			if (Lives == 0) {
				Debug.Log ("Game Over");
			}
			Debug.Log ("Life Lost");
			StartCoroutine (Dead ());
		}
	}

	IEnumerator Dead ()
	{
		Debug.Log ("dead");
		flag = 2;
		Player = GameObject.FindWithTag ("Player");
		rend.enabled = false;
		yield return new WaitForSeconds (2);
		Debug.Log ("respawn");
		flag =1;
		Player.transform.position = Respawn.transform.position;
		rend.enabled = true;
		}
}


