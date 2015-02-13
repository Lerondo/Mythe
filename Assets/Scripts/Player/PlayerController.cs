using UnityEngine;
using System.Collections;

public class PlayerController : Unit {
	public int[] allDamages = new int[5];
	public int[] allCooldowns = new int[5];

	private Animator _playerAnimator;
	private bool _isTryingToClimb = false;
	private bool _isClimbing = false;
	private bool _isMoving = false;
	private bool _justJumped = false;
	private float _jumpHeight = 25f;
	private GameObject currentFloor;

	void Awake()
	{
		_playerAnimator = GetComponent<Animator>();
	}
	protected override void Start ()
	{
		_currentAttackDmg = 10;
	}
	protected override void Update()
	{
		if(!_death)
		{
			if(!_justJumped)
			{
				CheckCollision();
			} 
			else if(rigidbody.velocity.y <= -0.5f)
			{
				_justJumped = false;
			}
			if(!_isGrounded && !_justJumped)
			{
				_playerAnimator.Play("Jump", 0, 0.48f);
			}
		}
	}
	/// <summary>
	/// Checks the collision.
	/// </summary>
	void CheckCollision()
	{
		Vector3 spherePosition = this.transform.position;
		spherePosition.y -= 1.5f;
		Collider[] colliders = Physics.OverlapSphere (spherePosition,  0.1f);
		foreach(Collider col in colliders)
		{
			if(col.transform.tag == "Floor" && !col.isTrigger) 
			{
				if(currentFloor == null || col.gameObject != currentFloor)
				{
					currentFloor = col.gameObject;
					Physics.IgnoreCollision(col,this.collider,false);
				}
				_isGrounded = true;
				break;
			} else {
				_isGrounded = false;
			}
		}
	}

	/// <summary>
	/// Attack with the specified skillNumber.
	/// </summary>
	/// <param name="skillNumber">Skill number.</param>
	public void StartAttack(int skillNumber)
	{
		_currentAttackDmg = allDamages[skillNumber];
		_playerAnimator.SetTrigger("Attack");
	}

	/// <summary>
	/// Move the specified movement.
	/// </summary>
	/// <param name="movement">Movement.</param>
	public void Move(Vector3 movement, bool isGoingRight)
	{
		if(!_isClimbing)
		{
			if(_isGrounded)
				_playerAnimator.SetBool("Running", true);
			_isMoving = true;
			if(_speed <= 4.9f)
			{
				_speed += 0.01f;
			}
			movement *= _speed * Time.deltaTime;
			transform.Translate(movement);
			Vector3 newRot = this.transform.eulerAngles;
			newRot.y = 90f;
			if(!isGoingRight)
			{
				newRot.y = 270f;
			}
			transform.eulerAngles = newRot;
		}
	}
	public bool GetIsMoving()
	{
		return _isMoving;
	}
	/// <summary>
	/// Stoppeds the moving.
	/// </summary>
	public void StoppedMoving()
	{
		_speed = 3f;
		_playerAnimator.SetBool("Running", false);
		_isMoving = false;
	}
	/// <summary>
	/// Falls down.
	/// </summary>
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
			_playerAnimator.SetTrigger("Jump");
			Vector3 jumpForce = rigidbody.velocity;
			jumpForce.y = Mathf.Sqrt( 2f * _jumpHeight);
			rigidbody.velocity = jumpForce; 
			_isGrounded = false;
			_justJumped = true;
		} 
		else if(!_isTryingToClimb) 
		{
			_isTryingToClimb = true;
		}
	}
	/// <summary>
	/// Climb the specified climbMovement.
	/// </summary>
	/// <param name="climbMovement">Climb movement.</param>
	public void Climb(Vector3 climbMovement)
	{
		climbMovement *= _speed * Time.deltaTime;
		transform.Translate(climbMovement);
	}
	/// <summary>
	/// Gets the is climbing.
	/// </summary>
	/// <returns><c>true</c>, if is climbing was gotten, <c>false</c> otherwise.</returns>
	public bool GetIsClimbing()
	{
		return _isClimbing;
	}
	/// <summary>
	/// Starts the climbing.
	/// </summary>
	public void StartClimbing()
	{
		_isClimbing = true;
		rigidbody.useGravity = false;
		rigidbody.velocity = new Vector3(0,0,0);
		Vector3 newPos = this.transform.position;
		newPos.z = -2f;
		this.transform.position = newPos;
	}
	/// <summary>
	/// Stops the climbing.
	/// </summary>
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
					other.GetComponent<HealthController>().UpdateHealth(-_currentAttackDmg);
					other.GetComponent<Unit>().KnockBack(this.transform.position);
					TextMessenger txtMessenger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TextMessenger>();
					txtMessenger.MakeText(_currentAttackDmg.ToString(), this.transform.position + new Vector3(0,3,1), Color.red, 24, true);
				}
			}
		}
	}

	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name="other">Other.</param>
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
			if(!_isGrounded)
			{
				Physics.IgnoreCollision(this.collider,other.collider,true);
			} else {
				Physics.IgnoreCollision(this.collider,other.collider,false);
				_playerAnimator.Play("Jump", 0, 0.52f);
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
