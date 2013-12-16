using UnityEngine;
using System.Collections;

/*
 * Main Menu Script
 * 
 * */

public class MenuScript : MonoBehaviour {

    //GUISkin to use
    private GUISkin skin;

    const int buttonWidth = 500;
    const int buttonHeight = 60;

	// Use this for initialization
	void Start () {
        //Load GUISkin from Resources folder
        skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        //Get the GUISkin
        GUI.skin = skin;

        //Create a button
        if (
          GUI.Button(
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Start Game"
          )
        )
        {
            //Start the first level
            Application.LoadLevel("Level1");
        }
    }
}
