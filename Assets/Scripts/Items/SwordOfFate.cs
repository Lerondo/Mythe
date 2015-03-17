using UnityEngine;
using System.Collections;

public class SwordOfFate : Item {

	public SwordOfFate()
	{
		itemSort = ItemSort.Weapon;
		itemQuality = ItemQuality.Legendary;
		_name = "Sword of Fate";
		_damage = 11;
		_magicDamage = 5;
		_defence = 0;
		_levelRequirement = 8;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/Sword_Of_Fate";
		_itemSprite = "Sprites/Items/dagger";
		_itemTexture = "Textures/Items/swordoffate";
		//_itemMesh = Resources.Load("Models/Items/Axe1", typeof(Mesh)) as Mesh;
		//_itemSprite = Resources.Load("Sprites/Items/axe", typeof(Sprite)) as Sprite;
		//_itemTexture = Resources.Load("Textures/Items/axe",typeof(Texture)) as Texture;
	}
}