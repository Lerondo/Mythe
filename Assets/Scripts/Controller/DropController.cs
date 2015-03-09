using UnityEngine;
using System.Collections;

public class DropController : MonoBehaviour {
	public int dropRate;
	public void DropItem()
	{
		if(Random.Range(0,100) <= dropRate)
		{
			GameObject newDrop = ObjectPool.instance.GetObjectForType("Item", false);
			newDrop.GetComponent<ItemDrop>().SetItem(ItemDatabase.GetRandomItem());
			newDrop.transform.position = this.transform.position;
		}
	}
}
