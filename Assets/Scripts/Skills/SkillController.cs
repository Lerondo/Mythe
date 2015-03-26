using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillController : MonoBehaviour {
	private List<Skill> _currentSkills = new List<Skill>();
	private Animator _playerAnimator;
	public Animator bowAnimator;

	void Awake()
	{
		_playerAnimator = GetComponent<Animator>();
		_currentSkills.Add(new StrongSlash());
		_currentSkills.Add(new ChargeSlash());
		_currentSkills.Add(new AttackSpeedBuff());
		_currentSkills.Add(new HealthRegen());
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
		CheckWeaponSkills();
		skillNumber--;
		if(Time.time > _currentSkills[skillNumber].currentCoolDown)
		{
			_currentSkills[skillNumber].currentCoolDown = Time.time + _currentSkills[skillNumber].coolDown;
			_playerAnimator.SetTrigger(_currentSkills[skillNumber].animationName);
			if(_playerAnimator.GetBool("HasBow"))
				bowAnimator.SetTrigger(_currentSkills[skillNumber].animationName);
			StartCoroutine(_currentSkills[skillNumber].Activate(this.transform));
		}
		else 
		{
			GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>().MakeText("You can't use that yet", this.transform.position + new Vector3(0,2,0),Color.yellow,24,true);
		}
	}
	public void CheckWeaponSkills()
	{
		if(_playerAnimator.GetBool("HasBow"))
		{
			_currentSkills.Clear();
			_currentSkills.Add(new FireArrow());
			_currentSkills.Add(new RapidFire());
			//TODO: add 4 bow skills.
		} 
		else if(_playerAnimator.GetBool("HasStaff"))
		{
			_currentSkills.Clear();
			//TODO: add 4 staff skills.
		} else {
			_currentSkills.Clear();
			_currentSkills.Add(new StrongSlash());
			_currentSkills.Add(new ChargeSlash());
			_currentSkills.Add(new AttackSpeedBuff());
			_currentSkills.Add(new HealthRegen());
		}
	}
}
