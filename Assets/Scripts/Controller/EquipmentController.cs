using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentController : MonoBehaviour {
	public GameObject playerSword;
	public List<Item> equipedItems = new List<Item>();

	//all items for player
	public Item _sword = new Item();
	public Item _shield = new Item();
	public Item _helm = new Item();
	public Item _legs = new Item();
	public Item _body = new Item();
	public Item _boots = new Item();

	private PlayerStats _playerStats;
	// Use this for initialization
	void Start () {
		_playerStats = GameObject.FindGameObjectWithTag(TagManager.Player).GetComponent<PlayerStats>();

		//making fake items! (gets replaced by real items later on)
		_sword.itemSort = Item.ItemSort.sword;
		_shield.itemSort = Item.ItemSort.shield;
		_helm.itemSort = Item.ItemSort.helm;
		_legs.itemSort = Item.ItemSort.legs;
		_body.itemSort = Item.ItemSort.body;
		_boots.itemSort = Item.ItemSort.boots;
		equipedItems.Add(_sword);
		equipedItems.Add(_shield);
		equipedItems.Add(_helm);
		equipedItems.Add(_legs);
		equipedItems.Add(_body);
		equipedItems.Add(_boots);
		//TODO: get save file and equip items.
	}
	/// <summary>
	/// Equips a item.
	/// </summary>
	public void EquipItem(Item item)
	{
		for (int i = 0; i < equipedItems.Count; i++) {
			if(item.itemSort == equipedItems[i].itemSort)
			{
				_playerStats.UpdateDamage(item.GetItemDamage(),equipedItems[i].GetItemDamage());
				_playerStats.UpdateDefence(item.GetItemDefence(),equipedItems[i].GetItemDefence());
				equipedItems[i] = item;
				break;
			}
		}
		if(item.itemSort == Item.ItemSort.sword)
		{
			playerSword.GetComponent<MeshFilter>().mesh = item.GetItemMesh();
			playerSword.renderer.material.mainTexture = item.GetItemTexture();
		}
	}
}
