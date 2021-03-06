﻿using UnityEngine;
using System.Collections;

public class Archer : Enemy {
	private ObjectPool _objectPool;
	public Transform spawnPoint;
	// Use this for initialization
	void Awake()
	{
		_objectPool = GameObject.FindGameObjectWithTag("GameController").GetComponent<ObjectPool>();
	}
	protected override void Start () {
		_range = 10f;
		_currentAttackDmg = 5;
	}
	protected override AnimationEvent Attack ()
	{
		FireArrow();
		return null;
	}
	private void FireArrow()
	{
		GameObject newArrow = _objectPool.GetObjectForType("Arrow", false);
		newArrow.transform.position = spawnPoint.position;
		newArrow.transform.rotation = spawnPoint.rotation;
		Projectile arrowScript = newArrow.GetComponent<Projectile>();
		arrowScript.SetDamage(_currentAttackDmg);
	}
}
