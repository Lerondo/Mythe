using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	private GameObject _player;
	private Vector3 _playerPos;
	private Vector3 _camPos;
	private bool _shaking;

	[SerializeField]private float minX = -15f;
	[SerializeField]private float maxX = 300f;
	[SerializeField]private float minY = -20f;
	[SerializeField]private float maxY = 50f;

	void Start()
	{
		_player = GameObject.FindGameObjectWithTag (Tags.Player);
	}
	void Update()
	{
		if(!_shaking)
			FollowPlayer ();
	}
	public IEnumerator ShakeScreen()
	{
		_shaking = true;
		for (int i = 0; i < 10; i++) 
		{
			_playerPos = new Vector3 (_player.transform.position.x+Random.Range(-1,1), _player.transform.position.y+Random.Range(-1,1), 0);
			_camPos = new Vector3 (Mathf.Clamp(_playerPos.x, minX, maxX), Mathf.Clamp(_playerPos.y, minY, maxY), -15);
			transform.position = _camPos;
			yield return new WaitForSeconds(0.05f);
		}
		_shaking = false;
	}
	void FollowPlayer()
	{
		_playerPos = new Vector3 (_player.transform.position.x, _player.transform.position.y, 0);
		_camPos = new Vector3 (Mathf.Clamp(_playerPos.x, minX, maxX), Mathf.Clamp(_playerPos.y, minY, maxY), -15);
		transform.position = _camPos;
	}
}
