using UnityEngine;
using System.Collections;

public class PlayerController : Unit {
	public Collider myAttackCollider;
	public int[] allDamages = new int[5];
	public int[] allCooldowns = new int[5];

	private bool _justHit;
	private bool _isLastAttack;
	private Animator _playerAnimator;
	private Vector3 _checkPoint;
	private PlayerStats _stats;
	void Awake()
	{
		_playerAnimator = GetComponent<Animator>();
		_stats = GetComponent<PlayerStats>();
	}
	protected override void Start ()
	{
		_currentAttackDmg = 10;
	}
	protected override void Update()
	{
		if(!_death)
		{
			if(this.transform.position.y <= -5f)
				OnDeath();
		}
	}
	public bool GetIsDeath()
	{
		return _death;
	}
	public bool GetJustHit()
	{
		return _justHit;
	}
	public void SetJustHit(bool justHit)
	{
		_justHit = justHit;
		Invoke("CanGetHitAgain", 0.5f);
	}
	private void CanGetHitAgain()
	{
		_justHit = false;
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
		rigidbody.velocity = Vector3.zero;
		GetComponent<HealthController>().ResetHealth();
		_death = false;
	}
	/// <summary>
	/// Attack with the specified skillNumber.
	/// </summary>
	/// <param name="skillNumber">Skill number.</param>
	public void StartAttack(int skillNumber)
	{
		_currentAttackDmg = allDamages[skillNumber] + _stats.GetDamage();
		_playerAnimator.SetTrigger("Attack");
	}
	/// <summary>
	/// Attack via AnimationEvent.
	/// </summary>
	protected override AnimationEvent Attack()
	{
		myAttackCollider.enabled = true;
		return base.Attack();
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
		if(!other.isTrigger)
		{
			if(other.transform.tag == TagManager.Enemy)
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
	private void DoDamage(GameObject entity, float yPower, float xPower)
	{
		_justAttacked = true;	
		_attacking = false;
		entity.GetComponent<HealthController>().UpdateHealth(-_currentAttackDmg);
		entity.GetComponent<Unit>().KnockBack(this.transform.position, yPower,xPower);
		TextMessenger txtMessenger = GameObject.FindGameObjectWithTag(TagManager.GameController).GetComponent<TextMessenger>();
		txtMessenger.MakeText(_currentAttackDmg.ToString(), entity.transform.position + new Vector3(0,3,0), Color.red, 24, true);
	}
}
