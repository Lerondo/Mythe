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
	public void AddItem(Item newItem)
	{
		_playerItems.Add(newItem);
	}
	public void ShowCurrentItems()
	{
		for (int i = 0; i < _playerItems.Count; i++) {
			int itemId = ItemDatabase.itemList.IndexOf(_playerItems[i]);
			_inventoryInterface.SetInventorySpace(itemId,i);
		}
	}
}
