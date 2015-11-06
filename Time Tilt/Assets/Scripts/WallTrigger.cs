using UnityEngine;
using System.Collections;

public class WallTrigger : MonoBehaviour {

	public Transform leftSide;
	public Transform rightSide;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" || other.tag == "Enemy" || other.tag == "PickUp" || other.tag == "Bullet" || other.tag == "Player2"){
			if(tag == "RightWall")
			{
				other.gameObject.transform.position = new Vector3(leftSide.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
			}
			if(tag == "LeftWall")
			{
				other.gameObject.transform.position = new Vector3(rightSide.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
			}
		}
	}
}
