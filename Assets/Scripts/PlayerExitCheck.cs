using UnityEngine;
using System.Collections;

/*
 * Script to check if the player has reached the exit
 * 
 * */
public class PlayerExitCheck : MonoBehaviour {

    //PlayerControl script
	private PlayerControl playerControl;

    //Sound to play when the player reaches the exit
    public AudioClip winClip;

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

	void OnTriggerEnter2D(Collider2D col)
	{
        //Check if we have entered the Exit gameobject's trigger
		if(col.gameObject.tag=="Exit")
		{
			Debug.Log("WIN");

            //Play the win sound clip
            AudioSource.PlayClipAtPoint(winClip, transform.position);

            //Mark player as dead
			playerControl.dead=true;

            //Level is now complete
			playerControl.won=true;

            //Disable player's jump
			playerControl.canJump=false;

            //Destroy the player
			Destroy(gameObject);
		}
	}


}
