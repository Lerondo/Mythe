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
		AddSkill(new ChargeSlash());
		AddSkill(new AttackSpeedBuff());
		AddSkill(new HealthRegen());
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
		skillNumber--;
		if(Time.time > _currentSkills[skillNumber].currentCoolDown)
		{
			_currentSkills[skillNumber].currentCoolDown = Time.time + _currentSkills[skillNumber].coolDown;
			playerAnimator.SetTrigger(_currentSkills[skillNumber].animationName);
			StartCoroutine(_currentSkills[skillNumber].Activate(this.transform));
		}
		else 
		{
			GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>().MakeText("You can't use that yet", this.transform.position + new Vector3(0,2,0),Color.yellow,24,true);
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
