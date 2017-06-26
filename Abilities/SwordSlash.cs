using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : BaseAbility {

	public SwordSlash(){
		AbilityName = "Sword Slash";
		AbilityDescription = "A strong sword slash";
		AbilityID = 2;
		AbilityPower = 20;
		AbilityCost = 10;
		AbilityCritChance = 85;
		AbilityCritModifier = 1.2f;
		AbilityStatusEffects.Add (new BurnStatusEffect());
		AbilityStatusEffect = new BurnStatusEffect ();
	}
}
