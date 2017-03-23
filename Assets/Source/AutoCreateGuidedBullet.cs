using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCreateGuidedBullet : DefineManager {

	public GameObject[] bulletPrefab;
	float createBulletTimeGab, createBulletTimeBuffer;

	// Use this for initialization
	void Start () {
		createBulletTimeGab = 5f;
		createBulletTimeBuffer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAvailableToCreateBullet ()) {
			createBulletTimeBuffer = 0;
			CreateEnemey ();
		}
		else {
			createBulletTimeBuffer += Time.deltaTime;
		}
	}

	bool IsAvailableToCreateBullet() {
		return createBulletTimeBuffer > createBulletTimeGab;
	}

	void CreateEnemey() {
		float i, maxWidth = 1.7f, centerOfBulletPositionX = maxWidth / CREATE_ENEMY_NUM * ((int)CREATE_ENEMY_NUM / 2);
		for (i = 0; i < maxWidth; i += maxWidth / CREATE_ENEMY_NUM) {
			Vector3 createPosition = new Vector3 (i - centerOfBulletPositionX, END_OF_TOP_SCREEN_TOP_GAP, 0);
			Instantiate (bulletPrefab[0], createPosition, Quaternion.identity);
		}
	}
}
