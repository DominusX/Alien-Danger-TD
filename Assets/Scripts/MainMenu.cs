using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void loadLeaderboardScene()
	{
		Application.LoadLevel(1);
	}

	void OnGUI()
	{
		//GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backGroundText);
		
		//GUI.DrawTexture (new Rect (Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.height * .2f), titleText);
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
			//Do SomeThing..
			//Application.LoadLevel (1);
		}
		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .42f, Screen.width * .5f, Screen.height * .1f), "Leaderboard", myStyle)) {
			//Do SomeThing..
			Application.LoadLevel (1);
		}
		
		
		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .54f, Screen.width * .5f, Screen.height * .1f), "Instructions", myStyle)) {
			
			//load instruction scene
			
		}
		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .66f, Screen.width * .5f, Screen.height * .1f), "Quit", myStyle)) {
			//TODO
			//Application.LoadLevel (4);
			Application.Quit();
		}
	}
}
