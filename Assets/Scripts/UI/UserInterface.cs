using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UserInterface : MonoBehaviour {
	public const string HEALTHBAR = "healthbar";
	public const string MANABAR = "manabar";
	public const string EXPERIENCEBAR = "xpbar";

	//Ingame bars
	[SerializeField]private Slider _healthBar;
	[SerializeField]private Slider _manaBar;
	[SerializeField]private Slider _experienceBar;

	private Dictionary<string, Slider> _allBars = new Dictionary<string, Slider>();

	void Start()
	{
		_allBars.Add(HEALTHBAR, _healthBar);
		_allBars.Add(MANABAR, _manaBar);
		_allBars.Add(EXPERIENCEBAR, _experienceBar);
	}
	/// <summary>
	/// Updates a userinterface slider.
	/// </summary>
	/// <param name="bar">Bar.</param>
	/// <param name="value">Value.</param>
	public void UpdateBar(string bar, int value)
	{
		_allBars[bar].value = value;
	}
	/// <summary>
	/// Updates the max value.
	/// </summary>
	/// <param name="bar">Bar.</param>
	/// <param name="value">Value.</param>
	public void UpdateMaxValue(string bar, int value)
	{
		_allBars[bar].maxValue += value;
	}
	/// <summary>
	/// Sets the max value.
	/// </summary>
	/// <param name="bar">Bar.</param>
	/// <param name="value">Value.</param>
	public void SetMaxValue(string bar,int value)
	{
		_allBars[bar].maxValue = value;
	}
	/// <summary>
	/// Gets the max value.
	/// </summary>
	/// <returns>The max value.</returns>
	/// <param name="bar">Bar.</param>
	public float GetMaxValue(string bar)
	{
		return _allBars[bar].maxValue;
	}
}
