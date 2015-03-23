using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	private GameObject _player;
	private Vector3 _playerPos;
	private Vector3 _camPos;
	private Vector3 _oldCamPos;

	[SerializeField]private float minX = -15f;
	[SerializeField]private float maxX = 300f;
	[SerializeField]private float minY = -20f;
	[SerializeField]private float maxY = 50f;

	void Start()
	{
		_oldCamPos = this.transform.position;
		_player = GameObject.FindGameObjectWithTag (Tags.Player);
	}
	void Update()
	{
		FollowPlayer ();
	}
	public IEnumerator MoveCloser()
	{
		for(int i = 0; i < 2500; i++)
		{
			int noOfFramesToWait = (int)(0.16f * Application.targetFrameRate);
			for (int j = 0; j < noOfFramesToWait; j++) 
			{
				yield return null;
			}
			transform.position = Vector3.Lerp (_camPos, new Vector3 (_playerPos.x + 1, _playerPos.y + 0.5f, -3), 0.05f);
		}
	}
	public IEnumerator MoveAway()
	{
		for(int i = 0; i < 2500; i++)
		{
			int noOfFramesToWait = (int)(0.16f * Application.targetFrameRate);
			for (int j = 0; j < noOfFramesToWait; j++)
			{
				yield return null;
			}
			transform.position = Vector3.Lerp (_camPos, _oldCamPos, Time.deltaTime);
		}
	}
	void FollowPlayer()
	{
		_playerPos = new Vector3 (_player.transform.position.x, _player.transform.position.y, 0);
		_camPos = new Vector3 (Mathf.Clamp(_playerPos.x, minX, maxX), Mathf.Clamp(_playerPos.y, minY, maxY), -15);
		transform.position = _camPos;
	}
}
