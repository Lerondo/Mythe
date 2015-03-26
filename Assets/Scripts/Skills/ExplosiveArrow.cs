using UnityEngine;
using System.Collections;

public class ExplosiveArrow : Skill {
	public ExplosiveArrow()
	{
		animationName = "fireBowAttack";
		_coolDown = 60f;
		type = skillType.offensive;
	}
	public override IEnumerator Activate (Transform player)
	{
		player.GetComponent<PlayerController>().bowAnimator.SetTrigger("Attack");
		yield return new WaitForSeconds(1f);
		GameObject newArrow = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("BombArrow", false) as GameObject;
		newArrow.GetComponent<ArrowBehavior>().SetDamage(5);
		newArrow.GetComponent<ArrowBehavior>().tagToHit = Tags.Enemy;
		Transform spawnPoint = player.GetComponent<PlayerController>().spawnPoint;
		newArrow.transform.position = spawnPoint.position;
		newArrow.transform.rotation = spawnPoint.rotation;
		
	}
}
