using UnityEngine;
using System.Collections;

public class DropController : MonoBehaviour {
	public int dropRate;
	public void DropItem()
	{
		if(Random.Range(0,100) <= dropRate)
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
