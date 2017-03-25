using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : DefineManager {

	float printGameScore = 0;
	Text scoreCalculatorText;
	GameObject scoreCalculatorObject;

	// Use this for initialization
	void Start () {
		GAME_SCORE = 0;	

		scoreCalculatorObject = gameObject;
		scoreCalculatorText = scoreCalculatorObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreCalculatorText.text = "Score: " + (int)printGameScore;
		if (printGameScore < GAME_SCORE) {
			printGameScore += (GAME_SCORE - printGameScore) / ANIME_SPEED;
		}
	}
}
