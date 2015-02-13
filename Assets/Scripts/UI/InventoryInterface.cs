using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour {
	public Text statText;
	public GameObject controllerMenu;
	public GameObject inventoryInterface;

	private Button[] allButtons = new Button[30];
	private ItemDatabase _itemDatabase;
	void Awake()
	{
		_itemDatabase = GetComponent<ItemDatabase>();
	}
	void Start()
	{
		float counter = 0;
		GameObject[] allItemSlots = new GameObject[30];
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
	public void Back()
	{
		controllerMenu.SetActive(true);
		inventoryInterface.SetActive(false);
	}
	public void SetInventorySpace(int itemId, int slot)
	{
		Sprite itemSprite = _itemDatabase.GetItemSprite(itemId);
		allButtons[slot].GetComponent<Image>().sprite = itemSprite;
		allButtons[slot].onClick.AddListener(() => ShowStats(itemId));
		Debug.Log(ItemDatabase.itemList[itemId].GetItemSort());
	}
	public void ShowStats(int itemId)
	{
		string stats = "";
		stats += ItemDatabase.itemList[itemId].GetItemSort() + "\n";
		stats += ItemDatabase.itemList[itemId].GetItemQuality() + "\n";
		stats += ItemDatabase.itemList[itemId].GetItemDamage() + "\n";
		stats += ItemDatabase.itemList[itemId].GetItemDefence();
		statText.text = stats;
	}
}
