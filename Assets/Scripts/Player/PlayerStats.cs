using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public int basicDamage;
	public int basicDefence;
	private int _level;
	private float _experience = 0;
	private float _maxExp = 125;
	private int _damage;
	private int _defence;
	private int _goldValue = 100;
	private UserInterface _userInterface;
	void Awake()
	{
		_userInterface = GameObject.FindGameObjectWithTag(TagManager.GameController).GetComponent<UserInterface>();
	}
	void Start()
	{
		//TODO: get save updatestats.
	}
	public int GetDamage()
	{
		return _damage;
	}
	public void UpdateGold (int gold)
	{
		_goldValue += gold;
	}
	public int GetGold()
	{
		return _goldValue;
	}
	public void UpdateExp(float exp)
	{
		_experience += exp;
		if(_experience >= _maxExp)
		{
			_experience -= _maxExp;
			_maxExp *= 1.75f;
			_level++;
			basicDamage += 5;
			basicDefence += 1;
			_damage += 5;
			_defence += 5;
			_userInterface.UpdateMaxValue(UserInterface.EXPERIENCEBAR, Mathf.FloorToInt(_maxExp));
		}
		_userInterface.UpdateBar(UserInterface.EXPERIENCEBAR, Mathf.FloorToInt(_experience));
	}
	public void UpdateDamage(int newDamage,int oldDamage)
	{
		_damage -= oldDamage;
		_damage += newDamage;
	}
	public void UpdateDefence(int newDefence,int oldDefence)
	{
		_defence -= oldDefence;
		_defence += newDefence;
	}
}
