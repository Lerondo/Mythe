using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopController : MonoBehaviour {

	public GameObject _buyButton;
	private List<Item> _playerItems = new List<Item>();
	private ShopInterface _shopInterface;
	private DialogueController _dialogueController;

	void Awake()
	{
		_dialogueController = GameObject.FindGameObjectWithTag (TagManager.GameController).GetComponent<DialogueController> ();
		_shopInterface = GetComponent<ShopInterface>();
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
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
			_buyButton.SetActive(false);
	}
}
