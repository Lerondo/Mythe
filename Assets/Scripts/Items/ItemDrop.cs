using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour {
	public Item currentItem;
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<InventoryController>().AddItem(currentItem);
			Destroy(this.gameObject);
		} 
	}
	public void SetItem(Item item)
	{
		currentItem = item;
	}
}
