using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	private GameObject _player;
	private Vector3 _camPos;

	[SerializeField]private float minX = -15f;
	[SerializeField]private float maxX = 300f;
	[SerializeField]private float minY = -20f;
	[SerializeField]private float maxY = 50f;

	void Start()
	{
		_player = GameObject.Find ("Player");
	}

	void Update()
	{
		if (_player != null)
		{
			_camPos = new Vector3 (Mathf.Clamp(_player.transform.position.x, minX, maxX), Mathf.Clamp(_player.transform.position.y, minY, maxY), -10);
			transform.position = _camPos;
		}
	}
}
