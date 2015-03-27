using UnityEngine;
using System.Collections;

public class ArcherDash : Skill {
	public ArcherDash()
	{
		animationName = "Jump";
		type = skillType.buff;
		_coolDown = 5f;
		_mana = 0;
	}
	public override IEnumerator Activate (Transform player)
	{
		yield return new WaitForEndOfFrame();
		if(player.eulerAngles.y >= 260)
		{
			player.GetComponent<Rigidbody>().velocity += new Vector3(10,3,0);
		} else {
			player.GetComponent<Rigidbody>().velocity += new Vector3(-10,3,0);
		}
	}
}
