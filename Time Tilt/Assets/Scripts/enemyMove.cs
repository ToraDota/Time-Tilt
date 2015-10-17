using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour
{

	public static System.Random rnd = new System.Random ();
	public static int direction = rnd.Next (0, 2);
	public float enemySpeed = 3f;

	// Use this for initialization
	void Start ()
	{
     
	}

	// Update is called once per frame
	void Update ()
	{
		if (direction == 0)
			transform.Translate (Vector3.left * enemySpeed * Time.deltaTime);
		else
			transform.Translate (Vector3.right * enemySpeed * Time.deltaTime);

		Physics2D.IgnoreLayerCollision(8,9);
	}

	//destroy
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.name == "Lance") {
			Destroy (gameObject);
		}
	}


}