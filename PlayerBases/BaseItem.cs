using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem : MonoBehaviour {

	private string itemName;
	private string itemDescription;
	private int itemID;
	private int endurance;
	private int stamina;
	private int strength;
	private int intellect;

	public enum ItemTypes{
		equipment,
		weapon,
		scroll,
		potion,
		chest
	}

	private ItemTypes itemType;

	public BaseItem(){
	
	}

	public BaseItem(Dictionary<string,string> itemsDictionary){
		itemName = itemsDictionary["ItemName"];
		itemID = int.Parse (itemsDictionary["ItemID"]);
		itemType = (ItemTypes)System.Enum.Parse (typeof(BaseItem.ItemTypes), itemsDictionary["ItemType"].ToString());
	}

	public string ItemName{
		get{return ItemName;}
		set{ItemName = value;}
	}
	public string ItemDescription{
		get{return ItemDescription;}
		set{ItemDescription = value;}
	}
	public int ItemID{
		get{return ItemID;}
		set{ItemID = value;}
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
