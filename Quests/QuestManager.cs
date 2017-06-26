using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public int tryme = 69697;

	public static QuestManager questManager;
	public List <Quest> questList = new List<Quest> ();
	public List <Quest> currentQuestList = new List<Quest> ();

	void Awake(){
		if(questManager == null){
			questManager = this;
		}else if(questManager != this){
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void QuestRequest(QuestObject NPCQuestObject){
		//AVAILABLE QUEST
		if(NPCQuestObject.availableQuestIDs.Count > 0){
			for(int i = 0; i < questList.Count; i++){
				for(int j = 0; j < NPCQuestObject.availableQuestIDs.Count; j++){
					if(questList[i].id == NPCQuestObject.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVAILABLE){
						Debug.Log ("Quest ID: "+ NPCQuestObject.availableQuestIDs[j] +" "+ questList[i].progress);
						//LATEST TEST
						//AcceptQuest (NPCQuestObject.availableQuestIDs[j]);
						//QUEST UI MANAGER
						QuestUIManager.questUIManager.questAvailable = true;
						QuestUIManager.questUIManager.availableQuests.Add (questList[i]);
					}
				}
			}
		}

		//ACTIVE QUEST
		for(int i = 0; i < currentQuestList.Count; i++){
			for(int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++){
				if(currentQuestList[i].id == NPCQuestObject.receivableQuestIDs[j] && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED || currentQuestList[i].progress == Quest.QuestProgress.COMPLETE){
					Debug.Log ("hey, Quest ID: "+ NPCQuestObject.receivableQuestIDs[j] +" is "+ currentQuestList[i].progress);
					//LATEST TEST
					//CompleteQuest(NPCQuestObject.receivableQuestIDs[j]);
					//QUEST UI MANAGER
					QuestUIManager.questUIManager.questRunning = true;
					QuestUIManager.questUIManager.activeQuests.Add (questList[i]);
				}
			}
		}
	}

	//ACCEPT QUEST
	public void AcceptQuest(int questID){
		for(int i = 0; i < questList.Count; i++){
			if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE){
				currentQuestList.Add (questList[i]);
				questList [i].progress = Quest.QuestProgress.ACCEPTED;
			}
		}
	}

	//GIVE UP QUEST
	public void GiveUpQuest(int questID){
		for(int i = 0; i < questList.Count; i++){
			if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED){
				currentQuestList.Remove (currentQuestList[i]);
				questList [i].progress = Quest.QuestProgress.AVAILABLE;
				questList [i].questObjectiveCount = 0;
			}
		}
	}

	//COMPLETE QUEST
	public void CompleteQuest(int questID){
		for(int i = 0; i < questList.Count; i++){
			if(questList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.COMPLETE){
				currentQuestList.Remove (currentQuestList[i]);
				questList [i].progress = Quest.QuestProgress.DONE;

				//REWARD

			}
		}
		CheckChainQuest (questID);
	}

		//CHECK CHAIN QUESTS
	void CheckChainQuest(int questID){
		int tempID = 0;
		for(int i = 0; i < questList.Count; i++){
			if(questList[i].id == questID && questList[i].nextQuest > 0){
				tempID = questList[i].nextQuest;
			}
		}

		if(tempID > 0){
			for(int i = 0; i < questList.Count; i++){
				if(questList[i].id == tempID && questList[i].progress == Quest.QuestProgress.NOT_AVAILABLE){
					questList[i].progress = Quest.QuestProgress.AVAILABLE;
				}
			}
		}
	}
	

	//ADD QUEST ITEM
	public void AddQuestItem(string questObjective, int itemAmount){
		for(int i = 0; i < currentQuestList.Count; i++){
			if(currentQuestList[i].questObjective == questObjective && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED){
				currentQuestList [i].questObjectiveCount += itemAmount;
			}

			if(currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirement && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED){
				currentQuestList [i].progress = Quest.QuestProgress.COMPLETE;
			}
		}
	}


	public bool RequestAvailableQuest(int questID){
		for (int i = 0; i < questList.Count; i++) {
			if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE){
				return true;
			}
		}
		return false;
	}

	public bool RequestCompleteQuest(int questID){
		for (int i = 0; i < questList.Count; i++) {
			if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.COMPLETE){
				return true;
			}
		}
		return false;
	}

	public bool RequestAcceptedQuest(int questID){
		for (int i = 0; i < questList.Count; i++) {
			if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED){
				return true;
			}
		}
		return false;
	}

	public bool CheckAvailableQuests(QuestObject NPCQuestObject){
		for (int i = 0; i < questList.Count; i++) {
			for (int j = 0; j < questList.Count; j++) {
				if(questList[i].id == NPCQuestObject.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVAILABLE){
					return true;
				}
			}
		}
		return false;
	}

	public bool CheckAcceptedQuests(QuestObject NPCQuestObject){
		for (int i = 0; i < questList.Count; i++) {
			for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++) {
				if(questList[i].id == NPCQuestObject.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.ACCEPTED){
					return true;
				}
			}
		}
		return false;
	}

	public bool CheckCompletedQuests(QuestObject NPCQuestObject){
		for (int i = 0; i < questList.Count; i++) {
			for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++) {
				if(questList[i].id == NPCQuestObject.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.COMPLETE){
					return true;
				}
			}
		}
		return false;
	}

	//SHOW QUEST LOG
	public void ShowQuestLog(int questID){
		for(int i = 0; i < currentQuestList.Count; i++){
			if(currentQuestList[i].id == questID){
				QuestUIManager.questUIManager.ShowQuestLog (currentQuestList[i]);
			}
		}
	}
}
