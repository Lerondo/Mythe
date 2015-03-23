using UnityEngine;
using System.Collections;

[System.Serializable]
public class Skill : System.Object {
	protected string _animationName;
	protected float _coolDown;
	protected float _currentCoolDown;
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
	public float coolDown
	{
		get{
			return _coolDown;
		}
		set{
			_coolDown = value;
		}
	}
}
