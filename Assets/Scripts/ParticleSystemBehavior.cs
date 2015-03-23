using UnityEngine;
using System.Collections;

public class ParticleSystemBehavior : MonoBehaviour {
	public void StartPooling()
	{
		Invoke ("PoolMyself", GetComponent<ParticleSystem>().duration);
	}
	private void PoolMyself()
	{
		GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().PoolObject(this.gameObject);
	}
}
