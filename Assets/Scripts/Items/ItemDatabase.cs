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
	public static Item GetRandomItem()
	{
		int randomItem = Random.Range(0,ItemDatabase.itemList.Count);
		float randomizedStats = Random.Range(5,15);
		randomizedStats *= 0.1f;
		Item newItem = itemList[randomItem];
		newItem.itemDamage = Mathf.FloorToInt(newItem.itemDamage * randomizedStats);
		newItem.itemDefence = Mathf.FloorToInt(newItem.itemDefence * randomizedStats);
		newItem.itemMagicDamage = Mathf.FloorToInt(newItem.itemMagicDamage * randomizedStats);
		newItem.itemBuyValue = Mathf.FloorToInt(newItem.itemBuyValue * randomizedStats);
		newItem.itemSellValue = Mathf.FloorToInt(newItem.itemSellValue * randomizedStats);
		return newItem;
	}
}
