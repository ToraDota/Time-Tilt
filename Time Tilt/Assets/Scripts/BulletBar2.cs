using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletBar2 : MonoBehaviour {

	public Slider bulletBar;
	
	private PlayerController2 player2;
	
	public int maxBullets;
	
	private int bullets;
	
	private bool bulletBarOn;
	
	// Use this for initialization
	void Start () {
		player2 = FindObjectOfType<PlayerController2>();
		
		bulletBar.gameObject.SetActive(true);
		bulletBar.value = 0;
		
		//bulletBarOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(player2.gunNumber == 0){
			bulletBar.value = 0;
			//bulletBar.gameObject.SetActive(false);
			//bulletBarOn = false;
		}
		else if(player2.gunNumber == 1){
			//bulletBar.gameObject.SetActive(true);
			bulletBar.maxValue = 5;
			bulletBar.value = player2.bulletCounter;
		}
		else if(player2.gunNumber == 2){
			bulletBar.gameObject.SetActive(true);
			bulletBar.maxValue = 10;
			bulletBar.value = player2.bulletCounter;
		}
	}
}
