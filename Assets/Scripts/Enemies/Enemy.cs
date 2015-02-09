using UnityEngine;
using System.Collections;

public class Enemy : Unit {
	private Transform _target;
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") 
		{
			_target = other.transform;
		}
	}
	void OnTriggerExit(Collider other) 
	{
		if (other.tag == "Player") 
		{
			_target = null;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if(_attacking && !_justAttacked)
		{
			if(other.tag == "Player")
			{
				_justAttacked = true;
				//target.GetComponent<PlayerResources> ().TakeDamage (_currentAttackDmg);
			}
		}
	}
	protected override void Update() 
	{
		if (_target) 
		{
			Vector3 raycastDirection = _target.position - transform.position;
			Ray ray = new Ray(transform.position, raycastDirection);
			Debug.DrawRay(transform.position, raycastDirection);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 10f))
			{
				if(hit.transform.tag == "Player")
				{
					transform.LookAt (_target);
					transform.Translate (Vector3.forward * _speed * Time.deltaTime);
					if (Vector3.Distance (this.transform.position, _target.position) < 2) 
					{
						//TODO: if animation not playing set animation + animation event attack
					}
				}
			}
		}
	}
}
