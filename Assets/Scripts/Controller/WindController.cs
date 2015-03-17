using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindController : MonoBehaviour 
{
	private float _factor = 10.0f;
	private Transform _windTransform;
	private float _startTime;
	private Vector3 _startPos;
	private ObjectPool _objectPool;
	void Awake()
	{
		_objectPool = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>();
	}
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
		if(Input.mousePosition.x > 200 && Input.mousePosition.y > 100 && Input.mousePosition.y < 600 && Input.mousePosition.x < 800)
		{
			_startTime = Time.time;
			_startPos = Input.mousePosition;
			_startPos.z = transform.position.z - Camera.main.transform.position.z;
			_startPos = Camera.main.ScreenToWorldPoint(_startPos);

			Collider[] currentCols = Physics.OverlapSphere(_startPos, 1f);
			foreach(Collider col in currentCols)
			{
				if(col.rigidbody != null)
				{
					rigidbodies.Add(col.rigidbody);
				}
			}
		}
	}
	void MouseUp() {
		Vector3 endPos = Input.mousePosition;
		endPos.z = transform.position.z - Camera.main.transform.position.z;
		endPos = Camera.main.ScreenToWorldPoint(endPos);
		
		Vector3 force = endPos - _startPos;
		force.z = force.magnitude;
		force /= (Time.time - _startTime);
		
		foreach(Rigidbody rbody in rigidbodies)
		{
			rbody.AddForce(force * _factor);
		}
		GameObject windAnim = _objectPool.GetObjectForType("WindAnimation", true) as GameObject;
		windAnim.transform.position = _startPos;
		windAnim.GetComponent<RemoveWindAnim>().InvokeRemove();
		float angle = Mathf.Atan2(endPos.y-_startPos.y, endPos.x-_startPos.x) * Mathf.Rad2Deg;
		windAnim.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}