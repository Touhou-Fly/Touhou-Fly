﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : ObjectHealthControl {

	GameObject bossObject;
	Animator bossSpriteAnime;
	Vector3 movingPosition;
	float movingPositionUpdateTimer, movingPositionUpdateTimeGab;

	// Use this for initialization
	void Start () {
		bossObject = gameObject;
		bossSpriteAnime = GetComponent<Animator> ();

		movingPosition = new Vector3 ();

		movingPositionUpdateTimeGab = 3;
		movingPositionUpdateTimer = movingPositionUpdateTimeGab;
	}
	
	// Update is called once per frame
	void Update () {
		if (movingPositionUpdateTimer >= movingPositionUpdateTimeGab) {
			movingPosition = GetRandomMovingPosition (new Vector3 (-0.5F, 0.3F, 0), new Vector3 (1, 0.4F, 0));
			movingPositionUpdateTimer = 0;
			Debug.Log ("init position");
		}
		MakeObjectMoveToTargetPosition (movingPosition, 0.25F);
		movingPositionUpdateTimer += Time.deltaTime;

		SetAnimation(GetMovingDirection(AdvanceAbs(bossObject.transform.position, 1.0f), AdvanceAbs(movingPosition, 1.0f)));
	}

	Vector3 GetRandomMovingPosition(Vector3 minimalMovingPosition, Vector3 movingScale) {
		return new Vector3 (Random.Range (minimalMovingPosition.x, minimalMovingPosition.x + movingScale.x),
							Random.Range (minimalMovingPosition.y, minimalMovingPosition.y + movingScale.y),
							0);
	}

	void MakeObjectMoveToTargetPosition(Vector3 targetPosition, float speed) {
		float step = speed * Time.deltaTime;
		bossObject.transform.position = Vector3.MoveTowards (bossObject.transform.position, targetPosition, step);
	}

	int GetMovingDirection(Vector3 nowPosition, Vector3 targetPosition) {
		if (nowPosition.x - targetPosition.x < ZERO) {
			if (nowPosition.y - targetPosition.y < ZERO) {
				//right top
				return DIRECTION_RIGHT_TOP;
			}
			else if(nowPosition.y - targetPosition.y > ZERO) {
				//right bottom
				return DIRECTION_RIGHT_BOTTOM;
			}
		}
		else if (nowPosition.x - targetPosition.x > ZERO) {
			if (nowPosition.y - targetPosition.y < ZERO) {
				//left top
				return DIRECTION_LEFT_TOP;
			}
			else if(nowPosition.y - targetPosition.y > ZERO) {
				//left bottom
				return DIRECTION_LEFT_BOTTOM;
			}
		}
		if (nowPosition.x - targetPosition.x == ZERO && nowPosition.y - targetPosition.y == ZERO) {
			//center
			return DIRECTION_CENTER;
		}
		return DIRECTION_FAILED;
	}

	Vector3 AdvanceAbs(Vector3 vector, float min) {
		return new Vector3 (vector.x + min, vector.y + min, vector.z + min);
	}

	void SetAnimation(int directionData) {
		switch (directionData) {
			case DIRECTION_RIGHT_TOP:
				bossSpriteAnime.SetFloat ("DirectionX", 1);
				bossSpriteAnime.SetFloat ("DirectionY", ZERO);
				break;
			case DIRECTION_RIGHT_BOTTOM:
				bossSpriteAnime.SetFloat ("DirectionX", 1);
				bossSpriteAnime.SetFloat ("DirectionY", ZERO);
				break;
			case DIRECTION_LEFT_TOP:
				bossSpriteAnime.SetFloat ("DirectionX", -1);
				bossSpriteAnime.SetFloat ("DirectionY", ZERO);
				break;
			case DIRECTION_LEFT_BOTTOM:
				bossSpriteAnime.SetFloat ("DirectionX", -1);
				bossSpriteAnime.SetFloat ("DirectionY", ZERO);
				break;
			default:
				bossSpriteAnime.SetFloat ("DirectionX", ZERO);
				bossSpriteAnime.SetFloat ("DirectionY", ZERO);
				break;
		}
	}
}