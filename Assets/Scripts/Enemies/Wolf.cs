using UnityEngine;
using System.Collections;

public class Wolf : Melee {
	

	protected override void Start () 
	{
		base.Start();
		_range = 3f;
		_health = 100;
		_speed = 2.5f;
		_currentAttackDmg = 10;
	}
}
