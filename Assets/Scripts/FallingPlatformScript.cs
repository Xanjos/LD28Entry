using UnityEngine;
using System.Collections;

/*
 * Script to make a platform drop down and fall after a delay when a player touches it
 * 
 * */

public class FallingPlatformScript : MonoBehaviour {

    //Check if the platform is falling
	private bool isFalling=false;

    //Check if the timer has started
    private bool started = false;

    //How long to delay the fall by
	public float delay=3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
            //Decrement the timer. When it reaches 0, make the platform fall
            delay -= Time.fixedDeltaTime;
            if (delay <= 0)
            {
                if (!isFalling)
                {
                    isFalling = true;

                    //Allow the platform's rigidbody to fall down with gravity
                    rigidbody2D.isKinematic = false;
                    rigidbody2D.gravityScale = 1f;
                }
            }
        }
	
	}

	void FixedUpdate()
	{
		if(isFalling)
		{
			//Check if the falling platform has reached a certain velocity

			if(rigidbody2D.velocity.y<-10)
			{
                //Stop any forces acting on the platform's rigidbody
				rigidbody2D.isKinematic=true;

                //Destroy the platform
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
        //Check if the colliding object is the player and if it is, start the timer
		if(col.gameObject.tag=="Player")
		{
            if (!started)
            {
                started = true;
            }
			
		}
	}
}
