using UnityEngine;
using System.Collections;

public class DropController : MonoBehaviour {
	public int dropRate;

	private ItemDatabase _itemDatabase;
	void Awake()
	{
		_itemDatabase = GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemDatabase>();
	}
	public void DropItem()
	{
		if(Random.Range(0,100) <= dropRate)
		{
			int randomItem = Random.Range(0,_itemDatabase.itemList.Count);
			GameObject newDrop = ObjectPool.instance.GetObjectForType("Item", false);
			newDrop.GetComponent<ItemDrop>().SetItem(_itemDatabase.itemList[randomItem]);
			newDrop.GetComponent<MeshFilter>().mesh = _itemDatabase.GetItemMesh(randomItem);
			newDrop.renderer.material.mainTexture = _itemDatabase.GetItemTexture(randomItem);
			newDrop.transform.position = this.transform.position;
		}
	}
}
