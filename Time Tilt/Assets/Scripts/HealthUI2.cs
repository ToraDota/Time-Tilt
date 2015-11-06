using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthUI2 : MonoBehaviour {

	private int healthCount;
	
	private int maxHealth;
	
	public Slider healthBar2;
	
	private PlayerTwoHealthManager healthManager;
	
	//Text text;
	
	void Start(){
		//text = GetComponent<Text>();
		healthManager = FindObjectOfType<PlayerTwoHealthManager>();
		
		healthBar2 = GetComponent<Slider>();
		
		
		healthCount = PlayerTwoHealthManager.player2Health;
		
		maxHealth = healthManager.maxPlayerHealth;
		
		healthBar2.maxValue = maxHealth;
	}
	
	void Update(){
		if (healthCount < 0){
			healthCount = 0;
		}
		
		healthCount = PlayerTwoHealthManager.player2Health;
		
		healthBar2.value = healthCount;
		
		//text.text = "" + healthCount;
	}
	
	public void ResetHealthCounter(){
		//call when game over happens
		healthCount = PlayerTwoHealthManager.player2Health;
	}
}
