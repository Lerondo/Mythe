using UnityEngine;
using System.Collections;

public class Melee : Enemy {

	protected override void Start()
	{
		_range = 2f;
		_speed = 2.5f;
		_currentAttackDmg = 10;
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
				bool isPlayerHit = other.GetComponent<PlayerController>().GetJustHit();
				if(!isPlayerHit)
				{
					_justAttacked = true;				
					other.GetComponent<HealthController>().UpdateHealth(-_currentAttackDmg);
					other.GetComponent<Unit>().KnockBack(this.transform.position);
					other.GetComponent<PlayerController>().SetJustHit(true);
				}
			}
		}
	}
}
