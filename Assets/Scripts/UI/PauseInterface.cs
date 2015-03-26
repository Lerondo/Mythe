using UnityEngine;
using System.Collections;

public class PauseInterface : MonoBehaviour {

	public GameObject pauseInterface;
	public GameObject optionsInterface;
	public GameObject controllerMenu;
	private PlayBack _playBack;
	
	private SaveLoadDataSerialized _saveLoadData;
	void Awake()
	{
		_playBack = GameObject.FindGameObjectWithTag (Tags.GameController).GetComponent<PlayBack> ();
		_saveLoadData = GameObject.FindGameObjectWithTag(Tags.SaveLoadObject).GetComponent<SaveLoadDataSerialized>();
	}
	void Start()
	{
		pauseInterface.SetActive (false);
		optionsInterface.SetActive (false);
	}
	public void ReturnToGame()
	{
		//_saveLoadData.Save(SavePaths.currentPath);
		controllerMenu.SetActive(true);
		pauseInterface.SetActive (false);
		ChangeTimeScale ();
	}
	public void Options()
	{
		_playBack.canPause = false;
		pauseInterface.SetActive (false);
		optionsInterface.SetActive (true);
	}
	public void RestartLevel()
	{
		ChangeTimeScale ();
		Application.LoadLevel (Application.loadedLevel);
	}
	public void MainMenu()
	{
		_saveLoadData.Save(SavePaths.currentPath);
		ChangeTimeScale ();
		Application.LoadLevel ("Menu");
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
	private void ChangeTimeScale()
	{
		if(Time.timeScale == 1)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}
