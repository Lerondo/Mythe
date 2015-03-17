using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindController : MonoBehaviour 
{
	float factor = 5.0f;
	
	private float startTime;
	private Vector3 startPos;
	
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			MouseDown();
		} else if(Input.GetMouseButtonUp(0))
		{
			MouseUp();
		}
	}
	
	List<Rigidbody> rigidbodies = new List<Rigidbody>();
	
	
	void MouseDown() 
	{
		rigidbodies.Clear ();
		if(Input.mousePosition.x > 200 && Input.mousePosition.y > 200 && Input.mousePosition.y < 600 && Input.mousePosition.x < 800)
		{
			startTime = Time.time;
			startPos = Input.mousePosition;
			startPos.z = transform.position.z - Camera.main.transform.position.z;
			startPos = Camera.main.ScreenToWorldPoint(startPos);

			Collider[] currentCols = Physics.OverlapSphere(startPos, 1f);
			foreach(Collider col in currentCols)
			{
				if(col.GetComponent<Rigidbody>() != null)
				{
					rigidbodies.Add(col.GetComponent<Rigidbody>());
				}
			}
		}
	}
	void MouseUp() {
		Vector3 endPos = Input.mousePosition;
		endPos.z = transform.position.z - Camera.main.transform.position.z;
		endPos = Camera.main.ScreenToWorldPoint(endPos);
		
		Vector3 force = endPos - startPos;
		force.z = force.magnitude;
		force /= (Time.time - startTime);
		force *= 2;
		
		foreach(Rigidbody rbody in rigidbodies)
		{
			rbody.AddForce(force * factor);
		}
	}
}