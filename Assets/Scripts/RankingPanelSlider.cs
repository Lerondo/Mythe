using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankingPanelSlider : MonoBehaviour {
	public Slider slider;
	public GameObject rankingPanel;
	private Vector3 _standardPos;
	void Start()
	{
		_standardPos = rankingPanel.transform.position;
	}
	public void SlideBar()
	{
		Vector3 newPos = _standardPos;
		newPos.y += slider.value;
		rankingPanel.transform.position = newPos;
	}
}
