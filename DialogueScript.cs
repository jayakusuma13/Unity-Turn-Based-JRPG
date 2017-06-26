using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour {

	public Fungus.Flowchart flowchart;
	private bool waitForButton;
	private bool requireButtonPress;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(waitForButton && Input.GetKeyDown(KeyCode.Return)){
			flowchart.ExecuteBlock ("Start");
			waitForButton = false;
		}

		if (flowchart.HasExecutingBlocks()) {
			player.CanMove = false;
		} else {
			player.CanMove = true;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			waitForButton = true;
			return;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			waitForButton = false;
		}
	}
}
