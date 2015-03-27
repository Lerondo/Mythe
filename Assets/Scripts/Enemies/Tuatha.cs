using UnityEngine;
using System.Collections;

public class Tuatha : Melee {
	public GameObject weapon;

	protected override void Start () {
		_range = 2.5f;
		_health = 150;
		_speed = 2.5f;
		_currentAttackDmg = 10;
		Item item = ItemDatabase.GetRandomItem();
		while(item.itemSort != Item.ItemSort.Weapon && item.weaponSort != Item.WeaponSort.Sword)
		{
			item = ItemDatabase.GetRandomItem();
		}
		_currentAttackDmg += item.itemDamage;
		weapon.GetComponent<MeshFilter>().mesh = Resources.Load(item.itemMesh,typeof(Mesh)) as Mesh;
		weapon.GetComponent<Renderer>().material.mainTexture = Resources.Load(item.itemTexture, typeof(Texture)) as Texture;
		base.Start();
	}

	protected override AnimationEvent Attack ()
	{
		_audioSource.clip = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<AudioList>().PlayAudio("HitSound");
		_audioSource.Play();
		return base.Attack ();
	}
}
