using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	private GameObject _player;

	void Start()
	{
		_player = GameObject.Find ("Player");
	}

	void Update()
	{
		this.transform.position = new Vector3 (_player.transform.position.x, _player.transform.position.y + 1.74f, -10);
	}
}
