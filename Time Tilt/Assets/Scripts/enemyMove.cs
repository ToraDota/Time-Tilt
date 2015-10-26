using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour
{
    public int i;
    public float flapforce= 1f;
    public ForceMode2D forceMode = ForceMode2D.Impulse;
    private float nextActionTime = 0.1f;
    public float period = .1f;
    public Transform target;
    public int rotationSpeed;
    public int maxdistance;
    private Transform myTransform;
    public static System.Random rnd = new System.Random ();
	public static int direction =  1;  //rnd.Next (0, 2);
	public float enemySpeed = 3f;


    void Awake()
    {
        myTransform = transform;
        if (direction == 0)
            transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
    }

    void Start()
    {

        maxdistance = 0;
    }


	// Update is called once per frame
	void Update ()
	{
        //Follow script
        if (Vector3.Distance(target.position, myTransform.position) > maxdistance)
        {
            // Get a direction vector from us to the target
            Vector3 dir = target.position - myTransform.position;

            // Normalize it so that it's a unit direction vector
            dir.Normalize();

            // Move ourselves in that direction
            myTransform.position += dir * enemySpeed * Time.deltaTime;
        }
        //tried to make a flap script, not sure what's actually wrong with it.
        if (Time.time >= nextActionTime)
        {
            nextActionTime = Time.time + period;
            for (i = 0; i < 10; i++)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapforce, forceMode);
            }
        }



        Physics2D.IgnoreLayerCollision(8,9);
	}

}