using UnityEngine;
using System.Collections;

public class FinishMenu : MonoBehaviour {

	public string mainMenu;
	
	public void MainMenu(){
		Application.LoadLevel(mainMenu);
	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.O) 
		   || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.F) 
		   || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H)){

			MainMenu ();

		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Quit ();
		}

	}
	
	public void Quit(){
		Application.Quit();
	}
}
