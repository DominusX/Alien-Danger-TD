using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System.Linq;

using UnityEngine.UI;

public class GlobalScoreBoard : MonoBehaviour {
	static int currentTopScores = 9999;
	public static List<ScoreEntry> topScores = new List<ScoreEntry>();

	public struct ScoreEntry {
		public int PlayerScore;
		public string playerName;
	}

	void Awake(){

		var query = ParseObject.GetQuery("GameScore").WhereExists("playerName").WhereExists("PlayerScore").OrderByDescending("PlayerScore").Limit(5);
		var task = query.FindAsync(); //encapsulate the whole process of network... runs in the background
		topScores.Clear ();
		task.ContinueWith( (t) => {
			foreach(ParseObject gameScore in t.Result){
				topScores.Add(new ScoreEntry(){
				PlayerScore = gameScore.Get<int>("PlayerScore"),
				playerName = gameScore.Get<string>("playerName")
				
				});
				Debug.Log("init finished");
			}
		});
	}

	//setting the currentTopScore
	public void setCurrentScore(int score){
		currentTopScores = score;
	}

	//checking the highScore
	public bool isHighScore(int score){
		var topFive = topScores.Take (5);
		if (topFive.Any ()) {
			return (score > topFive.Last().PlayerScore);
		} else {
			return true;
		}
	}

	public void ClaimCurrentScore(string name , int score){
		ParseObject gameScore = new ParseObject ("GameScore");
		gameScore ["playerName"] = name;
		gameScore ["PlayerScore"] = score;
		gameScore.SaveAsync ();
	}

	public string getPlayerName(){
		//use playerPrefs to load the playername
		return "playerName";
	}

	public int getCurrentTopScore(){
		//use playerpref to get the current score..
		return 777;
	}

	public List<ScoreEntry> GetScores(){
		return topScores;
	}
}