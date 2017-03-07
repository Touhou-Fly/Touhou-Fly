using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : ObjectHealthControl {

	const float END_OF_TOP_SCREEN = 1.0f, END_OF_BOTTOM_SCREEN = -1.0f;

	GameObject enemyObject;
	Vector3 enemyPosition;

	// Use this for initialization
	void Start () {
		enemyObject = gameObject;
		enemyPosition = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		enemyPosition = enemyObject.transform.position;

		AutoDestroy (enemyPosition, enemyObject);

		enemyObject.transform.Translate(Vector3.forward * Time.deltaTime);
		enemyObject.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
	}

	void AutoDestroy(Vector3 myPosition, GameObject myObject) {
		if (END_OF_TOP_SCREEN < myPosition.y || myPosition.y < END_OF_BOTTOM_SCREEN) {
			Destroy (myObject);
		}
	}
}
