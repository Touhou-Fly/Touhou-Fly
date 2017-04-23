using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeLineControl : DefineManager {

	public GameObject autoCreateEnemyPrefab, autoCreateGuidedBulletPrefab, bossPrefab;

	GameObject autoCreateEnemyObject, autoCreateGuidedBulletObject, bossObject;
	AutoCreateGuidedBullet autoCreateGuidedBullet;
	float gameTimer, shootingTimeGab;
	bool createGuidedBullet, isBossCreated, isStageUpgraded;
	int subStageCounter = 0, howManyShootGuidedBulletThisTime;

	// Use this for initialization
	void Start () {
		gameTimer = ZERO;
		createGuidedBullet = true;
		subStageCounter = 0;
		isBossCreated = false;
		isStageUpgraded = false;

		autoCreateEnemyObject = Instantiate (autoCreateEnemyPrefab, Vector3.zero, Quaternion.identity);
		autoCreateGuidedBulletObject = Instantiate (autoCreateGuidedBulletPrefab, Vector3.zero, Quaternion.identity);

		autoCreateGuidedBullet = autoCreateGuidedBulletObject.GetComponent<AutoCreateGuidedBullet> ();

		autoCreateEnemyObject.SetActive (true);
		autoCreateGuidedBulletObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		gameTimer += Time.deltaTime;

		PlayerBoostControl ();
		//SwapActive ();
		SwapAttack();

		if (isBossCreated) {
			if (bossObject == null) {
				if (!isStageUpgraded) {
					isStageUpgraded = false;
					NOW_STAGE += 1;
					isBossCreated = false;
					GameEventManager.AddNewEvent (EVENT_CHALLENGE_NEXT_STAGE);
				}
			}
		}
	}

	void SwapAttack() {
		if (gameTimer > SWAP_ACTIVE_TIME) {
			autoCreateEnemyObject.SetActive (false);
			if (createGuidedBullet) {
				createGuidedBullet = false;
				shootingTimeGab = Random.Range (0.4f, 0.8f);
				howManyShootGuidedBulletThisTime = Random.Range (5, 10);
				autoCreateGuidedBullet.FireBullet (howManyShootGuidedBulletThisTime, shootingTimeGab);
			}
			if (gameTimer > SWAP_ACTIVE_TIME + howManyShootGuidedBulletThisTime * shootingTimeGab + 1.0f) {
				autoCreateEnemyObject.SetActive (true);
				gameTimer = ZERO;
				createGuidedBullet = true;
				if (bossObject == null) {
					subStageCounter += 1;
				}
			}
		}
		if (subStageCounter % BOSS_CREATE_STAGE_BUFFER == ZERO && subStageCounter != ZERO) {
			subStageCounter = ZERO;
			bossObject = Instantiate (bossPrefab, BOSS_CREATE_POSITION, Quaternion.identity);
			isBossCreated = true;
		}
	}

	void SwapActive() {
		if (gameTimer > SWAP_ACTIVE_TIME) {
			autoCreateEnemyObject.SetActive (false);
			autoCreateGuidedBulletObject.SetActive (true);
			if (createGuidedBullet) { 
				autoCreateGuidedBullet.CreateEnemey ();
				createGuidedBullet = false;
			}
			if (gameTimer > SWAP_ACTIVE_TIME + 5.0f) {
				autoCreateGuidedBulletObject.SetActive (false);
				autoCreateEnemyObject.SetActive (true);
				gameTimer = 0;
				createGuidedBullet = true;
			}
		}
	}

	void PlayerBoostControl() {
		if (BOOST_TIME > ZERO) {
			BOOST_TIME -= Time.deltaTime;
		}
	}
}
