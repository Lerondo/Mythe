using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	private GameObject _player;
	private Vector3 _camPos;

	private float minX;
	private float maxX;
	private float minY;
	private float maxY;

	void Start()
	{
		_player = GameObject.Find ("Player");
	}

	void Update()
	{
		if (_player != null)
		{
			_camPos = new Vector3 (Mathf.Clamp(_player.transform.position.x, -7f, 55f), Mathf.Clamp(_player.transform.position.y, 3.8f, 20f), -10);
			transform.position = _camPos;
		}
	}
}
