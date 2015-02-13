using UnityEngine;
using System.Collections;

public class JoySticksController : MonoBehaviour {
	public PlayerController playerController;
	public GameObject controllerMenu;
	public GameObject inventoryInterface;
	private int _currentFingerId;
	public RectTransform movementJoyStickTransform;

	void Start()
	{
		_currentFingerId = -1;
	}
	public void PressButton(int buttonID)
	{
		if(buttonID <= 6)
		{
			playerController.StartAttack(buttonID);
		} else {
			inventoryInterface.SetActive(true);
			controllerMenu.SetActive(false);
		}
	}
	public void SetFingerIndex(int index)
	{
		Debug.Log(index);
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
				if(Input.GetTouch(_currentFingerId).position.x > movementJoyStickTransform.position.x+20 || Input.GetTouch(_currentFingerId).position.x < movementJoyStickTransform.position.x-20)
				{
					float xOffSet = Input.GetTouch(_currentFingerId).position.x - movementJoyStickTransform.position.x;
					bool isGoingRight = true;
					xOffSet *= 0.01f;
					if(xOffSet < 0)
					{
						isGoingRight = false;
					}
					xOffSet = Mathf.Abs(xOffSet);
					if(xOffSet > 1)
					{
						xOffSet = 1;
					}
					Vector3 movement = new Vector3(0,0,xOffSet);
					playerController.Move(movement, isGoingRight);
				} else {
					if(playerController.GetIsMoving())
					{
						playerController.StoppedMoving();
					}
				}
				if(playerController.GetIsClimbing())
				{
					float yOffSet = Input.GetTouch(_currentFingerId).position.y - movementJoyStickTransform.position.y;
					yOffSet *= 0.01f;
					Vector3 climbMovement = new Vector3(0,yOffSet,0);
					playerController.Climb(climbMovement);
				}
				else if(Input.GetTouch(_currentFingerId).position.y > movementJoyStickTransform.position.y+50)
				{
					playerController.Jump();
				} else if(Input.GetTouch(_currentFingerId).position.y < movementJoyStickTransform.position.y-50)
				{
					playerController.FallDown();
				}
			}
		} else {
			_currentFingerId = -1;
			if(playerController.GetIsMoving())
			{
				playerController.StoppedMoving();
			}
		}
	}
}
