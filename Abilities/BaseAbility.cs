using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseAbility {
	private string abilityName;
	private string abilityDescription;
	private int abilityID;
	private int abilityPower;
	private int abilityCost;
	private BaseStatusEffect abilityStatusEffect;
	private List<BaseStatusEffect> abilityStatusEffects = new List<BaseStatusEffect> ();
	private int abilityCritChance;
	private float abilityCritModifier;

	public string AbilityName{
		get{return abilityName;}
		set{abilityName = value;}
	}
	public string AbilityDescription{
		get{return abilityDescription;}
		set{abilityDescription = value;}
	}
	public int AbilityID{
		get{return abilityID;}
		set{abilityID = value;}
	}
	public int AbilityPower{
		get{return abilityPower;}
		set{abilityPower = value;}
	}
	public int AbilityCost{
		get{return abilityCost;}
		set{abilityCost = value;}
	}
	public List<BaseStatusEffect> AbilityStatusEffects{
		get{return abilityStatusEffects;}
		set{abilityStatusEffects = value;}
	}
	public BaseStatusEffect AbilityStatusEffect{
		get{return abilityStatusEffect;}
		set{abilityStatusEffect = value;}
	}
	public int AbilityCritChance{
		get{return abilityCritChance;}
		set{abilityCritChance = value;}
	}
	public float AbilityCritModifier{
		get{return abilityCritModifier;}
		set{abilityCritModifier = value;}
	}
}
