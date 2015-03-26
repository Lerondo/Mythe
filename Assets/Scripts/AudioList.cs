using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AudioList : MonoBehaviour 
{
	//Music
	[SerializeField]private AudioClip preMusic;
	[SerializeField]private AudioClip menuMusic;
	[SerializeField]private AudioClip hubmusic;

	//PlayerSounds
	[SerializeField]private AudioClip walkSound;
	[SerializeField]private AudioClip climbSound;
	[SerializeField]private AudioClip jumpSound;
	[SerializeField]private AudioClip playerHitSound;
	[SerializeField]private AudioClip attackingSound;
	[SerializeField]private AudioClip chargeShout;
	[SerializeField]private AudioClip magicShotSound;

	//BowSounds
	[SerializeField]private AudioClip bowStretchingSound;
	[SerializeField]private AudioClip arrowShotSound;
	[SerializeField]private AudioClip arrowInpactSound;

	//MeleeSounds
	[SerializeField]private AudioClip hitSound;
	[SerializeField]private AudioClip meleeHitSound;

	//MagicSounds
	[SerializeField]private AudioClip magicInpactSound;

	//WorldSounds
	[SerializeField]private AudioClip birdSound;
	[SerializeField]private AudioClip windSound;
	[SerializeField]private AudioClip wolfSound;

	//EnemySounds
	[SerializeField]private AudioClip wolfAttackSound;

	//OtherSounds
	[SerializeField]private AudioClip ButtonClickSound;

	private List<AudioClip> AudioL = new List<AudioClip> ();

	public void Lists()
	{
		//Music
		AudioL.Add (preMusic);
		AudioL.Add (menuMusic);
		AudioL.Add (hubmusic);
	
		//PlayerSounds
		AudioL.Add (walkSound);
		AudioL.Add (climbSound);
		AudioL.Add (jumpSound);
		AudioL.Add (playerHitSound);
		AudioL.Add (meleeHitSound);
		AudioL.Add (chargeShout);

		//ObjectSound
		AudioL.Add (arrowShotSound);
		AudioL.Add (arrowInpactSound);
		AudioL.Add (hitSound);

		//WorldSounds
		AudioL.Add (birdSound);
		AudioL.Add (windSound);
	
	
		//getComponent<AudioSource>().audio = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<AudioList>().PlayAudio("windSound");
		//getComponent<AudioSource>().play();
	}
	public AudioClip PlayAudio(string audioname)
	{
		AudioClip newSound = null;
		foreach(AudioClip sound in AudioL)
		{
			if(sound.name == audioname)
			{
				newSound = sound;
				break;
			}
		}
		if(newSound == null)
		{
			Debug.LogWarning("no sound has been found, add it in the list if exists.");
			return null;
		}
		return newSound;
	}
	void Awake()
	{
		Lists ();
	}


}
