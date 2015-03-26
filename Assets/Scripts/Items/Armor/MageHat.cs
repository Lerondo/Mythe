using UnityEngine;
using System.Collections;

[System.Serializable]
public class MageHat : Item {
	public MageHat()
	{
		itemSort = ItemSort.Helm;
		itemQuality = ItemQuality.Rare;
		_name = "Mage Hat";
		_damage = 0;
		_magicDamage = 4;
		_defence = 2;
		_levelRequirement = 5;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/mage_hat";
		_itemSprite = "Sprites/Items/mage_hat";
		_itemTexture = "Textures/Items/mage_hat";
	}
}
