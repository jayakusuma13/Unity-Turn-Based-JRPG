using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatusEffect : MonoBehaviour {

	private string statusEffectName;
	private string statusEffectDescription;
	private int statusEffectID;
	private int statusEffectPower;
	private int statusEffectCost;
	private int statusEffectApplyPercentage;
	private int statusEffectStayAppliedPercentage;
	private int statusEffectMinTurnApplied;
	private int statusEffectMaxTurnApplied;

	public string StatusEffectName{
		get{return statusEffectName;}
		set{statusEffectName = value;}
	}
	public string StatusEffectDescription{
		get{return statusEffectDescription;}
		set{statusEffectDescription = value;}
	}
	public int StatusEffectID{
		get{return statusEffectID;}
		set{statusEffectID = value;}
	}
	public int StatusEffectPower{
		get{return statusEffectPower;}
		set{statusEffectPower = value;}
	}
	public int StatusEffectApplyPercentage{
		get{return statusEffectApplyPercentage;}
		set{statusEffectApplyPercentage = value;}
	}
	public int StatusEffectMinTurnApplied{
		get{return statusEffectMinTurnApplied;}
		set{statusEffectMinTurnApplied = value;}
	}
	public int StatusEffectMaxTurnApplied{
		get{return statusEffectMaxTurnApplied;}
		set{statusEffectMaxTurnApplied = value;}
	}
	public int StatusEffectStayAppliedPercentage{
		get{return statusEffectStayAppliedPercentage;}
		set{statusEffectStayAppliedPercentage = value;}
	}
}
