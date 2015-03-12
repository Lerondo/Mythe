using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	//TODO: Entry Message, Talk Message, Exit Message lists
	//TODO: spawn dialogue via objectpool
	//TODO: change image by list.
	//TODO: set position.
	//TODO: timer poolobject via objectbool
	
	public string[] merchantWelcomeText = new string[0];
	public string[] merchantLeaveText = new string[0];
	public Text merchantText;

	public void WelcomeMessage(Vector3 position)
	{
		StartCoroutine(CreateDialogue(merchantWelcomeText[Random.Range(0,merchantWelcomeText.Length)],position));
	}
	public void LeaveMessage(Vector3 position)
	{
		StartCoroutine(CreateDialogue(merchantLeaveText[Random.Range(0,merchantLeaveText.Length)],position));
	}
	public IEnumerator CreateDialogue(string text, Vector3 position)
	{
		GameObject newText = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ObjectPool>().GetObjectForType("Text", false);
		TextBehavior textScript = newText.GetComponent<TextBehavior>();
		textScript.SetPosition(position);
		textScript.SetAbleToMove(false);
		Text textComponent = newText.GetComponent<Text>();
		textComponent.color = Color.black;
		textComponent.text = "";
		textScript.SetResetTime (5f);
		char[] allCharsInText = text.ToCharArray();
		foreach(char characters in allCharsInText)
		{
			textComponent.text += characters;
			yield return new WaitForSeconds(0.04f);
		}
	}
}
