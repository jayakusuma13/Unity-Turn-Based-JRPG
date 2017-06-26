using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour {

	private bool hasAddedXP;
	private BattleStateStart BattleStateStartScript = new BattleStateStart();
	private BattleCalculations battleCalcScript = new BattleCalculations();
	private BattleStateEnemyChoice battleStateEnemyChoiceScript = new BattleStateEnemyChoice();
	private BattleGUI battleGUIScript = new BattleGUI();
	public static BaseAbility enemyUsedAbility;
	public static BaseAbility playerUsedAbility;

	public static int statusEffectBaseDamage;
	public static int totalTurnCount;
	public static bool playerDidCompleteTurn;
	public static bool enemyDidCOmpleteTurn;
	public static BattleStates currentUser;

	public Text thetext;
	public GameObject box;
	private bool Previous;
	public List<string> logMessages = new List<string>();
	private bool messageTrigger;
	int i = 0;
	private bool messageTime;

	private BattleStateAddStatusEffects battleStateAddStatusEffectsScript = new BattleStateAddStatusEffects();
	public enum BattleStates{
		start,
		playerChoice,
		enemyChoice,
		calcDamage,
		addStatusEffects,
		endturn,
		win,
		lose
	}

	public static BattleStates currentState;
	// Use this for initialization
	void Start () {
		hasAddedXP = false;
		currentState = BattleStates.start;
		totalTurnCount = 1;
	}

	void showMessage(){
		
	}

	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Return)){
			thetext.text = logMessages [i];
			if (i < logMessages.Count-1) {
				i++;
			} else {
				//box.SetActive(false);
			}
		}

		switch(currentState){
		case(BattleStates.start):
			BattleStateStartScript.PrepareBattle ();
			break;
		case(BattleStates.playerChoice):
			showLogMessage("Your Health is " + GameInformation.PlayerHealth);
			showLogMessage("The Enemy Health is " + GameInformation.EnemyHealth);
			currentUser = BattleStates.playerChoice;
			break;
		case(BattleStates.enemyChoice):
			//enemyDidCOmpleteTurn = true;
			showLogMessage("Enemy Turn");

			currentUser = BattleStates.enemyChoice;
			battleStateEnemyChoiceScript.EnemyCompleteTurn();
			break;
		case(BattleStates.calcDamage):
			if (currentUser == BattleStates.playerChoice) {
				battleCalcScript.CalculateTotalPlayerDamage (playerUsedAbility);
				showLogMessage("Enemy has taken " + battleCalcScript.totalPlayerDamage + " Damage!");

				GameInformation.EnemyHealth = (int)(GameInformation.EnemyHealth - battleCalcScript.totalPlayerDamage);
				showLogMessage("Enemy health now is " + GameInformation.EnemyHealth);

			}
			if (currentUser == BattleStates.enemyChoice) {
				battleCalcScript.CalculateTotalEnemyDamage (enemyUsedAbility);
				showLogMessage("You have taken " + battleCalcScript.totalEnemyDamage + " Damage!");

				GameInformation.PlayerHealth = (int)(GameInformation.PlayerHealth - battleCalcScript.totalEnemyDamage);
				showLogMessage("Your health now is " + GameInformation.PlayerHealth);

			}
			//battleCalcScript.CalculateTotalPlayerDamage (playerUsedAbility);
			CheckWhoGoesNext();
			break;
		case(BattleStates.addStatusEffects):
			//Debug.Log ("Checking for Status Effects");
			battleStateAddStatusEffectsScript.CheckAbilityForStatusEffects (playerUsedAbility);
			break;
		case(BattleStates.lose):
			showLogMessage("You lose");
			break;
		case(BattleStates.endturn):
			//GameInformation.DebugLogText = " ";
			totalTurnCount += 1;
			playerDidCompleteTurn = false;
			enemyDidCOmpleteTurn = false;
			if (GameInformation.EnemyHealth > 0 && GameInformation.PlayerHealth > 0) {
				showLogMessage("Your Turn!");
				currentState = CombatController.BattleStates.playerChoice;
			} else if (GameInformation.EnemyHealth <= 0) {
				currentState = CombatController.BattleStates.win;
			} else if(GameInformation.PlayerHealth <= 0){
				currentState = CombatController.BattleStates.lose;
			}
			break;
		case(BattleStates.win):
			showLogMessage("You won!");
			break;
		}
	}

	private void CheckWhoGoesNext(){
		if (playerDidCompleteTurn && !enemyDidCOmpleteTurn) {
			currentState = CombatController.BattleStates.enemyChoice;
		} else if (!playerDidCompleteTurn && enemyDidCOmpleteTurn) {
			currentState = CombatController.BattleStates.playerChoice;
		} else {
			currentState = CombatController.BattleStates.endturn;
		}
	}

	private IEnumerator showLog(string logMessage){
		Debug.Log (logMessage);
		thetext.text = logMessage;
		yield return new WaitForSeconds (3);
		//Debug.Log (logMessage);
	}

	private IEnumerator timer(){
		yield return new WaitForSeconds (4);
		messageTime = true;
		yield return new WaitForSeconds (4);
		messageTime = false;

	}

	private void showLogMessage(string Message){
		if (!logMessages.Contains(Message)) {
			logMessages.Add (Message);
		}
	}
		
}
