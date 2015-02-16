using UnityEngine;
using System.Collections;

public class CheckPointBehavior : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			other.GetComponent<PlayerController>().SetCheckPoint(this.transform.position);
		}
	}
}
