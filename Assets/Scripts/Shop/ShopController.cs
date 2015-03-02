using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopController : MonoBehaviour {

	public GameObject _buyButton;
	private List<Item> _playerItems = new List<Item>();
	private ShopInterface _shopInterface;
	void Awake()
	{
		_shopInterface = GetComponent<ShopInterface>();
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
	public void ShowCurrentItems()
	{
		for (int i = 0; i < _playerItems.Count; i++) {
			_shopInterface.SetShopSpace(i,_playerItems[i]);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
			_buyButton.SetActive(true);
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
			_buyButton.SetActive(false);
	}
}
