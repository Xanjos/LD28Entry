using UnityEngine;
using System.Collections;

/*
 * Script for turning a platform invisible (its collider will still be there though)
 * 
 * */
public class InvisiblePlatformScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Hide the gameobject's sprite
		transform.GetComponent<SpriteRenderer>().enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
