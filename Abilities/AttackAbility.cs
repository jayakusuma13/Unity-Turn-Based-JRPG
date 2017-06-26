using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : BaseAbility {

	public AttackAbility(){
		AbilityName = "Normal Attack";
		AbilityDescription = "A normal sword slash";
		AbilityID = 1;
		AbilityPower = 10;
		AbilityCost = 5;
		AbilityCritChance = 5;
	}

}
