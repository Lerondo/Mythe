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
		itemList.Add(new ObsidianDagger());
		itemList.Add(new Bandana());
		itemList.Add(new WoodenBow());
		itemList.Add(new WoodenStaff());
		itemList.Add(new BodyPlate());
		itemList.Add(new ClothHood());
		itemList.Add(new KneeCaps());
		//itemList.Add(new HipPads());
		itemList.Add(new MageHat());
		itemList.Add(new ShoulderPads());

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
		int quality = Random.Range(0,100);
		List<Item> itemsToDrop = new List<Item>();
		if(quality <= 5)
		{
			foreach(Item item in itemList)
			{
				if(item.currentItemQuality == Item.ItemQuality.Legendary)
				{
					itemsToDrop.Add(item);
				}
			}
		} 
		else if(quality <= 20)
		{
			foreach(Item item in itemList)
			{
				if(item.currentItemQuality == Item.ItemQuality.Rare)
				{
					itemsToDrop.Add(item);
				}
			}
		} 
		else if(quality <= 50)
		{
			foreach(Item item in itemList)
			{
				if(item.currentItemQuality == Item.ItemQuality.Uncommon)
				{
					itemsToDrop.Add(item);
				}
			}
		} 
		else
		{
			foreach(Item item in itemList)
			{
				if(item.currentItemQuality == Item.ItemQuality.Common)
				{
					itemsToDrop.Add(item);
				}
			}
		}
		int randomItem = Random.Range(0,itemsToDrop.Count);
		float randomizedStats = Random.Range(5,15);
		randomizedStats *= 0.1f;
		Item newItem = itemsToDrop[randomItem];
		newItem.itemDamage = Mathf.FloorToInt(newItem.itemDamage * randomizedStats);
		newItem.itemDefence = Mathf.FloorToInt(newItem.itemDefence * randomizedStats);
		newItem.itemMagicDamage = Mathf.FloorToInt(newItem.itemMagicDamage * randomizedStats);
		newItem.itemBuyValue = Mathf.FloorToInt(newItem.itemBuyValue * randomizedStats);
		newItem.itemSellValue = Mathf.FloorToInt(newItem.itemSellValue * randomizedStats);
		return newItem;
	}
}
