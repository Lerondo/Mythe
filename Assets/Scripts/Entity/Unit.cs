using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	protected bool _isGrounded = false;
	protected bool _attacking = false;
	protected bool _justAttacked = false;
	protected float _speed = 5f;
	protected float _currentAttackDmg;
	protected float _range;
	protected int _health;

	protected virtual void Start () {
		//start function
	}

	protected virtual void Update () {
		//update function
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
