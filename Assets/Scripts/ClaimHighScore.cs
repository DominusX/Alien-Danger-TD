using UnityEngine;
using System.Collections;

public class ClaimHighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//ClaimScore ();
	
	}
	static void ClaimScore (){
		GlobalScoreBoard g = new GlobalScoreBoard ();
		if (g.isHighScore (700)) {
			//check if user current score > the one saved in player pref then only claim the highScore..
			g.ClaimCurrentScore ("Wow Score", 99999);
		} else {
			Debug.Log("Not in top 5 ");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
