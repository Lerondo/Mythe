using UnityEngine;
using System.Collections;

public class Axe : Item {

	public Axe()
	{
		itemSort = ItemSort.sword;
		itemQuality = ItemQuality.common;
		_damage = 5;
		_defence = 0;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = Resources.Load("Models/Items/Axe1", typeof(Mesh)) as Mesh;
		_itemSprite = Resources.Load("Sprites/Items/axe", typeof(Sprite)) as Sprite;
		_itemTexture = Resources.Load("Textures/Items/axe",typeof(Texture)) as Texture;
	}
}
