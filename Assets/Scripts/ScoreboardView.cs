using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class ScoreboardView : MonoBehaviour {

    public Text txt;
	string scores = " ";
	string newline="\n";
	bool isPrinted = false;

	void OnGUI() {
		if (GlobalScoreBoard.topScores.Count == 5 &&!isPrinted) {
			printScores();
			isPrinted=true;
		}
	}

	public void printScores(){

		string player1 = newline+ GlobalScoreBoard.topScores.ElementAt(0).playerName + "   " +GlobalScoreBoard.topScores.ElementAt(0).PlayerScore + newline;
		string player2 = GlobalScoreBoard.topScores.ElementAt(1).playerName + "   " + GlobalScoreBoard.topScores.ElementAt(1).PlayerScore + newline;
		string player3 = GlobalScoreBoard.topScores.ElementAt(2).playerName + "   " + GlobalScoreBoard.topScores.ElementAt(2).PlayerScore + newline;
		string player4 = GlobalScoreBoard.topScores.ElementAt(3).playerName + "   " + GlobalScoreBoard.topScores.ElementAt(3).PlayerScore + newline;
		string player5 = GlobalScoreBoard.topScores.ElementAt(4).playerName + "   " + GlobalScoreBoard.topScores.ElementAt(4).PlayerScore + newline;
		txt.text = player1 + player2 + player3 + player4 + player5;
		
	}
}