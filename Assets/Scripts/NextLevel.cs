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
