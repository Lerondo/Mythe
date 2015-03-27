using UnityEngine;
using System.Collections;

public class Melee : Enemy 
{
	private HealthController _playerHealth;
	private Unit _playerUnit;
	protected AudioSource _audioSource;

	protected override void Start()
	{
		_enemyAnimator.SetBool ("Idle", true);
		_audioSource = GetComponent<AudioSource>();
		base.Start();
	}
	protected override AnimationEvent Attack()
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
					if(_playerHealth == null || _playerUnit == null)
					{
						_playerUnit = col.GetComponent<Unit>();
						_playerHealth = col.GetComponent<HealthController>();
					}
					bool isPlayerHit = _playerUnit.justHit;
					if(!isPlayerHit)
					{
						_justAttacked = true;				
						_playerHealth.DoDamage(_currentAttackDmg);
						_playerUnit.KnockBack(this.transform.position, 2f, 2f);
						_playerUnit.justHit = true;
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
	protected override AnimationEvent StopAttack()
	{
		_attacking = false;
		return null;
	}
}
