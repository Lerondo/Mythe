using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();

		_audioSource.clip = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<AudioList>().PlayAudio("MainMusic");
		_audioSource.Play();

		Physics.gravity = new Vector3(0,-15,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
