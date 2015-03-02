using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopInterface : MonoBehaviour {
	public Text statText;
	public Text goldText;
	public Text costText;
	public Sprite emptySlot;
	public GameObject controllerMenu;
	public GameObject shopInterface;

	private List<Item> _shopList = new List<Item> ();
	private InventoryController _playerInventory;
	private PlayerStats _playerStats;
	private int selectedButtonId;
	private Item selectedItem;
	private Button[] allButtons = new Button[15];
	void Awake()
	{
		_playerInventory = GetComponent<InventoryController>();
		_playerStats = GameObject.Find("Player").GetComponent<PlayerStats> ();
	}
	void Start()
	{
		float counter = 0;
		GameObject[] allItemSlots = new GameObject[15];
		for (int i = 0; i < allItemSlots.Length; i++) 
		{
			counter++;
			allItemSlots[i] = GameObject.Find("ShopSlot" + counter);
		}
		for (int i = 0; i < allItemSlots.Length; i++) {
			allButtons[i] = allItemSlots[i].GetComponent<Button>();
			Item newShopItem = ItemDatabase.itemList[Random.Range(0,ItemDatabase.itemList.Count)];
			SetShopSpace(i,newShopItem);
		}
		shopInterface.SetActive (false);
	}
	public void Back()
	{
		controllerMenu.SetActive(true);
		shopInterface.SetActive (false);
	}
	public void SetShopSpace(int slot, Item item)
	{
		Sprite itemSprite = item.GetItemSprite();
		allButtons[slot].GetComponent<Image>().sprite = itemSprite;
		allButtons[slot].onClick.AddListener(() => ShowStats(slot,item));
	}
	public void ResetShopSpace(int slot)
	{
		allButtons[slot].GetComponent<Image>().sprite = emptySlot;
		allButtons[slot].onClick.RemoveAllListeners();
		statText.text = "";
	}
	public void ShowStats(int buttonSlot, Item item)
	{
		string stats = "";
		stats += item.GetItemSort() + "\n";
		stats += item.GetItemQuality() + "\n";
		stats += item.GetItemDamage() + "\n";
		stats += item.GetItemDefence() + "\n";
		stats += item.GetItemBuyValue ();
		statText.text = stats;
		selectedButtonId = buttonSlot;
		selectedItem = item;
	}
	public void BuyCurrentSelected()
	{
		Item item = selectedItem;
		if (item.GetItemBuyValue() <= _playerStats.GetGold())
		{
			_playerStats.UpdateGold(-item.GetItemBuyValue());
			_playerInventory.AddItem(selectedItem);
			ResetShopSpace(selectedButtonId);
		}else {
			Debug.Log("Not Enough Gold");
		}
	}
}
