using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using TDTK;

namespace TDTK {

	public class UIGameOverMenu : MonoBehaviour {

		private GameObject thisObj;
		private static UIGameOverMenu instance;
		
		public Text txtTitle;
		public GameObject butContinueObj;
		
		void Awake(){
			instance=this;
			thisObj=gameObject;
			transform.localPosition=Vector3.zero;
		}
		
		// Use this for initialization
		void Start () {
			Hide();
		}

		public void OnContinueButton(){
			WindowsClameScore.scoreSubmitted = false;
			Time.timeScale=1;
			GameControl.LoadNextScene();
		}
		
		public void OnRestartButton(){
			WindowsClameScore.scoreSubmitted = false;
			Application.LoadLevel(Application.loadedLevelName);
		}
		
		public void OnMainMenuButton(){
			WindowsClameScore.scoreSubmitted = false;
			Time.timeScale=1;
			GameControl.LoadMainMenu();
		}

		public static bool isOn=true;
		public static void Show(bool playerWon){ instance._Show(playerWon); }
		public void _Show(bool playerWon){

			if(playerWon){
				txtTitle.text="Level Completed!";
				butContinueObj.SetActive(true);
			}
			else{
				txtTitle.text="Game Over";
				butContinueObj.SetActive(false);
			}

			// Getting resources, getting points from framework & setting player prefs
			List<Rsc> resources = ResourceManager.GetResourceList();
			PlayerPrefs.SetInt ("Player Score", resources [1].value);

			isOn=true;
			thisObj.SetActive(isOn);
			Time.timeScale=0;
			WindowsClameScore.ClaimScore();
			WindowsClameScore.scoreSubmitted = true;
		}

		public static void Hide(){ instance._Hide(); }
		public void _Hide(){
			isOn=false;
			thisObj.SetActive(isOn);
		}
	}
}