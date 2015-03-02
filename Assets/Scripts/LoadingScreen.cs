using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {
	public Sprite[] allLoadingScreens = new Sprite[0];
	public GameObject loadingScreen;
	public GameObject loadingCanvas;
	void Start()
	{
		loadingCanvas.SetActive(false);
	}
	public void LoadScreen()
	{
		loadingCanvas.SetActive(true);
		loadingScreen.GetComponent<Image>().sprite = allLoadingScreens[Random.Range(0,allLoadingScreens.Length)];
	}
}
