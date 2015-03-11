using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {
	
	private int _nextLvl = 1;
	private int _nextLvlTimer = 0;
	private Color _oldDarkColor;
	private LoadingScreen _loadingScreen;
	private SaveLoadDataSerialized _saveLoadData;

	private Image _darkness;

	void Awake()
	{
		_loadingScreen = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<LoadingScreen>();
		_saveLoadData = GameObject.FindGameObjectWithTag(Tags.SaveLoadObject).GetComponent<SaveLoadDataSerialized>();
	}
	void Start()
	{
		_darkness = GameObject.Find ("darkpanel").GetComponent<Image> ();
		_oldDarkColor = _darkness.color;
		_darkness.gameObject.SetActive(false);
		_nextLvl = PlayerPrefs.GetInt ("next_lvl", _nextLvl);

	}
	IEnumerator GoToNextLevel()
	{
		_nextLvlTimer = 0;
		_darkness.gameObject.SetActive(true);
		while(_nextLvlTimer < 225)
		{
			_darkness.color = Color.Lerp(_darkness.color, Color.black, Time.deltaTime * 4);
			_nextLvlTimer += 4;
			if(_nextLvlTimer > 223)
				_loadingScreen.LoadScreen();
			yield return new WaitForEndOfFrame();
		}
		_darkness.color = _oldDarkColor;
		_darkness.gameObject.SetActive(false);

		if(PlayerPrefs.GetInt("next_lvl") > Application.levelCount)
		{
			_saveLoadData.Save(SavePaths.currentPath);
			PlayerPrefs.SetInt("next_lvl", 0);
			_nextLvl = PlayerPrefs.GetInt("next_lvl");
			Application.LoadLevel(_nextLvl);
		}
		else
		{
			Application.LoadLevel(_nextLvl);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			StartCoroutine(GoToNextLevel());
			PlayerPrefs.SetInt("next_lvl", Application.loadedLevel + 1);
			_nextLvl = PlayerPrefs.GetInt("next_lvl");
		}
	}
}
