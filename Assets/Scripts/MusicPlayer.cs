using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour 
{
	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
	
		_audioSource = GetComponent<AudioSource> ();
		_audioSource.clip = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<AudioList>().PlayAudio("MainMusic");
		_audioSource.Play();

	}
}
