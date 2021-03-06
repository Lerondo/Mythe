﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveLoadDataSerialized : MonoBehaviour {
	private PlayerStats _playerStats;
	private Equipment _equipment;
	private Inventory _inventory;
	private HealthController _healthController;
	private GameObject _player;
	private string _currentUsername;
	public static SaveLoadDataSerialized Instance;

	void OnLevelWasLoaded(int index)
	{
		if(index == 1)
		{
			_playerStats = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStats>();
			_playerStats.username = _currentUsername;
		}
	}
	void Awake()
	{
		if(Instance)
		{
			Destroy(this.gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
	}
	public void DeleteSave(string path)
	{
		if(File.Exists(Application.persistentDataPath + path))
		{
			File.Delete(Application.persistentDataPath + path);
		}
	}

	public void Save (string path) 
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + path);

		SaveData saveData = new SaveData();

		//get all components
		GameObject gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
		_player = GameObject.FindGameObjectWithTag(Tags.Player);
		_playerStats = _player.GetComponent<PlayerStats>();
		_healthController = _player.GetComponent<HealthController>();
		_equipment = gameController.GetComponent<Equipment>();
		_inventory = gameController.GetComponent<Inventory>();

		//get all values
		//Loaded level
		saveData.loadedlevel = Application.loadedLevel;

		//player Stats
		saveData.exp = _playerStats.experience;
		saveData.maxExp = _playerStats.maxExperience;
		saveData.gold = _playerStats.gold;
		saveData.health = _healthController.health;
		saveData.level = _playerStats.level;
		saveData.damage = _playerStats.basicDamage;
		saveData.defence = _playerStats.basicDefence;
		saveData.timePlayed = _playerStats.timePlayed;
		saveData.isRanked = _playerStats.isRanked;
		saveData.playableLevels = _playerStats.playableLevels;

		//Player Position
		saveData.playerX = _player.transform.position.x;
		saveData.playerY = _player.transform.position.y;
		saveData.playerZ = _player.transform.position.z;
		//player username
		saveData.username = _playerStats.username;
		if(saveData.username == "")
		{
			saveData.username = _currentUsername;
		}

		//Inventory Items
		//saveData.inventoryItemsIds = _inventory.GetInventoryItemIds();
		saveData.inventoryItems = _inventory.inventory;

		//Equiped Items
		//saveData.equipedItemsIds = _equipment.GetEquipedItemIds();
		saveData.equipedItems = _equipment.equipedItems;

		binaryFormatter.Serialize(file,saveData);
		file.Close();
	}
	public void SetUsername(string username)
	{
		_currentUsername = username;
	}
	public void LoadCharacterPanel(string path, int id)
	{
		Menu menu = GameObject.FindGameObjectWithTag(Tags.Menu).GetComponent<Menu>();
		if(File.Exists(Application.persistentDataPath + path))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);
			
			SaveData saveData = binaryFormatter.Deserialize(file) as SaveData;
			menu.SetCharacterText(id, saveData.username);
			file.Close();
		} else {
			menu.SetCharacterText(id, "New Character");
		}
	}
	public IEnumerator Load (string path) 
	{
		if(File.Exists(Application.persistentDataPath + path))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);

			SaveData saveData = binaryFormatter.Deserialize(file) as SaveData;
			//Set all values
			Application.LoadLevel(saveData.loadedlevel);
			while(Application.isLoadingLevel)
			{
				yield return new WaitForEndOfFrame();
			}
			//get all components
			GameObject gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
			_player = GameObject.FindGameObjectWithTag(Tags.Player);
			_playerStats = _player.GetComponent<PlayerStats>();
			_healthController = _player.GetComponent<HealthController>();
			_equipment = gameController.GetComponent<Equipment>();
			_inventory = gameController.GetComponent<Inventory>();

			//setting all values
			_playerStats.basicDamage = saveData.damage;
			_playerStats.basicDefence = saveData.defence;
			_playerStats.experience = saveData.exp;
			_playerStats.maxExperience = saveData.maxExp;
			_playerStats.gold = saveData.gold;
			_healthController.health = saveData.health;
			_playerStats.level = saveData.level;
			_playerStats.playableLevels = saveData.playableLevels;
			_player.transform.position = new Vector3(saveData.playerX,saveData.playerY,saveData.playerZ);
			_playerStats.username = saveData.username;
			_playerStats.timePlayed = saveData.timePlayed;
			_playerStats.isRanked = saveData.isRanked;

			_equipment.EquipAllItems(saveData.equipedItems);
			_inventory.inventory = saveData.inventoryItems;
			file.Close();
		} else
		{
			GameObject.FindGameObjectWithTag(Tags.Menu).GetComponent<Menu>().ShowNewCharacter();
		}
		SavePaths.currentPath = path;
	}
	public IEnumerator LoadPlayerInfo (string path) 
	{
		if(File.Exists(Application.persistentDataPath + path))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);
			
			SaveData saveData = binaryFormatter.Deserialize(file) as SaveData;
			//Set all values
			while(Application.isLoadingLevel)
			{
				yield return new WaitForEndOfFrame();
			}
			//get all components
			GameObject gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
			_player = GameObject.FindGameObjectWithTag(Tags.Player);
			_playerStats = _player.GetComponent<PlayerStats>();
			_healthController = _player.GetComponent<HealthController>();
			_equipment = gameController.GetComponent<Equipment>();
			_inventory = gameController.GetComponent<Inventory>();
			
			//setting all values
			_playerStats.basicDamage = saveData.damage;
			_playerStats.basicDefence = saveData.defence;
			_playerStats.experience = saveData.exp;
			_playerStats.playableLevels = saveData.playableLevels;
			_playerStats.maxExperience = saveData.maxExp;
			_playerStats.gold = saveData.gold;
			_healthController.health = saveData.health;
			_playerStats.level = saveData.level;
			_playerStats.username = saveData.username;
			_playerStats.timePlayed = saveData.timePlayed;
			_playerStats.isRanked = saveData.isRanked;
			
			_equipment.EquipAllItems(saveData.equipedItems);
			_inventory.inventory = saveData.inventoryItems;
			file.Close();
		}
	}
}
[System.Serializable]
public class SaveData
{
	public int loadedlevel;
	public int gold;
	public int health;
	public float exp;
	public float maxExp;
	public int level;
	public int damage;
	public int defence;
	public string username;
	public float playerX;
	public float playerY;
	public float playerZ;
	public float timePlayed;
	public bool isRanked;
	public int playableLevels;
	public List<Item> equipedItems = new List<Item>();
	public List<Item> inventoryItems = new List<Item>();
	//TODO: time
}
