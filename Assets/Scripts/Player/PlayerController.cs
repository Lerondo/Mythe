using UnityEngine;
using System.Collections;

public class PlayerController : Unit {
	public int[] allDamages = new int[5];
	public int[] allCooldowns = new int[5];
	
	private bool _isTryingToClimb = false;
	private bool _isMoving = false;
	private bool _isClimbing = false;
	private float _jumpHeight = 10f;
	private GameObject currentFloor;

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
		if(!_isClimbing)
		{
			if(_speed <= 4.9f)
			{
				_speed += 0.01f;
			}
			movement *= _speed * Time.deltaTime;
			transform.Translate(movement);
		}
	}
	public void SetIsMoving(bool moving)
	{
		if(moving == false)
		{
			_speed = 3f;
		}
	}
	public void FallDown()
	{
		Physics.IgnoreCollision(currentFloor.collider, collider, true);
		_isGrounded = false;
	}

	/// <summary>
	/// Jump.
	/// </summary>
	/// <param name="climbMovement">Climb movement.</param>
	public void Jump()
	{
		if(_isGrounded)
		{
			Vector3 jumpForce = rigidbody.velocity;
			jumpForce.y = Mathf.Sqrt( 2f * _jumpHeight);
			rigidbody.velocity = jumpForce; 
		} 
		else if(!_isTryingToClimb) 
		{
			_isTryingToClimb = true;
		}
	}
	public void Climb(Vector3 climbMovement)
	{
		climbMovement *= _speed * Time.deltaTime;
		transform.Translate(climbMovement);
	}
	public bool GetIsClimbing()
	{
		return _isClimbing;
	}
	public void StartClimbing()
	{
		_isClimbing = true;
		rigidbody.useGravity = false;
		rigidbody.velocity = new Vector3(0,0,0);
		Vector3 newPos = this.transform.position;
		newPos.z = -1f;
		this.transform.position = newPos;
	}
	public void StopClimbing()
	{
		_isClimbing = false;
		rigidbody.useGravity = true;
		Vector3 newPos = this.transform.position;
		newPos.z = 0f;
		this.transform.position = newPos;
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

	void OnTriggerExit(Collider other)
	{
		if(other.transform.tag == "Ladder")
		{
			StopClimbing();
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
			if(currentFloor == null)
			{
				currentFloor = other.gameObject;
			}
			else if(other.gameObject != currentFloor)
			{
				Physics.IgnoreCollision(currentFloor.collider, collider, false);
				currentFloor = other.gameObject;
			}
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
