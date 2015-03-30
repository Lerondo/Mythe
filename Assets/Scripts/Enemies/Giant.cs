using UnityEngine;
using System.Collections;

public class Giant : Tuatha {
	protected override void Start ()
	{
		base.Start ();
		_currentAttackDmg *= 3;
		_health *= 3;
	}
}
