using UnityEngine;
using System.Collections;

public class FireArrowBehavior : Projectile {
	public override void OnTriggerEnter (Collider other)
	{
		if(other.transform.tag == _tagToHit || !other.isTrigger)
		{
			bool isTargetHit = other.GetComponent<Unit>().justHit;
			if(!isTargetHit)
			{
				other.transform.GetComponent<Unit>().SetOnFire();
				other.GetComponent<HealthController>().DoDamage(_damage);
				other.GetComponent<Unit>().KnockBack(this.transform.position, 2f, 2f);
				other.GetComponent<Unit>().justHit = true;
				if(Random.Range(0,100) <= 25)
				{
					_damage = Mathf.FloorToInt(_damage * 1.5f);
					TextMessenger txtMessenger = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>();
					txtMessenger.MakeText(_damage.ToString(), other.transform.position + new Vector3(0,3,0), Color.red, 24, true);
				} else {
					TextMessenger txtMessenger = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>();
					txtMessenger.MakeText(_damage.ToString(), other.transform.position + new Vector3(0,3,0), Color.yellow, 24, true);
				}
				ObjectPool.instance.PoolObject(this.gameObject);
			}
		}
	}
}
