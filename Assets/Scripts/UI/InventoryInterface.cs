using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour {
	public Text statText;
	public Text goldText;
	public Text lvlRequirementText;
	public Sprite emptySlot;
	public GameObject controllerMenu;
	public GameObject inventoryInterface;
	public GameObject equipOffHandButton;
	
	private PlayerStats _playerStats;
	private Inventory _playerInventory;
	private int selectedButtonId;
	private Item selectedItem;
	private Button[] allButtons = new Button[24];
	void Awake()
	{
		_playerStats = GameObject.Find ("Player").GetComponent<PlayerStats> ();
		_playerInventory = GetComponent<Inventory>();
	}
	void Start()
	{
		float counter = 0;
		GameObject[] allItemSlots = new GameObject[24];
		for (int i = 0; i < allItemSlots.Length; i++) 
		{
			counter++;
			allItemSlots[i] = GameObject.Find("Slot" + counter);
		}
		for (int i = 0; i < allItemSlots.Length; i++) {
			allButtons[i] = allItemSlots[i].GetComponent<Button>();
		}
		inventoryInterface.SetActive(false);
		equipOffHandButton.SetActive (false);
		lvlRequirementText.text = "";
	}
	public void UpdateInterface()
	{
		ResetInventoryTexts();
	}
	public void Back()
	{
		controllerMenu.SetActive(true);
		inventoryInterface.SetActive(false);
	}
	public void SetInventorySpace(int slot, Item item)
	{
		Sprite itemSprite = Resources.Load(item.itemSprite, typeof(Sprite)) as Sprite;
		allButtons[slot].GetComponent<Image>().sprite = itemSprite;
		allButtons[slot].onClick.AddListener(() => ShowStats(slot,item));
	}
	public void ResetInventorySpace(int slot)
	{
		allButtons[slot].GetComponent<Image>().sprite = emptySlot;
		allButtons[slot].onClick.RemoveAllListeners();
		ResetInventoryTexts();
	}
	public void ShowStats(int buttonSlot, Item item)
	{
		string stats = "";
		stats += item.itemSort + "\n";
		stats += item.itemQuality + "\n";
		stats += item.itemDamage + "\n";
		stats += item.itemDefence + "\n";
		stats += "LevelRequirement: " + item.levelRequirement;
		statText.text = stats;
		selectedButtonId = buttonSlot;
		selectedItem = item;
		if (item.offHandWieldAble == true)
			equipOffHandButton.SetActive(true);
		else
			equipOffHandButton.SetActive(false);
		if (selectedItem.levelRequirement > _playerStats.level)
			lvlRequirementText.text = "Level not high enough!";
		else
			lvlRequirementText.text = "";
	}
	public void EquipCurrentSelected(bool offHand)
	{
		if (selectedItem != null)
		{
			if(_playerStats.level >= selectedItem.levelRequirement)
			{
				if(offHand)
				{
					equipOffHandButton.SetActive(false);
					selectedItem.itemSort = Item.ItemSort.OffHand;
				}
				Item oldItem = GetComponent<Equipment>().EquipItem(selectedItem);
				_playerInventory.RemovePlayerItem(selectedItem);
				SetInventorySpace(selectedButtonId, oldItem);
				selectedItem = null;
				ResetInventoryTexts();
			}
		}
	}
	public void ResetInventoryTexts()
	{
		lvlRequirementText.text = "";
		statText.text = "";
		goldText.text = "Gold : " + _playerStats.gold;
	}
}
