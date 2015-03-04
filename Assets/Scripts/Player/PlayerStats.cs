using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public int basicDamage;
	public int basicDefence;
	private int _level;
	private string _username;
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
	public string GetUsername()
	{
		return _username;
	}
	public void SetUsername(string name)
	{
		_username = name;
	}
	public float GetExperience()
	{
		return _experience;
	}
	public void SetExperience(float exp)
	{
		_experience = exp;
	}
	public void SetMaxExperience(float exp)
	{
		_maxExp = exp;
	}
	public int GetLevel()
	{
		return _level;
	}
	public void SetLevel(int lvl)
	{
		_level = lvl;
	}
	public float GetMaxExperience()
	{
		return _maxExp;
	}
	public int GetBasicDamage()
	{
		return basicDamage;
	}
	public void SetBasicDamage(int dmg)
	{
		basicDamage = dmg;
	}
	public void SetBasicDefence(int def)
	{
		basicDefence = def;
	}
	public int GetBasicDefence()
	{
		return basicDefence;
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
	public void SetGold(int gold)
	{
		_goldValue = gold;
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
