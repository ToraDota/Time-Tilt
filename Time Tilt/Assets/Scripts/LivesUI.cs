using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

	private int livesCount;
	
	Text text;
	
	void Start(){
		text = GetComponent<Text>();
		
		//livesCount = PlayerHealthManager.playerLives;
		livesCount = PlayerPrefs.GetInt("Player1Lives");
	}
	
	void Update(){
		
		livesCount = PlayerPrefs.GetInt("Player1Lives");
		
		text.text = "" + livesCount;
	}
	
	public void ResetLivesCounter(){ //might be useless if the player just gets kicked back to the main menu 
		//call when game over happens
		livesCount = PlayerPrefs.GetInt("Player1Lives");
	}
}
