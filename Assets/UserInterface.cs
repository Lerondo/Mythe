using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {
	
	public Slider healthBar;
	public Slider staminaBar;
	public Slider XPBar;

	private PlayerControllerA _playerController;

	void Update()
	{
		CheckBars ();
		//EXPBar Constant Check
		if (_playerController.experience >= XPBar.maxValue)
		{
			_playerController.experience -= XPBar.maxValue;
			Mathf.Floor(XPBar.maxValue = XPBar.maxValue * 1.8f);
		}
	}

	void CheckBars()
	{
		//Visual Bars constant checking
		staminaBar.value = _playerController._stamina;
		healthBar.value =_playerController._health;
		XPBar.value = _playerController.experience;
	}
}
