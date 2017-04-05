using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostCalculator : DefineManager {

	GameObject boostTimeStatusObject;
	Text boostTimeStatusText;

	// Use this for initialization
	void Start () {
		boostTimeStatusObject = gameObject;
		boostTimeStatusText = boostTimeStatusObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		boostTimeStatusText.text = CalculateNowBoostTime ();
	}

	string CalculateNowBoostTime() {
		int i;
		string boostTimeStatusString = "BoostTime: ";
		//Debug.Log ("boost time: " + (int)BOOST_TIME);
		for (i = 0; i < BOOST_TIME; i += 1) {
			boostTimeStatusString += "*";
		}
		return boostTimeStatusString;
	}
}
