using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsInterface : MonoBehaviour {

	public GameObject pauseInterface;
	public GameObject optionsInterface;
	public Slider volumeSlider;

	private static int _gameQuality;

	void Start()
	{
		_gameQuality = PlayerPrefs.GetInt ("game_Quality", _gameQuality);
		QualitySettings.SetQualityLevel(_gameQuality);
	}
	public void ReturnToPauseMenu()
	{
		pauseInterface.SetActive (true);
		optionsInterface.SetActive (false);
	}
	public void IncreaseQuality()
	{
		if (_gameQuality < 4)
			PlayerPrefs.SetInt("game_Quality", _gameQuality + 1);
		UpdatePrefs ();
	}
	public void DecreaseQuality()
	{
		if (_gameQuality > 1)
			PlayerPrefs.SetInt("game_Quality", _gameQuality - 1);
		UpdatePrefs ();
	}
	public void ChangeVolume()
	{
		AudioListener.volume = volumeSlider.value;
	}
	void UpdatePrefs()
	{
		_gameQuality = PlayerPrefs.GetInt ("game_Quality", _gameQuality);
		QualitySettings.SetQualityLevel (_gameQuality);
	}
}
