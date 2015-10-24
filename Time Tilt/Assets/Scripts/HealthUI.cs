using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	private int healthCount;
	
	Text text;
	
	void Start(){
		text = GetComponent<Text>();
		
		healthCount = PlayerHealthManager.playerHealth;
	}
	
	void Update(){
		if (healthCount < 0){
			healthCount = 0;
		}

		healthCount = PlayerHealthManager.playerHealth;

		text.text = "" + healthCount;
	}
	
	public void ResetHealthCounter(){
		//call when game over happens
		healthCount = PlayerHealthManager.playerHealth;
	}
}
