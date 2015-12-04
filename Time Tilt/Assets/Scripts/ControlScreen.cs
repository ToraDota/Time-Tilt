using UnityEngine;
using System.Collections;

public class ControlScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.O) 
		   || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.F) 
		   || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H)){
			Application.LoadLevel("Past");
		}
	}
}
