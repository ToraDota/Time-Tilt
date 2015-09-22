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
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left*Speed);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Speed);
        else
            transform.Translate(Vector3.zero * still);

    }

}
