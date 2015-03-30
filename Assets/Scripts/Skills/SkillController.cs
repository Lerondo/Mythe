using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillController : MonoBehaviour {
	private List<Skill> _currentSkills = new List<Skill>();
	private Animator _playerAnimator;
	private PlayerStats _playerStats;
	public Animator bowAnimator;
	private HealthController HealthMana;


	void Awake()
	{
		_playerStats = GetComponent<PlayerStats>();

		_playerAnimator = GetComponent<Animator>();
		//Warrior
		_currentSkills.Add(new StrongSlash());
		_currentSkills.Add(new ChargeSlash());
		_currentSkills.Add(new AttackSpeedBuff());
		_currentSkills.Add(new HealthRegen());
		//Archer
		_currentSkills.Add(new FireArrow());
		_currentSkills.Add(new RapidFire());
		_currentSkills.Add(new ArcherDash());
		_currentSkills.Add(new ExplosiveArrow());
		//Mage
		_currentSkills.Add (new InstantHeal ());
		_currentSkills.Add (new ManaRegen ());
		_currentSkills.Add (new Fireball ());
		_currentSkills.Add (new IceNova ());

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
		if(_playerAnimator.GetBool("HasBow"))
		{
			skillNumber += 4;
		} else if(_playerAnimator.GetBool("HasStaff"))
		{
			skillNumber += 8;
		}
		if(Time.time > _currentSkills[skillNumber].currentCoolDown && _playerStats.mana >= _currentSkills[skillNumber].mana)
		{
			_currentSkills[skillNumber].currentCoolDown = Time.time + _currentSkills[skillNumber].coolDown;
			_playerAnimator.SetTrigger(_currentSkills[skillNumber].animationName);
			_playerStats.mana -= _currentSkills[skillNumber].mana;
			StartCoroutine(_currentSkills[skillNumber].Activate(this.transform));
		}
		else 
		{
			GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>().MakeText("You can't use that yet", this.transform.position + new Vector3(0,2,0),Color.yellow,24,true);
		}
	}
}
