using UnityEngine;
using System.Collections;

public class ExplosiveArrow : Skill {
	public ExplosiveArrow()
	{
		animationName = "fireBowAttack";
		_coolDown = 60;
		_mana = 10;
		type = skillType.offensive;
		_mana = 25;
	}
	public override IEnumerator Activate (Transform player)
	{
		player.GetComponent<PlayerController>().bowAnimator.SetTrigger("Attack");
		yield return new WaitForSeconds(1f);
		GameObject newArrow = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("BombArrow", false) as GameObject;
		newArrow.GetComponent<Projectile>().SetDamage(5);
		newArrow.GetComponent<Projectile>().tagToHit = Tags.Enemy;
		Transform spawnPoint = player.GetComponent<PlayerController>().spawnPoint;
		newArrow.transform.position = spawnPoint.position;
		newArrow.transform.rotation = spawnPoint.rotation;
		
	}
}
