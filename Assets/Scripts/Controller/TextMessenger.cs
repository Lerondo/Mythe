using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextMessenger : MonoBehaviour {
	public void MakeText(string text, Vector3 Position, Color color, int size, bool ableToMove)
	{
		GameObject newText = GameObject.FindGameObjectWithTag(TagManager.GameController).GetComponent<ObjectPool>().GetObjectForType("Text", false);
		TextBehavior textScript = newText.GetComponent<TextBehavior>();
		textScript.SetPosition(Position);
		textScript.SetResetTime (2f);
		textScript.SetAbleToMove(ableToMove);
		Text textComponent = newText.GetComponent<Text>();
		textComponent.text = text;
		textComponent.fontSize = size;
		textComponent.color = color;
	}
}
