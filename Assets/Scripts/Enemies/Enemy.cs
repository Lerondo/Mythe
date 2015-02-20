using UnityEngine;
using System.Collections;

public class Enemy : Unit {
	protected Transform _target;
	protected float _attackCooldown;
	protected float _exp = 50;
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other) 
	{
		if(!other.isTrigger)
		{
			if (other.tag == "Player") 
			{
				_target = other.transform;
			}
		}
	}

	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit(Collider other) 
	{
		if(!other.isTrigger)
		{
			if (other.tag == "Player") 
			{
				_target = null;
			}
		}
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	protected override void Update() 
	{
		if(!_death)
		{
			if (_target) 
			{
				if(IsSeeingPlayer())
				{
					MoveTowardsPlayer();
				}
			}
		}
	}

	/// <summary>
	/// Moves towards the player.
	/// </summary>
	private void MoveTowardsPlayer()
	{
		if (Vector3.Distance (this.transform.position, _target.position) < _range) 
		{
			//TODO: if animation not playing set animation + animation event attack
			if(_attackCooldown < Time.time)
			{
				Attack();
				_attackCooldown = Time.time + 2f;
			}
		} 
		else 
		{
			Vector3 movement = new Vector3(1,0,0);
			Vector3 scale = new Vector3(1,1,1);
			if(this.transform.position.x > _target.transform.position.x)
			{
				movement.x *= -1;
				scale.x *= -1;
			}
			movement *= _speed * Time.deltaTime;
			transform.localScale = scale;
			transform.position += movement;
		}
	}

	/// <summary>
	/// Determines whether this instance is seeing the player.
	/// </summary>
	/// <returns><c>true</c> if this instance is seeing player; otherwise, <c>false</c>.</returns>
	private bool IsSeeingPlayer()
	{
		Vector3 raycastDirection = _target.position - transform.position;
		Ray ray = new Ray(transform.position, raycastDirection);
		Debug.DrawRay(transform.position, raycastDirection);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 10f))
		{
			if(hit.transform.tag == "Player")
			{
				return true;
			}
		}
		return false;
	}
	public float GetExp()
	{
		return _exp;
	}
}
