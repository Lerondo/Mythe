using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {
	public const string HEALTHBAR = "healthbar";
	public const string STAMINABAR = "staminabar";
	public const string XPBAR = "xpbar";

	//Ingame bars
	[SerializeField]private Slider _healthBar;
	[SerializeField]private Slider _staminaBar;
	[SerializeField]private Slider _XPBar;

	/// <summary>
	/// Updates a userinterface slider.
	/// </summary>
	/// <param name="bar">Bar.</param>
	/// <param name="value">Value.</param>
	public void UpdateBar(string bar, int value)
	{
		if(bar == HEALTHBAR)
		{
			_healthBar.value = value;
		}
		else if(bar == STAMINABAR)
		{
			_staminaBar.value = value;
		}
		else if(bar == XPBAR)
		{
			_XPBar.value = value;
		} else {
			Debug.LogWarning("bar does not exist");
		}
	}
	/// <summary>
	/// Updates the max value.
	/// </summary>
	/// <param name="bar">Bar.</param>
	/// <param name="value">Value.</param>
	public void UpdateMaxValue(string bar, int value)
	{
		if(bar == HEALTHBAR)
		{
			_healthBar.maxValue += value;
		}
		else if(bar == STAMINABAR)
		{
			_staminaBar.maxValue += value;
		}
		else if(bar == XPBAR)
		{
			_XPBar.maxValue += value;
		} else {
			Debug.LogWarning("bar does not exist");
		}
	}
	/// <summary>
	/// Sets the max value.
	/// </summary>
	/// <param name="bar">Bar.</param>
	/// <param name="value">Value.</param>
	public void SetMaxValue(string bar,int value)
	{
		if(bar == HEALTHBAR)
		{
			_healthBar.maxValue = value;
		}
		else if(bar == STAMINABAR)
		{
			_staminaBar.maxValue = value;
		}
		else if(bar == XPBAR)
		{
			_XPBar.maxValue = value;
		} else {
			Debug.LogWarning("bar does not exist");
		}
	}
	/// <summary>
	/// Gets the max value.
	/// </summary>
	/// <returns>The max value.</returns>
	/// <param name="bar">Bar.</param>
	public float GetMaxValue(string bar)
	{
		if(bar == HEALTHBAR)
		{
			return _healthBar.maxValue;
		}
		else if(bar == STAMINABAR)
		{
			return _staminaBar.maxValue;
		}
		else if(bar == XPBAR)
		{
			return _XPBar.maxValue;
		} else {
			Debug.LogWarning("bar does not exist");
		}
		return 0;
	}
}
