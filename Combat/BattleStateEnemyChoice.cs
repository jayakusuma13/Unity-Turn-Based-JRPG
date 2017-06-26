using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateEnemyChoice : MonoBehaviour {

	private EnemyAbilityChoice enemyAbilityChoiceScript = new EnemyAbilityChoice();

	public void EnemyCompleteTurn(){
		CombatController.enemyUsedAbility = enemyAbilityChoiceScript.ChooseEnemyAbility ();
		Debug.Log ("Enemy Choice " + CombatController.enemyUsedAbility.AbilityName);
		CombatController.currentState = CombatController.BattleStates.calcDamage;
	}
}
