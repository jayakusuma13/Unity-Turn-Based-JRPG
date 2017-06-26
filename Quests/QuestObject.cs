using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour {

	private bool inTrigger = false;
	private int test = 69;

	public List<int> availableQuestIDs = new List<int> ();
	public List<int> receivableQuestIDs = new List<int> ();

	public GameObject QuestMarker;
	public Image theImage;

	public Sprite questAvailableSprite;
	public Sprite questReceivableSprite;

	// Use this for initialization
	void Start () {
		SetQuestMaker ();

	}

	public void SetQuestMaker(){
		if (QuestManager.questManager.CheckCompletedQuests (this)) {
			QuestMarker.SetActive (true);
			theImage.sprite = questReceivableSprite;
			theImage.color = Color.black;
		} else if (QuestManager.questManager.CheckAvailableQuests (this)) {
			QuestMarker.SetActive (true);
			theImage.sprite = questAvailableSprite;
			theImage.color = Color.black;
		} else if (QuestManager.questManager.CheckAcceptedQuests (this)) {
			QuestMarker.SetActive (true);
			theImage.sprite = questReceivableSprite;
			theImage.color = Color.blue;
		} else {
			QuestMarker.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(inTrigger && Input.GetKeyDown(KeyCode.Space)){
			//QuestManager.questManager.QuestRequest(this);
			//QuestManager.questManager.CheckQuests (this.test);
			//Debug.Log(QuestUIController.questUIcontroller.tryme);
			QuestUIManager.questUIManager.CheckQuests (this);
			//QuestUIController.questUIcontroller.CheckQuests(this.test);
			//Debug.Log(QuestUIManager.questUIManager.tryme);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			inTrigger = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			inTrigger = false;
		}
	}
}
