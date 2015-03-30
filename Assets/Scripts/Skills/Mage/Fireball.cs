using UnityEngine;
using System.Collections;

public class Fireball : Skill 
{
	public Fireball()
	{
		type = skillType.offensive;
		_coolDown = 5f;
		_mana = 10;
	}
	public override IEnumerator Activate (Transform player)
	{
		//GameObject gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
		yield return new WaitForSeconds (1);
		GameObject newBolt = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("Fireball", false) as GameObject;
		newBolt.GetComponent<Projectile>().SetDamage(15);
		newBolt.GetComponent<Projectile>().tagToHit = Tags.Enemy;
		Transform spawnpoint = player.GetComponent<PlayerController> ().spawnPoint;
		newBolt.transform.position = spawnpoint.position;
		newBolt.transform.rotation = spawnpoint.rotation;
	}

}
