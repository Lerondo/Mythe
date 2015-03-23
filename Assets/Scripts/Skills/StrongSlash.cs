using UnityEngine;
using System.Collections;

[System.Serializable]
public class StrongSlash : Skill {
	public StrongSlash()
	{
		animationName = "attack";
		type = skillType.offensive;
		_coolDown = 5f;
	}
	public override void Activate (Vector3 playerPos, Vector3 playerEuler)
	{
		if(Time.time > _currentCoolDown)
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
			_currentCoolDown = Time.time + _coolDown;
		} 
		else 
		{
			GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<TextMessenger>().MakeText("You can't use that yet", playerPos + new Vector3(0,2,0),Color.yellow,24,true);
		}
	}
}
