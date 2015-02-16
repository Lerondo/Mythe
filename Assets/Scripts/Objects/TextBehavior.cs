using UnityEngine;
using System.Collections;

public class TextBehavior : MonoBehaviour {
	private RectTransform _rectTransform;
	private bool _ableToMove = false;
	void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
	}
	public void SetAbleToMove(bool ableToMove)
	{
		_ableToMove = ableToMove;
	}
	public void SetPosition(Vector3 pos)
	{
		Vector3 rectPos = Camera.main.WorldToScreenPoint(pos);
		_rectTransform.position = rectPos;

		Invoke ("PoolMyself", 2f);
	}
	private void PoolMyself()
	{
		GameObject.FindGameObjectWithTag("GameController").GetComponent<ObjectPool>().PoolObject(this.gameObject);
	}
	// Update is called once per frame
	void Update () 
	{
		if(_ableToMove)
		{
			Vector3 movement = _rectTransform.position;
			movement.x += 0.1f;
			movement.y += 0.1f;
			_rectTransform.position = movement;
		}
	}
}
