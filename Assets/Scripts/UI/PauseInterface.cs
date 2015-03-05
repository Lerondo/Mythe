using UnityEngine;
using System.Collections;

public class PauseInterface : MonoBehaviour {

	public GameObject pauseInterface;
	public GameObject optionsInterface;
	public GameObject controllerMenu;

	private SaveLoadDataSerialized _saveLoadData;
	void Awake()
	{
		_saveLoadData = GameObject.FindGameObjectWithTag(TagManager.SaveLoadObject).GetComponent<SaveLoadDataSerialized>();
	}
	void Start()
	{
		pauseInterface.SetActive (false);
		optionsInterface.SetActive (false);
	}
	public void ReturnToGame()
	{
		_saveLoadData.Save(SavePaths.currentPath);
		pauseInterface.SetActive (false);
		controllerMenu.SetActive(true);
	}
	public void Options()
	{
		pauseInterface.SetActive (false);
		optionsInterface.SetActive (true);
	}
	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void MainMenu()
	{
		_saveLoadData.Save(SavePaths.currentPath);
		Time.timeScale = 1;
		Application.LoadLevel ("Menu");
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
}
