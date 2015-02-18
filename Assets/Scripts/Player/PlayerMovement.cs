using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Collider myCollider;
	
	private Animator _playerAnimator;
	private float _speed = 3f;
	private float _climbSpeed = 3f;
	private bool _isGrounded = false;
	private bool _isTryingToClimb = false;
	private bool _isClimbing = false;
	private bool _isMoving = false;
	private bool _isFalling = false;
	private bool _justJumped = false;
	private bool _death = false;
	private float _jumpHeight = 25f;
	private GameObject _currentFloor;
	void Awake()
	{
		_playerAnimator = GetComponent<Animator>();
	}
	public bool GetJustJumped()
	{
		return _justJumped;
	}
	public void SetIsGrounded(bool grounded)
	{
		_isGrounded = grounded;
	}
	public void SetCurrentFloor(GameObject floor)
	{
		_currentFloor = floor;
	}
	public bool GetIsMoving()
	{
		return _isMoving;
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
			if(_speed <= 7.4f)
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
	/// Falls down.
	/// </summary>
	public void FallDown()
	{
		Physics.IgnoreCollision(_currentFloor.collider, myCollider, true);
		_isGrounded = false;
		_isFalling = true;
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
	public void StartClimbing(float z)
	{
		_isClimbing = true;
		_playerAnimator.SetBool("Climbing",true);
		rigidbody.useGravity = false;
		rigidbody.velocity = new Vector3(0,0,0);
		Vector3 newPos = this.transform.position;
		newPos.z = z - 0.1f;
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
		Vector3 newPos = this.transform.position;
		newPos.z = 0f;
		this.transform.position = newPos;
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
				if(_currentFloor == null || col.gameObject != _currentFloor)
				{
					_isFalling = false;
					_currentFloor = col.gameObject;
					Physics.IgnoreCollision(col,myCollider,false);
				}
				if(!_isFalling)
				{
					if(!_justJumped && !_isGrounded)
					{
						_playerAnimator.SetTrigger("Idle");
					}
					_isGrounded = true;
				}
				break;
			} else {
				_isGrounded = false;
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
				Physics.IgnoreCollision(myCollider,other.collider,true);
			} else {
				Physics.IgnoreCollision(myCollider,other.collider,false);
			}
		}
	}
}
