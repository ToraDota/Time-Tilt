using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;

	Text text;

	void Start(){
		text = GetComponent<Text>();

		//score = 0;
		score = PlayerPrefs.GetInt("CurrentScore");
	}

	void Update(){

		text.text = "" + score;
	}

	public static void UpScore(int pointsToAdd){
		score += pointsToAdd;
		PlayerPrefs.GetInt("CurrentScore", score);
	}

	public static void Reset(){
		//call when game over happens
		score = PlayerPrefs.GetInt ("CurrentScore", 0);
	}

}
