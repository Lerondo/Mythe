using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	private PlayerStats _playerStats;
	private UserInterface _userInterface;
	private Unit _currentUnit;
	private int _health = 100;
	private int _maxHealth = 100;
	void Awake()
	{
		if(GetComponent<PlayerController>())
			_userInterface = GameObject.FindGameObjectWithTag("GameController").GetComponent<UserInterface>();
		_currentUnit = GetComponent<Unit>();
	}
	void Start()
	{
		_playerStats = GameObject.FindGameObjectWithTag (Tags.Player).GetComponent<PlayerStats> ();
	}
	public void ResetHealth()
	{
		_health = _maxHealth;
		UpdateInterface();
	}
	public int health
	{
		get{
			return _health;
		}
		set{
			_health = value;
			UpdateInterface();
		}
	}
	public void UpdateMaxHealth(int health)
	{
		_maxHealth += health;
	}
	public void UpdateHealth(int health)
	{
		_health += health;
		UpdateInterface();
		if(_health <= 0)
		{
			_currentUnit.SetDeath(true);
			Die();
		}
	}
	private void UpdateInterface()
	{
		if(_userInterface != null)
		{
			_userInterface.UpdateBar(UserInterface.HEALTHBAR, _health);
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

