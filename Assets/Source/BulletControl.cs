using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : DefineManager {

	Vector3 bulletPosition;
	GameObject eachBulletObject;
	float bulletSpeed = 4.0f;

	// Use this for initialization
	void Start () {
		bulletPosition = new Vector3 ();
		eachBulletObject = gameObject;
	}

	// Update is called once per frame
	void Update () {
		bulletPosition = eachBulletObject.transform.position;

		AutoDestroy (bulletPosition, eachBulletObject);

		//eachBulletObject.transform.Translate(Vector3.forward * Time.deltaTime);
		eachBulletObject.transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed, Space.World);
	}

	void AutoDestroy(Vector3 myPosition, GameObject myObject) {
		if (END_OF_TOP_SCREEN < myPosition.y || myPosition.y < END_OF_BOTTOM_SCREEN) {
			Destroy (myObject);
		}
	}
}
