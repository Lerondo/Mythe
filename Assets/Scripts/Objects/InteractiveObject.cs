using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour {
	public enum objectSort
	{
		playerInteractive,
		objectInteractive,
		bothInteractive
	}
	protected objectSort _objectSort;
	protected Animator _objectAnimator;
	void Awake () {
		_objectAnimator = GetComponent<Animator>();
	}
	public virtual void Activate()
	{
		_objectAnimator.SetTrigger("Activate");
		//activate function.
	}
	public objectSort GetObjectSort()
	{
		return _objectSort;
	}
}
