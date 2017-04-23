using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : DefineManager {

	public Sprite[] gameEventSprites;

	GameObject eventControllerObject;
	SpriteRenderer eventSpriteRenderer;
	int eventNumberTemp;
	bool isEventObjectMoving;

	// Use this for initialization
	void Start () {
		eventControllerObject = gameObject;
		eventNumberTemp = NOT_AVAILABLE;
		isEventObjectMoving = false;

		eventSpriteRenderer = eventControllerObject.GetComponent<SpriteRenderer> ();

		eventControllerObject.transform.position = new Vector3 (END_OF_RIGHT_SCREEN, 0.5f, 0);

		//AddNewEvent (EVENT_BONUS_FAILED);
		//AddNewEvent (EVENT_CHALLENGE_NEXT_STAGE);
	}
	
	// Update is called once per frame
	void Update () {
		if (eventControllerObject.transform.position.x >= END_OF_RIGHT_SCREEN) {
			eventNumberTemp = DelSavedEvent ();
			//Debug.Log ("now event: " + eventNumberTemp);
			if (eventNumberTemp != NOT_AVAILABLE) {
				eventSpriteRenderer.sprite = gameEventSprites [eventNumberTemp];
				isEventObjectMoving = true;
			} 
			else {
				isEventObjectMoving = false;
				eventSpriteRenderer.sprite = null;
			}
		}
		if (eventControllerObject.transform.position.x <= END_OF_LEFT_SCREEN) {
			isEventObjectMoving = false;
			eventControllerObject.transform.position = new Vector3 (END_OF_RIGHT_SCREEN, 0.5f, 0);
		}
		if (isEventObjectMoving) {
			eventControllerObject.transform.Translate(Vector3.left * Time.deltaTime, Space.World);
		}
	}

	public static bool AddNewEvent(int eventNumber) {
		if (!IsEventQueueFull ()) {
			EVENT_QEUEUE [EVENT_QUEUE_REAR] = eventNumber;
			EVENT_QUEUE_REAR = (EVENT_QUEUE_REAR + 1) % MAXIMUM_EVENT_SAVE_MEMORY_SIZE;
			return true;
		} 
		return false;
	}

	public static bool IsEventQueueFull() {
		return (EVENT_QUEUE_REAR + 1) % MAXIMUM_EVENT_SAVE_MEMORY_SIZE == EVENT_QUEUE_FRONT;
	}

	public static bool IsNotEventQueueEmpty() {
		return EVENT_QUEUE_REAR != EVENT_QUEUE_FRONT;
	}

	static int DelSavedEvent() {
		if (IsNotEventQueueEmpty ()) {
			int savedEvent = NOT_AVAILABLE;
			savedEvent = EVENT_QEUEUE [EVENT_QUEUE_FRONT];
			EVENT_QUEUE_FRONT = (EVENT_QUEUE_FRONT + 1) % MAXIMUM_EVENT_SAVE_MEMORY_SIZE;
			return savedEvent;
		}
		return NOT_AVAILABLE;
	}
}
