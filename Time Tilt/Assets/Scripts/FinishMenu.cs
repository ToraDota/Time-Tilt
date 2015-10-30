using UnityEngine;
using System.Collections;

public class FinishMenu : MonoBehaviour {

	public string mainMenu;
	
	public void MainMenu(){
		Application.LoadLevel(mainMenu);
	}
	
	public void Quit(){
		Application.Quit();
	}
}
