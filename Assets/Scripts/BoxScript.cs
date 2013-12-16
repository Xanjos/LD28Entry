using UnityEngine;
using System.Collections;

/*
 * Script for keeping a box within camera bounds
 * 
 * */

public class BoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
	
	}
}
