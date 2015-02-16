using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeight = 290;
	private bool _paused = false;
	private bool _inOptions = false;

	private static int _gameQuality;
	private static float _gameVolume = 1.0f;

	[SerializeField]private GUIStyle _optionsStyle;

	void Start()
	{
		Time.timeScale = 1;
		QualitySettings.SetQualityLevel(_gameQuality);
	}

	void OnGUI()
	{
		if(_paused)
		{
			GUI.BeginGroup(new Rect(100 , 100 , groupWidth, groupHeight), _optionsStyle);
			if (GUI.Button(new Rect(0,0,buttonWidth, buttonHeight), "Return to Game"))
				_paused = togglePause();
			if (_inOptions == false)
			{
				if (GUI.Button(new Rect(0,60, buttonWidth, buttonHeight), "Options"))
				{
					_inOptions = true;
					groupWidth = 425;
				}
			}
			else if (_inOptions == true)
			{
				if (GUI.Button(new Rect(0,60, buttonWidth, buttonHeight), "Close Options"))
			 	{
					_inOptions = false;
					groupWidth = 200;
				}
			}
			if (GUI.Button(new Rect(0,120,buttonWidth, buttonHeight), "Main Menu"))
				Application.LoadLevel("Menu");
			if (GUI.Button(new Rect(0,180, buttonWidth, buttonHeight), "Restart Level"))
				Application.LoadLevel(Application.loadedLevel);
			if (GUI.Button(new Rect(0,240, buttonWidth, buttonHeight), "Quit Game"))
				Application.Quit();
			    GUI.EndGroup();

			if (_inOptions)
			{
				GUI.BeginGroup(new Rect(325 , 100 , groupWidth, groupHeight));
				if (GUI.Button(new Rect(0,0, buttonWidth, buttonHeight), "Increase Quality"))
				{
					if (_gameQuality < 5)
						PlayerPrefs.SetInt("game_Quality", _gameQuality + 1);
				}
				if (GUI.Button(new Rect(0,60, buttonWidth, buttonHeight), "Decrease Quality"))
				{
					if (_gameQuality > 0)
						PlayerPrefs.SetInt("game_Quality", _gameQuality - 1);
				}
				GUI.Label(new Rect(0,120, buttonWidth, buttonHeight), "Volume");
				
				_gameVolume = GUI.HorizontalSlider(new Rect(0, 180, buttonWidth, buttonHeight), _gameVolume, 0.0f, 1.0f);
				GUI.EndGroup();
			}
		}
	}

	void Update()
	{
		_gameQuality = PlayerPrefs.GetInt ("game_Quality", _gameQuality);
		QualitySettings.SetQualityLevel (_gameQuality);
		Debug.Log (_gameVolume.ToString("F1"));

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
			_paused = togglePause();

		AudioListener.volume = _gameVolume;
	}

	protected bool togglePause()
	{
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			_inOptions = false;
			return(false);
		}else{
			Time.timeScale = 0;
			return(true);
		}
	}
}