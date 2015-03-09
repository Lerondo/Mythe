using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillController : MonoBehaviour {
	private List<Skill> _currentSkills = new List<Skill>();
	private Animator playerAnimator;
	void Awake()
	{
		playerAnimator = GetComponent<Animator>();
		AddSkill(new StrongSlash());
	}
	public List<Skill> currentSkills
	{
		get
		{
			return _currentSkills;
		}
		set
		{
			_currentSkills = value;
		}
	}
	public void ActivateSkill(int skillNumber)
	{
		_currentSkills[skillNumber].Activate(this.transform.position,this.transform.eulerAngles);
		if(_currentSkills[skillNumber].type == Skill.skillType.buff)
		{
			//TODO: buff stuff
		} else if(_currentSkills[skillNumber].type == Skill.skillType.debuff)
		{
			//TODO: debuff stuff.
		} else {
			//TODO: offensive stuff.
		}
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
