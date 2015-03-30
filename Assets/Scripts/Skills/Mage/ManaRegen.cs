using UnityEngine;
using System.Collections;

public class ManaRegen : Skill {

	public ManaRegen()
	{
		type = skillType.buff;
		_coolDown = 20f;
		_mana = 0;
		animationName = "Buff";
	}
	public override IEnumerator Activate (Transform player)
	{
		GameObject gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
		yield return new WaitForSeconds (1);
		HealthController manaController = player.GetComponent<HealthController>();
		TextMessenger txtMessenger = gameController.GetComponent<TextMessenger>();

		manaController.mana += _mana;
		txtMessenger.MakeText(_mana.ToString(), player.position+new Vector3(0,2,0),Color.blue,24,true);
	}
}
