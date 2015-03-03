using UnityEngine;
using System.Collections;

public class WindController : MonoBehaviour {
	float factor = 5.0f;
	
	private float startTime;
	private Vector3 startPos;

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
		
			OnMouseDown();
		} else if(Input.GetMouseButtonUp(0))
		{
			OnMouseUp();
		}
	}
	void OnMouseDown() {
		//clear lijst
		startTime = Time.time;
		startPos = Input.mousePosition;
		//draw collider and get all rigidbodys in collider
		startPos.z = transform.position.z - Camera.main.transform.position.z;
		startPos = Camera.main.ScreenToWorldPoint(startPos);
		//set al rigidbodys in list
	}
	
	void OnMouseUp() {
		Vector3 endPos = Input.mousePosition;
		endPos.z = transform.position.z - Camera.main.transform.position.z;
		endPos = Camera.main.ScreenToWorldPoint(endPos);
		
		Vector3 force = endPos - startPos;
		force.z = force.magnitude;
		force /= (Time.time - startTime);

		//loop trough all rigidbodys
		rigidbody.AddForce(force * factor);
	}
}