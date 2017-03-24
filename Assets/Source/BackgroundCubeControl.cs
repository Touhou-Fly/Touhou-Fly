using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCubeControl : DefineManager {
	public float speed = 5f, fallingSpeed = 0.2f;
	Vector3 rotateDirection;
	GameObject backgroundCubeObject;

	// Use this for initialization
	void Start () {
		backgroundCubeObject = gameObject;
		fallingSpeed = Random.Range (0.2f, 0.5f) + 0.2f;
		rotateDirection = new Vector3 (Random.Range (0.5f, 1.5f) + 0.5f, Random.Range (0.5f, 1.5f) + 0.5f, Random.Range (0.5f, 1.5f) + 0.5f);
	}

	void Update ()
	{
		backgroundCubeObject.transform.Rotate(rotateDirection, speed * Time.deltaTime);
		//backgroundCubeObject.transform.Translate(Vector3.forward * Time.deltaTime);
		backgroundCubeObject.transform.Translate(Vector3.down * Time.deltaTime * fallingSpeed, Space.World);

		AutoDestroy (backgroundCubeObject.transform.position, backgroundCubeObject);
	}

	void AutoDestroy(Vector3 myPosition, GameObject myObject) {
		if (myPosition.y < END_OF_BOTTOM_SCREEN_WIDTH_GAP) {
			Destroy (myObject);
		}
	}
}
