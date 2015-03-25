using UnityEngine;
using System.Collections;

public class PlayBack : MonoBehaviour {

	public GameObject pauseInterface;
	
	void Update()
	{		
		if(Input.GetKeyDown(KeyCode.Escape))
			togglePause();
	}
	protected bool togglePause()
	{
		if (Time.timeScale == 0)
		{
			pauseInterface.SetActive(false);
			Time.timeScale = 1;
			return(false);
		}else{
			pauseInterface.SetActive(true);
			Time.timeScale = 0;
			return(true);
		}
	}
	public void PauseGame()
	{
		togglePause();
	}
}
