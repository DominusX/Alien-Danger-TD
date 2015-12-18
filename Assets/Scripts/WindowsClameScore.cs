using UnityEngine;
using System.Collections;
using System;

public class WindowsClameScore : MonoBehaviour {
	
	public static Boolean scoreSubmitted = false;
	
	/* Setting & submitting score to global scoring system "Parse"
	 * A dll handles the request coming to and from the global scores cloud storage
	 */
	public static void ClaimScore() {
		
		string playerName = null;
		int playerScore = 0;
		
		if(!scoreSubmitted){
			try{
				playerName = PlayerPrefs.GetString ("Player Name");
				playerScore = PlayerPrefs.GetInt ("Player Score");
				
				if(playerName.Equals ("") || playerName == null)
					playerName = "Anonymous";

				HighScoresWindows.AddNewHighscore(playerName, playerScore);
				
				print ("Player " + playerName + " Score Saved!");
			}
			catch(Exception error){
				print ("Error: " + error);
			}
		}
	}
}