using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

	public string sceneToLoad;
	public string spawnPointName;

	void OnTriggerEnter(Collider other){
		QuestManager.questManager.AddQuestItem ("Jump down", 1);
	}
}
