using UnityEngine;
using System.Collections;

[System.Serializable]
public class ClothHood : Item {

	public ClothHood()
	{
		itemSort = ItemSort.Helm;
		itemQuality = ItemQuality.Common;
		_name = "Simple Hood";
		_damage = 0;
		_magicDamage = 0;
		_defence = 2;
		_levelRequirement = 1;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/Hood1";
		_itemSprite = "Sprites/Items/Hood1";
		_itemTexture = "Textures/Items/Hood1";
	}
}
