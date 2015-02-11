using UnityEngine;
using System.Collections;

public class LadderBehavior : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			if(!other.isTrigger)
				other.gameObject.GetComponent<PlayerController>().StartClimbing();
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			if(!other.isTrigger)
				other.gameObject.GetComponent<PlayerController>().StopClimbing();
		}
	}
}
