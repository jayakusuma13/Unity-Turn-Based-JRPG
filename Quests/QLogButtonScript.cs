using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QLogButtonScript : MonoBehaviour {

	public int QuestID;
	public Text questTitle;

	public void ShowAllInfos(){
		//QuestUIManager.questUIManager.ShowQuestLog (QuestID);
		QuestManager.questManager.ShowQuestLog(QuestID);
	}

	public void ClosePanel(){
		QuestUIManager.questUIManager.HideQuestPanel ();
	}
}
