using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCreateGuidedBullet : DefineManager {

	public GameObject[] bulletPrefab;
	float createBulletTimeGab, createBulletTimeBuffer, counter;
	int createBulletNum, createdBulletNum;

	// Use this for initialization
	void Start () {
		createBulletTimeGab = 1f;
		createBulletTimeBuffer = 0;
		createBulletNum = 5;
		createdBulletNum = createBulletNum + 1;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (IsAvailableToCreateBullet ()) {
			createBulletTimeBuffer = 0;
			CreateEnemey ();
		}
		else {
			createBulletTimeBuffer += Time.deltaTime;
		}*/
		if (createBulletNum > createdBulletNum) {
			createBulletTimeBuffer += Time.deltaTime;
			if (createBulletTimeBuffer > createBulletTimeGab) {
				createBulletTimeBuffer = ZERO;
				counter = CreateEnemey (counter);
				createdBulletNum += 1;
			}
		} 
		else {
			counter = ZERO;
		}
	}

	public void FireBullet(int createBulletNum, float createBulletTimeGab) {
		Debug.Log ("FireBullet Called");
		createdBulletNum = ZERO;
		this.createBulletNum = createBulletNum;
		this.createBulletTimeGab = createBulletTimeGab;
	}

	bool IsAvailableToCreateBullet() {
		return createBulletTimeBuffer > createBulletTimeGab;
	}

	public void CreateEnemey() {
		float i, maxWidth = 1.7f, centerOfBulletPositionX = maxWidth / CREATE_ENEMY_NUM * ((int)CREATE_ENEMY_NUM / 2);
		for (i = 0; i < maxWidth; i += maxWidth / CREATE_ENEMY_NUM) {
			Vector3 createPosition = new Vector3 (i - centerOfBulletPositionX, END_OF_TOP_SCREEN_TOP_GAP, 0);
			Instantiate (bulletPrefab[0], createPosition, Quaternion.identity);
		}
	}

	public float CreateEnemey(float i) {
		float maxWidth = 1.7f, centerOfBulletPositionX = maxWidth / createBulletNum * ((int)createBulletNum / 2);
		if (i >= maxWidth)
			return -1;
		Vector3 createPosition = new Vector3 (i - centerOfBulletPositionX, END_OF_TOP_SCREEN_TOP_GAP, 0);
		Instantiate (bulletPrefab[0], createPosition, Quaternion.identity);
		i += maxWidth / createBulletNum;
		return i;
	}
}
