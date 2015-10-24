using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;

	Text text;

	void Start(){
		text = GetComponent<Text>();

		score = 0;
	}

	void Update(){
		if (score < 0){
			score = 0;
		}

		text.text = "" + score;
	}

	public static void UpScore(int pointsToAdd){
		score += pointsToAdd;
	}

	public static void Reset(){
		//call when game over happens
		score = 0;
	}

}
