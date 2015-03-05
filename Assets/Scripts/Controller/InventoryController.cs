using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour {
	private List<Item> _playerItems = new List<Item>();
	private InventoryInterface _inventoryInterface;
	void Awake()
	{
		_inventoryInterface = GetComponent<InventoryInterface>();
	}
	public List<Item> GetInventory()
	{
		return _playerItems;
	}
	public void SetInventory(List<Item> inventory)
	{
		_playerItems = inventory;
	}
	public void RemovePlayerItem(Item item)
	{
		_playerItems.Remove(item);
	}
	public Item GetPlayerItem(int item)
	{
		return _playerItems[item];
	}
	public void AddItem(Item newItem)
	{
		_playerItems.Add(newItem);
	}
	public List<int> GetInventoryItemIds()
	{
		List<int> newItemList = new List<int>();
		for(int i = 0; i < _playerItems.Count;i++)
		{
			newItemList.Add(_playerItems[i].itemId);
		}
		return newItemList;
	}
	public void ShowCurrentItems()
	{
		for (int i = 0; i < _playerItems.Count; i++) {
			_inventoryInterface.SetInventorySpace(i,_playerItems[i]);
		}
	}
}
