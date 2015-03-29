using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Unit : MonoBehaviour {
	protected bool _isGrounded = false;
	protected bool _attacking = false;
	protected bool _justAttacked = false;
	protected float _speed = 5f;
	protected int _currentAttackDmg;
	protected float _range;
	protected bool _death = false;
	protected int _health;
	protected bool _justHit = false;
	protected ParticleSystem _particleSystem;

	protected virtual void Start () {
		//start function
	}
	public void SetOnFire()
	{
		StartCoroutine(OnFire());
	}
	private IEnumerator OnFire()
	{
		if(_particleSystem == null)
			_particleSystem = GetComponent<ParticleSystem>();

		_particleSystem.Play();
		for (int i = 0; i < 10; i++) 
		{
			GetComponent<HealthController>().health -= 5;
			GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>().MakeText("5",this.transform.position+new Vector3(0,2,0),Color.red,18,true);
			yield return new WaitForSeconds(0.5f);
		}
		_particleSystem.Stop();
	}
	protected virtual void Update () {
		//update function
	}
	public int health
	{
		get{
			return _health;
		}
		set{
			_health = value;
		}
	}
	public void SetDeath(bool death)
	{
		_death = death;
	}
	public bool justHit
	{
		get
		{
			return _justHit;
		}
		set{
			_justHit = value;
			if(value == true)
				Invoke("CanGetHitAgain", 0.5f);
		}
	}
	private void CanGetHitAgain()
	{
		_justHit = false;
	}
	public virtual void KnockBack(Vector3 position, float yPower, float xPower)
	{
		float side = this.transform.position.x - position.x;
		Vector3 knockback = this.GetComponent<Rigidbody>().velocity;
		knockback.y = yPower;
		knockback.x = xPower;
		if(side < 0)
		{
			knockback.x *= -1;
		} 
		this.GetComponent<Rigidbody>().velocity = knockback;
	}
	/// <summary>
	/// Attack via AnimationEvent.
	/// </summary>
	protected virtual AnimationEvent Attack()
	{
		_attacking = true;
		_justAttacked = false;
		return null;
	}
	/// <summary>
	/// Stops the attack via AnimationEvent.
	/// </summary>
	/// <returns>nothing.</returns>
	protected virtual AnimationEvent StopAttack()
	{
		_attacking = false;
		return null;
	}
}
