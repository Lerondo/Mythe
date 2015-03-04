﻿using UnityEngine;
using System.Collections;

public class JoySticksController : MonoBehaviour {
	public PlayerController playerController;
	public PlayerMovement playerMovement;
	public GameObject controllerMenu;
	public GameObject inventoryInterface;
	public GameObject shopInterface;
	public GameObject followButton;
	public RectTransform movementJoyStickTransform;
	private int _currentFingerId;
	private Vector2 _movementJoystickOriginalPos;


	void Start()
	{
		_currentFingerId = -1;
		_movementJoystickOriginalPos = movementJoyStickTransform.position;
		followButton.SetActive(false);
	}
	public void PressButton(int buttonID)
	{
		if(buttonID <= 6)
		{
			playerController.StartSkill(buttonID);
		} else if (buttonID == 7){
			GetComponent<InventoryController>().ShowCurrentItems();
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
				followButton.SetActive(true);

				Vector2 buttonPos = Input.GetTouch(_currentFingerId).position;
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
					if(playerMovement.GetIsMoving())
					{
						playerMovement.StoppedMoving();
					}
				}
				if(playerMovement.GetIsClimbing())
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
					playerMovement.SetIsTryingToClimb(true);
				}
			}
		} else {
			_currentFingerId = -1;
			followButton.SetActive(false);
			if(playerMovement.GetIsMoving())
			{
				playerMovement.StoppedMoving();
			} else if(playerMovement.GetIsClimbing())
			{
				playerMovement.SetPlayerAnimatorSpeed(0f);
			}
		}
	}
}
