using UnityEngine;
using System.Collections;

public class HubLevels : MonoBehaviour {
	private PlayerStats _playerStats;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;
	public GameObject level5;
	// Use this for initialization
	void Awake()
	{
		_playerStats = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStats>();
	}
	void Start () {
		if(_playerStats.playableLevels == 5)
		{
			level2.SetActive(true);
			level3.SetActive(true);
			level4.SetActive(true);
			level5.SetActive(true);
		}
		else if(_playerStats.playableLevels == 4)
		{
			level2.SetActive(true);
			level3.SetActive(true);
			level4.SetActive(true);
		}
		else if(_playerStats.playableLevels == 3)
		{
			level2.SetActive(true);
			level3.SetActive(true);
		}
		else if(_playerStats.playableLevels == 2)
		{
			level2.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
