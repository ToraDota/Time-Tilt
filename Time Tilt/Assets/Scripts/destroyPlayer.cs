using UnityEngine;
using System.Collections;

public class destroyPlayer : MonoBehaviour
{
	public Renderer rendHead;
	public Renderer rendBottom;
	public Renderer rendLance;
	public Renderer rendBodyBack;
	public Renderer rendBodyFront;
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
		Player.transform.position = new Vector3 (-11, 0, 0);
		rendHead.enabled = false;
		rendLance.enabled = false;
		rendBottom.enabled = false;
		rendBodyBack.enabled = false;
		rendBodyFront.enabled = false;
		yield return new WaitForSeconds (2);
		Debug.Log ("respawn");
		flag =1;
		Player.transform.position = Respawn.transform.position;
		rendHead.enabled = true;
		rendLance.enabled = true;
		rendBottom.enabled = true;
		rendBodyBack.enabled = true;
		rendBodyFront.enabled = true;
		}
}


