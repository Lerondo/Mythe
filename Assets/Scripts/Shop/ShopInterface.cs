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
	private GameObject _merchant;

	private Inventory _playerInventory;
	private PlayerStats _playerStats;
	private int _selectedButtonId;
	private List<Item> _currentShopItems = new List<Item>();
	private List<GameObject> _allItemSlots = new List<GameObject>();
	private float _beginTime;
	private Item _selectedItem;
	private Button[] _allButtons = new Button[15];
	private int _slotCount = 15;
	void Awake()
	{
		_dialogueController = GetComponent<DialogueController> ();
		_playerInventory = GetComponent<Inventory>();
		_playerStats = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStats> ();
	}
	void Start()
	{
		_beginTime = Time.time;
		_merchant = GameObject.FindGameObjectWithTag (Tags.Merchant);
		float counter = 0;
		for (int i = 0; i < _slotCount; i++) 
		{
			counter++;
			_allItemSlots.Add(GameObject.Find("ShopSlot" + counter));
		}
		GenerateNewItems();
		shopInterface.SetActive (false);
		insufficientText.enabled = false;
	}
	private void GenerateNewItems()
	{
		_currentShopItems.Clear();
		for (int i = 0; i < _allItemSlots.Count; i++) {
			_allButtons[i] = _allItemSlots[i].GetComponent<Button>();
			Item newShopItem = ItemDatabase.itemList[Random.Range(0,ItemDatabase.itemList.Count)];
			SetShopSpace(i,newShopItem);
			_currentShopItems.Add(newShopItem);
		}
		_beginTime = Time.time;
	}
	public void CheckSwapItems()
	{
		if(_beginTime > Time.time + 900)
		{
			GenerateNewItems();
		}
	}
	public void Back()
	{
		ResetTexts ();
		controllerMenu.SetActive(true);
		shopInterface.SetActive (false);
		_dialogueController.LeaveMessage (_merchant.transform.position + new Vector3(0,3,0));
	}
	public void SetShopSpace(int slot, Item item)
	{
		Sprite itemSprite = Resources.Load(item.itemSprite, typeof(Sprite)) as Sprite;
		_allButtons[slot].GetComponent<Image>().sprite = itemSprite;
		_allButtons[slot].onClick.AddListener(() => ShowStats(slot,item));
	}
	public void ResetShopSpace(int slot)
	{
		_allButtons[slot].GetComponent<Image>().sprite = emptySlot;
		_allButtons[slot].onClick.RemoveAllListeners();
		statText.text = "";
	}
	public void ShowStats(int buttonSlot, Item item)
	{
		string stats = "";
		stats += item.currentItemSort + "\n";
		stats += item.itemName + "\n";
		stats += item.itemQuality + "\n";

		if (!CheckIfZero(item.itemDamage))
			stats += "Damage : " + item.itemDamage + "\n";
		if (!CheckIfZero(item.itemMagicDamage))
			stats += "Magic Dmg : " + item.itemMagicDamage + "\n";
		if (!CheckIfZero(item.itemDefence))
			stats += "Defence : " + item.itemDefence;
		stats += "LevelRequirement: " + item.levelRequirement;
		statText.text = stats;
		_selectedButtonId = buttonSlot;
		_selectedItem = item;
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
		Item item = _selectedItem;
		if (_selectedItem != null)
		{
			if (item.itemBuyValue <= _playerStats.gold)
			{
				_playerStats.UpdateGold(-item.itemBuyValue);
				_playerInventory.AddItem(_selectedItem);
				ResetShopSpace(_selectedButtonId);
				ResetTexts();
				_selectedItem = null;
			}
		}
	}
	public void ResetTexts()
	{
		statText.text = "Stats";
		costText.text = "Cost : ";
		goldText.text = "Gold : " + _playerStats.gold;
	}
}
