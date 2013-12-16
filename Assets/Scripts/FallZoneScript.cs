using UnityEngine;
using System.Collections;

/*
 * Script for destroying objects that fall in the attached gameobject's BoxCollider2D trigger
 * 
 * */
public class FallZoneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") //Check if the triggering object is a Player
        {
            //Get the PlayerControl script
            PlayerControl playerControl = col.gameObject.GetComponentInChildren<PlayerControl>();
            
            //Player is now dead
            playerControl.dead = true;

            //Disable Player's jump
            playerControl.canJump = false;
           
        }
        Destroy(col.gameObject); //Destroy the triggering object
    }
}
