﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {


		Physics.gravity = new Vector3(0,-15,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
