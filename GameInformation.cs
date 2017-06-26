using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	public static List<BaseAbility> playerAbilities;

	public static string PlayerName{ get; set;}
	public static int PlayerLevel{ get; set;}
	public static BaseCharacterClass PlayerClass{ get; set;}
	public static int PlayerHealth{ get; set;}
	public static int PlayerEnergy{ get; set;}
	public static int Stamina{ get; set;}
	public static int Endurance{ get; set;}
	public static int Strength{ get; set;}
	public static int Intellect{ get; set;}
	public static int Gold{ get; set;}
	public static int CurrentXP{ get; set;}
	public static int RequiredXP{ get; set;}

	public static string EnemyName{ get; set;}
	public static int EnemyLevel{ get; set;}
	public static BaseCharacterClass EnemyClass{ get; set;}
	public static int EnemyHealth{ get; set;}
	public static int EnemyEnergy{ get; set;}
	public static string DebugLogText{ get; set;}

	public static BaseAbility playerMoveOne = new AttackAbility ();
	public static BaseAbility playerMoveTwo = new SwordSlash ();
}
