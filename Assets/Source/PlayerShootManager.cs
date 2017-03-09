using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour {

	public GameObject bulletPrefab;

	GameObject playerObject;
	float bulletShootGabTime, bulletShootLastTime;

	// Use this for initialization
	void Start () {
		playerObject = gameObject;
		bulletShootGabTime = 0.0625f;
		bulletShootLastTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (bulletPrefab != null && IsTimeToShootAnotherBullet()) {
			Instantiate (bulletPrefab, playerObject.transform.position, Quaternion.identity);
		}
	}

	bool IsTimeToShootAnotherBullet() {
		if (bulletShootLastTime > bulletShootGabTime) {
			bulletShootLastTime = 0;
			return true;
		}
		else {
			bulletShootLastTime = bulletShootLastTime + Time.deltaTime;
		}
		return false;
	}
}
