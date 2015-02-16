using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemDatabase : MonoBehaviour {
	public List<Item> itemList = new List<Item>();
	[SerializeField]private Sprite[] itemSprites = new Sprite[0];
	[SerializeField]private Texture[] itemTextures = new Texture[0];
	[SerializeField]private Mesh[] itemMeshes = new Mesh[0];
	// Use this for initialization
	void Awake () {
		//add all curren usable items inside this list.
		itemList.Add(new WoodenSword());
		itemList.Add(new Axe());
	}
	public Sprite GetItemSprite(int id)
	{
		return itemSprites[id];
	}
	public Texture GetItemTexture(int id)
	{
		return itemTextures[id];
	}
	public Mesh GetItemMesh(int id)
	{
		return itemMeshes[id];
	}
}
