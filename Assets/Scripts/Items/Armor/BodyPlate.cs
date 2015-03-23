using UnityEngine;
using System.Collections;

public class BodyPlate : Item {

	public BodyPlate()
	{
		itemSort = ItemSort.Body;
		itemQuality = ItemQuality.Uncommon;
		_name = "Steel Armour Plate";
		_damage = 0;
		_magicDamage = 0;
		_defence = 5;
		_levelRequirement = 3;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/bodyPlate1";
		_itemSprite = "Sprites/Items/bodyPlate1";
		_itemTexture = "Textures/Items/bodyPlate1";
	}
}
