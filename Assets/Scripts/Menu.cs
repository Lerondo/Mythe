using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour 
{
	private GameObject mainMenuPanel;
	private GameObject creditsPanel;
	private GameObject optionsPanel;

	private bool mainMenuPanelBool = true;
	private bool creditsPanelBool = false;
	private bool optionsPanelBool = false;

	void Awake()
	{
		mainMenuPanel 	= GameObject.Find ("MenuPanel");
		creditsPanel 	= GameObject.Find ("CreditsPanel");
		optionsPanel 	= GameObject.Find ("OptionsPanel");
	}

	void Start()
	{
		creditsPanel.SetActive (false);
		optionsPanel.SetActive (false);
	}
	
	//Play Button
	public void PlayButtonPressed ()
	{
		Debug.Log ("Startbutton clicked");
		GetComponent<LoadingScreen>().LoadScreen();
		Application.LoadLevel (1);
	}

	//Quit Button
	public void QuitButtonPressed ()
	{
		Debug.Log ("Quitbutton clicked");
		Application.Quit ();
	}

	//Options Button
	public void OptionsButtonPressed()
	{
		//Activates/Deactivates Panels
		mainMenuPanel.SetActive (false);
		creditsPanel.SetActive (false);
		optionsPanel.SetActive (true);

		optionsPanel.transform.position = new Vector2 (0, 0);

		mainMenuPanelBool = false;
		optionsPanelBool = true;
	}

	//Credits Button
	public void CreditsButtonPressed()
	{
		//Activates/Deactivates Panels
		mainMenuPanel.SetActive (false);
		creditsPanel.SetActive (true);
		optionsPanel.SetActive (false);

		creditsPanel.transform.position = new Vector2 (0, 0);
	}

	//Back button
	public void BackButtonPressed()
	{
		//Activates/Deactivates Panels
		mainMenuPanel.SetActive (true);
		creditsPanel.SetActive (false);
		optionsPanel.SetActive (false);

		if (creditsPanelBool == true) 
		{
			creditsPanel.transform.position = new Vector2 (100, 100);

		} else if (optionsPanelBool == true) 
		{
			optionsPanel.transform.position = new Vector2 (-100,-100);
		}
	}
}
