﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControllerA : MonoBehaviour {

	//Player Visual and linking
	private GameObject Player;
	private float fadeSpeed = 5f;
	private Color _transparant;

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

	//Experience
	private float experience = 0;
	public Slider XPBar;

	//Check if on Ground
	private bool isGrounded = false;

	void Start()
	{
		Player = GameObject.Find ("Player");
		_transparant = new Color (0, 0, 0, 0);
	}

	void Update () 
	{
		CheckMovement ();
		CheckBars ();

		//Damage Test
		if(Input.GetKeyDown(KeyCode.H) && _health > 0)
			_health -= 20;
		
		if (_health <= 0)
		{
			Player.renderer.material.color = Color.Lerp (Player.renderer.material.color, _transparant, fadeSpeed * Time.deltaTime);
			Destroy(gameObject, 5f);
		}
		
		//Stamina Refill
		if (StaTimer > 0)
		{
			StaTimer--;
		}else if(StaTimer == 0 && _stamina < 100)
			_stamina ++;

		//EXP Test
		if (Input.GetKeyDown (KeyCode.X))
			experience += 40;

		//EXPBar Constant Check
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
		StaTimer = 200;
	}

	void CheckMovement()
	{
		// Movement and Jumping
		float x = Input.GetAxis ("Horizontal") * _speed * Time.smoothDeltaTime;
		
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true && _stamina >= 20)
		{
			rigidbody.AddForce (0, _jumpForce, 0);
			isGrounded = false;
			DecreaseStamina();
		}
		
		transform.Translate (x, 0, 0, Space.Self);
	}

	void CheckBars()
	{
		//Visual Bars constant checking
		staminaBar.value = _stamina;
		healthBar.value = _health;
		XPBar.value = experience;
	}
}
