using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIController : MonoBehaviour {

	public static QuestUIController questUIcontroller;

	public int tryme = 99969;

	void Awake(){
		if(questUIcontroller == null){
			questUIcontroller = this;
		}else if(questUIcontroller != this){
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	//CALLED FROM QUEST OBJECT
	public void CheckQuests(int number){
		/*currentQuestObject = questObject;
		QuestManager.questManager.QuestRequest (questObject);
		if ((questRunning || questAvailable) && !questPanelActive) {
			ShowQuestPanel ();
		} else {
			Debug.Log ("No Quest Available");
		}*/
		Debug.Log ("hey there"+ number);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
