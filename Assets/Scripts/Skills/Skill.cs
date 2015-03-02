using UnityEngine;
using System.Collections;

public class Skill {
	protected string _animationName;
	public virtual void Activate(Vector3 playerPos, Vector3 playerEuler)
	{
		//Put here specified skill
	}
	public virtual void OnDrawGizmos(Vector3 playerPos, Vector3 playerEuler)
	{
	}
}
