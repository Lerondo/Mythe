using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public GUIStyle lvlupTexture;

	private UserInterface _userInteface;
	private HealthController _healthController;

	private float _experience;
	private float _maxExp;
	private float _XoffSet = 0.42f;

	private bool _lvlingup = false;

	void Awake()
	{
		_userInteface = GetComponent<UserInterface>();
		_healthController = GetComponent<HealthController>();
	}
	public void UpdateExperience(float exp)
	{
		_experience += exp;
		if (_experience >= _maxExp)
		{
			_experience -= _maxExp;
			Mathf.Floor(_maxExp = _maxExp * 1.5f);
			levelUp();
		}
	}
	private void levelUp()
	{
		//Lvling up values
		_healthController.UpdateMaxHealth(20);
		_userInteface.UpdateMaxValue(UserInterface.HEALTHBAR, 20);
		_lvlingup = true;
		Invoke("StopGUI",1f);
	}
	private void StopGUI()
	{
		_lvlingup = false;
	}
	void OnGUI()
	{
		if (_lvlingup)
			GUI.Label(new Rect(Screen.width * _XoffSet, 100 , 150, 150), "", lvlupTexture);
	}
}
