using UnityEngine;
using System.Collections;

/*
 * Script to check if a player has collided with hazards such as spikes
 * 
 * */

public class PlayerHazardCheck : MonoBehaviour {

    //PlayerControl script
	private PlayerControl playerControl;

    //Sound to play when player is hit
    public AudioClip hurtClip;

	void Awake()
	{
        //Get the PlayerControl script
		playerControl = GetComponentInChildren<PlayerControl>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
        //Check if the player has collided with a hazard such as a spike
		if(col.gameObject.tag=="Hazard")
		{
			Debug.Log("HIT");

            //Play the hurt sound
            AudioSource.PlayClipAtPoint(hurtClip, transform.position);

            //Player is now dead
			playerControl.dead=true;

            //Disable Player's Jump
			playerControl.canJump=false;

            //Destroy the player
			Destroy(gameObject);
		}
	}
}
