using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	List<Rigidbody> rigidbodies = new List<Rigidbody>();


	void OnMouseDown() 
	{
		//clear list
		rigidbodies.Clear ();

		startTime = Time.time;
		startPos = Input.mousePosition;
		startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		startPos.z = transform.position.z - Camera.main.transform.position.z;

		//Draw collider & add rigidbodies inside the drawn collider to the list
		Vector3 spherePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		spherePos.z = 0;
		Collider[] touchedRigidbodies = Physics.OverlapSphere (spherePos, 0.5f);

		foreach(Collider col in touchedRigidbodies)
		{
			if(col.rigidbody)
			{
				rigidbodies.Add(col.rigidbody);
			}
		}
	
	void OnMouseUp() {
		Vector3 endPos = Input.mousePosition;
		endPos.y = transform.position.y - Camera.main.transform.position.y;
		endPos = Camera.main.ScreenToWorldPoint(endPos);

		Vector3 force = endPos - startPos;
		force.y = force.magnitude;
		force /= (Time.time - startTime);


		foreach(Rigidbody rbody in rigidbodies)
		{
			rbody.AddForce(force * factor);
		}
	}
}