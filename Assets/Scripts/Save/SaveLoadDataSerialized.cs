using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveLoadDataSerialized : MonoBehaviour {
	private PlayerStats _playerStats;
	private EquipmentController _equipment;
	private InventoryController _inventory;
	private HealthController _healthController;
	private GameObject _player;
	void Awake()
	{
		_player = GameObject.FindGameObjectWithTag(TagManager.Player);
		_playerStats = _player.GetComponent<PlayerStats>();
		_healthController = _player.GetComponent<HealthController>();
		_equipment = GetComponent<EquipmentController>();
		_inventory = GetComponent<InventoryController>();
	}
	public void Save (string path) 
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + path);

		SaveData saveData = new SaveData();
		//get all values
		saveData.damage = _playerStats.GetBasicDamage();
		saveData.defence = _playerStats.GetBasicDefence();
		saveData.equipedItems = _equipment.equipedItems;
		saveData.exp = _playerStats.GetExperience();
		saveData.maxExp = _playerStats.GetMaxExperience();
		saveData.gold = _playerStats.GetGold();
		saveData.health = _healthController.GetHealth();
		saveData.inventoryItems = _inventory.GetInventory();
		saveData.level = _playerStats.GetLevel();
		saveData.playerPosition = _player.transform.position;
		saveData.username = _playerStats.GetUsername();

		binaryFormatter.Serialize(file,saveData);
		file.Close();
	}
	public void Load (string path) 
	{
		if(File.Exists(Application.persistentDataPath + path))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);

			SaveData saveData = binaryFormatter.Deserialize(file) as SaveData;
			//Set all values
			_playerStats.SetBasicDamage(saveData.damage);
			_playerStats.SetBasicDefence(saveData.defence);
			_equipment.equipedItems = saveData.equipedItems;
			_playerStats.SetExperience(saveData.exp);
			_playerStats.SetMaxExperience(saveData.maxExp);
			_playerStats.SetGold(saveData.gold);
			_healthController.SetHealth(saveData.health);
			_inventory.SetInventory(saveData.inventoryItems);
			_playerStats.SetLevel(saveData.level);
			_player.transform.position = saveData.playerPosition;
			_playerStats.SetUsername(saveData.username);

			file.Close();
		} else {
			Debug.LogWarning("Save data not found!");
		}
	}
}
[System.Serializable]
public class SaveData
{
	public int gold;
	public int health;
	public float exp;
	public float maxExp;
	public int level;
	public int damage;
	public int defence;
	public string username;
	public Vector3 playerPosition;
	public List<Item> equipedItems = new List<Item>();
	public List<Item> inventoryItems = new List<Item>();
	//TODO: time
}
