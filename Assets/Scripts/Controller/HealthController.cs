﻿using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	private UserInterface _userInterface;
	private Unit _currentUnit;
	private int _health = 100;
	private int _maxHealth = 100;
	private float fadeSpeed = 5f;
	private Color _transparant;
	void Awake()
	{
		if(GetComponent<PlayerController>())
			_userInterface = GameObject.FindGameObjectWithTag("GameController").GetComponent<UserInterface>();
		_currentUnit = GetComponent<Unit>();
	}
	void Start()
	{
		_transparant = new Color(0,0,0,0);
	}
	public void ResetHealth()
	{
		_health = _maxHealth;
		UpdateInterface();
	}
	public int GetHealth()
	{
		return _health;
	}
	public void SetHealth(int health)
	{
		_health = health;
		UpdateInterface();
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
			Destroy(gameObject, 5f);
		}
	}
}
