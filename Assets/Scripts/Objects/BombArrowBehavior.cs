using UnityEngine;
using System.Collections;

public class ProjectileBehavior : Projectile {
	public override void OnTriggerEnter (Collider other)
	{
		if(other.transform.tag == _tagToHit || !other.isTrigger)
		{
			bool isTargetHit = other.GetComponent<Unit>().justHit;
			if(!isTargetHit)
			{
				GameObject newExplosion = ObjectPool.instance.GetObjectForType("Explosion", false) as GameObject;
				newExplosion.transform.position = this.transform.position;
				newExplosion.GetComponent<ParticleSystemBehavior>().StartPooling();
				ObjectPool.instance.PoolObject(this.gameObject);
			}
		}
	}
}
