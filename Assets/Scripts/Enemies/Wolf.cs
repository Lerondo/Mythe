using UnityEngine;
using System.Collections;

public class Wolf : Melee {
	

	protected override void Start () 
	{
		_range = 3f;
		_health = 1;
		_speed = 2.5f;
		_currentAttackDmg = 10;
		base.Start();
	}
}
