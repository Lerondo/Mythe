using UnityEngine;
using System.Collections;

public class InstantHeal : Skill {
	private int _heal;

	public InstantHeal()
	{
		_coolDown = 100f;
		_mana = 25;
		animationName = "Buff";
		type = skillType.buff;
	}

	public override IEnumerator Activate (Transform player)
	{
		GameObject gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
		yield return new WaitForSeconds (1);
		HealthController healthController = player.GetComponent<HealthController> ();
		TextMessenger txtMessenger = gameController.GetComponent<TextMessenger>();

		healthController.health += _heal;
		txtMessenger.MakeText(_heal.ToString(), player.position+new Vector3(0,2,0),Color.green,24,true);
	}
}
