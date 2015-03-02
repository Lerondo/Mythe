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
