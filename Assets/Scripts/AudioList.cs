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
		AudioL.Add (attackingSound);
		AudioL.Add (chargeShout);

		//ObjectSound
		AudioL.Add (arrowShotSound);
		AudioL.Add (arrowInpactSound);
		AudioL.Add (hitSound);

		//WorldSounds
		AudioL.Add (birdSound);
		AudioL.Add (windSound);
	

		foreach (AudioClip SoundF in AudioL) 
		{

		}
	}

	void Awake()
	{
		Lists ();
	}


}
