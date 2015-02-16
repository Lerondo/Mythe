using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentController : MonoBehaviour {
	public GameObject playerSword;

	//all item ids for character interface
	private int _swordId;
	private int _shieldId;
	private int _helmId;
	private int _legsId;
	private int _bodyId;
	private int _bootsId;

	private PlayerStats _playerStats;
	private ItemDatabase _itemDatabase;
	// Use this for initialization
	void Start () {
		_itemDatabase = GetComponent<ItemDatabase>();
		_playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		//TODO: get save file and equip items.
	}
	/// <summary>
	/// Equips a item.
	/// </summary>
	/// <param name="itemId">Item identifier.</param>
	public void EquipItem(int itemId)
	{
		if(_itemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.sword)
		{
			UpdateItemStats(_swordId,itemId);
			_swordId = itemId;
			playerSword.renderer.material.mainTexture = _itemDatabase.GetItemTexture(itemId);
			playerSword.GetComponent<MeshFilter>().mesh = _itemDatabase.GetItemMesh(itemId);
		} 
		else if(_itemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.shield)
		{
			UpdateItemStats(_shieldId,itemId);
			_shieldId = itemId;
		} else if(_itemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.helm)
		{
			UpdateItemStats(_helmId,itemId);
			_helmId = itemId;
		} else if(_itemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.legs)
		{
			UpdateItemStats(_legsId,itemId);
			_legsId = itemId;
		} else if(_itemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.body)
		{
			UpdateItemStats(_bodyId,itemId);
			_bodyId = itemId;
		} else if(_itemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.boots)
		{
			UpdateItemStats(_bootsId,itemId);
			_bootsId = itemId;
		} else if(_itemDatabase.itemList[itemId] == null)
		{
			Debug.LogError("Item does not exist!");
		}
	}
	private void UpdateItemStats(int oldItemId,int newItemId)
	{
		int newDamage = _itemDatabase.itemList[newItemId].GetItemDamage();
		int oldDamage = _itemDatabase.itemList[oldItemId].GetItemDamage();
		int newDefence = _itemDatabase.itemList[newItemId].GetItemDefence();
		int oldDefence = _itemDatabase.itemList[oldItemId].GetItemDefence();
		_playerStats.UpdateDamage(oldDamage,newDamage);
		_playerStats.UpdateDefence(oldDefence,newDefence);
	}
}
