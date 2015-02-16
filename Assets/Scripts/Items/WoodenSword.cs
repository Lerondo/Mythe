using UnityEngine;
using System.Collections;

public class WoodenSword : Item {
	
	public WoodenSword()
	{
		itemSort = ItemSort.sword;
		itemQuality = ItemQuality.common;
		_damage = 2;
		_defence = 0;
	}

}
