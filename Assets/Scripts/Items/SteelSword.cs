using UnityEngine;
using System.Collections;

[System.Serializable]
public class SteelSword : Item {

	public SteelSword()
	{
		itemSort = ItemSort.Weapon;
		itemQuality = ItemQuality.Uncommon;
		_name = "Steel Sword";
		_damage = 9;
		_magicDamage = 0;
		_defence = 0;
		_levelRequirement = 5;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/steelSword01";
		_itemSprite = "Sprites/Items/steelSword01";
		_itemTexture = "Textures/Items/steelSword01";
		/*
		_itemMesh = Resources.Load("Models/Items/steelSword01", typeof(Mesh)) as Mesh;
		_itemSprite = Resources.Load("Sprites/Items/steelSword01", typeof(Sprite)) as Sprite;
		_itemTexture = Resources.Load("Textures/Items/steelSword01",typeof(Texture)) as Texture;
		*/
	}
}
