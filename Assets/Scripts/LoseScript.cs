using UnityEngine;
using System.Collections;

/**
 * Script that shows displays buttons to restart the level or return to the main menu
 * when the player fails the level
 * */

public class LoseScript : MonoBehaviour {

    //GUISkin to use
	private GUISkin skin;

    const int buttonWidth = 120;
    const int buttonHeight = 60;

	void Awake()
	{

	}

	// Use this for initialization
	void Start () {

		Debug.Log("Lost");

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
		
        //Draw a label
		GUI.Label(new Rect(10f, 10f, 100f, 50f), "Level Failed!!");

        //Create the retry button	
		if (
			GUI.Button(
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Retry!"
			)
			)
		{
			// Reload the level
			Application.LoadLevel(Application.loadedLevel);
		}

        //Create the main menu button
        if (
            GUI.Button(
            new Rect(
            Screen.width / 2 - (buttonWidth / 2),
            (2 * Screen.height / 3) - (buttonHeight / 2),
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
