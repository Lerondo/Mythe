using UnityEngine;
using System.Collections;

public class Skill {
	protected string _animationName;
	public enum skillType
	{
		offensive,
		debuff,
		buff
	}
	public skillType type;
	public string animationName;
	public virtual void Activate(Vector3 playerPos, Vector3 playerEuler)
	{
		//Put here specified skill
	}
}
