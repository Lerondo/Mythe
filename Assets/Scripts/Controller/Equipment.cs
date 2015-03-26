using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {
	public GameObject playerRH;
	public GameObject playerLH;
	public GameObject playerHelm;
	public GameObject playerRK;
	public GameObject playerLK;
	public GameObject playerRS;
	public GameObject playerLS;
	public GameObject playerLHip;
	public GameObject playerRHip;
	public GameObject bow;
	public List<Item> equipedItems = new List<Item>();
	public Animator _playerAnimator;

	//all items for player
	private Item _sword;
	private Item _offHand = new Item();
	private Item _helm = new Item();
	private Item _legs = new Item();
	private Item _body = new Item();
	private Item _boots = new Item();
	private Item _shoulders = new Item();

	private Dictionary<Item.WeaponSort, string> _weaponSorts = new Dictionary<Item.WeaponSort, string>();
	private Dictionary<Item.ItemSort, List<GameObject>> _itemObject = new Dictionary<Item.ItemSort, List<GameObject>>();
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
		List<GameObject> playerRightHand = new List<GameObject>();
		playerRightHand.Add(playerRH);
		List<GameObject> playerLeftHand = new List<GameObject>();
		playerLeftHand.Add(playerLH);
		List<GameObject> playerHelmList = new List<GameObject>();
		playerHelmList.Add(playerHelm);
		List<GameObject> playerKnees = new List<GameObject>();
		playerKnees.Add(playerLK);
		playerKnees.Add(playerRK);
		List<GameObject> playerShoulders = new List<GameObject>();
		playerShoulders.Add(playerLS);
		playerShoulders.Add(playerRS);
		/*List<GameObject> playerHips = new List<GameObject>();
		playerHips.Add(playerRHip);
		playerHips.Add(playerLHip); */

		_itemObject.Add(Item.ItemSort.Weapon, playerRightHand);
		_itemObject.Add(Item.ItemSort.OffHand, playerLeftHand);
		_itemObject.Add(Item.ItemSort.Helm, playerHelmList);
		_itemObject.Add(Item.ItemSort.Legs, playerKnees);
		_itemObject.Add(Item.ItemSort.Shoulders, playerShoulders);
		//_itemObject.Add(Item.ItemSort.Hips, playerHips);
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

			_legs = new KneeCaps();
			EquipItem(_legs);
			_body = new BodyPlate();
			EquipItem(_body);
			_boots.itemSort = Item.ItemSort.Boots;
			_shoulders = new ShoulderPads();
			EquipItem(_shoulders);
			equipedItems.Add(_sword);
			equipedItems.Add(_offHand);
			equipedItems.Add(_helm);
			equipedItems.Add(_legs);
			equipedItems.Add(_body);
			equipedItems.Add(_boots);
			equipedItems.Add(_shoulders);
		} else {
			_sword = new WoodenBow();
			EquipItem(_sword);
			//making fake items! (gets replaced by real items later on)
			_offHand.itemSort = Item.ItemSort.OffHand;
			_helm.itemSort = Item.ItemSort.Helm;
			_legs.itemSort = Item.ItemSort.Legs;
			_body.itemSort = Item.ItemSort.Body;
			_boots.itemSort = Item.ItemSort.Boots;
			_shoulders.itemSort = Item.ItemSort.Shoulders;
			equipedItems.Add(_sword);
			equipedItems.Add(_offHand);
			equipedItems.Add(_helm);
			equipedItems.Add(_legs);
			equipedItems.Add(_body);
			equipedItems.Add(_boots);
			equipedItems.Add(_shoulders);
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
				_itemObject[item.itemSort][0].GetComponent<MeshFilter>().mesh = null;
				_itemObject[item.itemSort][0].GetComponent<Renderer>().material.mainTexture = null;
				bow.SetActive(true);
			} 
			else 
			{
				if(bow.activeSelf && item.itemSort == Item.ItemSort.Weapon)
				{
					bow.SetActive(false);
				}
				for (int i = 0; i < _itemObject[item.itemSort].Count; i++) 
				{
					_itemObject[item.itemSort][i].GetComponent<MeshFilter>().mesh = Resources.Load(item.itemMesh,typeof(Mesh)) as Mesh;
					_itemObject[item.itemSort][i].GetComponent<Renderer>().material.mainTexture = Resources.Load(item.itemTexture, typeof(Texture)) as Texture;
				}
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
