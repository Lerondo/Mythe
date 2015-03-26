using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShoulderPads : Item {
	public ShoulderPads()
	{
		itemSort = ItemSort.Shoulders;
		itemQuality = ItemQuality.Rare;
		_name = "Simple ShoulderPads";
		_damage = 0;
		_magicDamage = 0;
		_defence = 4;
		_levelRequirement = 3;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/Right_shoulder_piece";
		_itemSprite = "Sprites/Items/shoulder";
		_itemTexture = "Textures/Items/shoulder_hip_and_knee_plating";
	}
}
