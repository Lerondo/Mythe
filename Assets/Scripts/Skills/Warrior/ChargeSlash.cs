using UnityEngine;
using System.Collections;

[System.Serializable]
public class ChargeSlash : Skill {
		
	public ChargeSlash()
	{
		animationName = "ChargeSlash";
		type = skillType.offensive;
		_coolDown = 5f;

	}
	public override IEnumerator Activate (Transform player)
	{
		yield return new WaitForSeconds(0.25f);
		player.GetComponent<Animator>().speed = 0;
		Vector3 spherePosition = player.position;
		Vector3 chargePosition = player.position;
		spherePosition.x += 1f;
		chargePosition.y += 2;
		chargePosition.x -= 1;
		if(player.eulerAngles.y >= 260)
		{
			spherePosition.x -= 2;
			chargePosition.x += 2;
		}
		GameObject chargeSlash = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("Charge", false) as GameObject;
		chargeSlash.transform.position = chargePosition;
		chargeSlash.transform.parent = player;
		chargeSlash.GetComponent<ParticleSystemBehavior>().StartPooling();

		yield return new WaitForSeconds(1f);

		player.GetComponent<Animator>().speed = 1;

		Collider[] colliders = Physics.OverlapSphere (spherePosition,  0.0005f);
		foreach(Collider col in colliders)
		{
			if(col.tag == Tags.Enemy)
			{
				player.GetComponent<PlayerController>().DoDamage(col.gameObject,5,5,15);
				break;
			}
		}
	}
}
