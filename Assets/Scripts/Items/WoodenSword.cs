using UnityEngine;
using System.Collections;

[System.Serializable]
public class WoodenSword : Item {
	
	public WoodenSword()
	{
		itemSort = ItemSort.Weapon;
		itemQuality = ItemQuality.Common;
		_name = "Wooden Sword";
		_damage = 2;
		_magicDamage = 0;
		_defence = 0;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/woodenSword01";
		_itemSprite = "Sprites/Items/woodenSword01";
		_itemTexture = "Textures/Items/woodenSword01";
		/*
		_itemMesh = Resources.Load("Models/Items/woodenSword01", typeof(Mesh)) as Mesh;
		_itemSprite = Resources.Load("Sprites/Items/woodenSword01", typeof(Sprite)) as Sprite;
		_itemTexture = Resources.Load("Textures/Items/woodenSword01",typeof(Texture)) as Texture;
		*/
	}

}
