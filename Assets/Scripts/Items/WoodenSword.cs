using UnityEngine;
using System.Collections;

public class WoodenSword : Item {
	
	public WoodenSword()
	{
		 _itemSort = ItemSort.sword;
		_itemQuality = ItemQuality.common;
		_damage = 2;
		_defence = 0;
	}

}
