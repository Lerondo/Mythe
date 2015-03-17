using UnityEngine;
using System.Collections;

public class RemoveWindAnim : MonoBehaviour {
	private ObjectPool _objectPool;
	void Awake()
	{
		_objectPool = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>();
	}
	public void InvokeRemove () 
	{
		Invoke("PoolMyself", 3.5f);
	}
	void Update()
	{
		this.transform.position = this.transform.position + Vector3.forward * Time.deltaTime * 10;
		Vector3 newPos = this.transform.position;
		newPos.z = 0;
		this.transform.position = newPos;
	}
	private void PoolMyself()
	{
		_objectPool.PoolObject(this.gameObject);
	}
}
