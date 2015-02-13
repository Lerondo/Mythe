using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Unit : MonoBehaviour {
	protected bool _isGrounded = false;
	protected bool _attacking = false;
	protected bool _justAttacked = false;
	protected float _speed = 5f;
	protected int _currentAttackDmg;
	protected float _range;
	protected bool _death = false;
	protected int _health;

	protected virtual void Start () {
		//start function
	}

	protected virtual void Update () {
		//update function
	}
	public void SetDeath(bool death)
	{
		_death = death;
	}
	public void KnockBack(Vector3 position)
	{
		float side = this.transform.position.x - position.x;
		Vector3 knockback = this.rigidbody.velocity;
		if(side < 0)
		{
			knockback.x = -2;
			knockback.y = 2;
			this.rigidbody.velocity = knockback;
		} 
		else 
		{
			knockback.x = 2;
			knockback.y = 2;
			this.rigidbody.velocity = knockback;
		}
	}
	/// <summary>
	/// Attack via AnimationEvent.
	/// </summary>
	protected virtual AnimationEvent Attack()
	{
		_attacking = true;
		_justAttacked = false;
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
