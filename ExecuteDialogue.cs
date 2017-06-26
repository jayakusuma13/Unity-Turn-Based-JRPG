using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteDialogue : MonoBehaviour {

	public Fungus.Flowchart myFlowchart;
	public bool requiredButtonPress;
	private bool waitForPress;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (waitForPress && Input.GetKeyDown (KeyCode.Return)) {
			myFlowchart.ExecuteBlock ("Start");
			while(myFlowchart.HasExecutingBlocks()){
				Debug.Log ("is doing flowchart");
				player.CanMove = false;
			}
			Debug.Log ("it is done");
			//player.CanMove = false;
			waitForPress = false;
			player.CanMove = false;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(requiredButtonPress){
				waitForPress = true;
				return;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			waitForPress = false;
		}
	}
}
