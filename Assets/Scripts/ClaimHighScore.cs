using UnityEngine;
using System.Collections;
using System;

public class ClaimHighScore : MonoBehaviour {

	public static Boolean scoreSubmitted = false;

	/* Setting & submitting score to global scoring system "Parse"
	 * A dll handles the request coming to and from the global scores cloud storage
	 */
	public static void ClaimScore() {
		
		GlobalScoreBoard globalScores = new GlobalScoreBoard ();
		
		string playerName = null;
		int playerScore = 0;

		if(!scoreSubmitted){
			try{
				if(globalScores.isHighScore(PlayerPrefs.GetInt ("Player Score"))){
					
					playerName = PlayerPrefs.GetString ("Player Name");
					playerScore = PlayerPrefs.GetInt ("Player Score");
					
					if(playerName.Equals ("") || playerName == null)
						playerName = "Anonymous";
					
					globalScores.ClaimCurrentScore(playerName, playerScore);
					
					print ("Player " + playerName + " Score Saved!");
				}
				else{
					print ("Player " + playerName + " Score Not in Top Five!");
				}
			}
			catch(Exception error){
				print ("Error: " + error);
			}
		}
	}
}