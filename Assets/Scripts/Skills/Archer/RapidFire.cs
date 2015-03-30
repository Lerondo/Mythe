using UnityEngine;
using System.Collections;

public class RapidFire : Skill {
	public RapidFire()
	{
		animationName = "SpeedAttack";
		type = skillType.offensive;
		_coolDown = 10f;
		_mana = 20;
	}
	public override IEnumerator Activate (Transform player)
	{
		player.GetComponent<PlayerController>().bowAnimator.SetFloat("speedAttacks", 0);
		player.GetComponent<Animator>().SetFloat("speedAttacks", 0);
		yield return new WaitForSeconds(1);
		player.GetComponent<Animator>().SetFloat("speedAttacks", 4);
		player.GetComponent<PlayerController>().bowAnimator.SetFloat("speedAttacks", 4);
	}
}
