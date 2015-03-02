using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillController : MonoBehaviour {
	private List<Skill> _currentSkills = new List<Skill>();
	void Awake()
	{
		AddSkill(new StrongSlash());
	}
	public void ActivateSkill(int skillNumber)
	{
		_currentSkills[skillNumber].Activate(this.transform.position,this.transform.eulerAngles);
	}
	 void OnDrawGizmos()
	{
		Vector3 spherePosition = this.transform.position;
		spherePosition.x += 1;
		if(this.transform.eulerAngles.y == 270)
		{
			spherePosition.x -= 2;
		}
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(spherePosition, 1f);
	}
	public void AddSkill(Skill skill)
	{
		if(_currentSkills.Count < 4)
		{
			_currentSkills.Add (skill);
		} else {
			//TODO: popup window to much skills
		}
	}
}
