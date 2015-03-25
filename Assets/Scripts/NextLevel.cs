using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {
	
	public int nextLvl = 1;
	private int nextLvlTimer = 0;
	private Color _oldDarkColor;
	private LoadingScreen _loadingScreen;
	private SaveLoadDataSerialized _saveLoadData;
	private WWWScreenshot _wwwScreenShot;

	public Image fadeScreen;

	void Awake()
	{
		_loadingScreen = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<LoadingScreen>();
		_saveLoadData = GameObject.FindGameObjectWithTag(Tags.SaveLoadObject).GetComponent<SaveLoadDataSerialized>();
		_wwwScreenShot = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<WWWScreenshot>();
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
			_oldDarkColor = fadeScreen.color;
		fadeScreen.gameObject.SetActive(false);
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
			_saveLoadData.Save(SavePaths.currentPath);
			Application.LoadLevel(nextLvl);
		}
		else
		{
			_loadingScreen.loadingScreen.SetActive(false);
			fadeScreen.gameObject.SetActive(false);
			StartCoroutine(_wwwScreenShot.UploadPNG());
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			StartCoroutine(GoToNextLevel());
		}
	}
}
