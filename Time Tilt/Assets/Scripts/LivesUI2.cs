﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesUI2 : MonoBehaviour {

	private int livesCount;
	
	Text text;
	
	void Start(){
		text = GetComponent<Text>();
		
		//livesCount = PlayerTwoHealthManager.player2Lives;
		livesCount = PlayerPrefs.GetInt("Player2Lives");
	}
	
	void Update(){
		
		livesCount = PlayerPrefs.GetInt("Player2Lives");
		
		text.text = "" + livesCount;
	}
	
	public void ResetLivesCounter(){
		//call when game over happens
		livesCount = PlayerPrefs.GetInt("Player2Lives");
	}
}
