using UnityEngine;
using System.Collections;

public class CheckGround : MonoBehaviour {

	private PlayerController player;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
//		if(player.grounded == true){
//			Debug.Log("ajslda;lkskd;la");
//		}
	
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Platform")
		{
			player.grounded = true;
		}
	}

	void OnTriggerStay2D(Collider2D other){

		if(other.tag == "Platform")
		{
			player.grounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Platform")
		{
			player.grounded = false;
		}
	}

}
