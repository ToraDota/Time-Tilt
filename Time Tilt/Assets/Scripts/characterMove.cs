using UnityEngine;
using System.Collections;

public class characterMove : MonoBehaviour {
    public GameObject target;
    public float Speed = 1f;
    public float still = 0f;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey (KeyCode.A)) {
			//look left 
			transform.right = new Vector3 (-1, 0, 0);
			//move left
			transform.Translate (Vector3.right * Speed);
		} else if (Input.GetKey (KeyCode.D)) {
			//move right
			transform.Translate (Vector3.right * Speed);
			//look right
			transform.right = new Vector3(1,0,0);
		} else
            transform.Translate(Vector3.zero * still);

    }
	
}
