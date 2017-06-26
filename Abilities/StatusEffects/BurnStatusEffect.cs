using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BurnStatusEffect : BaseStatusEffect {
	public BurnStatusEffect(){
		StatusEffectName = "Burn";
		StatusEffectDescription = "Burns enemy";
		StatusEffectID = 1;
		StatusEffectPower = 10;
		StatusEffectApplyPercentage = 75;
		StatusEffectStayAppliedPercentage = 75;
		StatusEffectMinTurnApplied = 2;
		StatusEffectMaxTurnApplied = 6;
	}
}
