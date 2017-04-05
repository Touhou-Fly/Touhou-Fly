using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCalculator : DefineManager {

	GameObject powerStatusObject;
	Text powerStatusText;

	// Use this for initialization
	void Start () {
		powerStatusObject = gameObject;
		powerStatusText = powerStatusObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		powerStatusText.text = CalculatePowerStatus ();
	}

	string CalculatePowerStatus() {
		int i;
		string powerStatusString = "Power: ";
		for (i = 0; i <= PLAYER_SHOOTING_DAMAGE; i += 1) {
			powerStatusString += "*";
		}
		return powerStatusString;
	}
}
