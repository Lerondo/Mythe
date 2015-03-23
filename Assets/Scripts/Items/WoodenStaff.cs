using UnityEngine;
using System.Collections;

[System.Serializable]
public class WoodenStaff : Item {

	public WoodenStaff()
	{
		itemSort = ItemSort.Weapon;
		itemQuality = ItemQuality.Rare;
		_weaponSort = WeaponSort.Staff;
		_name = "Staff Of The Druid";
		_damage = 0;
		_magicDamage = 9;
		_defence = 1;
		_levelRequirement = 5;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/staff";
		_itemSprite = "Sprites/Items/staff";
		_itemTexture = "Textures/Items/staff";
	}
}
