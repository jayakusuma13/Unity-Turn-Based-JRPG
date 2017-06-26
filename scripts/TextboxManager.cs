using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour {

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

		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}

		if (endAtline == 0) {
			endAtline = textLines.Length - 1;
		}

		if (IsActive) {
			EnableTextbox ();
		} else {
			DisableTextbox ();
		}
	}

	void Update(){

		if (!IsActive) {
			return;
		}

		//thetext.text = textLines[currentLine];
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!IsTyping) {
				currentLine += 1;

				if (currentLine > endAtline) {
					DisableTextbox ();
				} else {
					StartCoroutine(TextScroll(textLines[currentLine]));
				}
			}
			else if(IsTyping && !cancelTyping){
				cancelTyping = true;
			}
		}


	}

	private IEnumerator TextScroll(string lineOfText){
		int letter = 0;
		thetext.text = "";
		IsTyping = true;
		cancelTyping = false;
		while (IsTyping && !cancelTyping && (letter < lineOfText.Length - 1)) {
			thetext.text += lineOfText[letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}
		thetext.text = lineOfText;
		IsTyping = false;
		cancelTyping = false;
	}

	public void EnableTextbox(){
		box.SetActive (true);
		IsActive = true;
		player.CanMove = false;
		StartCoroutine (TextScroll(textLines[currentLine]));
	}

	public void DisableTextbox(){
		box.SetActive (false);
		IsActive = false;
		player.CanMove = true;
	}

	public void ReloadScript(TextAsset newText){
		if (newText != null) {
			textLines = new string[1];
			textLines = (newText.text.Split ('\n'));
		}
	}
		
}
