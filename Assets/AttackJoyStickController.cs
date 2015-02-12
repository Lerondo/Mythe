/*using UnityEngine;
using System.Collections;

public class AttackJoyStickController : MonoBehaviour {
	public RectTransform[] attackButtonsTransform = new RectTransform[5];
	public PlayerController playerController;
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length != 0)
		{
			foreach(Touch touch in Input.touches)
			{
				for (int i = 0; i < attackButtonsTransform.Length; i++) 
				{
					if(attackButtonsTransform[i].rect.Contains(touch.position))
						playerController.Attack(i);
				}
			}
		}
	}
}*/ 
