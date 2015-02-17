using UnityEngine;
using System.Collections;

public class BackgroundOffset : MonoBehaviour {

	private float speed;
	private GameObject _cam;

	void Start()
	{
		_cam = GameObject.Find ("Main Camera");

		if (this.gameObject.name == "FarBackground")
			speed = 0.05f;
		else if (this.gameObject.name == "CloseBackground")
			speed = 0.08f;
	}

	void Update()
	{
		renderer.material.mainTextureOffset = new Vector2 (_cam.transform.position.x * speed, 0);
		if (this.gameObject.name == "CloseBackground")
			transform.position = new Vector3 (_cam.transform.position.x, 4.3f, -8f);

	}
}
