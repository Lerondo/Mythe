using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {
	public GameObject playerRH;
	public GameObject playerLH;
	public GameObject playerHelm;
	public GameObject bow;
	public List<Item> equipedItems = new List<Item>();
	public Animator _playerAnimator;

	//all items for player
	public Item _sword;
	public Item _offHand = new Item();
	public Item _helm = new Item();
	public Item _legs = new Item();
	public Item _body = new Item();
	public Item _boots = new Item();

	private Dictionary<Item.WeaponSort, string> _weaponSorts = new Dictionary<Item.WeaponSort, string>();
	private Dictionary<Item.ItemSort, GameObject> _itemObject = new Dictionary<Item.ItemSort, GameObject>();
	private PlayerStats _playerStats;
	// Use this for initialization
	void Awake()
	{
		GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
		_playerAnimator = player.GetComponent<Animator>();
		_playerStats = player.GetComponent<PlayerStats>();
	}
	void Start () {
		//Dictionary for changing the gameobjects etc.;
		_itemObject.Add(Item.ItemSort.Weapon, playerRH);
		_itemObject.Add(Item.ItemSort.OffHand, playerLH);
		_itemObject.Add(Item.ItemSort.Helm, playerHelm);
		_weaponSorts.Add(Item.WeaponSort.Bow, "HasBow");
		_weaponSorts.Add(Item.WeaponSort.Staff, "HasStaff");
		_weaponSorts.Add(Item.WeaponSort.Sword, "HasSword");
		if(_playerStats.username == "cheater")
		{
			_sword = new SwordOfFate();
			EquipItem(_sword);
			_helm = new Bandana();
			EquipItem(_helm);
			_offHand = new SwordOfFate();
			_offHand.itemSort = Item.ItemSort.OffHand;
			EquipItem(_offHand);
			//making fake items! (gets replaced by real items later on)

			_legs.itemSort = Item.ItemSort.Legs;
			_body.itemSort = Item.ItemSort.Body;
			_boots.itemSort = Item.ItemSort.Boots;
			equipedItems.Add(_sword);
			equipedItems.Add(_offHand);
			equipedItems.Add(_helm);
			equipedItems.Add(_legs);
			equipedItems.Add(_body);
			equipedItems.Add(_boots);
		} else {
			_sword = new WoodenSword();
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
	public int GetDefence()
	{
		int defence = 0;
		foreach(Item item in equipedItems)
		{
			defence += item.itemDefence;
		}
		return defence;
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
			if(item.weaponSort == Item.WeaponSort.Bow)
			{
				_itemObject[item.itemSort].GetComponent<MeshFilter>().mesh = null;
				_itemObject[item.itemSort].GetComponent<Renderer>().material.mainTexture = null;
				bow.SetActive(true);
			} 
			else 
			{
				if(bow.activeSelf)
				{
					bow.SetActive(false);
				}
				_itemObject[item.itemSort].GetComponent<MeshFilter>().mesh = Resources.Load(item.itemMesh,typeof(Mesh)) as Mesh;
				_itemObject[item.itemSort].GetComponent<Renderer>().material.mainTexture = Resources.Load(item.itemTexture, typeof(Texture)) as Texture;
			}
		}
		if(item.itemSort == Item.ItemSort.Weapon)
		{
			_playerAnimator.SetBool("HasStaff", false);
			_playerAnimator.SetBool("HasSword", false);
			_playerAnimator.SetBool("HasBow", false);
			_playerAnimator.SetBool(_weaponSorts[item.weaponSort], true);
		}
		return oldItem;
	}
}
