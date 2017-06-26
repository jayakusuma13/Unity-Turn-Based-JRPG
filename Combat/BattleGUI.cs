using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGUI : MonoBehaviour {

	private string playerName;
	private int playerLevel;
	private int playerHealth;
	private int playerEnergy;

	public GameObject box;
	public Text thetext;
	public string logText;
	public List<string> logMessages = new List<string>();
	int i = 0;

	// Use this for initialization
	void Start () {
		playerName = GameInformation.PlayerName;
		playerLevel = GameInformation.PlayerLevel;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(Input.GetKeyDown(KeyCode.Return)){
			Debug.Log (logMessages.Count);
			thetext.text = logMessages [i];
			if (i < logMessages.Count-1) {
				i++;
			} else {
				//box.SetActive(false);
			}
		}
		*/
	}

	void OnGUI(){
		if (CombatController.currentState == CombatController.BattleStates.playerChoice) {
			DisplayPlayerChoice ();
		}

	}

	private void DisplayPlayerChoice(){
		if (GUI.Button (new Rect (Screen.width - 200, Screen.height - 50, 100, 30), GameInformation.playerMoveOne.AbilityName)) {
			CombatController.playerUsedAbility = GameInformation.playerMoveOne;
			CombatController.currentState = CombatController.BattleStates.addStatusEffects;
		}
		if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 50, 100, 30), GameInformation.playerMoveTwo.AbilityName)) {
			CombatController.playerUsedAbility = GameInformation.playerMoveTwo;
			CombatController.currentState = CombatController.BattleStates.addStatusEffects;
		}
	}

	public void showLogMessage(string Message){
		if (!logMessages.Contains(Message)) {
			logMessages.Add (Message);
		}
	}
}
