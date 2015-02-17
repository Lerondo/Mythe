using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {
	
	private int _nextLvl = 1;

	private bool _startNextLvl = false;
	private int _nextLvlTimer = 0;

	private Image _darkness;
	private PlayerControllerA _playerController;

	void Start()
	{
		_playerController = GameObject.Find ("Player").GetComponent<PlayerControllerA> ();
		_darkness = GameObject.Find ("darkpanel").GetComponent<Image> ();

		_nextLvl = PlayerPrefs.GetInt ("next_lvl", _nextLvl);

	}

	void Update()
	{
		if (_startNextLvl == true)
		{
			_darkness.color = Color.Lerp(_darkness.color, Color.black, Time.deltaTime);
			_nextLvlTimer++;
		}

		if (_nextLvlTimer > 225)
		{
			if(PlayerPrefs.GetInt("next_lvl") >= 3)
			{
				PlayerPrefs.SetInt("next_lvl", 0);
				_nextLvl = PlayerPrefs.GetInt("next_lvl");
				Application.LoadLevel(_nextLvl);
			}
			else
				Application.LoadLevel(_nextLvl);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			_playerController.enabled = false;
			_startNextLvl = true;
			PlayerPrefs.SetInt("next_lvl", _nextLvl + 1);
			_nextLvl = PlayerPrefs.GetInt("next_lvl");
		}
	}
}
