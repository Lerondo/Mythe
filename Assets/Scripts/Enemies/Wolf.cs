using UnityEngine;
using System.Collections;

public class Wolf : Melee {
	

	protected override void Start () 
	{
		_range = 4f;
		_health = 100;
		_speed = 2.5f;
		_currentAttackDmg = 10;
		_exp = 50;
		base.Start();
	}

	protected override AnimationEvent Attack ()
	{
		_audioSource.clip = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<AudioList>().PlayAudio("WolfBite");
		_audioSource.Play();
		return base.Attack ();
	}
}
