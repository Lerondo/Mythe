using UnityEngine;
using System.Collections;

public class PauseInterface : MonoBehaviour {

	public GameObject pauseInterface;
	public GameObject optionsInterface;
	public GameObject controllerMenu;
	
	void Start()
	{
		pauseInterface.SetActive (false);
		optionsInterface.SetActive (false);
	}
	public void ReturnToGame()
	{
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
		Application.LoadLevel ("Menu");
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
}
