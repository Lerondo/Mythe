using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject pauseInterface;
	private CameraControll _camControll;

	void Awake()
	{
		_camControll = GameObject.Find ("Main Camera").GetComponent<CameraControll> ();
	}
	void Update()
	{		
		if(Input.GetKeyDown(KeyCode.Escape))
			togglePause();
	}
	protected bool togglePause()
	{
		if (Time.timeScale == 0)
		{
			_camControll.StartCoroutine(_camControll.MoveAway());
			pauseInterface.SetActive(false);
			Time.timeScale = 1;
			return(false);
		}else{
			_camControll.StartCoroutine(_camControll.MoveCloser());
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
