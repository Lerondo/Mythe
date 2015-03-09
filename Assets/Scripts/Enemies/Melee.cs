using UnityEngine;
using System.Collections;

public class Melee : Enemy {
	private HealthController _playerHealth;
	private Unit _playerUnit;
	private PlayerController _playerController;
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
		if(_attacking && !_justAttacked && other.transform.tag == Tags.Player)
		{
			if(_playerHealth == null || _playerUnit == null || _playerController == null)
			{
				_playerController = other.GetComponent<PlayerController>();
				_playerUnit = other.GetComponent<Unit>();
				_playerHealth = other.GetComponent<HealthController>();
			}
			bool isPlayerHit = _playerController.justHit;
			if(!isPlayerHit)
			{
				_justAttacked = true;				
				_playerHealth.UpdateHealth(-_currentAttackDmg);
				_playerUnit.KnockBack(this.transform.position, 2f, 2f);
				_playerController.justHit = true;
			}
		}
	}
}
