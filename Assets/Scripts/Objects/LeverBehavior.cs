using UnityEngine;
using System.Collections;

public class LeverBehavior : InteractiveObject {
	public GameObject objectToActivate;
	void Start () 
	{
		_objectSort = objectSort.playerInteractive;
	}
	public override void Activate ()
	{
		base.Activate();
		objectToActivate.GetComponent<InteractiveObject>().Activate();
	}
}
