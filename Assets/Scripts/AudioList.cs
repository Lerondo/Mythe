using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AudioList : MonoBehaviour 
{
	//Music
	[SerializeField]private AudioClip menuMusic;
	[SerializeField]private AudioClip hubmusic;

	//EffectSounds
	[SerializeField]private AudioClip hitSound;
	[SerializeField]private AudioClip walkSound;



	public void Lists()
	{
		List<AudioClip> AudioL = new List<AudioClip> ();
		//Music
		AudioL.Add (menuMusic);
		AudioL.Add (hubmusic);

		//Effects
		AudioL.Add (hitSound);
		AudioL.Add (walkSound);

		foreach (AudioClip effectS in AudioL) 
		{

		}
	}


}
