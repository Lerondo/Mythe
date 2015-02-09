using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int[] allDamages = new int[5];

	private CharacterController _controller;
	private bool _isGrounded = false;
	private bool _attacking = false;
	private bool _defending = false;
	private float _currentAttackDmg;
	private float _speed = 5f;
	private float _jumpHeight = 10f;
	void Start () {
	}
	public void Attack(int skillNumber)
	{
		Debug.Log("doing attack: " + skillNumber);
		_attacking = true;
		_currentAttackDmg = allDamages[skillNumber];
		//TODO: check animation by skillnumber.
	}
	private void Defend()
	{
		_defending = true;
	}
	public void Move(Vector3 movement)
	{
		movement *= _speed * Time.deltaTime;
		transform.Translate(movement);
	}
	public void Jump()
	{
		if(_isGrounded)
		{
			Vector3 jumpForce = rigidbody.velocity;
			jumpForce.y = Mathf.Sqrt( 2f * _jumpHeight);
			rigidbody.velocity = jumpForce; 
		}
	}
	void OnTriggerStay(Collider other)
	{
		if(_attacking)
		{
			if(other.transform.tag == "Enemy")
			{
				_attacking = false;
				//TODO: give dmg
			}
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "Floor")
		{
			_isGrounded = true;
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
