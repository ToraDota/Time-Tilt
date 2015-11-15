using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public Button startText;
    public Button exitText;

	public int player1Lives;
	public int player2Lives;
	public int currentScore;

	// Use this for initialization
	void Start () {
	
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();

	}

    public void ExitPress()
    {
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        Application.LoadLevel("prototype");

		//sets each characters lives value to an initial amount and creates the pref to carry over between loads.
		//players share a score counter.
		PlayerPrefs.SetInt ("Player1Lives", player1Lives);
		PlayerPrefs.SetInt ("Player2Lives", player2Lives);
		PlayerPrefs.SetInt("CurrentScore", currentScore);
		PlayerPrefs.SetInt("PlayerTwoHasSpawned", 0); //player two has not spawned. 0 = not spawned, 1 = has spawned.
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.U)|| Input.GetKeyDown(KeyCode.Alpha1)){
			StartLevel();
		}

		if(Input.GetKeyDown (KeyCode.Escape)){
			ExitGame ();
		}
	}
}
