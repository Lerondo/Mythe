using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AudioList : MonoBehaviour 
{
	//Menu
	public AudioClip clicksound;
	public AudioClip menuMusic;

	//EffectSounds
	public AudioClip hitSound;
	public AudioClip walkSound;

	public void Lists()
	{

		List<AudioClip> effectSound = new List<AudioClip> ();

		effectSound.Add (clicksound);
		effectSound.Add (hitSound);
		effectSound.Add (walkSound);

		foreach (AudioClip effectS in effectSound) 
		{
			audio.volume = GetComponent<AudioManager>().valueEffects;
		}

		//Music List
		List<AudioClip> musicSound = new List<AudioClip> ();

		musicSound.Add (menuMusic);

		foreach (AudioClip MusicS in musicSound) 
		{
			audio.volume = GetComponent<AudioManager>().valueMusic;
		}
	}
}
