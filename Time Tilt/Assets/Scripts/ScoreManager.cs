using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;

	public static bool scoreWentUp;
	public static bool canCheckAgain;

	private int newRem;
	private int oldRem;

	public int modulusAmt;

	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;

	public GameObject gun1;
	public GameObject gun2;
	public GameObject gun3;
	public GameObject gun4;
	public GameObject lifePickup;

	private Transform dropPoint;

	Text text;

	void Start(){
		text = GetComponent<Text>();

		scoreWentUp = false;
		canCheckAgain = false;
		oldRem = 10000;

		//score = 0;
		score = PlayerPrefs.GetInt("CurrentScore");
	}

	void Update(){

		text.text = "" + score;

		if(score % modulusAmt == 0 && scoreWentUp == true){
			SpawnRandomItem();
			scoreWentUp = false;
		}
		else if(score > modulusAmt && scoreWentUp == true){
			newRem = score%modulusAmt; // gets the remainder of the current score with 10000 divided into it
				if(newRem < oldRem){
				SpawnRandomItem();
				}
			oldRem = newRem;
			scoreWentUp = false;
		}
	}

	public void SpawnRandomItem(){
		var chanceDrop = Random.Range (1, 101); //100 values 1-100
		var chanceLoc = Random.Range(1,4); //3 values, 3 locations
		if(chanceLoc == 1){
			dropPoint = spawn1.transform;
		}
		else if(chanceLoc == 2){
			dropPoint = spawn2.transform;
		}
		else if(chanceLoc == 3){
			dropPoint = spawn3.transform;
		}

		if(chanceDrop > 0 && chanceDrop <= 25){
			Instantiate(gun1, dropPoint.position, dropPoint.rotation);
		}
		else if(chanceDrop > 25 && chanceDrop <= 50){
			Instantiate(gun2, dropPoint.position, dropPoint.rotation);
		}
		else if(chanceDrop > 50 && chanceDrop <= 75){
			Instantiate(gun3, dropPoint.position, dropPoint.rotation);
		}
		else if(chanceDrop > 75 && chanceDrop <= 95){
			Instantiate(gun4, dropPoint.position, dropPoint.rotation);
		}
		else if(chanceDrop > 95 && chanceDrop <= 100){
			Instantiate(gun3, dropPoint.position, dropPoint.rotation);
		}

	}

	public static void UpScore(int pointsToAdd){
		score += pointsToAdd;
		PlayerPrefs.SetInt("CurrentScore", score);
		scoreWentUp = true;
		canCheckAgain = true;
	}

	public static void Reset(){
		//call when game over happens
		score = PlayerPrefs.GetInt ("CurrentScore", 0);
	}

}
