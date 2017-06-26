using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QButtonScript : MonoBehaviour {

	public int QuestID;
	public Text questTitle;

	private GameObject acceptButton;
	private GameObject giveUpButton;
	private GameObject completeButton;

	private QButtonScript acceptButtonScript;
	private QButtonScript giveUpButtonScript;
	private QButtonScript completeButtonScript;

	void Start(){
		acceptButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel")
			.transform.Find("Quest Description").transform.Find("GameObject")
			.transform.Find("Accept Button").gameObject;
		acceptButtonScript = acceptButton.GetComponent<QButtonScript> ();

		giveUpButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel")
			.transform.Find("Quest Description").transform.Find("GameObject")
			.transform.Find("Give Up Button").gameObject;
		giveUpButtonScript = giveUpButton.GetComponent<QButtonScript> ();

		completeButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel")
			.transform.Find("Quest Description").transform.Find("GameObject")
			.transform.Find("Complete Button").gameObject;
		completeButtonScript = completeButton.GetComponent<QButtonScript> ();

		acceptButton.SetActive (false);
		giveUpButton.SetActive (false);
		completeButton.SetActive (false);
	}

	//SHOW ALL INFOS
	public void ShowAllInfos(){
		QuestUIManager.questUIManager.ShowSelectedQuest (QuestID);
		//ACCEPT BUTTON
		if (QuestManager.questManager.RequestAvailableQuest (QuestID)) {
			acceptButton.SetActive (true);
			acceptButtonScript.QuestID = QuestID;
		} else {
			acceptButton.SetActive (false);
		}

		//GIVE UP BUTTON
		if (QuestManager.questManager.RequestAcceptedQuest (QuestID)) {
			giveUpButton.SetActive (true);
			giveUpButtonScript.QuestID = QuestID;
		} else {
			giveUpButton.SetActive (false);
		}

		//COMPLETE BUTTON
		if (QuestManager.questManager.RequestCompleteQuest (QuestID)) {
			completeButton.SetActive (true);
			completeButtonScript.QuestID = QuestID;
		} else {
			completeButton.SetActive (false);
		}
	}

	public void AcceptQuest(){
		QuestManager.questManager.AcceptQuest (QuestID);
		QuestUIManager.questUIManager.HideQuestPanel ();

		//UPDATE ALL NPCS
		QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
		foreach(QuestObject obj in currentQuestGuys){
			//setquestMarker
		}
	}

	public void GiveUpQuest(){
		QuestManager.questManager.GiveUpQuest (QuestID);
		QuestUIManager.questUIManager.HideQuestPanel ();

		//UPDATE ALL NPCS
		QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
		foreach(QuestObject obj in currentQuestGuys){
			obj.SetQuestMaker ();
		}
	}

	public void CompleteQuest(){
		QuestManager.questManager.CompleteQuest (QuestID);
		QuestUIManager.questUIManager.HideQuestPanel ();

		//UPDATE ALL NPCS
		QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
		foreach(QuestObject obj in currentQuestGuys){
			obj.SetQuestMaker ();
		}
	}

	public void ClosePanel(){
		QuestUIManager.questUIManager.HideQuestPanel ();
	}
}
