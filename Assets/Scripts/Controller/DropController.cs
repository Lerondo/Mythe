using UnityEngine;
using System.Collections;

public class DropController : MonoBehaviour {
	public int dropRate;
	//private int[] dropRates = new int[4];
	private int commonDropRate = 50;
	private int uncommonDropRate = 35;
	private int rareDropRate = 10;
	private int legendaryDropRate = 5;
	/*
	void Start()
	{
		dropRates[0] = legendaryDropRate;
		dropRates[1] = rareDropRate;
		dropRates[2] = uncommonDropRate;
		dropRates[3] = commonDropRate; 
	} */
	public void DropItem()
	{
		//common droprate
		if(Random.Range(0,100) <= dropRate)
		{
			/*
			int randomQuality = Random.Range(0,100);
			int itemQuality = 0;
			for (int i = 0; i < 4; i++) {
				if(randomQuality <= dropRates[i])
				{
					itemQuality = i;
					break;
				}
			} */
			int randomItem = Random.Range(0,ItemDatabase.itemList.Count);
			GameObject newDrop = ObjectPool.instance.GetObjectForType("Item", false);
			newDrop.GetComponent<ItemDrop>().SetItem(ItemDatabase.itemList[randomItem]);
			newDrop.GetComponent<MeshFilter>().mesh = ItemDatabase.itemList[randomItem].GetItemMesh();
			newDrop.renderer.material.mainTexture = ItemDatabase.itemList[randomItem].GetItemTexture();
			newDrop.transform.position = this.transform.position;
		}
	}
}
