using UnityEngine;
using System.Collections;

public class FireArrow : Skill {
	public FireArrow()
	{
		animationName = "fireBowAttack";
		type = skillType.offensive;
		_coolDown = 5f;
		_mana = 10;
	}
	public override IEnumerator Activate (Transform player)
	{
		player.GetComponent<PlayerController>().bowAnimator.SetTrigger("Attack");
		yield return new WaitForSeconds(1f);
		GameObject newArrow = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("FireArrow", false) as GameObject;
		newArrow.GetComponent<ProjectileBehavior>().SetDamage(5);
		newArrow.GetComponent<ProjectileBehavior>().tagToHit = Tags.Enemy;
		Transform spawnPoint = player.GetComponent<PlayerController>().spawnPoint;
		newArrow.transform.position = spawnPoint.position;
		newArrow.transform.rotation = spawnPoint.rotation;

	}
}
