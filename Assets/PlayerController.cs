using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//Speed variables
	private float _speed = 5f;
	private float _jumpForce = 300f;

	//Health and Stamina
	private int _health = 100;
	private int _stamina = 100;
	public Slider healthBar;
	public Slider staminaBar;

	//Stamina Regen timer
	private int StaTimer = 0;

	private float experience = 0;

	public Slider XPBar;

	private bool isGrounded = false;

	void Update () 
	{
		float x = Input.GetAxis ("Horizontal") * _speed * Time.smoothDeltaTime;

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true && _stamina >= 20)
		{
			rigidbody.AddForce (0, _jumpForce, 0);
			isGrounded = false;
			DecreaseStamina();
		}

		transform.Translate (x, 0, 0, Space.Self);

		if(Input.GetKeyDown(KeyCode.H) && _health > 0)
			_health -= 5;

		staminaBar.value = _stamina;
		healthBar.value = _health;
		XPBar.value = experience;

		if (StaTimer > 0)
		{
			StaTimer--;
		}else if(StaTimer == 0 && _stamina < 100)
			_stamina ++;

		if (Input.GetKeyDown (KeyCode.X))
			experience += 40;

		if (experience >= XPBar.maxValue)
		{
			experience -= XPBar.maxValue;
			Mathf.Floor(XPBar.maxValue = XPBar.maxValue * 1.8f);
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Ground")
			isGrounded = true;
	}

	void DecreaseStamina()
	{
		_stamina -= 20;
		StaTimer = 300;
	}
}
