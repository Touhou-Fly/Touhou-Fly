using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeLineControl : DefineManager {

	public GameObject autoCreateEnemyPrefab, autoCreateGuidedBulletPrefab;

	GameObject autoCreateEnemyObject, autoCreateGuidedBulletObject;
	AutoCreateGuidedBullet autoCreateGuidedBullet;
	float gameTimer;
	bool createGuidedBullet;

	// Use this for initialization
	void Start () {
		gameTimer = ZERO;
		createGuidedBullet = true;

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
	}

	void SwapAttack() {
		if (gameTimer > SWAP_ACTIVE_TIME) {
			autoCreateEnemyObject.SetActive (false);
			if (createGuidedBullet) {
				createGuidedBullet = false;
				autoCreateGuidedBullet.FireBullet (5, 0.5f);
			}
			if (gameTimer > SWAP_ACTIVE_TIME + 6.0f) {
				autoCreateEnemyObject.SetActive (true);
				gameTimer = ZERO;
				createGuidedBullet = true;
			}
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
