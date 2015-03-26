using UnityEngine;
using System.Collections;

[System.Serializable]
public class HipPads : Item {
	public HipPads()
	{
		itemSort = ItemSort.Hips;
		itemQuality = ItemQuality.Rare;
		_name = "Simple HipPads";
		_damage = 0;
		_magicDamage = 0;
		_defence = 1;
		_levelRequirement = 3;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/Right_hip_piece";
		_itemSprite = "Sprites/Items/hip";
		_itemTexture = "Textures/Items/shoulder_hip_and_knee_plating";
	}
}
