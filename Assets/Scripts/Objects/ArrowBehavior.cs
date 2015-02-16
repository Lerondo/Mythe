using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
	private float _speed = 5f;
	private int _damage;
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
	}
	public void SetDamage(int damage)
	{
		_damage = damage;
		Invoke ("PoolMyself", 5f);
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			other.GetComponent<HealthController>().UpdateHealth(-_damage);
			other.GetComponent<Unit>().KnockBack(this.transform.position);
			ObjectPool.instance.PoolObject(this.gameObject);
		}
	}
	void PoolMyself()
	{
		ObjectPool.instance.PoolObject(this.gameObject);
	}
}
