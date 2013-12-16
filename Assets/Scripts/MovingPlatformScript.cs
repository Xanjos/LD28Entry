using UnityEngine;
using System.Collections;

/*
 * Script to make a platform move between 2 points
 * 
 * */

public class MovingPlatformScript : MonoBehaviour {

    //Original position of the platform
    private Vector2 originalPos;

    //Position to move to
    private Vector2 destinationPos;

    //Smoothing rate
    public float smooth;

    //Check if the platform is moving in reverse
    public bool reverse = false;

	// Use this for initialization
	void Start () {

        //Get the gameobject's starting position and assign that as the original position
        originalPos = transform.position;

        //Check the position of the child PlatformEndPoint GameObject and assign that as the destination position
        destinationPos = transform.FindChild("PlatformEndPoint").position;
	}
	
	// Update is called once per frame
	void Update () {

        //Transition the platform from either its current position to its destination or its current position to its
        //original position (when reverse is true)
        if (!reverse)
        {
            transform.position = Vector2.Lerp(transform.position, destinationPos, Time.deltaTime * smooth);
            if(Vector2.Distance(transform.position,destinationPos)<1)
            reverse = true;
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, originalPos, Time.deltaTime * smooth);
            if (Vector2.Distance(transform.position, originalPos) <1)
                reverse = false;
        }
	
	}

  
}
