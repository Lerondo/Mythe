using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	private UserInterface _userInterface;
	private Unit _currentUnit;
	private int _health = 100;
	private int _maxHealth = 100;
	private float fadeSpeed = 5f;
	private Color _transparant;
	void Awake()
	{
		if(GetComponent<PlayerController>())
			_userInterface = GameObject.FindGameObjectWithTag("GameController").GetComponent<UserInterface>();
		_currentUnit = GetComponent<Unit>();
	}
	void Start()
	{
		_transparant = new Color(0,0,0,0);
	}
	public int GetHealth()
	{
		return _health;
	}
	public void SetHealth(int health)
	{
		_health = health;
		UpdateInterface();
	}
	public void UpdateMaxHealth(int health)
	{
		_maxHealth += health;
	}
	public void UpdateHealth(int health)
	{
		_health += health;
		UpdateInterface();
		if(_health <= 0)
		{
			_currentUnit.SetDeath(true);
			StartCoroutine(Die ());
		}
	}
	private void UpdateInterface()
	{
		if(_userInterface != null)
		{
			_userInterface.UpdateBar(UserInterface.HEALTHBAR, _health);
		}
	}
	private IEnumerator Die()
	{
		Destroy(gameObject, 5f);
		while(gameObject.renderer.material.color.a >= 0 && this.gameObject != null)
		{
			gameObject.renderer.material.color = Color.Lerp (gameObject.renderer.material.color, _transparant, fadeSpeed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
	}
}

