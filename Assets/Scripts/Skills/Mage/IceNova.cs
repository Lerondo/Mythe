using UnityEngine;
using System.Collections;

public class IceNova : Skill {

	public IceNova()
	{
		type = skillType.offensive;
		_coolDown = 15f;
		_mana = 20;
	}

	public override IEnumerator Activate (Transform player)
	{
		yield return new WaitForSeconds (1);
		GameObject newNova = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("IceNova", false) as GameObject;
		newNova.GetComponent<Projectile>().SetDamage(20);
		newNova.GetComponent<Projectile>().tagToHit = Tags.Enemy;
		Transform spawnpoint = player.GetComponent<PlayerController> ().spawnPoint;

		for (int i = 0; i < 5; i++) 
		{
			Vector3 newPos = Vector3.zero;
			newPos.x = spawnpoint.position.x + 10;
			newPos.y = spawnpoint.position.y - 10 + 2 * Time.deltaTime;
			if (newNova.transform.position.y >= 2 && newPos.y >= 2) 
			{
				newPos.y = 2;
			}
			newNova.transform.position = newPos;
			newNova.transform.rotation = spawnpoint.rotation;
			

			yield return new WaitForEndOfFrame();
		}


	}
}
