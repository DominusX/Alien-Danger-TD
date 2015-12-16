using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void loadLeaderboardScene()
	{
		Application.LoadLevel(1);
	}

	void OnGUI()
	{
		GUIStyle myStyle = new GUIStyle (GUI.skin.box);
		myStyle.normal.textColor = Color.white;
		
		myStyle.onNormal.textColor = Color.white;
		myStyle.onHover.textColor = Color.white;
		
		myStyle.alignment = TextAnchor.MiddleCenter;
	
		RectOffset margin = new RectOffset ();
		margin.bottom = 10;
		margin.top = 10;
		myStyle.margin = margin;
		
		int ftSize = (int)(Screen.height * .07);
		myStyle.fontSize = ftSize;

		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .30f, Screen.width * .5f, Screen.height * .1f), "New Game", myStyle)) {
		}

		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .42f, Screen.width * .5f, Screen.height * .1f), "Leaderboard", myStyle)) {
			Application.LoadLevel (1);
		}

		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .66f, Screen.width * .5f, Screen.height * .1f), "Quit", myStyle)) {
			Application.Quit();
		}
	}
}