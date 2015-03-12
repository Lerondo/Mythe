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

	private Inventory _playerInventory;
	private PlayerStats _playerStats;
	private int selectedButtonId;
	private Item selectedItem;
	private Button[] allButtons = new Button[15];
	void Awake()
	{
		_dialogueController = GetComponent<DialogueController> ();
		_playerInventory = GetComponent<Inventory>();
		_playerStats = GameObject.Find("Player").GetComponent<PlayerStats> ();
	}
	void Start()
	{
		merchant = GameObject.Find (Tags.Merchant);
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
		Sprite itemSprite = Resources.Load(item.itemSprite, typeof(Sprite)) as Sprite;
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
		stats += item.currentItemSort + "\n";
		stats += item.itemName + "\n";
		stats += item.currentItemQuality + "\n";
		stats += item.itemSort + "\n";
		stats += item.itemName + "\n";
		stats += item.itemQuality + "\n";

		if (!CheckIfZero(item.itemDamage))
			stats += "Damage : " + item.itemDamage + "\n";
		if (!CheckIfZero(item.itemMagicDamage))
			stats += "Magic Dmg : " + item.itemMagicDamage + "\n";
		if (!CheckIfZero(item.itemDefence))
			stats += "Defence : " + item.itemDefence;
		statText.text = stats;
		selectedButtonId = buttonSlot;
		selectedItem = item;
		costText.text = "Cost : " + item.itemBuyValue;
		goldText.text = "Gold : " + _playerStats.gold + " > " + (_playerStats.gold - item.itemBuyValue);
		if (_playerStats.gold - item.itemBuyValue < 0)
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
			if (item.itemBuyValue <= _playerStats.gold)
			{
				_playerStats.UpdateGold(-item.itemBuyValue);
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
		goldText.text = "Gold : " + _playerStats.gold;
	}
}
