using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeEffect : DefineManager {

	Camera gameMainCamera;
	float shakeStatus, shakeAmount, shakeDecrease;

	// Use this for initialization
	void Start () {
		gameMainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();

		shakeStatus = 0.1f;
		shakeAmount = 0.1f;
		shakeDecrease = 1.0f;

		//ShakeCamera ();
	}

	// Update is called once per frame
	void Update () {
		//GetShakeCameraRange (SHAKE_CAMERA_RANGE);
		if (SHAKE_CAMERA_RANGE > 0) {
			Vector3 shakePosition = Random.insideUnitSphere * shakeAmount;
			shakePosition.z = -10;
			gameMainCamera.transform.localPosition = shakePosition;
			SHAKE_CAMERA_RANGE -= Time.deltaTime * shakeDecrease;
		}
		else {
			gameMainCamera.transform.localPosition = new Vector3 (0, 0, -10);
		}
	}

	public void ShakeCamera() {
		shakeStatus = 0.5f;
	}

	public void GetShakeCameraRange(float shakeRange) {
		shakeStatus = shakeRange;
		SHAKE_CAMERA_RANGE = 0;
	}
}
