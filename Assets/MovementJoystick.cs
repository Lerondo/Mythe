/*using UnityEngine;
using System.Collections;

public class MovementJoystick : MonoBehaviour {
	private int _currentFingerId;
	private RectTransform thisTransform;
	
	public PlayerController playerController;
	void Start()
	{
		thisTransform = this.GetComponent<RectTransform>();
		_currentFingerId = -1;
	}
	void Update()
	{
		if(Input.touches.Length > 0)
		{
			if(_currentFingerId == -1)
			{
				for(int i = 0;i < Input.touches.Length; i++)
				{
					Touch touch = Input.GetTouch(i);			
					if(thisTransform.rect.Contains(touch.position))
					{
						_currentFingerId = touch.fingerId;
					}
				}
			}
			else
			{
				if(Input.GetTouch(_currentFingerId).position.x > thisTransform.position.x || Input.GetTouch(_currentFingerId).position.x < thisTransform.position.x)
				{
					float xOffSet = Input.GetTouch(_currentFingerId).position.x - thisTransform.position.x;
					xOffSet *= 0.01f;
					if(xOffSet > 1)
					{
						xOffSet = 1;
					} else if(xOffSet < -1)
					{
						xOffSet = -1;
					}
					Vector3 movement = new Vector3(xOffSet,0,0);
					playerController.Move(movement);
				}
				if(Input.GetTouch(_currentFingerId).position.y > this.transform.position.y+20)
				{
					playerController.Jump();
				}
			}
		} else {
			_currentFingerId = -1;
		}
	}
}*/
