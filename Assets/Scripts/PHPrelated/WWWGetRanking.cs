using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WWWGetRanking : MonoBehaviour {
	private string imagesUrl = "16710.hosts.ma-cloud.nl/mythe/uploads/";
	private string URL = "16710.hosts.ma-cloud.nl/mythe/getHighscores.php?unity=true";
	public Image[] allImages;
	public Text[] allTexts;
	void Start () {
		CreateFakeImages();
		WWW www = new WWW(URL);
		StartCoroutine(WaitForRequest(www));
	}
	void CreateFakeImages()
	{
		foreach(Image image in allImages)
		{
			image.sprite = Sprite.Create(Texture2D.whiteTexture,new Rect(0,0,522,326),new Vector2(0,0));
			Color newColor = Color.white;
			newColor.a = 0;
			image.color = newColor;
		}
	}
	IEnumerator WaitForRequest(WWW www) {
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!");
			string[] allRows = www.text.Split(',');
			for (int i = 0; i < allRows.Length; i++) {
				string[] allInfo = allRows[i].Split('-');

				allTexts[i].text = allInfo[1] + " - " + allInfo[2];
				WWW spritewww = new WWW(imagesUrl + allInfo[3]);
				yield return spritewww;
				Sprite newSprite = Sprite.Create(spritewww.texture, new Rect(0,0,spritewww.texture.width,spritewww.texture.height),new Vector2(0,0));
				allImages[i].sprite = newSprite;
				allImages[i].color = Color.white;
			}
		} 
		else 
		{
			Debug.Log("WWW Error: " + www.error);
		}
	}
}
