using UnityEngine;
using System.Collections;

/*
 * Script to make a platform disappear after a delay when the player touches it
 * 
 * */

public class DisappearingPlatformScript : MonoBehaviour {

    //Check if the platform is disappearing
    private bool isDisappearing = false;

    //How long to wait until it disappears
    public float delay = 3;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (isDisappearing)
        {
            //Decrement the timer and destroy the platform when it reaches 0
            delay -= Time.fixedDeltaTime;
            if (delay <= 0)
            {
                Destroy(gameObject);
            }
        }
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //Check if the colliding object is the player and if it is, start the timer
        if (col.gameObject.tag == "Player")
        {
            if (!isDisappearing)
            {
                isDisappearing = true;
                

            }
        }
    }
}
