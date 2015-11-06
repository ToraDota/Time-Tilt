using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	private int healthCount;

	private int maxHealth;

	public Slider healthBar;

	private PlayerHealthManager healthManager;
	
	//Text text;
	
	void Start(){
		//text = GetComponent<Text>();
		healthManager = FindObjectOfType<PlayerHealthManager>();

		healthBar = GetComponent<Slider>();
		

		healthCount = PlayerHealthManager.playerHealth;

		maxHealth = healthManager.maxPlayerHealth;

		healthBar.maxValue = maxHealth;
	}
	
	void Update(){
		if (healthCount < 0){
			healthCount = 0;
		}

		healthCount = PlayerHealthManager.playerHealth;

		healthBar.value = healthCount;

		//text.text = "" + healthCount;
	}
	
	public void ResetHealthCounter(){
		//call when game over happens
		healthCount = PlayerHealthManager.playerHealth;
	}
}
