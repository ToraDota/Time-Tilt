using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public Button startText;
    public Button exitText;


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
