using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public int basicDamage;
	public int basicDefence;
	private ItemDatabase _itemDatabase;
	private int _damage;
	private int _defence;
	private int _shieldId;
	void Awake()
	{
		_itemDatabase = GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemDatabase>();
	}
	void Start()
	{
		//TODO: get save updatestats.
	}
	public void UpdateDamage(int newDamage,int oldDamage)
	{
		_damage -= oldDamage;
		_damage += newDamage;
	}
	public void UpdateDefence(int newDefence,int oldDefence)
	{
		_defence -= oldDefence;
		_defence += newDefence;
	}
	public void UpdateStats(int swordId, int shieldId, int helmId, int legsId, int bodyId, int bootsId)
	{
		_damage = basicDamage;
		_defence = basicDefence;
		for (int i = 0; i < 6; i++) 
		{
			int dmg = 0;
			int def = 0;
			switch(i)
			{
			case 1:
				dmg = _itemDatabase.itemList[swordId].GetItemDamage();
				def = _itemDatabase.itemList[swordId].GetItemDefence();
				break;
			case 2:
				dmg = _itemDatabase.itemList[shieldId].GetItemDamage();
				def = _itemDatabase.itemList[shieldId].GetItemDefence();
				break;
			case 3:
				dmg = _itemDatabase.itemList[helmId].GetItemDamage();
				def = _itemDatabase.itemList[helmId].GetItemDefence();
				break;
			case 4:
				dmg = _itemDatabase.itemList[legsId].GetItemDamage();
				def = _itemDatabase.itemList[legsId].GetItemDefence();
				break;
			case 5:
				dmg = _itemDatabase.itemList[bodyId].GetItemDamage();
				def = _itemDatabase.itemList[bodyId].GetItemDefence();
				break;
			case 6:
				dmg = _itemDatabase.itemList[bootsId].GetItemDamage();
				def = _itemDatabase.itemList[bootsId].GetItemDefence();
				break;
			default:
				break;
			}
			_defence += def;
			_damage += dmg;
		}
	}
}
