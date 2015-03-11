using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopInterface : MonoBehaviour {
	public Text statText;
	public Text goldText;
	public Text costText;
	public Text insufficientText;
	public Sprite emptySlot;
	public GameObject controllerMenu;
	public GameObject shopInterface;
	private DialogueController _dialogueController;
	public GameObject merchant;

	private InventoryController _playerInventory;
	private PlayerStats _playerStats;
	private int selectedButtonId;
	private Item selectedItem;
	private Button[] allButtons = new Button[15];
	void Awake()
	{
		_dialogueController = GetComponent<DialogueController> ();
		_playerInventory = GetComponent<InventoryController>();
		_playerStats = GameObject.Find("Player").GetComponent<PlayerStats> ();
	}
	void Start()
	{
		merchant = GameObject.Find (TagManager.Merchant);
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
		insufficientText.enabled = false;
	}
	public void Back()
	{
		controllerMenu.SetActive(true);
		shopInterface.SetActive (false);
		_dialogueController.LeaveMessage (merchant.transform.position + new Vector3(0,3,0));
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
		stats += item.GetItemName() + "\n";
		stats += item.GetItemQuality() + "\n";
		if (!CheckIfZero(item.GetItemDamage()))
			stats += "Damage : " + item.GetItemDamage() + "\n";
		if (!CheckIfZero(item.GetItemMagicDamage()))
			stats += "Magic Dmg : " + item.GetItemMagicDamage() + "\n";
		if (!CheckIfZero(item.GetItemDefence()))
			stats += "Defence : " + item.GetItemDefence ();
		statText.text = stats;
		selectedButtonId = buttonSlot;
		selectedItem = item;
		costText.text = "Cost : " + item.GetItemBuyValue ();
		goldText.text = "Gold : " + _playerStats.GetGold () + " > " + (_playerStats.GetGold () - item.GetItemBuyValue ());
		if (_playerStats.GetGold() - item.GetItemBuyValue() < 0)
			insufficientText.enabled = true;
		else 
			insufficientText.enabled = false;
	}
	public bool CheckIfZero(float currentStat)
	{
		if(currentStat > 0)
		{
			return false;
		}
		return true;
	}
	public void BuyCurrentSelected()
	{
		Item item = selectedItem;
		if (selectedItem != null)
		{
			if (item.GetItemBuyValue() <= _playerStats.GetGold())
			{
				_playerStats.UpdateGold(-item.GetItemBuyValue());
				_playerInventory.AddItem(selectedItem);
				ResetShopSpace(selectedButtonId);
				ResetTexts();
				selectedItem = null;
			}
		}
	}
	public void ResetTexts()
	{
		costText.text = "Cost : ";
		goldText.text = "Gold : " + _playerStats.GetGold ();
	}
}
