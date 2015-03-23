using UnityEngine;
using System.Collections;

[System.Serializable]
public class StrongSlash : Skill {
	public StrongSlash()
	{
		animationName = "StrongSlash";
		type = skillType.offensive;
		_coolDown = 5f;
	}
	public override IEnumerator Activate (Vector3 playerPos, Vector3 playerEuler)
	{
		yield return new WaitForSeconds(0.75f);
		Vector3 spherePosition = playerPos;
		Collider[] colliders = Physics.OverlapSphere (spherePosition,  1f);
		foreach(Collider col in colliders)
		{
			if(col.tag == Tags.Enemy)
			{
				GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerController>().DoDamage(col.gameObject,3,3,10);
			}
		}
		GameObject strongSlash = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("StrongSlash", false) as GameObject;
		strongSlash.transform.position = playerPos - new Vector3(0,1,0);
		strongSlash.GetComponent<ParticleSystemBehavior>().StartPooling();
	}
}
