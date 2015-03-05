using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemDatabase : MonoBehaviour {
	public static List<Item> itemList = new List<Item>();
	// Use this for initialization
	void Awake () {
		//add all curren usable items inside this list.
		itemList.Add(new WoodenSword());
		itemList.Add(new Axe());
		itemList.Add(new SteelSword ());

		for(int i = 0; i < itemList.Count; i++)
		{
			itemList[i].itemId = i;
		}
	}
	public static List<Item> GetItemsViaId(List<int> itemIds)
	{
		List<Item> newItemList = new List<Item>();
		for(int i = 0; i < itemIds.Count;i++)
		{
			newItemList.Add(itemList[itemIds[i]]);
		}
		return newItemList;
	}
}
