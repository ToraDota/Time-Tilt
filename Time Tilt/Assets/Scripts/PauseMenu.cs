using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	// Update is called once per frame
	void Update () {
		if(isPaused){
			pauseMenuCanvas.SetActive(true); //if paused then the menu is active
			Time.timeScale = 0f;
			Cursor.visible = false; // change to true for pc builds and also disable it when leaving the menu.
		}
		else{
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.H)){
			isPaused = !isPaused;
		}

		if(isPaused == true){
			if(Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F)){
				Resume ();
			}

			if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.G)){
				MainMenu();
			}

//			if(Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.H)){
//				//Quit (); put back in for pc
//				Resume ();
//			}
		}
	}

	public void Resume(){
		isPaused = false;
	}

	public void MainMenu(){
		Application.LoadLevel(mainMenu);
	}

	public void Quit(){
		Application.Quit();
	}
}


