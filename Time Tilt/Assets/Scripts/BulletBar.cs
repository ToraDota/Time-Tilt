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
	}
	
	// Update is called once per frame
	void Update () {
		if(player.gunNumber == 0 && bulletBarOn){
			bulletBar.gameObject.SetActive(false);
			bulletBarOn = false;
		}
		else if(player.gunNumber > 0 && bulletBarOn == false){
			bulletBar.gameObject.SetActive(true);
			bulletBarOn = true;
			maxBullets = player.bulletCounter;
		}
		else{
			bulletBar.maxValue = maxBullets;
			bulletBar.value = player.bulletCounter;
		}
	}
}
