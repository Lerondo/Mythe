using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

	//Ingame bars
	public Slider healthBar;
	public Slider staminaBar;
	public Slider XPBar;

	//Links
	private PlayerControllerA _playerController;

	//Lvling Systems
	private bool lvlingup = false;
	private int lvluptimer = 0;
	public GUIStyle lvlupTexture;

	private float XoffSet = 0.42f;

	void Awake()
	{
		//PlayerScript linken
		_playerController = GameObject.Find ("Player").GetComponent<PlayerControllerA>();
	}

	void Update()
	{		
		//EXP Test
		if (Input.GetKeyDown (KeyCode.X))
			_playerController.experience += XPBar.maxValue /2;

		//Timed LvlUp visual
		if (lvlingup == true)
			lvluptimer ++;
		if (lvluptimer > 150)
		{
			lvlingup = false;
			lvluptimer = 0;
		}

		CheckBars ();
		//EXPBar Constant Check
		if (_playerController.experience >= XPBar.maxValue)
		{
			_playerController.experience -= XPBar.maxValue;
			Mathf.Floor(XPBar.maxValue = XPBar.maxValue * 1.5f);
			lvlUp();
		}
	}
	
	void CheckBars()
	{
		//Visual Bars constant checking
		staminaBar.value = _playerController._stamina;
		healthBar.value = _playerController._health;
		XPBar.value = _playerController.experience;
	}

	void lvlUp()
	{
		//Lvling up values
		_playerController._health += 20;
		healthBar.maxValue += 20;
		lvlingup = true;
	}

	void OnGUI()
	{
		if (lvlingup)
			GUI.Label(new Rect(Screen.width * XoffSet, 100 , 150, 150), "", lvlupTexture);
	}
}
