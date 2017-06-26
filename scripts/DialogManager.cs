using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject box;
	public Text thetext;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtline;

	public bool IsActive;
	public bool StopPlayer;
	private bool IsTyping = false;
	private bool cancelTyping = false;

	public float typeSpeed;

	public PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}

	void Update(){
		thetext.text = textLines [currentLine];
	}

	public void EnableTextbox(){
		box.SetActive (true);
		IsActive = true;
	}

	public void DisableTextbox(){
		box.SetActive (false);
		IsActive = false;
		player.CanMove = true;
	}

}
