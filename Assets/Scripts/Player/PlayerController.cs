using UnityEngine;
using System.Collections;

public class PlayerController : Unit {
	public Collider myAttackCollider;
	public Transform spawnPoint;
	//TODO: list skills

	private Equipment _equipment;
	private bool _isLastAttack;
	private Animator _playerAnimator;
	private ObjectPool _objectPool;
	private Vector3 _checkPoint;
	private PlayerStats _stats;
	void Awake()
	{
		_playerAnimator = GetComponent<Animator>();
		_stats = GetComponent<PlayerStats>();
		_objectPool = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>();
		_equipment = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<Equipment>();
	}
	protected override void Update()
	{
		if(!_death)
		{
			if(this.transform.position.y <= -10f)
				OnDeath();
		}
	}
	public bool isDeath
	{
		get
		{
			return _death;
		}
	}
	public void SetCheckPoint(Vector3 pos)
	{
		_checkPoint = pos;
		_checkPoint.z = 0;
		_checkPoint.y += 3f;
	}
	public void OnDeath()
	{
		this.transform.position = _checkPoint;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		GetComponent<HealthController>().ResetHealth();
		_death = false;
	}
	/// <summary>
	/// start a skill with the specified skillNumber.
	/// </summary>
	/// <param name="skillNumber">Skill number.</param>
	public void StartSkill(int skillNumber)
	{
		if(skillNumber == 1)
		{
			GetComponent<SkillController>().ActivateSkill(skillNumber);
		} else {
			_playerAnimator.SetTrigger("Attack");
		}
		//set trigger to current skill
	}
	/// <summary>
	/// Attack via AnimationEvent.
	/// </summary>
	protected override AnimationEvent Attack()
	{
		myAttackCollider.enabled = true;
		if(_playerAnimator.GetBool("HasBow"))
		{
			ShootArrow();
		}
		return base.Attack();
	}
	private void ShootArrow()
	{
		_currentAttackDmg = _stats.basicDamage + _equipment.GetDamage();
		GameObject newArrow = _objectPool.GetObjectForType("Arrow", false) as GameObject;
		newArrow.GetComponent<ArrowBehavior>().SetDamage(_currentAttackDmg);
		newArrow.transform.position = spawnPoint.position;
		newArrow.transform.rotation = spawnPoint.rotation;
		newArrow.GetComponent<ArrowBehavior>().tagToHit = Tags.Enemy;
	}
	/// <summary>
	/// lastattack via animationevent.
	/// </summary>
	/// <returns>The attack.</returns>
	private AnimationEvent LastAttack()
	{
		myAttackCollider.enabled = true;
		_justAttacked = false;
		_isLastAttack = true;
		return null;
	}
	/// <summary>
	/// Stops the attack via AnimationEvent.
	/// </summary>
	/// <returns>nothing.</returns>
	protected override AnimationEvent StopAttack()
	{
		myAttackCollider.enabled = false;
		_isLastAttack = false;
		return base.StopAttack();
	}

	/// <summary>
	/// Raises the trigger stay event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay(Collider other)
	{
		if(!other.isTrigger && _playerAnimator.GetBool("HasSword"))
		{
			if(other.transform.tag == Tags.Enemy)
			{
				if(_attacking && !_justAttacked)
				{
					DoDamage(other.gameObject, 2f, 2f);
				} 
				else if(_isLastAttack && !_justAttacked)
				{
					DoDamage(other.gameObject, 2f, 5f);
				}
			}
		}
	}
	public void DoDamage(GameObject entity, float yPower, float xPower)
	{
		_justAttacked = true;	
		_attacking = false;
		_currentAttackDmg = _stats.basicDamage + _equipment.GetDamage();
		if(Random.Range(0,100) <= 25)
		{
			_currentAttackDmg = Mathf.FloorToInt(_currentAttackDmg * 1.5f);
			TextMessenger txtMessenger = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>();
			txtMessenger.MakeText(_currentAttackDmg.ToString(), entity.transform.position + new Vector3(0,3,0), Color.red, 24, true);
		} else {
			TextMessenger txtMessenger = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>();
			txtMessenger.MakeText(_currentAttackDmg.ToString(), entity.transform.position + new Vector3(0,3,0), Color.yellow, 24, true);
		}
		entity.GetComponent<HealthController>().UpdateHealth(-_currentAttackDmg);
		entity.GetComponent<Enemy>().justHit = true;
		entity.GetComponent<Unit>().KnockBack(this.transform.position, yPower,xPower);

	}
	public override void KnockBack (Vector3 position, float yPower, float xPower)
	{
		base.KnockBack (position, yPower, xPower);
		_playerAnimator.SetTrigger("KnockBack");
	}
}
