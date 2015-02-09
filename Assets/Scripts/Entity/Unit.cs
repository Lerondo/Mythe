using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	protected bool _isGrounded = false;
	protected bool _attacking = false;
	protected bool _justAttacked = false;
	protected float _speed = 5f;
	protected float _currentAttackDmg;

	protected virtual void Start () {
		//start function
	}

	protected virtual void Update () {
		//update function
	}
	protected AnimationEvent Attack()
	{
		_attacking = true;
		_justAttacked = false;
		return null;
	}
	protected AnimationEvent StopAttack()
	{
		_attacking = false;
		return null;
	}
}
