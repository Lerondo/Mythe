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
			OnMouseDown();
		} else if(Input.GetMouseButtonUp(0))
		{
			OnMouseUp();
		}
	}
	
	List<Rigidbody> rigidbodies = new List<Rigidbody>();
	
	
	void OnMouseDown() 
	{
		/*rigidbodies.Clear ();
		
		startTime = Time.time;
		startPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		startPos.z = 0;

		Debug.Log (startPos+"StartPos");
		
		Collider[] touchedRigidbodies = Physics.OverlapSphere (startPos, 0.000005f);
		
		foreach (Collider col in touchedRigidbodies) 
		{
			if(col.rigidbody)
			{
				rigidbodies.Add (col.rigidbody);
			}
<<<<<<< HEAD
		}*/

		rigidbodies.Clear ();

		startTime = Time.time;
		startPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		startPos.z = 0;
	}
	void OnMouseUp() {
		Vector3 endPos = Input.mousePosition;
		endPos.z = 0;
		endPos = Camera.main.ScreenToWorldPoint(endPos);

		Debug.Log (endPos+"Endpos");
		
		
		Vector3 force =  endPos - startPos;
		force.z = 5f;
		force /= (Time.time - startTime);
		
		
		foreach(Rigidbody rbody in rigidbodies)
		{
			Debug.Log(rbody.name);
			rbody.AddForce(force * factor);
		}
	}
}