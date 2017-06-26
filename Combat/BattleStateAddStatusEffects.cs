using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateAddStatusEffects : MonoBehaviour {

	public void CheckAbilityForStatusEffects(BaseAbility usedAbility){
			switch (usedAbility.AbilityStatusEffect.StatusEffectName) {
		case("Burn"):
			if (TryToApplyStatusEffect (usedAbility)) {
				CombatController.statusEffectBaseDamage = usedAbility.AbilityStatusEffect.StatusEffectPower;
			} else {
				CombatController.statusEffectBaseDamage = 0;
			}
				CombatController.currentState = CombatController.BattleStates.calcDamage;
				break;
			default:
				Debug.Log ("ERROR IN STATUS EFFECT");
				break;
			}
	}

	private bool TryToApplyStatusEffect(BaseAbility usedAbility){
		int randomTemp = Random.Range (1,101);
		if (randomTemp <= usedAbility.AbilityStatusEffect.StatusEffectApplyPercentage) {
			return true;
		}
		return false;
	}
}
