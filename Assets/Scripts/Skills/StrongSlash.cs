using UnityEngine;
using System.Collections;

[System.Serializable]
public class StrongSlash : Skill {
	public StrongSlash()
	{
		animationName = "StrongSlash";
		type = skillType.offensive;
		_coolDown = 5f;
		_mana = 10;
	}
	public override IEnumerator Activate (Transform player)
	{
		yield return new WaitForSeconds(0.75f);
		Vector3 spherePosition = player.position;
		Collider[] colliders = Physics.OverlapSphere (spherePosition,  1f);
		foreach(Collider col in colliders)
		{
			if(col.tag == Tags.Enemy)
			{
				GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerController>().DoDamage(col.gameObject,3,3,10);
			}
		}
		GameObject strongSlash = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("StrongSlash", false) as GameObject;
		strongSlash.transform.position = player.position - new Vector3(0,1,0);
		strongSlash.GetComponent<ParticleSystemBehavior>().StartPooling();
		strongSlash.transform.parent = player;
	}
}
