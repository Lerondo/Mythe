using UnityEngine;
using System.Collections;

public class Axe : Item {

	public Axe()
	{
		_itemSort = ItemSort.sword;
		_itemQuality = ItemQuality.common;
		_damage = 4;
		_defence = 0;
	}
}
