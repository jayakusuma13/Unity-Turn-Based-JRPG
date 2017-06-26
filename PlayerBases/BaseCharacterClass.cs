using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass : MonoBehaviour {

	private string characterClassName;
	private string characterClassDescription;

	private int stamina = 12;
	private int endurance = 10;
	private int strength = 8;
	private int intellect = 8;

	public enum CharacterClasses
	{
		MAGE,
		ARCHER,
		WARRIOR,
		ROGUE
	}

	public enum MainStatBonuses
	{
		STAMINA,
		ENDURANCE,
		STRENGTH,
		INTELLECT
	}

	public enum SecondStatBonuses
	{
		STAMINA,
		ENDURANCE,
		STRENGTH,
		INTELLECT
	}

	public CharacterClasses CharacterClass{ get; set;}
	public MainStatBonuses MainStat{ get; set;}
	public SecondStatBonuses SecondMainStat{ get; set;}
	public List<BaseAbility> playerAbilities = new List<BaseAbility>();

	public string CharacterClassName{
		get{return characterClassName;}
		set{characterClassName = value;}
	}
	public string CharacterClassDescription{
		get{return characterClassDescription;}
		set{characterClassDescription = value;}
	}
	public int Stamina{
		get{return stamina;}
		set{stamina = value;}
	}
	public int Strength{
		get{return strength;}
		set{strength = value;}
	}
	public int Intellect{
		get{return intellect;}
		set{intellect = value;}
	}
	public int Endurance{
		get{return endurance;}
		set{endurance = value;}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
