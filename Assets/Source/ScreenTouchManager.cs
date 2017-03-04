using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ScreenTouchManager : MonoBehaviour {

	const int NOT_TOUCHED = 0, FIRST_FINGER_TOUCH_ID = 0;

	Vector2 touchPosition;

	// Use this for initialization
	void Start () {
		touchPosition = new Vector2 ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.touchCount != NOT_TOUCHED && Input.GetTouch (FIRST_FINGER_TOUCH_ID).phase == TouchPhase.Began) {
			if (EventSystem.current.IsPointerOverGameObject ()) {
				Debug.Log ("UI HIT Vec: " + Input.GetTouch(0).position);
				touchPosition = Input.GetTouch (0).position;
			}
		}*/
		if (Input.touchCount != NOT_TOUCHED) {
			foreach (Touch screenTouch in Input.touches) {
				if (screenTouch.phase == TouchPhase.Moved) {
					Debug.Log ("UI HIT Vec: " + screenTouch.position);
					touchPosition = screenTouch.position;
				}
			}
		}
	}

	void OnGUI() {
		GUI.Label (new Rect (0, 0, 500, 100), "Touch Position: " + touchPosition);
	}
}
