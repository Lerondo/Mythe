using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item : System.Object{
	public enum ItemSort
	{
		Helm,
		Weapon,
		OffHand,
		Body,
		Legs,
		Boots
	}
	public enum ItemQuality
	{
		Common,
		Uncommon,
		Rare,
		Legendary
	}
	public ItemSort itemSort;
	public ItemQuality itemQuality;
	public int itemId;
	protected string _name;
	protected int _damage;
	protected int _magicDamage;
	protected int _defence;
	protected int _buyValue;
	protected int _sellValue;
	protected int _levelRequirement;
	protected bool _equiped = false;
	protected string _itemMesh;
	protected string _itemTexture;
	protected string _itemSprite;
	public string itemName
	{
		get{
			return _name;
		}
		set{
			_name = value;
		}
	}
	public int levelRequirement
	{
		get{
			return _levelRequirement;
		}
		set{
			_levelRequirement = value;
		}
	}
	public ItemSort currentItemSort
	{
		get
		{
			return itemSort;
		}
		set
		{
			itemSort = value;
		}
	}
	public ItemQuality currentItemQuality
	{
		get{
		return itemQuality;
		}
		set{
			itemQuality = value;
		}
	}
	public int itemDamage
	{
		get{
		return _damage;
		}
		set{
			_damage = value;
		}
	}
	public int itemMagicDamage
	{
		get{
			return _magicDamage;
		}
		set{
			_magicDamage = value;
		}
	}
	public int itemDefence
	{
		get{
			return _defence;
		}
		set{
			_defence = value;
		}
	}
	public int itemBuyValue
	{
		get{
			return _buyValue;
		}
		set{
			_buyValue = value;
		}
	}
	public int itemSellValue
	{
		get{
			return _sellValue;
		}
		set{
			_sellValue = value;
		}
	}
	public string itemMesh
	{
		get{
			return _itemMesh;
		}
		set{
			_itemMesh = value;
		}
	}
	public string itemTexture
	{
		get{
			return _itemTexture;
		}
		set{
			_itemTexture = value;
		}
	}
	public string itemSprite
	{
		get{
			return _itemSprite;
		}
		set{
			_itemSprite = value;
		}
	}
}
