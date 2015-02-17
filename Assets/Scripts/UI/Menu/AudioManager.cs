using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour 
{
	private float sliderValue;
	public float valueEffects;
	public float valueMusic;

	public void OnValueChangedEffects(float newValueEffects)
	{
		valueEffects = newValueEffects;
	}

	public void OnValueChangedMusic(float newValueMusic)
	{
		valueMusic = newValueMusic;
	}
}

