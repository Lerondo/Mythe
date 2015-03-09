using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour {
	public Item currentItem;
	private float _rotationSpeed = 25f;
	void Update()
	{
		this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles,this.transform.eulerAngles+new Vector3(0,5,0),_rotationSpeed*Time.deltaTime);
	}
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
		this.gameObject.GetComponent<MeshFilter>().mesh = Resources.Load(currentItem.itemMesh,typeof(Mesh)) as Mesh;;
		this.gameObject.renderer.material.mainTexture = Resources.Load(currentItem.itemTexture,typeof(Texture)) as Texture;
	}
}
