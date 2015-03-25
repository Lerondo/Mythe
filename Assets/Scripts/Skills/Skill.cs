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
	public virtual IEnumerator Activate(Transform player)
	{
		//Put here specified skill
		return null;
	}
	public float currentCoolDown
	{
		get{
			return _currentCoolDown;
		}
		set{
			_currentCoolDown = value;
		}
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
