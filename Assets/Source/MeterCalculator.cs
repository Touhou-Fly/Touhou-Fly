using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MeterCalculator : DefineManager {

	GameObject meterPrinterObject;
	Text meterPrinterText;
	float nowMovedMeter, printMovedMeter;

	// Use this for initialization
	void Start () {
		meterPrinterObject = gameObject;
		meterPrinterText = meterPrinterObject.GetComponent<Text> ();

		nowMovedMeter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		meterPrinterText.text = (int)printMovedMeter + "CM";
		if (printMovedMeter < nowMovedMeter) {
			printMovedMeter += (nowMovedMeter - printMovedMeter) / ANIME_SPEED;
		}
		if (AM_I_STILL_AILVE) {
			if (BOOST_TIME > 0) {
				nowMovedMeter += 5;
			}
			else {
				nowMovedMeter += 1;
			} 
		}
	}
}
