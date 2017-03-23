using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCreateEnemy : DefineManager {

	public GameObject[] enemyPrefab, bossPrefab;

	float createEnemyTimeGab, createEnemyTimeBuffer;

	// Use this for initialization
	void Start () {
		createEnemyTimeGab = 2.5f;
		createEnemyTimeBuffer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAvailableToCreateEnemy ()) {
			createEnemyTimeBuffer = 0;
			CreateEnemey ();
		}
		else {
			createEnemyTimeBuffer += Time.deltaTime;
		}
	}

	bool IsAvailableToCreateEnemy() {
		return createEnemyTimeBuffer > createEnemyTimeGab;
	}

	void CreateEnemey() {
		float i, maxWidth = 1.7f, centerOfCreateEnemyPositionX = maxWidth / CREATE_ENEMY_NUM * ((int)CREATE_ENEMY_NUM / 2);
		for (i = 0; i < maxWidth; i += maxWidth / CREATE_ENEMY_NUM) {
			Vector3 createPosition = new Vector3 (i - centerOfCreateEnemyPositionX, END_OF_TOP_SCREEN, 0);
			Instantiate (enemyPrefab[0], createPosition, Quaternion.identity);
		}
	}
}
