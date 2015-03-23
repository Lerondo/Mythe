using UnityEngine;
using System.Collections;

public class ObsidianDagger : Item {
	
	public ObsidianDagger()
	{
		itemSort = ItemSort.Weapon;
		_offHandWieldAble = true;
		itemQuality = ItemQuality.Rare;
		_weaponSort = WeaponSort.Sword;
		_name = "Obsidian Dagger";
		_damage = 7;
		_magicDamage = 0;
		_defence = 0;
		_levelRequirement = 5;
		_buyValue = (_damage + _defence) * 3;
		_sellValue = Mathf.FloorToInt(_buyValue / 3);
		_itemMesh = "Models/Items/Obsidian_dagger";
		_itemSprite = "Sprites/Items/dagger";
		_itemTexture = "Textures/Items/dagger";
		//_itemMesh = Resources.Load("Models/Items/Axe1", typeof(Mesh)) as Mesh;
		//_itemSprite = Resources.Load("Sprites/Items/axe", typeof(Sprite)) as Sprite;
		//_itemTexture = Resources.Load("Textures/Items/axe",typeof(Texture)) as Texture;
	}
}
