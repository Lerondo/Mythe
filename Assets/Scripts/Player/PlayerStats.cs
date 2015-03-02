using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public int basicDamage;
	public int basicDefence;
	private int _level;
	private float _experience = 0;
	private float _maxExp = 125;
	private int _damage;
	private int _defence;
	private int _goldValue = 100;
	private UserInterface _userInterface;
	void Awake()
	{
		_userInterface = GameObject.FindGameObjectWithTag(TagManager.GameController).GetComponent<UserInterface>();
	}
	void Start()
	{
		//TODO: get save updatestats.
	}
	public int GetDamage()
	{
		return _damage;
	}
	public void UpdateGold (int gold)
	{
		_goldValue += gold;
	}
	public int GetGold()
	{
		return _goldValue;
	}
	public void UpdateExp(float exp)
	{
		_experience += exp;
		if(_experience >= _maxExp)
		{
			_experience -= _maxExp;
			_maxExp *= 1.75f;
			_level++;
			basicDamage += 5;
			basicDefence += 1;
			_damage += 5;
			_defence += 5;
			_userInterface.UpdateMaxValue(UserInterface.XPBAR, Mathf.FloorToInt(_maxExp));
		}
		_userInterface.UpdateBar(UserInterface.XPBAR, Mathf.FloorToInt(_experience));
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
				dmg = ItemDatabase.itemList[swordId].GetItemDamage();
				def = ItemDatabase.itemList[swordId].GetItemDefence();
				break;
			case 2:
				dmg = ItemDatabase.itemList[shieldId].GetItemDamage();
				def = ItemDatabase.itemList[shieldId].GetItemDefence();
				break;
			case 3:
				dmg = ItemDatabase.itemList[helmId].GetItemDamage();
				def = ItemDatabase.itemList[helmId].GetItemDefence();
				break;
			case 4:
				dmg = ItemDatabase.itemList[legsId].GetItemDamage();
				def = ItemDatabase.itemList[legsId].GetItemDefence();
				break;
			case 5:
				dmg = ItemDatabase.itemList[bodyId].GetItemDamage();
				def = ItemDatabase.itemList[bodyId].GetItemDefence();
				break;
			case 6:
				dmg = ItemDatabase.itemList[bootsId].GetItemDamage();
				def = ItemDatabase.itemList[bootsId].GetItemDefence();
				break;
			default:
				break;
			}
			_defence += def;
			_damage += dmg;
		}
	}
}
