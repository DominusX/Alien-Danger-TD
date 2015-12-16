using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetPlayerName : MonoBehaviour {
	
	public InputField nameInputField;
	
	private void Start(){
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
		submitEvent.AddListener(SubmitName);
		nameInputField.onEndEdit = submitEvent;
	}
	
	private void SubmitName(string playerName){
		PlayerPrefs.SetString("Player Name", playerName);
	}
}