using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentController : MonoBehaviour {
	private int _swordId;
	private int _shieldId;
	private int _helmId;
	private int _legsId;
	private int _bodyId;
	private int _bootsId;
	// Use this for initialization
	void Start () {
		//TODO: get save file and equip items.
	}
	public void EquipItem(int itemId)
	{
		if(ItemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.sword)
		{
			_swordId = itemId;
			//TODO: set mesh and texture;
		} else if(ItemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.shield)
		{
			_shieldId = itemId;
		} else if(ItemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.helm)
		{
			_helmId = itemId;
		} else if(ItemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.legs)
		{
			_legsId = itemId;
		} else if(ItemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.body)
		{
			_bodyId = itemId;
		} else if(ItemDatabase.itemList[itemId].GetItemSort() == Item.ItemSort.boots)
		{
			_bootsId = itemId;
		} else if(ItemDatabase.itemList[itemId] == null)
		{
			Debug.LogError("Item does not exist!");
		}
	}
}
