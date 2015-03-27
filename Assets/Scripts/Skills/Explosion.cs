using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	private int _damage = 20;
	public void Explode()
	{
		Collider[] cols = Physics.OverlapSphere(this.transform.position,5);
		foreach(Collider col in cols)
		{
			if(col.tag == Tags.Enemy)
			{
				col.GetComponent<HealthController>().DoDamage(_damage);
				col.GetComponent<Unit>().KnockBack(this.transform.position, 2f, 2f);
				col.GetComponent<Unit>().justHit = true;
				TextMessenger txtMessenger = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>();
				txtMessenger.MakeText(_damage.ToString(), col.transform.position + new Vector3(0,3,0), Color.yellow, 24, true);
			}
		}
	}
}
