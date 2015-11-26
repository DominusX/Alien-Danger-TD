using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TDTK;

namespace TDTK {

	public class MenuSystem : MonoBehaviour {

		public RectTransform frame;
		
		public List<string> displayedName=new List<string>();
		public List<string> levelName=new List<string>();
		public List<UnityButton> buttonList=new List<UnityButton>();
		
		// Use this for initialization
		void Start (){
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
		void Update () {
		
		}
		
		public void OnButtonPress(GameObject butObj){
			for(int i=0; i<buttonList.Count; i++){
				if(buttonList[i].rootObj==butObj){
					string curLevel = Application.loadedLevelName;
					switch(curLevel){
						case "Menu":
							if(i == 3){
								Application.Quit();
							}
							else{
								Application.LoadLevel(levelName[i]);
							}
						break;
						case "Leaderboard":
						case "Help":
							Application.LoadLevel(0);
						break;
						case "PlayerName":
							if(i == 0){
								Application.LoadLevel(4);
							}
							else{
								Application.LoadLevel(0);
							}
						break;
					}

				}
			}
		}
	}
}