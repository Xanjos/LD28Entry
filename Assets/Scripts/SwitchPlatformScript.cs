using UnityEngine;
using System.Collections;

/**
 *Script for turning a platform into a trigger switch that reveals a hidden gameobject 
 * 
 */

public class SwitchPlatformScript : MonoBehaviour {

    //The platform below the attached object's trigger(usually the child SwitchPlatfrom)
    public GameObject platform;

    //The GameObject to hide
    public GameObject objectToHide;

    //Sprite to change child SwitchPlatform to when activated
    public Sprite onSprite;

    void Awake()
    {
        //Disable the hidden object's SpriteRender and BoxCollider
        objectToHide.GetComponent<SpriteRenderer>().enabled = false;
        objectToHide.GetComponent<BoxCollider2D>().enabled = false;
    }

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //Check if the object that entered the trigger is a box
        if (col.gameObject.tag == "Box")
        {
            platform.GetComponent<SpriteRenderer>().sprite = onSprite;

            //Renable the hidden object's SpriteRenderer and BoxCollider
            objectToHide.GetComponent<SpriteRenderer>().enabled = true;
            objectToHide.GetComponent<BoxCollider2D>().enabled = true;

        }
        
    } 
}
