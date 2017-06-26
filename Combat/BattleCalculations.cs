using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCalculations{

	private StatCalculations statCalcScript = new StatCalculations();

	private BaseAbility playerUsedAbility;

	private int abilityPower;
	private float totalAbilityPowerDamage;
	private int totalUsedAbilityDamage;
	private int statusEffectDamage;
	public float totalPlayerDamage;
	public float totalEnemyDamage;
	private int totalCritStrikeDamage = 0;

	private float damageVarianceModifier = 0.25f;
	public float currentDamage;

	public void CalculateTotalPlayerDamage(BaseAbility usedAbility){
		playerUsedAbility = usedAbility;
		totalUsedAbilityDamage = (int)CalculateAbilityDamage (usedAbility);
		statusEffectDamage = CalculateStatusEffectDamage ();
		totalPlayerDamage = totalUsedAbilityDamage + statusEffectDamage + totalCritStrikeDamage;
		//totalPlayerDamage += (int)(Random.Range (-(totalPlayerDamage*damageVarianceModifier),totalPlayerDamage*damageVarianceModifier));
		//Debug.Log ("Total Player Damage: " + totalPlayerDamage);
		CombatController.playerDidCompleteTurn = true;
		CombatController.currentState = CombatController.BattleStates.enemyChoice;
	}

	public void CalculateTotalEnemyDamage(BaseAbility usedAbility){
		playerUsedAbility = usedAbility;
		totalUsedAbilityDamage = (int)CalculateAbilityDamage (usedAbility);
		statusEffectDamage = CalculateStatusEffectDamage ();
		totalEnemyDamage = totalUsedAbilityDamage + statusEffectDamage + totalCritStrikeDamage;
		//totalPlayerDamage += (int)(Random.Range (-(totalPlayerDamage*damageVarianceModifier),totalPlayerDamage*damageVarianceModifier));
		//Debug.Log ("Total Enemy Damage: " + totalPlayerDamage);
		CombatController.enemyDidCOmpleteTurn = true;
		CombatController.currentState = CombatController.BattleStates.endturn;
	}

	private float CalculateAbilityDamage(BaseAbility usedAbility){
		abilityPower = usedAbility.AbilityPower;
		totalAbilityPowerDamage = abilityPower * statCalcScript.FindPlayerMainStatAndCalculateMainStatModifier();
		return totalAbilityPowerDamage;
	}

	private int CalculateStatusEffectDamage(){
		statusEffectDamage = CombatController.statusEffectBaseDamage * GameInformation.PlayerLevel;
		Debug.Log ("Status Effect Damage "+ statusEffectDamage);
		return statusEffectDamage;
	}

	private int CalculateCriticalStrike(){
		if (DecideIfAbilityCriticallyHit ()) {
			return totalCritStrikeDamage = (int)(playerUsedAbility.AbilityCritModifier * totalAbilityPowerDamage);
		} else {
			return totalCritStrikeDamage = 0;
		}
	}

	private bool DecideIfAbilityCriticallyHit(){
		int randomTemp = Random.Range (1,101);
		if (randomTemp <= playerUsedAbility.AbilityCritChance) {
			Debug.Log ("CRIT!");
			return true;
		} else {
			return false;
		}
	}
}
