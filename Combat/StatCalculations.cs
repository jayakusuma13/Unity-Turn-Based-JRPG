using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculations {

	private float enemyStaminaModifier = 0.25f;
	private float enemyEnduranceModifier = 0.25f;
	private float enemyIntellectModifier = 0.2f;
	private float enemyStrengthModifier = 0.2f;
	private float playerStaminaModifier = 0.3f;
	private float playerEnduranceModifier = 0.3f;
	private float statModifier;

	private float mainStatModifier = 0.5f;
	private float secondStatModifier = 0.5f;

	public enum StatType{
		stamina,
		endurance,
		intellect,
		strength
	}

	public int CalculateStat(int statVal, StatType statType, int level, bool IsEnemy){
		if (IsEnemy) {
			SetEnemyModifier (statType);
			return(statVal+(int)((statVal*statModifier)*level));
		}else if(!IsEnemy){
			SetEnemyModifier (statType);
			Debug.Log ("an info " + IsEnemy);
			return(statVal+(int)((statVal*statModifier)*level));
		}
		return 0;
	}

	private void SetEnemyModifier(StatType statType){
		if(statType == StatType.stamina){
			statModifier = enemyStaminaModifier;
		}
		if(statType == StatType.strength){
			statModifier = enemyStrengthModifier;
		}
		if(statType == StatType.endurance){
			statModifier = enemyEnduranceModifier;
		}
		if(statType == StatType.intellect){
			statModifier = enemyIntellectModifier;
		}
	}

	public int CalculateHealth(int statValue){
		return statValue * 10;
	}

	public int CalculateEnergy(int statValue){
		return statValue * 12;
	}

	public float FindPlayerMainStatAndCalculateMainStatModifier(){
		if (GameInformation.PlayerClass.MainStat == BaseCharacterClass.MainStatBonuses.STRENGTH
			&& GameInformation.PlayerClass.MainStat == BaseCharacterClass.MainStatBonuses.ENDURANCE) {
			Debug.Log (GameInformation.Strength);
			return (GameInformation.Strength * mainStatModifier) + (GameInformation.Endurance * secondStatModifier);
		}
		return 1.0f;	
	}
		
}
