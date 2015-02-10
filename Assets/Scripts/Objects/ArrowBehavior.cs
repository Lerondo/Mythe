using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
	private float _speed = 5f;
	private float _damage;
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
	}
	public void SetDamage(float damage)
	{
		_damage = damage;
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			//TODO: do dmg
		}
	}
}
