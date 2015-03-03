using UnityEngine;
using System.Collections;

public class MovingClouds : MonoBehaviour {
	
	void Update () 
	{
		this.transform.Translate (0.0005f, 0, 0);
	}
}
