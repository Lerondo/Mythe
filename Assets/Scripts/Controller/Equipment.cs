using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {
	public GameObject playerRH;
	public GameObject playerLH;
	public GameObject playerHelm;
	public List<Item> equipedItems = new List<Item>();

	//all items for player
	public Item _sword;
	public Item _offHand = new Item();
	public Item _helm = new Item();
	public Item _legs = new Item();
	public Item _body = new Item();
	public Item _boots = new Item();

	private Dictionary<Item.ItemSort, GameObject> _itemObject = new Dictionary<Item.ItemSort, GameObject>();
	private PlayerStats _playerStats;
	// Use this for initialization
	void Awake()
	{
		_playerStats = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStats>();
	}
	void Start () {
		//Dictionary for changing the gameobjects etc.;
		_itemObject.Add(Item.ItemSort.Weapon, playerRH);
		_itemObject.Add(Item.ItemSort.OffHand, playerLH);
		_itemObject.Add(Item.ItemSort.Helm, playerHelm);
		if(_playerStats.username == "")
		{
			_sword = new SwordOfFate();
			EquipItem(_sword);
			//making fake items! (gets replaced by real items later on)
			_offHand.itemSort = Item.ItemSort.OffHand;
			_helm.itemSort = Item.ItemSort.Helm;
			_legs.itemSort = Item.ItemSort.Legs;
			_body.itemSort = Item.ItemSort.Body;
			_boots.itemSort = Item.ItemSort.Boots;
			equipedItems.Add(_sword);
			equipedItems.Add(_offHand);
			equipedItems.Add(_helm);
			equipedItems.Add(_legs);
			equipedItems.Add(_body);
			equipedItems.Add(_boots);
		}
	}
	public int GetDamage()
	{
		int damage = 0;
		foreach(Item item in equipedItems)
		{
			damage += item.itemDamage;
		}
		return damage;
	}
	public List<Item> GetEquipedItem()
	{
		return equipedItems;
	}
	public List<int> GetEquipedItemIds()
	{
		List<int> newItemList = new List<int>();
		for(int i = 0; i < equipedItems.Count;i++)
		{
			newItemList.Add(equipedItems[i].itemId);
		}
		return newItemList;
	}
	public void EquipAllItems(List<Item> itemList)
	{
		foreach(Item item in itemList)
		{
			EquipItem(item);
		}
	}
	/// <summary>
	/// Equips a item.
	/// </summary>
	public Item EquipItem(Item item)
	{
		Item oldItem = null;
		for (int i = 0; i < equipedItems.Count; i++) {
			if(item.itemSort == equipedItems[i].itemSort)
			{
				oldItem = equipedItems[i];
				equipedItems[i] = item;
			}
		}
		if(_itemObject.ContainsKey(item.itemSort))
		{
			_itemObject[item.itemSort].GetComponent<MeshFilter>().mesh = Resources.Load(item.itemMesh,typeof(Mesh)) as Mesh;
			_itemObject[item.itemSort].renderer.material.mainTexture = Resources.Load(item.itemTexture, typeof(Texture)) as Texture;
		}
		return oldItem;
	}
}
