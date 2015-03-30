using UnityEngine;
using System.Collections;

public class AttackSpeedBuff : Skill {
	public AttackSpeedBuff()
	{
		animationName = "SpeedAttack";
		type = skillType.offensive;
		_coolDown = 10f;
		_mana = 20;
	}
	public override IEnumerator Activate (Transform player)
	{
		player.GetComponent<Animator>().SetFloat("speedAttacks", 0);
		yield return new WaitForSeconds(1);
		player.GetComponent<Animator>().SetFloat("speedAttacks", 4);
	}
}
