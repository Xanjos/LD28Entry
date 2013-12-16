using UnityEngine;
using System.Collections;

/*
 *Script for controlling a player object's movement 
 * 
 */
public class PlayerControl : MonoBehaviour {

    //Check if the player can jump
	public bool canJump=false;

    //How much the player can move forward and backward by
	public float xForce = 300f;

    //Maximum speed while player is moving
	public float maxSpeed = 3f;

    //How high should the player jumo
	public float jumpPower = 1000f;

    //Check if player has used their only jump
	private bool jumpedOnce =false;

    //Reference to a child gameobject that can be used to check if the player is on the ground
	private Transform groundCheck;

    //Check if the player is on the ground
	public bool isGrounded =false;

    //Check if the player has completed the level
	public bool won=false;

    //Check if the player has died
	public bool dead=false;

    //Jumping AudioClip
    public AudioClip jumpSound;
	
    
    void Awake()
	{
        //Get the child GroundCheck object from the player
		groundCheck=transform.FindChild("GroundCheck");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        //Perform a linecast to see if the player is grounded
		isGrounded = Physics2D.Linecast(transform.position,groundCheck.position,1 << LayerMask.NameToLayer("Ground"));

		//Check if the player has pressed the jump button and is on the ground and also not used up a jump
		if(Input.GetButtonDown("Jump") && isGrounded&&!jumpedOnce)
			canJump = true;
	
	}

	void FixedUpdate()
	{
        //Get the horizontal axis value
		float h = Input.GetAxis("Horizontal");

        //Check if the current speed is less than the maximum speed
        if (h * rigidbody2D.velocity.x < maxSpeed)
        {
            //Give the player a horizontal force based on the current axis value
            rigidbody2D.AddForce(Vector2.right * h * xForce);
        }

		//Check if the player's horizontal velocity is over the maximum and limit accordingly
        if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
        {
            rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
        }

        //Restrict player movement to within camera bounds
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);

		// If jump conditions are fulfilled
		if(canJump)
		{
            //Play the jumping audio clip
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            
			//Give the player an upwards force.
			rigidbody2D.AddForce(new Vector2(0f, jumpPower));
			
			//Set jump conditions to false
			canJump = false;

            //Player has now used up their one jump
			jumpedOnce=true;
		}
	}

	void OnDestroy()
	{
        //Check if the player is dead
		if(dead)
		{
            //Get the Scripts GameObject
            GameObject scriptsObject = GameObject.Find("Scripts");

            //Turn off the Restart Script
            scriptsObject.GetComponent<RestartScript>().enabled = false;

            //Check if the player has completed the level. If true, add the WinScript to Scripts;
            //Otherwise, add the LoseScript
			if(won)
			{
				scriptsObject.AddComponent<WinScript>();
			}
			else
			{
				scriptsObject.AddComponent<LoseScript>();

			}
		}
	}
}
