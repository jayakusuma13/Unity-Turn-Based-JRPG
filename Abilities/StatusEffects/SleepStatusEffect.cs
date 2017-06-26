using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SleepStatusEffect : BaseStatusEffect {

	public SleepStatusEffect(){
		StatusEffectName = "Sleep";
		StatusEffectDescription = "Makes enemy sleep";
		StatusEffectID = 2;
		StatusEffectPower = 0;
		StatusEffectApplyPercentage = 100;
		StatusEffectStayAppliedPercentage = 25;
		StatusEffectMinTurnApplied = 1;
		StatusEffectMaxTurnApplied = 3;
	}
}

