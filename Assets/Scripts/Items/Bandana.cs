using UnityEngine;
using System.Collections;

public class Bandana : Item {
	
	public Bandana()
	{
		itemSort = ItemSort.Helm;
		itemQuality = ItemQuality.Uncommon;
		_name = "Bandana of the Thief";
		_damage = 0;
		_magicDamage = 0;
		_defence = 3;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/bandana";
		_itemSprite = "Sprites/Items/bandana";
		_itemTexture = "Textures/Items/bandana";
		//_itemMesh = Resources.Load("Models/Items/Axe1", typeof(Mesh)) as Mesh;
		//_itemSprite = Resources.Load("Sprites/Items/axe", typeof(Sprite)) as Sprite;
		//_itemTexture = Resources.Load("Textures/Items/axe",typeof(Texture)) as Texture;
	}
}
