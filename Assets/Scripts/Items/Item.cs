using UnityEngine;
using System.Collections;

public class Item{
	public enum ItemSort
	{
		helm,
		sword,
		shield,
		body,
		legs,
		boots
	}
	public enum ItemQuality
	{
		common,
		uncommon,
		rare,
		legendary
	}
	public ItemSort itemSort;
	public ItemQuality itemQuality;
	protected int _damage;
	protected int _defence;
	protected bool _equiped = false;
	protected Mesh _itemMesh;
	protected Texture _itemTexture;
	protected Sprite _itemSprite;

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
	public int GetItemDefence()
	{
		return _defence;
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
