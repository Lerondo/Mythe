using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Menu : MonoBehaviour 
{
	public Text characterTextA;
	public Text characterTextB;
	public Text characterTextC;

	private GameObject _mainMenuPanel;
	private GameObject _creditsPanel;
	private GameObject _optionsPanel;
	private GameObject _characterPanel;

	private Dictionary<int, string> loadPath = new Dictionary<int, string>();
	private Dictionary<int, Text> characterTexts = new Dictionary<int, Text>();
	private SaveLoadDataSerialized _saveLoadData;

	private bool _mainMenuPanelBool = true;
	private bool _creditsPanelBool = false;
	private bool _optionsPanelBool = false;

	void Awake()
	{
		_saveLoadData = GameObject.FindGameObjectWithTag(TagManager.SaveLoadObject).GetComponent<SaveLoadDataSerialized>();
		_mainMenuPanel 	= GameObject.Find ("MenuPanel");
		_creditsPanel 	= GameObject.Find ("CreditsPanel");
		_optionsPanel 	= GameObject.Find ("OptionsPanel");
		_characterPanel  = GameObject.Find ("CharacterSelection");
	}

	void Start()
	{
		_creditsPanel.SetActive (false);
		_optionsPanel.SetActive (false);
		_characterPanel.SetActive (false);
		loadPath.Add(0,SavePaths.SavePathA);
		loadPath.Add(1,SavePaths.SavePathB);
		loadPath.Add(2,SavePaths.SavePathC);
		characterTexts.Add(0, characterTextA);
		characterTexts.Add(1, characterTextB);
		characterTexts.Add(2, characterTextC);
		for(int i = 0; i < 3; i++)
		{
			_saveLoadData.LoadCharacterPanel(loadPath[i], i);
		}
	}
	public void SetCharacterText(int id, string text)
	{
		characterTexts[id].text = text;
	}
	//Play Button
	public void PlayButtonPressed ()
	{
		Debug.Log ("Startbutton clicked");
		_characterPanel.SetActive (true);
		_mainMenuPanel.SetActive (false);
		/*
		GetComponent<LoadingScreen>().LoadScreen();
		Application.LoadLevel (1); */
	}
	public void DeleteCharacter(int charId)
	{
		_saveLoadData.DeleteSave(loadPath[charId]);
		SetCharacterText(charId, "New Character");
	}
	public void LoadCharacter(int charId)
	{
		_saveLoadData.StartCoroutine(_saveLoadData.Load(loadPath[charId]));
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
		_mainMenuPanel.SetActive (false);
		_creditsPanel.SetActive (false);
		_optionsPanel.SetActive (true);

		_optionsPanel.transform.position = new Vector2 (0, 0);

		_mainMenuPanelBool = false;
		_optionsPanelBool = true;
	}

	//Credits Button
	public void CreditsButtonPressed()
	{
		//Activates/Deactivates Panels
		_mainMenuPanel.SetActive (false);
		_creditsPanel.SetActive (true);
		_optionsPanel.SetActive (false);

		_creditsPanel.transform.position = new Vector2 (0, 0);
	}

	//Back button
	public void BackButtonPressed()
	{
		//Activates/Deactivates Panels
		_mainMenuPanel.SetActive (true);
		_creditsPanel.SetActive (false);
		_optionsPanel.SetActive (false);

		if (_creditsPanelBool == true) 
		{
			_creditsPanel.transform.position = new Vector2 (100, 100);

		} else if (_optionsPanelBool == true) 
		{
			_optionsPanel.transform.position = new Vector2 (-100,-100);
		}
	}
}
