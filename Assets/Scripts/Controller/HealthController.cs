using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	private PlayerStats _playerStats;
	private UserInterface _userInterface;
	private Equipment _playerEquipment;
	private Unit _currentUnit;
	private int _health = 100;
	private int _maxHealth = 100;

	private int _mana = 100;
	private int _maxMana = 100;
	void Awake()
	{
		if(GetComponent<PlayerController>())
		{
			_userInterface = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<UserInterface>();
			_playerEquipment = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<Equipment>();
		}
		_currentUnit = GetComponent<Unit>();
		_playerStats = GameObject.FindGameObjectWithTag (Tags.Player).GetComponent<PlayerStats> ();
	}
	void Start()
	{
		if(GetComponent<Enemy>())
		{
			_health = GetComponent<Enemy>().health;
		}
	}
	public void ResetHealth()
	{
		_health = _maxHealth;
		UpdateInterfaceHealth();
	}
	public int health
	{
		get{
			return _health;
		}
		set{
			_health = value;
			if(_health > _maxHealth)
			{
				_health = _maxHealth;
			}
			UpdateInterfaceHealth();
		}
	}

	public int mana
	{
		get {
			return _mana;
			}
			set 
		{
			_mana = value;
			if (_mana > _maxMana) 
			{
				_mana = _maxMana;
			}
			UpdateUserInterfaceMana();
			}
	}

	public void UpdateMaxHealth(int health)
	{
		_maxHealth += health;
	}
	public void DoDamage(int dmg)
	{
		if(_currentUnit.name == "Player")
		{
			dmg -= _playerEquipment.GetDefence() + _playerStats.basicDefence;
		}
		if(dmg < 0)
		{
			dmg = 0;
		}
		_health -= dmg;
		UpdateInterfaceHealth();
		if(_health <= 0)
		{
			_currentUnit.SetDeath(true);
			Die();
		}
	}
	/*
	public void UpdateHealth(int health)
	{
		_health += health;
		UpdateInterface();
	}  */
	private void UpdateInterfaceHealth()
	{
		if(_userInterface != null)
		{
			_userInterface.UpdateBar(UserInterface.HEALTHBAR, _health);
		}
	}

	private void UpdateUserInterfaceMana()
	{
			if (_userInterface != null) 
			{
			_userInterface.UpdateBar(UserInterface.MANABAR, _mana);
			}
	}
	private void Die()
	{
		if(GetComponent<PlayerController>())
		{
			GetComponent<PlayerController>().OnDeath();
		} else {
			Destroy(gameObject);
			//TODO: death animation + drop gold
			_playerStats.UpdateGold(Mathf.FloorToInt(_maxHealth / 10));
			float currentExp = GetComponent<Enemy>().GetExp();
			GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStats>().UpdateExp(currentExp);
			GetComponent<DropController>().DropItem();
		}
	}
}

