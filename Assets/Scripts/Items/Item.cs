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
	protected ItemSort _itemSort;
	protected ItemQuality _itemQuality;
	protected int _damage;
	protected int _defence;
	protected bool _equiped = false;

	public ItemSort GetItemSort()
	{
		return _itemSort;
	}
	public ItemQuality GetItemQuality()
	{
		return _itemQuality;
	}
	public int GetItemDamage()
	{
		return _damage;
	}
	public int GetItemDefence()
	{
		return _defence;
	}
}
