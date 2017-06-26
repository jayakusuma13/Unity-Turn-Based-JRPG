using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateStart : MonoBehaviour {

	public BasePlayer newEnemy = new BasePlayer();
	private string[] enemyNames = new string[]{"Frank","Victor","Pinkguy"};
	private StatCalculations StatCalculation = new StatCalculations();

	private int playerStamina;
	private int playerEndurance;
	private int playerHealth;
	private int playerEnergy;

	private int enemyStamina;
	private int enemyEndurance;
	private int enemyHealth;
	private int enemyEnergy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PrepareBattle(){
		CreateNewEnemy ();
		DeterminePlayerVitals ();
		FirstTurn ();
	}

	public void CreateNewEnemy(){
		newEnemy.PlayerName = enemyNames[Random.Range(0,enemyNames.Length)];
		newEnemy.PlayerLevel = Random.Range (GameInformation.PlayerLevel - 2, GameInformation.PlayerLevel + 2);
		newEnemy.Stamina = StatCalculation.CalculateStat (newEnemy.Stamina, 
			StatCalculations.StatType.stamina, newEnemy.PlayerLevel,true);
		newEnemy.Intellect = StatCalculation.CalculateStat (newEnemy.Intellect, 
			StatCalculations.StatType.intellect, newEnemy.PlayerLevel,true);
		newEnemy.Strength = StatCalculation.CalculateStat (newEnemy.Strength, 
			StatCalculations.StatType.strength, newEnemy.PlayerLevel,true);	
		newEnemy.Endurance = StatCalculation.CalculateStat (newEnemy.Endurance, 
			StatCalculations.StatType.endurance, newEnemy.PlayerLevel,true);	
	}

	public void FirstTurn(){
		if (GameInformation.Strength >= newEnemy.Strength) {
			CombatController.currentState = CombatController.BattleStates.playerChoice;
		}else{
			CombatController.currentState = CombatController.BattleStates.enemyChoice;
		}
	}

	private void DeterminePlayerVitals(){
		GameInformation.PlayerClass = new BaseWarriorClass ();
		GameInformation.Intellect = GameInformation.PlayerClass.Intellect;	
		GameInformation.Strength = GameInformation.PlayerClass.Strength;
		GameInformation.Stamina = GameInformation.PlayerClass.Stamina;
		GameInformation.Endurance = GameInformation.PlayerClass.Endurance;

		GameInformation.PlayerHealth = StatCalculation.CalculateHealth(GameInformation.Stamina);
		GameInformation.PlayerEnergy = StatCalculation.CalculateEnergy (GameInformation.Endurance);
		GameInformation.PlayerLevel = 2;	
		/*
		playerStamina = StatCalculation.CalculateStat (GameInformation.Stamina,
			StatCalculations.StatType.stamina,GameInformation.PlayerLevel,false);
		playerEndurance = StatCalculation.CalculateStat (GameInformation.Endurance,
			StatCalculations.StatType.endurance,GameInformation.PlayerLevel,false);
		*/
		/*
		enemyStamina = StatCalculation.CalculateStat (GameInformation.Stamina,
			StatCalculations.StatType.stamina,GameInformation.PlayerLevel,false);
		enemyEndurance = StatCalculation.CalculateStat (GameInformation.Endurance,
			StatCalculations.StatType.endurance,GameInformation.PlayerLevel,false);
		enemyHealth = StatCalculation.CalculateHealth(newEnemy.Stamina);
		enemyEnergy = StatCalculation.CalculateEnergy (enemyEndurance);
		*/



		GameInformation.EnemyName = enemyNames[0];
		GameInformation.EnemyHealth = StatCalculation.CalculateHealth(GameInformation.Stamina / 2);
		GameInformation.EnemyEnergy = StatCalculation.CalculateEnergy (GameInformation.Endurance / 2);
		GameInformation.EnemyLevel = Random.Range ((int)GameInformation.PlayerLevel-1,(int)GameInformation.PlayerLevel+1);

	}
}
