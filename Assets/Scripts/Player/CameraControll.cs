using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	private GameObject _player;

	private Vector3 minY;
	private Vector3 maxY;

	void Start()
	{
		_player = GameObject.Find ("Player");
	}

	void Update()
	{
		if (_player != null)
			CheckToClamp ();

		if(this.transform.position.y < 3.8f)
			transform.position = minY;

		if(this.transform.position.y > 10f)
			transform.position = maxY;
	}

	void CheckToClamp()
	{
		this.transform.position = new Vector3 (_player.transform.position.x, _player.transform.position.y + 1.74f, -10);


		minY = new Vector3 (_player.transform.position.x, Mathf.Clamp(0f, 3.8F, 3.8F), -10);
		maxY = new Vector3(_player.transform.position.x, Mathf.Clamp(0f, 10F, 10F), -10);
	}
}
