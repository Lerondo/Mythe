using UnityEngine;
using System.Collections;

[System.Serializable]
public class WoodenBow : Item {
	public WoodenBow()
	{
		itemSort = ItemSort.Weapon;
		itemQuality = ItemQuality.Rare;
		_weaponSort = WeaponSort.Bow;
		_name = "Hunters Bow";
		_damage = 7;
		_magicDamage = 0;
		_defence = 1;
		_levelRequirement = 3;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/bow";
		_itemSprite = "Sprites/Items/bow";
		_itemTexture = "Textures/Items/bow";
	}
}
