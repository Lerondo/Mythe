using UnityEngine;
using System.Collections;

public class JoySticksController : MonoBehaviour {
	public PlayerController playerController;
	public PlayerMovement playerMovement;
	public GameObject controllerMenu;
	public GameObject inventoryInterface;
	public GameObject shopInterface;
	//public GameObject followButton;
	private int _currentFingerId;
	public GameObject followButton;
	public RectTransform movementJoyStickTransform;
	private Vector2 _movementJoystickOriginalPos;


	void Start()
	{
		_currentFingerId = -1;
		//followButton.SetActive(false);
		_movementJoystickOriginalPos = movementJoyStickTransform.position;
		followButton.SetActive(false);
	}
	public void PressButton(int buttonID)
	{
		if(buttonID <= 6)
		{
			playerController.StartSkill(buttonID);
		} else if (buttonID == 7){
			GetComponent<Inventory>().ShowCurrentItems();
			inventoryInterface.SetActive(true);
			controllerMenu.SetActive(false);
		}else{
			shopInterface.SetActive(true);
			controllerMenu.SetActive(false);
		}
	}
	public void SetFingerIndex(int index)
	{
		_currentFingerId = index;
	}
	public int GetFingerIndex()
	{
		return _currentFingerId;
	}
	void Update()
	{
		if(Input.touches.Length > 0)
		{
			if(_currentFingerId != -1)
			{
				//followButton.SetActive(true);
				Vector2 buttonPos = Input.GetTouch(_currentFingerId).position;
				buttonPos.x = Mathf.Clamp(Input.GetTouch(_currentFingerId).position.x, movementJoyStickTransform.position.x-50,movementJoyStickTransform.position.x+50);
				buttonPos.y = Mathf.Clamp(Input.GetTouch(_currentFingerId).position.y, movementJoyStickTransform.position.y-50,movementJoyStickTransform.position.y+50);
				//followButton.GetComponent<RectTransform>().position = buttonPos;
				followButton.SetActive(true);

				//Vector2 buttonPos = Input.GetTouch(_currentFingerId).position;
				float distance = Vector2.Distance(buttonPos,movementJoyStickTransform.position);
				float range = 50;
				if (distance > range) 
				{
					Vector2 step = buttonPos - _movementJoystickOriginalPos;
					step.Normalize();
					step *= range;

					buttonPos = _movementJoystickOriginalPos + step;
				}
				followButton.GetComponent<RectTransform>().position = buttonPos;

				if(Input.GetTouch(_currentFingerId).position.x > movementJoyStickTransform.position.x+10 || Input.GetTouch(_currentFingerId).position.x < movementJoyStickTransform.position.x-10)
				{
					float xOffSet = Input.GetTouch(_currentFingerId).position.x - movementJoyStickTransform.position.x;
					bool isGoingRight = true;
					if(xOffSet < 0)
					{
						isGoingRight = false;
						xOffSet = -1f;
					}
					xOffSet = Mathf.Abs(xOffSet);
					if(xOffSet > 0)
					{
						xOffSet = 1f;
					}
					Vector3 movement = new Vector3(0,0,xOffSet);
					playerMovement.Move(movement, isGoingRight);
				} 
				else 
				{
					if(playerMovement.isMoving)
					{
						playerMovement.StoppedMoving();
					}
				}
				if(playerMovement.isClimbing)
				{
					float yOffSet = Input.GetTouch(_currentFingerId).position.y - movementJoyStickTransform.position.y;
					yOffSet *= 0.01f;
					Vector3 climbMovement = new Vector3(0,yOffSet,0);
					playerMovement.Climb(climbMovement);
					if(yOffSet >= 0.1f || yOffSet <= -0.1f)
					{
						playerMovement.SetPlayerAnimatorSpeed(2f);
					}  
					else 
					{
						playerMovement.SetPlayerAnimatorSpeed(0f);
					}
				}
				else if(Input.GetTouch(_currentFingerId).position.y > movementJoyStickTransform.position.y+50)
				{
					playerMovement.Jump();
				} else if (Input.GetTouch(_currentFingerId).position.y < movementJoyStickTransform.position.y-50)
				{
					playerMovement.isTryingToClimb = true;
				}
			}
		} else {
			_currentFingerId = -1;
			if(playerMovement.isMoving)
			{
				followButton.SetActive(false);
				playerMovement.StoppedMoving();
			} else if(playerMovement.isClimbing)
			{
				playerMovement.SetPlayerAnimatorSpeed(0f);
			}
		}
	}
}
