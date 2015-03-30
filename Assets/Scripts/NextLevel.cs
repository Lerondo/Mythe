using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {
	
	public int nextLvl = 1;
	public int setPlayableLevel = 0;
	private int nextLvlTimer = 0;
	private Color _oldDarkColor;
	private LoadingScreen _loadingScreen;
	private SaveLoadDataSerialized _saveLoadData;
	private WWWScreenshot _wwwScreenShot;
	private PlayerStats _playerStats;

	public Image fadeScreen;

	void Awake()
	{
		_playerStats = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStats>();
		_loadingScreen = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<LoadingScreen>();
		_saveLoadData = GameObject.FindGameObjectWithTag(Tags.SaveLoadObject).GetComponent<SaveLoadDataSerialized>();
		_wwwScreenShot = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<WWWScreenshot>();
	}
	void Start()
	{
		_saveLoadData.StartCoroutine(_saveLoadData.LoadPlayerInfo(SavePaths.currentPath));
		_oldDarkColor = fadeScreen.color;
		fadeScreen.gameObject.SetActive(false);
		nextLvl = PlayerPrefs.GetInt ("next_lvl", nextLvl);
	}
	IEnumerator GoToNextLevel()
	{
		nextLvlTimer = 0;
		fadeScreen.gameObject.SetActive(true);
		while(nextLvlTimer < 225)
		{
			fadeScreen.color = Color.Lerp(fadeScreen.color, Color.black, Time.deltaTime * 4);
			nextLvlTimer += 4;
			if(nextLvlTimer > 223)
				_loadingScreen.LoadScreen();
			yield return new WaitForEndOfFrame();
		}
		fadeScreen.color = _oldDarkColor;
		fadeScreen.gameObject.SetActive(false);
		if(nextLvl != Application.levelCount)
		{
			if(setPlayableLevel > _playerStats.playableLevels)
				_playerStats.playableLevels = setPlayableLevel;
			_saveLoadData.Save(SavePaths.currentPath);
			Application.LoadLevel(nextLvl);
		}
		else
		{
			_saveLoadData.Save(SavePaths.currentPath);
			_loadingScreen.loadingScreen.SetActive(false);
			fadeScreen.gameObject.SetActive(false);
			StartCoroutine(_wwwScreenShot.UploadPNG());
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == Tags.Player)
		{
			StartCoroutine(GoToNextLevel());
		}
	}
}
