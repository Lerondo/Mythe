using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public GameObject firstSkillButton;
	public GameObject secondSkillButton;
	public GameObject thirdSkillButton;
	public GameObject fourthSkillButton;

	private int _basicDamage = 10;
	private int _basicDefence = 0;
	private int _level = 1;
	private string _username = "";
	private float _experience = 0;
	private float _maxExp = 125;
	private int _mana = 100;
	private int _goldValue = 100;
	private int _playableLevels = 1;
	private float _timePlayed = 0;
	private bool _isRanked = false;
	private UserInterface _userInterface;
	void Awake()
	{
		_userInterface = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<UserInterface>();
	}
	void Start()
	{
		StartCoroutine(UpdatePlayingTime());
		CheckLevelSkills();
	}
	private IEnumerator UpdatePlayingTime()
	{
		_timePlayed += 1;
		mana += 1;
		yield return new WaitForSeconds(1);
	}
	public int playableLevels
	{
		set{
			_playableLevels = value;
		}
		get{
			return _playableLevels;
		}
	}
	public bool isRanked
	{
		get{
			return _isRanked;
		}
		set{
			_isRanked = value;
		}
	}
	public float timePlayed
	{
		get{
			return _timePlayed;
		}
		set{
			_timePlayed = value;
		}
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
			_userInterface.UpdateMaxValue(UserInterface.EXPERIENCEBAR, Mathf.FloorToInt(_maxExp));
			CheckLevelSkills();
		}
		_userInterface.UpdateBar(UserInterface.EXPERIENCEBAR, Mathf.FloorToInt(_experience));
	}
	public void CheckLevelSkills()
	{
		if(_level >= 2)
		{
			firstSkillButton.SetActive(true);
		} 
		if(_level >= 5)
		{
			secondSkillButton.SetActive(true);
		} 
		if(_level >= 7)
		{
			thirdSkillButton.SetActive(true);
		} 
		if(_level >= 10)
		{
			fourthSkillButton.SetActive(true);
		}
	}
	public int mana
	{
		get{
			return _mana;
		}
		set{
			if(mana < 100)
			{
				_mana = value;
				_userInterface.UpdateBar(UserInterface.STAMINABAR, _mana);
			}
		}
	}
}
