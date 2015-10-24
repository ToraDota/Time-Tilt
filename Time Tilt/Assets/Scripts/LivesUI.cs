using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

	private int livesCount;
	
	Text text;
	
	void Start(){
		text = GetComponent<Text>();
		
		livesCount = PlayerHealthManager.playerLives;
	}
	
	void Update(){
		
		livesCount = PlayerHealthManager.playerLives;
		
		text.text = "" + livesCount;
	}
	
	public void ResetLivesCounter(){
		//call when game over happens
		livesCount = PlayerHealthManager.playerLives;
	}
}
