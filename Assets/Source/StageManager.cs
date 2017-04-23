using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : DefineManager {

	GameObject stageStatusObject;
	Text stageStatusText;

	// Use this for initialization
	void Start () {
		stageStatusObject = gameObject;
		stageStatusText = stageStatusObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		stageStatusText.text = "Stage: " + NOW_STAGE;
	}
}
