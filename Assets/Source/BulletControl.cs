﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

	const float END_OF_TOP_SCREEN = 1.0f, END_OF_BOTTOM_SCREEN = -1.0f;

	Vector3 bulletPosition;
	GameObject eachBulletObject;

	// Use this for initialization
	void Start () {
		bulletPosition = new Vector3 ();
		eachBulletObject = gameObject;
	}

	// Update is called once per frame
	void Update () {
		bulletPosition = eachBulletObject.transform.position;

		AutoDestroy (bulletPosition, eachBulletObject);

		eachBulletObject.transform.Translate(Vector3.forward * Time.deltaTime);
		eachBulletObject.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
	}

	void AutoDestroy(Vector3 myPosition, GameObject myObject) {
		if (END_OF_TOP_SCREEN < myPosition.y || myPosition.y < END_OF_BOTTOM_SCREEN) {
			Destroy (myObject);
		}
	}
}