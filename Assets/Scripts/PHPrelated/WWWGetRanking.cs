using UnityEngine;
using System.Collections;

public class WWWGetRanking : MonoBehaviour {
	private string imagesUrl = "16710.hosts.ma-cloud.nl/mythe/uploads/";
	private string URL = "16710.hosts.ma-cloud.nl/mythe/getHighscores.php?unity=true";
	void Start () {
		WWW www = new WWW(URL);
		StartCoroutine(WaitForRequest(www));
	}
	IEnumerator WaitForRequest(WWW www) {
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!");
			string[] allRows = www.text.Split(',');
			foreach(string row in allRows)
			{
				string[] allInfo = row.Split('-');
				Debug.Log(allInfo[1]);
				Debug.Log(allInfo[2]);
				Debug.Log(allInfo[3]);
			}
		} 
		else 
		{
			Debug.Log("WWW Error: " + www.error);
		}
	}
}
