using UnityEngine;
using System.Collections;

[System.Serializable]
public class SwordOfFate : Item {

	public SwordOfFate()
	{
		itemSort = ItemSort.Weapon;
		itemQuality = ItemQuality.Legendary;
		_weaponSort = WeaponSort.Sword;
		_name = "Sword of Fate";
		_damage = 11;
		_magicDamage = 5;
		_defence = 0;
		_levelRequirement = 8;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/Sword_Of_Fate";
		_itemSprite = "Sprites/Items/swordoffate";
		_itemTexture = "Textures/Items/swordoffate";
	}
}