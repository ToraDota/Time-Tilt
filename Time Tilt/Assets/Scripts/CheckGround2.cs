using UnityEngine;
using System.Collections;

public class CheckGround2 : MonoBehaviour {

	private PlayerController2 player2;
	
	
	// Use this for initialization
	void Start () {
		player2 = FindObjectOfType<PlayerController2>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player2.grounded == true){
			//Debug.Log("ajslda;lkskd;la");
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Platform")
		{
			player2.grounded = true;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		
		if(other.tag == "Platform")
		{
			player2.grounded = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Platform")
		{
			player2.grounded = false;
		}
	}
}
