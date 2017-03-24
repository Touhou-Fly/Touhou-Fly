using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFallingCube : DefineManager {

	public GameObject theCube;

	int i, createCubeLimit, createCubeNumThisTime;
	float createCubeTimeLimit, createCubeTimer;
	Vector3 createCubePosition;

	// Use this for initialization
	void Start () {
		createCubeTimer = 0;
		createCubeTimeLimit = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		createCubeTimer += Time.deltaTime;
		if (createCubeTimeLimit < createCubeTimer) {
			createCubeTimer = 0;
			createCubeLimit = Random.Range (1, 4);
			for (i = 0; i < createCubeLimit; i += 1) {
				createCubePosition = new Vector3 (2.0f / (createCubeLimit + 1) * (i + 1) - 1.0f, END_OF_TOP_SCREEN_TOP_GAP, 5);
				Instantiate (theCube, createCubePosition, Quaternion.identity);
			}
		}
	}
}
