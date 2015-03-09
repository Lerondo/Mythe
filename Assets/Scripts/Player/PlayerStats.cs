using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	private int _basicDamage;
	private int _basicDefence;
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
		_userInterface = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<UserInterface>();
	}
	void Start()
	{
		//TODO: get save updatestats.
	}
	public string username
	{
		get{
			return _username;
		}
		set{
			_username = value;
		}
	}
	public float experience
	{
		get{
			return _experience;
		}
		set{
			_experience = value;
		}
	}
	public float maxExperience
	{
		set{
			_maxExp = value;
		}
		get{
			return _maxExp;
		}
	}
	public int level
	{
		get{
			return _level;
		}
		set{
			_level = value;
		}
	}
	public int basicDamage
	{
		get{
			return _basicDamage;
		}
		set{
			_basicDamage = value;
		}
	}
	public int basicDefence
	{
		get{
			return _basicDefence;
		}
		set{
			_basicDefence = value;
		}
	}
	public int damage
	{
		get{
		return _damage;
		}
	}
	public void UpdateGold (int gold)
	{
		_goldValue += gold;
	}
	public int gold
	{
		get{
		return _goldValue;
		}
		set{
			_goldValue = value;
		}
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
