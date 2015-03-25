using UnityEngine;
using System.Collections;

[System.Serializable]
public class Axe : Item {

	public Axe()
	{
		itemSort = ItemSort.Weapon;
		itemQuality = ItemQuality.Common;
		_weaponSort = WeaponSort.Sword;
		_name = "Hunter's Axe";
		_damage = 5;
		_magicDamage = 0;
		_defence = 0;
		_levelRequirement = 3;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/Axe1";
		_itemSprite = "Sprites/Items/Axe1";
		_itemTexture = "Textures/Items/Axe1";
		//_itemMesh = Resources.Load("Models/Items/Axe1", typeof(Mesh)) as Mesh;
		//_itemSprite = Resources.Load("Sprites/Items/axe", typeof(Sprite)) as Sprite;
		//_itemTexture = Resources.Load("Textures/Items/axe",typeof(Texture)) as Texture;
	}
}
