using UnityEngine;
using System.Collections;

public class SteelSword : Item {

	public SteelSword()
	{
		itemSort = ItemSort.sword;
		itemQuality = ItemQuality.uncommon;
		_damage = 7;
		_defence = 0;
		_itemMesh = Resources.Load("Models/Items/steelSword01", typeof(Mesh)) as Mesh;
		_itemSprite = Resources.Load("Sprites/Items/steelSword01", typeof(Sprite)) as Sprite;
		_itemTexture = Resources.Load("Textures/Items/steelSword01",typeof(Texture)) as Texture;
	}
}
