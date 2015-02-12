using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	[SerializeField]private int buttonWidth = 200;
	[SerializeField]private int buttonHeight = 50;
	[SerializeField]private int groupWidth = 200;
	[SerializeField]private int groupHeight = 170;
	bool paused = false;

	void Start()
	{
		Time.timeScale = 1;
	}

	void OnGUI()
	{
		if(paused)
		{
			GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)),((Screen.height/2) - (groupHeight/2)), groupWidth, groupHeight));
			if (GUI.Button(new Rect(0,0,buttonWidth, buttonHeight), "Main Menu"))
		    	Debug.Log("Main Menu");
			if (GUI.Button(new Rect(0,60, buttonWidth, buttonHeight), "Restart Level"))
		        Debug.Log("Restart Level");
			if (GUI.Button(new Rect(0,120, buttonWidth, buttonHeight), "Quit Game"))
	       		Debug.Log("Quit Game");
			    GUI.EndGroup();
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
			paused = togglePause();
	}

	bool togglePause()
	{
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			return(false);
		}
		else
		{
			Time.timeScale = 0;
			return(true);
		}
	}
}