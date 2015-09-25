using UnityEngine;
using System.Collections;

public class Flap : MonoBehaviour {

    public string flapbutton = "Fire1";
    public float flapforce = 2.0f;
    public ForceMode2D forceMode = ForceMode2D.Impulse;
    private bool flap = false;

	// Use this for initialization
	void Start () {
	
	}
	void Update()
    {
        if(Input.GetButtonDown(flapbutton))
        {
            flap |= true;
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (flap)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * flapforce, forceMode);
            flap = false;
        }
	
	}
}
