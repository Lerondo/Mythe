using UnityEngine;
using System.Collections;

public class FireArrow : Skill {
	public FireArrow()
	{
		animationName = "fireBowAttack";
		type = skillType.offensive;
		_coolDown = 5f;
	}
	public override IEnumerator Activate (Transform player)
	{
		yield return new WaitForSeconds(1f);
		GameObject newArrow = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("FireArrow", false) as GameObject;
		newArrow.GetComponent<ArrowBehavior>().SetDamage(5);
		newArrow.GetComponent<ArrowBehavior>().tagToHit = Tags.Enemy;
		Transform spawnPoint = player.GetComponent<PlayerController>().spawnPoint;
		newArrow.transform.position = spawnPoint.position;
		newArrow.transform.rotation = spawnPoint.rotation;

	}
}
