using UnityEngine;
using System.Collections;

public class BackgroundOffset : MonoBehaviour {

	private float speed;
	private GameObject _cam;
	private GameObject _player;

	void Start()
	{
		_cam = GameObject.Find ("Main Camera");
		_player = GameObject.Find ("Player");

		if (this.gameObject.name == "FarBackground")
			speed = 0.05f;
		else if (this.gameObject.name == "CloseBackground")
			speed = 0.08f;
	}

	void Update()
	{
		if(_cam.transform.position.x == _player.transform.position.x)
			renderer.material.mainTextureOffset = new Vector2 (GameObject.Find("Player").transform.position.x * speed, 0);
		if (this.gameObject.name == "CloseBackground")
			transform.position = new Vector3 (_cam.transform.position.x, 4.4f, -8f);

	}
}
