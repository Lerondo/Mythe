using UnityEngine;
using System.Collections;

public class PlayerController : Unit {
	public Collider myCollider;
	public int[] allDamages = new int[5];
	public int[] allCooldowns = new int[5];
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
	public void SetCheckPoint(Vector3 pos)
	{
		_checkPoint = pos;
		_checkPoint.z = 0;
		_checkPoint.y += 3f;
		GetComponent<PlayerMovement>().SetCurrentFloor(null);
	}
	public void OnDeath()
	{
		this.transform.position = _checkPoint;
		GetComponent<HealthController>().ResetHealth();
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
	/// Raises the trigger stay event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay(Collider other)
	{
		if(_attacking && !_justAttacked)
		{
			if(!other.isTrigger)
			{
				if(other.transform.tag == TagManager.Enemy)
				{
					_justAttacked = true;	
					other.GetComponent<HealthController>().UpdateHealth(-_currentAttackDmg);
					other.GetComponent<Unit>().KnockBack(this.transform.position);
					TextMessenger txtMessenger = GameObject.FindGameObjectWithTag(TagManager.GameController).GetComponent<TextMessenger>();
					txtMessenger.MakeText(_currentAttackDmg.ToString(), other.transform.position + new Vector3(0,3,0), Color.red, 24, true);
				}
			}
		}
	}
}
