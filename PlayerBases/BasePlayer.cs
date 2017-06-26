using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer {

	private string playerName;
	private int playerLevel;

	private int stamina;
	private int endurance;
	private int strength;
	private int intellect;
	private int overpower;
	private int luck;
	private int charisma;
	private int gold;
	private int currentXP;
	private int requiredXP;
	private int statPointsToAllocate;

	public string PlayerName{ get; set;}
	public int PlayerLevel{
		get{return playerLevel;}
		set{playerLevel = value;}
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
