using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControllerA : MonoBehaviour {

	//Player Visual and linking
	private GameObject Player;
	private float fadeSpeed = 5f;
	private Color _transparant;

	//Speed variables
	private float _speed = 15f;
	private float _jumpForce = 450f;

	//Health, Stamina and Experience
	public int _health = 100;
	public int _stamina = 100;
	public float experience = 0;

	//Death Timer Restart
	private int onDeathRespawn = 250;

	//Stamina Regen timer
	private int StaTimer = 0;

	//Check if on Ground
	private bool isGrounded = false;

	void Start()
	{
		Player = GameObject.Find ("Player");
		_transparant = new Color (0, 0, 0, 0);
	}

	void Update () 
	{
		CheckHealth ();

		if (_health > 0)
		{
			if (Input.GetAxis ("Horizontal") != 0 || Input.GetKeyDown(KeyCode.Space))
				CheckMovement ();

			//Damage Test
			if(Input.GetKeyDown(KeyCode.H) && _health > 0)
				_health -= 20;

			//Stamina Refill
			if (StaTimer > 0)
			{
				StaTimer--;
			}else if(StaTimer == 0 && _stamina < 100)
				_stamina ++;
		}
		if (_health <= 0)
		{
			onDeathRespawn -= 1;
		}
		if (onDeathRespawn < 0)
			Application.LoadLevel(0);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Floor")
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
		
		transform.Translate (0, 0, x, Space.Self);
	}
	
	void CheckHealth()
	{
		if (_health <= 0)
		{
			Player.renderer.material.color = Color.Lerp (Player.renderer.material.color, _transparant, fadeSpeed * Time.deltaTime);
			Destroy(gameObject, 5f);
		}
	}
}
