using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentController : MonoBehaviour {
	public GameObject playerSword;
	public List<Item> equipedItems = new List<Item>();

	//all items for player
	public Item _sword;
	public Item _shield = new Item();
	public Item _helm = new Item();
	public Item _legs = new Item();
	public Item _body = new Item();
	public Item _boots = new Item();

	private PlayerStats _playerStats;
	// Use this for initialization
	void Start () {
		_playerStats = GameObject.FindGameObjectWithTag(TagManager.Player).GetComponent<PlayerStats>();
		_sword = new WoodenSword();
		EquipItem(_sword);
		//making fake items! (gets replaced by real items later on)
		_shield.itemSort = Item.ItemSort.Shield;
		_helm.itemSort = Item.ItemSort.Helm;
		_legs.itemSort = Item.ItemSort.Legs;
		_body.itemSort = Item.ItemSort.Body;
		_boots.itemSort = Item.ItemSort.Boots;
		equipedItems.Add(_sword);
		equipedItems.Add(_shield);
		equipedItems.Add(_helm);
		equipedItems.Add(_legs);
		equipedItems.Add(_body);
		equipedItems.Add(_boots);
		//TODO: get save file and equip items.
		//foreach(Item item in equipedItems){ EquipItem(item); }
	}
	public List<Item> GetEquipedItem()
	{
		return equipedItems;
	}
	public List<int> GetEquipedItemIds()
	{
		List<int> newItemList = new List<int>();
		for(int i = 0; i < equipedItems.Count;i++)
		{
			newItemList.Add(equipedItems[i].itemId);
		}
		return newItemList;
	}
	/// <summary>
	/// Equips a item.
	/// </summary>
	public Item EquipItem(Item item)
	{
		Item oldItem = null;
		for (int i = 0; i < equipedItems.Count; i++) {
			if(item.itemSort == equipedItems[i].itemSort)
			{
				oldItem = equipedItems[i];
				_playerStats.UpdateDamage(item.GetItemDamage(),equipedItems[i].GetItemDamage());
				_playerStats.UpdateDefence(item.GetItemDefence(),equipedItems[i].GetItemDefence());
				equipedItems[i] = item;
			}
		}
		if(item.itemSort == Item.ItemSort.Weapon)
		{
			playerSword.GetComponent<MeshFilter>().mesh = item.GetItemMesh();
			playerSword.renderer.material.mainTexture = item.GetItemTexture();
		}
		return oldItem;
	}
}
