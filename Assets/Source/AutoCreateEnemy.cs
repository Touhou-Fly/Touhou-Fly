using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCreateEnemy : DefineManager {

	public GameObject[] enemyPrefab, bossPrefab;

	float createEnemyTimeGab, createEnemyTimeBuffer;
	GameObject eachEnemyObject;
	EnemyControl eachEnemyControl;

	// Use this for initialization
	void Start () {
		createEnemyTimeGab = ENEMY_NORMAL_CREATE_TIME_GAP;
		createEnemyTimeBuffer = ZERO;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAvailableToCreateEnemy ()) {
			createEnemyTimeBuffer = ZERO;
			CreateEnemey ();
		}
		else {
			createEnemyTimeBuffer += Time.deltaTime;
		}
		if (BOOST_TIME > ZERO) {
			createEnemyTimeGab = ENEMY_BOOST_CREATE_TIME_GAP;
		}
		else {
			createEnemyTimeGab = ENEMY_NORMAL_CREATE_TIME_GAP;
		}
	}

	bool IsAvailableToCreateEnemy() {
		return createEnemyTimeBuffer > createEnemyTimeGab;
	}

	void CreateEnemey() {
		float i, maxWidth = ENEMY_CREATE_WIDTH_SCALE, centerOfCreateEnemyPositionX = maxWidth / CREATE_ENEMY_NUM * ((int)CREATE_ENEMY_NUM / 2);
		for (i = ZERO; i < maxWidth; i += maxWidth / CREATE_ENEMY_NUM) {
			Vector3 createPosition = new Vector3 (i - centerOfCreateEnemyPositionX, END_OF_TOP_SCREEN, ZERO);
			eachEnemyObject = Instantiate (enemyPrefab[ZERO], createPosition, Quaternion.identity);
			eachEnemyControl = eachEnemyObject.GetComponent<EnemyControl> ();
			if (BOOST_TIME > ZERO) {
				eachEnemyControl.SetEnemyFallingSpeed (BOOST_SPEED);
			}
		}
	}
}
