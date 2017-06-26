using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarriorClass : BaseCharacterClass {

	public BaseWarriorClass(){
		CharacterClassName = "Warrior";
		CharacterClassDescription = "A strong hero";
		Stamina = 15;
		Endurance = 12;
		MainStat = MainStatBonuses.STRENGTH;
		SecondMainStat = SecondStatBonuses.ENDURANCE;
		CharacterClass = CharacterClasses.WARRIOR;
		playerAbilities.Add (new AttackAbility ());
		playerAbilities.Add (new SwordSlash	());
	}
			
}
