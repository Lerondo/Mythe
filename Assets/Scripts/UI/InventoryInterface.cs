using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour {
	public Text statText;
	public Text goldText;
	public Sprite emptySlot;
	public GameObject controllerMenu;
	public GameObject inventoryInterface;

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
	}
	public void UpdateInterface()
	{
		goldText.text = "Gold : " + _playerStats.gold;
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
		statText.text = "";
	}
	public void ShowStats(int buttonSlot, Item item)
	{
		string stats = "";
		stats += item.itemSort + "\n";
		stats += item.itemQuality + "\n";
		stats += item.itemDamage + "\n";
		stats += item.itemDefence;
		statText.text = stats;
		selectedButtonId = buttonSlot;
		selectedItem = item;
	}
	public void EquipCurrentSelected()
	{
		Item oldItem = GetComponent<Equipment>().EquipItem(selectedItem);
		_playerInventory.RemovePlayerItem(selectedItem);
		SetInventorySpace(selectedButtonId, oldItem);
	}
}
