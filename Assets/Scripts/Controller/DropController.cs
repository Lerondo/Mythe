using UnityEngine;
using System.Collections;

public class DropController : MonoBehaviour {
	public int commonDropRate;
	public int uncommonDropRate;
	public int rareDropRate;
	public int legendaryDropRate;
	public void DropItem()
	{
		//common droprate
		if(Random.Range(0,100) <= commonDropRate)
		{
			int randomItem = Random.Range(0,ItemDatabase.itemList.Count);
			GameObject newDrop = ObjectPool.instance.GetObjectForType("Item", false);
			newDrop.GetComponent<ItemDrop>().SetItem(ItemDatabase.itemList[randomItem]);
			newDrop.GetComponent<MeshFilter>().mesh = ItemDatabase.itemList[randomItem].GetItemMesh();
			newDrop.renderer.material.mainTexture = ItemDatabase.itemList[randomItem].GetItemTexture();
			newDrop.transform.position = this.transform.position;
		}
	}
}
