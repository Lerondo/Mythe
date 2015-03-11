using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class FingerIndexChecker : MonoBehaviour, IPointerDownHandler {
	public JoySticksController joySticksController;
	public void OnPointerDown(PointerEventData data) 
	{
		if(joySticksController.GetFingerIndex() == -1)
		{
			foreach(Touch touch in Input.touches)
			{
				if(touch.phase == TouchPhase.Began)
				{
					joySticksController.SetFingerIndex(touch.fingerId);
				}
			}
		}
	}
}
