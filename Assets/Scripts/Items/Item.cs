using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item{
	public enum ItemSort
	{
		Helm,
		Weapon,
		Shield,
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
	protected bool _equiped = false;
	protected Mesh _itemMesh;
	protected Texture _itemTexture;
	protected Sprite _itemSprite;

	public string GetItemName()
	{
		return _name;
	}
	public ItemSort GetItemSort()
	{
		return itemSort;
	}
	public ItemQuality GetItemQuality()
	{
		return itemQuality;
	}
	public int GetItemDamage()
	{
		return _damage;
	}
	public int GetItemMagicDamage()
	{
		return _magicDamage;
	}
	public int GetItemDefence()
	{
		return _defence;
	}
	public int GetItemBuyValue()
	{
		return _buyValue;
	}
	public int GetItemSellValue()
	{
		return _sellValue;
	}
	public Mesh GetItemMesh()
	{
		return _itemMesh;
	}
	public Texture GetItemTexture()
	{
		return _itemTexture;
	}
	public Sprite GetItemSprite()
	{
		return _itemSprite;
	}
}
