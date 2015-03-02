using UnityEngine;
using System.Collections;

public class ShopEntered : MonoBehaviour {

	private bool _shopEntered;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			_shopEntered = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
			_shopEntered = false;
	}
}
