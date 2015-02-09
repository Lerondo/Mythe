using UnityEngine;
using System.Collections;

public class PlayerController : Unit {
	public int[] allDamages = new int[5];
	public int[] allCooldowns = new int[5];

	private bool _isTryingToClimb = false;
	private bool _isClimbing = false;
	private float _jumpHeight = 10f;

	/// <summary>
	/// Attack with the specified skillNumber.
	/// </summary>
	/// <param name="skillNumber">Skill number.</param>
	public void Attack(int skillNumber)
	{
		Debug.Log("doing attack: " + skillNumber);
		_currentAttackDmg = allDamages[skillNumber];
		//TODO: check animation by skillnumber.
	}

	/// <summary>
	/// Move the specified movement.
	/// </summary>
	/// <param name="movement">Movement.</param>
	public void Move(Vector3 movement)
	{
		movement *= _speed * Time.deltaTime;
		transform.Translate(movement);
	}

	/// <summary>
	/// Jump.
	/// </summary>
	/// <param name="climbMovement">Climb movement.</param>
	public void Jump(Vector3 climbMovement)
	{
		if(_isGrounded)
		{
			Vector3 jumpForce = rigidbody.velocity;
			jumpForce.y = Mathf.Sqrt( 2f * _jumpHeight);
			rigidbody.velocity = jumpForce; 
		} else if(!_isTryingToClimb) {
			_isTryingToClimb = true;
		} else if(_isClimbing)
		{
			climbMovement *= _speed * Time.deltaTime;
			transform.Translate(climbMovement);
		}
	}
	void Climb()
	{
		_isClimbing = true;
		rigidbody.useGravity = false;
	}
	protected override void Update () 
	{
		if(_isClimbing)
		{
			Vector3 newPos = this.transform.position;
			newPos.z = 1f;
			this.transform.position = newPos;
		} else {
			Vector3 newPos = this.transform.position;
			newPos.z = 0f;
			this.transform.position = newPos;
		}
	}

	/// <summary>
	/// Raises the trigger stay event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay(Collider other)
	{
		if(_attacking && !_justAttacked)
		{
			if(!other.isTrigger)
			{
				if(other.transform.tag == "Enemy")
				{
					_justAttacked = true;	
					//TODO: give dmg
				}
			}
		}
	}

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "Floor")
		{
			_isGrounded = true;
			_isTryingToClimb = false;
		}
		if(!_isGrounded && _isTryingToClimb)
		{
			if(other.transform.tag == "Ladder")
				Climb();
		}
	}

	/// <summary>
	/// Raises the collision exit event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnCollisionExit(Collision other)
	{
		if(other.transform.tag == "Floor")
		{
			_isGrounded = false;
		}
	}
}
