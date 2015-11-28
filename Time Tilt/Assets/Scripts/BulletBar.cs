using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletBar : MonoBehaviour {

	public Slider bulletBar;

	private PlayerController player;

	public int maxBullets;

	private int bullets;

	private bool bulletBarOn;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();

		bulletBar.gameObject.SetActive(true);
		bulletBar.value = 0;

		//bulletBarOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(player.gunNumber == 0){
			bulletBar.value = 0;
			//bulletBar.gameObject.SetActive(false);
			//bulletBarOn = false;
		}
		else if(player.gunNumber == 1){
			//bulletBar.gameObject.SetActive(true);
			bulletBar.maxValue = 5;
			bulletBar.value = player.bulletCounter;
		}
		else if(player.gunNumber == 2){
			bulletBar.gameObject.SetActive(true);
			bulletBar.maxValue = 10;
			bulletBar.value = player.bulletCounter;
		}
		else if(player.gunNumber == 3){
			bulletBar.gameObject.SetActive(true);
			bulletBar.maxValue = 3;
			bulletBar.value = player.bulletCounter;
		}
		else if(player.gunNumber == 4){
			bulletBar.gameObject.SetActive(true);
			bulletBar.maxValue = 1;
			bulletBar.value = player.bulletCounter;
		}
	}
}
