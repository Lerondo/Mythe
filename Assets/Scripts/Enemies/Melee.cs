using UnityEngine;
using System.Collections;

public class Melee : Enemy 
{
	private HealthController _playerHealth;
	private Unit _playerUnit;
	private PlayerController _playerController;
	protected override void Start()
	{
		_range = 3f;
		_speed = 2.5f;
		_currentAttackDmg = 10;
		_enemyAnimator.SetBool ("Idle", true);
	}
	protected virtual AnimationEvent Attack()
	{
		_attacking = true;
		_justAttacked = false;
		Vector3 spherePosition = this.transform.position;
		spherePosition.x += 1;
		if(this.transform.localScale.x == -0.5f)
		{
			spherePosition.x -= 2;
		}
		Collider[] cols = Physics.OverlapSphere(spherePosition,2);
		foreach (var col in cols) 
		{
			if(col.tag == Tags.Player)
			{
				if(_attacking && !_justAttacked)
				{
					if(_playerHealth == null || _playerUnit == null || _playerController == null)
					{
						_playerController = col.GetComponent<PlayerController>();
						_playerUnit = col.GetComponent<Unit>();
						_playerHealth = col.GetComponent<HealthController>();
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
				break;
			}
		}
		return null;
	}
	/// <summary>
	/// Stops the attack via AnimationEvent.
	/// </summary>
	/// <returns>nothing.</returns>
	protected virtual AnimationEvent StopAttack()
	{
		_attacking = false;
		return null;
	}
}
