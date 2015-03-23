using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	[SerializeField]private AudioMixerSnapshot playing;
	[SerializeField]private AudioMixerSnapshot pauzed;

	[SerializeField]private AudioMixer master;
	[SerializeField]private AudioMixer effects;



}
