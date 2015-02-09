using UnityEngine;
using System.Collections;

public class Melee : Enemy {

	protected override void Start()
	{
		_range = 2f;
	}
	/// <summary>
	/// Raises the trigger stay event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay(Collider other)
	{
		if(_attacking && !_justAttacked)
		{
			if(other.transform.tag == "Player")
			{
				_justAttacked = true;				
				//TODO: give dmg
			}
		}
	}
}
