using UnityEngine;
using System.Collections;

public class BackgroundOffset : MonoBehaviour {

	private float speed;
	private GameObject _cam;

	void Start()
	{
		_cam = GameObject.FindGameObjectWithTag ("MainCamera");

		if (this.gameObject.name == "background-back")
			speed = 0.05f;
		else if (this.gameObject.name == "background-close")
			speed = 0.08f;
	}

	void Update()
	{
		renderer.material.mainTextureOffset = new Vector2 (_cam.transform.position.x * speed, 0);
		
		if (this.gameObject.name == "background-close")
			transform.position = new Vector3 (_cam.transform.position.x, 4.3f, -8f);
	}
}
