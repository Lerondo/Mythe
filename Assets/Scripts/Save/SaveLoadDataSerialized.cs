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
	public static SaveLoadDataSerialized Instance;

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

	public IEnumerator Save (string path) 
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + path);

		SaveData saveData = new SaveData();

		//get all components
		GameObject gameController = GameObject.FindGameObjectWithTag(TagManager.GameController);
		_player = GameObject.FindGameObjectWithTag(TagManager.Player);
		_playerStats = _player.GetComponent<PlayerStats>();
		_healthController = _player.GetComponent<HealthController>();
		_equipment = gameController.GetComponent<EquipmentController>();
		_inventory = gameController.GetComponent<InventoryController>();

		//get all values
		saveData.loadedlevel = Application.loadedLevel;
		saveData.damage = _playerStats.GetBasicDamage();
		saveData.defence = _playerStats.GetBasicDefence();
		saveData.equipedItemsIds = _equipment.GetEquipedItemIds();
		saveData.exp = _playerStats.GetExperience();
		saveData.maxExp = _playerStats.GetMaxExperience();
		saveData.gold = _playerStats.GetGold();
		saveData.health = _healthController.GetHealth();
		saveData.inventoryItemsIds = _inventory.GetInventoryItemIds();
		saveData.level = _playerStats.GetLevel();
		saveData.playerX = _player.transform.position.x;
		saveData.playerY = _player.transform.position.y;
		saveData.playerZ = _player.transform.position.z;
		saveData.username = _playerStats.GetUsername();

		binaryFormatter.Serialize(file,saveData);
		file.Close();
		return null;
	}
	public void LoadCharacterPanel(string path, int id)
	{
		Menu menu = GameObject.Find("MenuPanel").GetComponent<Menu>();
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
			GameObject gameController = GameObject.FindGameObjectWithTag(TagManager.GameController);
			_player = GameObject.FindGameObjectWithTag(TagManager.Player);
			_playerStats = _player.GetComponent<PlayerStats>();
			_healthController = _player.GetComponent<HealthController>();
			_equipment = gameController.GetComponent<EquipmentController>();
			_inventory = gameController.GetComponent<InventoryController>();

			//setting all values
			_playerStats.SetBasicDamage(saveData.damage);
			_playerStats.SetBasicDefence(saveData.defence);
			_playerStats.SetExperience(saveData.exp);
			_playerStats.SetMaxExperience(saveData.maxExp);
			_playerStats.SetGold(saveData.gold);
			_healthController.SetHealth(saveData.health);
			_playerStats.SetLevel(saveData.level);
			_player.transform.position = new Vector3(saveData.playerX,saveData.playerY,saveData.playerZ);
			_playerStats.SetUsername(saveData.username);

			_equipment.equipedItems = ItemDatabase.GetItemsViaId(saveData.equipedItemsIds);
			_inventory.SetInventory(ItemDatabase.GetItemsViaId(saveData.inventoryItemsIds));

			file.Close();
		} else {
			Debug.LogWarning("Save data not found!");
			Debug.Log("Making new character");
			Application.LoadLevel(1);
		}
		SavePaths.currentPath = path;
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
	public List<int> equipedItemsIds = new List<int>();
	public List<int> inventoryItemsIds = new List<int>();
	//TODO: time
}
