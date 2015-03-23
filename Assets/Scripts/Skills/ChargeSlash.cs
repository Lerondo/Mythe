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
	public override IEnumerator Activate (Vector3 playerPos, Vector3 playerEuler)
	{
		yield return new WaitForSeconds(0.25f);
		GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<Animator>().speed = 0;
		Vector3 spherePosition = playerPos;
		Vector3 chargePosition = playerPos;
		Debug.Log(playerEuler);
		spherePosition.x += 1f;
		chargePosition.y += 2;
		chargePosition.x -= 1;
		if(playerEuler.y >= 260)
		{
			spherePosition.x -= 2;
			chargePosition.x += 2;
		}
		GameObject chargeSlash = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("Charge", false) as GameObject;
		chargeSlash.transform.position = chargePosition;
		chargeSlash.GetComponent<ParticleSystemBehavior>().StartPooling();

		yield return new WaitForSeconds(1f);

		GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<Animator>().speed = 1;

		Collider[] colliders = Physics.OverlapSphere (spherePosition,  0.0005f);
		foreach(Collider col in colliders)
		{
			if(col.tag == Tags.Enemy)
			{
				GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerController>().DoDamage(col.gameObject,5,5,15);
				break;
			}
		}
	}
}
