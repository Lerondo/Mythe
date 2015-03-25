using UnityEngine;
using System.Collections;

public class WWWScreenshot : MonoBehaviour {
	// Grab a screen shot and upload it to a CGI script.
	// The CGI script must be able to hande form uploads.
	public string username = "Menno";
	public float score = 130;
	private string screenShotURL= "16710.hosts.ma-cloud.nl/mythe/uploadImage.php";
	public IEnumerator UploadPNG() {
		PlayerStats playerStats = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStats>();
		if(username != playerStats.username)
		{
			// We should only read the screen after all rendering is complete
			yield return new WaitForEndOfFrame();
			// Create a texture the size of the screen, RGB24 format
			int width = Screen.width;
			int height = Screen.height;
			Texture2D tex = new Texture2D( width, height, TextureFormat.RGB24, false );
			// Read screen contents into the texture
			tex.ReadPixels(new Rect(0, 0, width, height), 0, 0 );
			tex.Apply();
			// Encode texture into PNG
			byte[] bytes = tex.EncodeToPNG();
			Destroy( tex );

			username = playerStats.username;
			score = playerStats.gold;
			string time = playerStats.timePlayed.ToString();
			// Create a Web Form
			WWWForm form = new WWWForm();
			form.AddField("frameCount", Time.frameCount.ToString());
			form.AddField("score", score.ToString());
			form.AddField("username", username);
			form.AddField("time", time);
			form.AddField("thumb", username + ".png");
			form.AddBinaryData("fileToUpload", bytes, username + ".png", "image/png");

			// Upload to a cgi script
			WWW w = new WWW(screenShotURL, form);
			yield return w;
			if (!string.IsNullOrEmpty(w.error))
				print(w.error);
			else
				print("Finished Uploading Screenshot + highscore");
			print (w.text);
		}
	}
}
