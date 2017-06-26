using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilityChoice : MonoBehaviour {

	private int totalPlayerHealth;
	private int playerHealthPercentage;
	private BaseAbility chosenAbility;

	public BaseAbility ChooseEnemyAbility(){
		totalPlayerHealth = GameInformation.PlayerHealth;
		playerHealthPercentage = totalPlayerHealth;
		if (playerHealthPercentage >= 75) {
			return chosenAbility = new SwordSlash();
		} else if (playerHealthPercentage < 75 && playerHealthPercentage >= 50) {
			return chosenAbility = new SwordSlash();
		} else if (playerHealthPercentage < 25) {
			return chosenAbility = new SwordSlash();
		}
		return chosenAbility = new AttackAbility();
	}

}
