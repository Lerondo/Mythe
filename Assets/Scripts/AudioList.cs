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
		effectSound.Add (menuMusic);
		effectSound.Add (hitSound);
		effectSound.Add (walkSound);

		foreach (AudioClip effectS in effectSound) 
		{

		}
	}


}
