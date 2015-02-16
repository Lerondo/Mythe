using UnityEngine;
using System.Collections;

public class Axe : Item {

	public Axe()
	{
		itemSort = ItemSort.sword;
		itemQuality = ItemQuality.common;
		_damage = 4;
		_defence = 0;
		 _itemMesh = Resources.Load("Models/Items/Axe1", typeof(Mesh)) as Mesh;
		_itemSprite = Resources.Load("Sprites/Items/axe", typeof(Sprite)) as Sprite;
		_itemTexture = Resources.Load("Textures/Items/axe",typeof(Texture)) as Texture;
	}
}
