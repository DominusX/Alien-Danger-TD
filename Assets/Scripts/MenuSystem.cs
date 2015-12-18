using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using TDTK;

namespace TDTK {
	
	public class MenuSystem : MonoBehaviour {

		private string curLevel = "";

		public RectTransform frame;
		
		public List<string> displayedName=new List<string>();
		public List<string> levelName=new List<string>();
		public List<UnityButton> buttonList=new List<UnityButton>();
		
		// Use this for initialization
		void Start (){
			PlayerPrefs.SetString("Player Name", "");
			PlayerPrefs.SetInt("Player Score", 0);

			curLevel = Application.loadedLevelName;
			
			for(int i=0; i<levelName.Count; i++){
				if(i==0) buttonList[0].Init();
				else if(i>0){
					buttonList.Add(buttonList[0].Clone("ButtonStart"+(i+1), new Vector3(0, -i*45, 0)));
				}
				
				buttonList[i].label.text=displayedName[i];
			}
			
			frame.sizeDelta=new Vector2(300, 60+levelName.Count*80);
		}
		
		// Update is called once per frame
		void Update() 
		{
			if (Input.GetKeyDown (KeyCode.Escape)) 
			{
				MenuFunction(curLevel);
			}
		}
		
		public void OnButtonPress(GameObject butObj){
			for(int i=0; i<buttonList.Count; i++){
				if(buttonList[i].rootObj==butObj){
					MenuFunction(curLevel, i);
				}
			}
		}
		
		public void MenuFunction(string curLevel, int i){
			switch(curLevel){
			case "Menu":
				if(i == 2){
					Application.Quit();
				}
				else{
					Application.LoadLevel(levelName[i]);
				}
				break;
			case "Leaderboard":
				Application.LoadLevel(0);
				break;
			case "PlayerName":
				if(i == 0){
					Application.LoadLevel(3);
				}
				else{
					Application.LoadLevel(0);
				}
				break;
			}
		}
		
		public void MenuFunction(string curLevel){
			switch(curLevel){
			case "Menu":
				Application.Quit();
				break;
			case "Leaderboard":
			case "PlayerName":
				Application.LoadLevel(0);
				break;
			}
		}
	}
}