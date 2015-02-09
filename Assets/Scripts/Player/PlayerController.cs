using UnityEngine;
using System.Collections;

public class PlayerController : Unit {
	public int[] allDamages = new int[5];

	private bool _isTryingToClimb = false;
	private bool _isClimbing = false;
	private float _jumpHeight = 10f;

	//ATTACKING
	public void Attack(int skillNumber)
	{
		Debug.Log("doing attack: " + skillNumber);
		_currentAttackDmg = allDamages[skillNumber];
		//TODO: check animation by skillnumber.
	}
	//MOVEMENT
	public void Move(Vector3 movement)
	{
		movement *= _speed * Time.deltaTime;
		transform.Translate(movement);
	}
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
	//COLLISION
	void OnTriggerStay(Collider other)
	{
		if(_attacking && !_justAttacked)
		{
			if(other.transform.tag == "Enemy")
			{
				_justAttacked = true;				
				//TODO: give dmg
			}
		}
	}
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
	void OnCollisionExit(Collision other)
	{
		if(other.transform.tag == "Floor")
		{
			_isGrounded = false;
		}
	}
}
