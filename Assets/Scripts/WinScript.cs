using UnityEngine;
using System.Collections;

/**
 * Script that shows displays a button to go to the next level when the player completes the current level
 * or a button to return to the main menu if the player has completed the last level
 * 
 * */

public class WinScript : MonoBehaviour {
	
    //GUISkin to use
	private GUISkin skin;

    const int buttonWidth = 120;
    const int buttonHeight = 60;

	// Use this for initialization
	void Start () {
		Debug.Log("Win");
        
        //Load GUISkin from Resources
		skin = Resources.Load("GUISkin") as GUISkin;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
        //Get the GUISkin
		GUI.skin = skin;	

        //Check if the current level is not the last level
        if (Application.loadedLevel != Application.levelCount - 1)
        {
            //Draw the Level Complete label
            GUI.Label(new Rect(10f, 10f, 100f, 50f), "Level Complete!!");

            //Create the next level button
            if (
                GUI.Button(
                new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (1 * Screen.height / 3) - (buttonHeight / 2),
                buttonWidth,
                buttonHeight
                ),
                "Next"
                )
                )
            {
                //Load the next level
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
        else //Player completed the last level
        {
            //Draw a label
            GUI.Label(new Rect(10f, 10f, 100f, 50f), "All Levels Complete!!");

            //Create the main menu button
            if (
                GUI.Button(
                new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (1 * Screen.height / 3) - (buttonHeight / 2),
                buttonWidth,
                buttonHeight
                ),
                "Main Menu"
                )
                )
            {
                //Return to the main menu
                Application.LoadLevel("MainMenu");
            }
        }
	}
}
