using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Animator _playerAnimator;
	private float _speed = 3f;
	private float _climbSpeed = 5f;
	private bool _isGrounded = false;
	private bool _isTryingToClimb = false;
	private bool _isClimbing = false;
	private bool _isMoving = false;
	private bool _canMove = true;
	private bool _justJumped = false;
	private bool _death = false;
	private float _jumpHeight = 50f;
	void Awake()
	{
		_playerAnimator = GetComponent<Animator>();
	}
	public void SetIsTryingToClimb(bool tryingToClimb)
	{
		_isTryingToClimb = tryingToClimb;
	}
	public bool GetJustJumped()
	{
		return _justJumped;
	}
	public void SetIsGrounded(bool grounded)
	{
		_isGrounded = grounded;
	}
	public bool GetIsMoving()
	{
		return _isMoving;
	}
	void FixedUpdate()
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if(!Physics.Raycast(transform.position, fwd, 1) && !Physics.Raycast(transform.position - new Vector3(0,1f,0), fwd, 1) && !Physics.Raycast(transform.position + new Vector3(0,1.5f,0), fwd, 1))
		{
			_canMove = true;
		} else {
			_canMove = false;
		}
	}
	/// <summary>
	/// Move the specified movement.
	/// </summary>
	/// <param name="movement">Movement.</param>
	public void Move(Vector3 movement, bool isGoingRight)
	{
		if(!_isClimbing && _canMove)
		{
			_isTryingToClimb = false;
			if(_isGrounded)
				_playerAnimator.SetBool("Running", true);
			_isMoving = true;
			if(_speed <= 7.4f)
				_speed += 0.1f;
			movement *= _speed * Time.deltaTime;
			transform.Translate(movement);
			Vector3 newRot = this.transform.eulerAngles;
			newRot.y = 90f;
			if(!isGoingRight)
				newRot.y = 270f;
			transform.eulerAngles = newRot;
		}
	}
	/// <summary>
	/// Stoppeds the moving.
	/// </summary>
	public void StoppedMoving()
	{
		_speed = 5f;
		_playerAnimator.SetBool("Running", false);
		_isMoving = false;
	}
	/// <summary>
	/// Jump.
	/// </summary>
	/// <param name="climbMovement">Climb movement.</param>
	public void Jump()
	{
		if(_isGrounded)
		{
			_justJumped = true;
			_playerAnimator.StopPlayback();
			_playerAnimator.SetTrigger("Jump");
			Vector3 jumpForce = rigidbody.velocity;
			jumpForce.y = Mathf.Sqrt( 2f * _jumpHeight);
			rigidbody.velocity = jumpForce; 
			_isGrounded = false;
		} 
		else if(!_isTryingToClimb) 
		{
			_isTryingToClimb = true;
		}
	}
	public void SetPlayerAnimatorSpeed(float speed)
	{
		_playerAnimator.speed = speed;
	}
	/// <summary>
	/// Climb the specified climbMovement.
	/// </summary>
	/// <param name="climbMovement">Climb movement.</param>
	public void Climb(Vector3 climbMovement)
	{
		climbMovement *= _climbSpeed * Time.deltaTime;
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
	public void StartClimbing(Vector3 ladderPos)
	{
		_isClimbing = true;
		_playerAnimator.SetBool("Climbing",true);
		rigidbody.useGravity = false;
		rigidbody.velocity = new Vector3(0,0,0);
		Vector3 newRot = this.transform.eulerAngles;
		newRot.y = 0;
		this.transform.eulerAngles = newRot;
		Vector3 newPos = this.transform.position;
		newPos.x = ladderPos.x - 0.2f;
		newPos.z = ladderPos.z - 0.2f;
		this.transform.position = newPos;
	}
	/// <summary>
	/// Stops the climbing.
	/// </summary>
	public void StopClimbing()
	{
		_isClimbing = false;
		_playerAnimator.SetBool("Climbing",false);
		rigidbody.useGravity = true;
		Vector3 newRot = this.transform.eulerAngles;
		newRot.y = 90;
		this.transform.eulerAngles = newRot;
		Vector3 newPos = this.transform.position;
		newPos.z = 0f;
		this.transform.position = newPos;
		_playerAnimator.speed = 1f;
	}
	void Update()
	{
		_death = GetComponent<PlayerController>().GetIsDeath();
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
			if(!_isGrounded && !_justJumped && !_isClimbing)
			{
				_playerAnimator.Play("Jump", 0, 0.30f);
			}
		}
	}
	/// <summary>
	/// Checks the collision.
	/// </summary>
	void CheckCollision()
	{
		Vector3 spherePosition = this.transform.position;
		spherePosition.y -= 1.75f;
		Collider[] colliders = Physics.OverlapSphere (spherePosition,  0.1f);
		foreach(Collider col in colliders)
		{
			if(col.transform.tag == "Floor" && !col.isTrigger) 
			{
				if(!_justJumped && !_isGrounded)
				{
					_playerAnimator.SetTrigger("Idle");
				}
				_isGrounded = true;
				break;
			} else {
				_isGrounded = false;
			}
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.transform.tag == TagManager.Ladder && _isClimbing)
		{
			StopClimbing();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == TagManager.Ladder && _isTryingToClimb)
		{
			StartClimbing(other.transform.position);
		}
	}
}
