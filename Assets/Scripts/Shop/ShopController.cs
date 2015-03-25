using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopController : MonoBehaviour {

	public GameObject _buyButton;
	private List<Item> _playerItems = new List<Item>();
	private ShopInterface _shopInterface;
	private DialogueController _dialogueController;
	private InventoryInterface _inventoryInterface;

	void Awake()
	{
		_dialogueController = GameObject.FindGameObjectWithTag (Tags.GameController).GetComponent<DialogueController> ();
		_shopInterface = GetComponent<ShopInterface>();
		_inventoryInterface = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<InventoryInterface>();
	}
	void Start()
	{
		_buyButton.SetActive (false);
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
		{
			_buyButton.SetActive(true);
			_dialogueController.WelcomeMessage(this.transform.position + new Vector3(0,3,0));
			_inventoryInterface.SwapButtons();
			_inventoryInterface.onShop = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			_buyButton.SetActive(false);
			_inventoryInterface.SwapButtons();
			_inventoryInterface.onShop = false;
		}
	}
}
