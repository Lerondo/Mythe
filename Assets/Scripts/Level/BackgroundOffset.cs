using UnityEngine;
using System.Collections;

public class BackgroundOffset : MonoBehaviour {

	private float speed;
	private GameObject cam;

	void Start()
	{
		cam = GameObject.Find ("Main Camera");

		if (this.gameObject.name == "FarBackground")
			speed = 0.05f;
		else if (this.gameObject.name == "MedBackground")
			speed = 0.010f;
		else if (this.gameObject.name == "CloseBackground")
			speed = 0.08f;
	}

	void Update()
	{
		if(Input.GetAxis("Horizontal") != 0)
			renderer.material.mainTextureOffset = new Vector2 (GameObject.Find("Player").transform.position.x * speed, 0);
		if (this.gameObject.name == "CloseBackground")
			transform.position = new Vector3 (cam.transform.position.x, 0.7f, -2.56f);

	}
}
