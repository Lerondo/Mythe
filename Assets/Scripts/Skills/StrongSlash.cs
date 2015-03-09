﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class StrongSlash : Skill {
	public StrongSlash()
	{
		animationName = "attack";
		type = skillType.offensive;
	}
	public override void Activate (Vector3 playerPos, Vector3 playerEuler)
	{
		Vector3 spherePosition = playerPos;
		spherePosition.x += 1;
		if(playerEuler.y == 270)
		{
			spherePosition.x -= 2;
		}
		Collider[] colliders = Physics.OverlapSphere (spherePosition,  1f);
		foreach(Collider col in colliders)
		{
			if(col.tag == Tags.Enemy)
			{
				GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerController>().DoDamage(col.gameObject,3,3);
			}
		}
	}
}
