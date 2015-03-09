using UnityEngine;
using System.Collections;

public class ButtonBehavior : InteractiveObject {
	public GameObject objectToActivate;
	// Use this for initialization
	void Start () 
	{
		_objectSort = objectSort.bothInteractive;
	}
	public override void Activate ()
	{
		base.Activate();
		objectToActivate.GetComponent<InteractiveObject>().Activate();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == Tags.Prop || other.transform.tag == Tags.Player)
		{
			Activate();
		}
	}
}
