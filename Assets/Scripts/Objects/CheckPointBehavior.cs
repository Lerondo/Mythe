using UnityEngine;
using System.Collections;

public class CheckPointBehavior : MonoBehaviour {

	void Start()
	{
		gameObject.GetComponentInChildren<ParticleSystem>().Stop();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == Tags.Player)
		{
			other.GetComponent<PlayerController>().SetCheckPoint(this.transform.position);
			gameObject.GetComponentInChildren<ParticleSystem>().Play();
		}
	}
}
