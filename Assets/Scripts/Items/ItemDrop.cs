using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour {
	public Item currentItem;
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == Tags.Player)
		{
			GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<Inventory>().AddItem(currentItem);
			Destroy(this.gameObject);
		} 
	}
	public void SetItem(Item item)
	{
		currentItem = item;
		this.gameObject.GetComponent<MeshFilter>().mesh = currentItem.GetItemMesh();
		this.gameObject.renderer.material.mainTexture = currentItem.GetItemTexture();
	}
}
