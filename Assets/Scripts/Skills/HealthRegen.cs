using UnityEngine;
using System.Collections;

public class HealthRegen : Skill {
	private int _heal = 5;
	public HealthRegen()
	{
		_coolDown = 120f;
		animationName = "Buff";
		type = skillType.buff;
		_mana = 50;
	}
	public override IEnumerator Activate (Transform player)
	{
		ParticleSystem playerParticles = player.GetComponent<ParticleSystem>();
		playerParticles.Play();
		GameObject gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
		HealthController healthController = player.GetComponent<HealthController>();
		TextMessenger txtMessenger = gameController.GetComponent<TextMessenger>();
		for (int i = 0; i < 10; i++) 
		{
			healthController.health += _heal;
			txtMessenger.MakeText(_heal.ToString(), player.position+new Vector3(0,2,0),Color.green,24,true);
			yield return new WaitForSeconds(1f);
		}
		playerParticles.Stop();
	}
}
