using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedBullet : BulletControl {

	Vector3 bulletNowPosition, bulletReachPosition, bulletNoticePosition;
	GameObject guidedBulletObject, noticeBulletPositionObject;
	// Use this for initialization
	void Start () {
		guidedBulletObject = gameObject;
		bulletNowPosition = new Vector3 ();
		bulletReachPosition = new Vector3 (MY_PLAYER_POSITION.x + Random.Range(-BULLET_ACCURACY, BULLET_ACCURACY), END_OF_BOTTOM_SCREEN_WIDTH_GAP, ZERO);

		noticeBulletPositionObject = guidedBulletObject.transform.FindChild ("noticeFireBallPosition").gameObject;
		bulletNoticePosition = noticeBulletPositionObject.transform.position;

		SetBulletSpeed (MINIMMAL_GUIDED_BULLET_SPEED);
		SetBulletObject (guidedBulletObject);

		//guidedBulletObject.transform.LookAt (bulletReachPosition);
	}
	
	// Update is called once per frame
	void Update () {

		if (BOOST_TIME > ZERO) {
			SetBulletSpeed (MAXIMMAL_GUIDED_BULLET_SPEED);
		} 

		bulletNowPosition = guidedBulletObject.transform.position;

		MakeObjectMoveToTargetPosition (bulletReachPosition);
		if (IsNoticeBulletObjectAilve (noticeBulletPositionObject)) { 
			SetNoticeObjectPosition (bulletNowPosition);
		}
		AutoDestroy (bulletNowPosition, guidedBulletObject);
		NoticeBulletObjectDestroy (noticeBulletPositionObject, guidedBulletObject.transform.position);
	}

	public void SetNoticeObjectPosition(Vector3 bulletNowPosition) {
		noticeBulletPositionObject.transform.position = new Vector3 (bulletNowPosition.x, 0.9f, bulletNowPosition.z);
	}

	public void AutoDestroy(Vector3 myPosition, GameObject myObject) {
		if (myPosition.y <= END_OF_BOTTOM_SCREEN_WIDTH_GAP) {
			Destroy (myObject);
		}
	}

	public bool IsBulletShowedInScreen(Vector3 bulletPosition) {
		return bulletPosition.y <= END_OF_TOP_SCREEN;
	}

	public void NoticeBulletObjectDestroy(GameObject noticeObject, Vector3 bulletPosition) {
		if(IsNoticeBulletObjectAilve(noticeObject)) {
			if (IsBulletShowedInScreen (bulletPosition)) {
				Destroy (noticeObject);
			}
		}
	}

	public bool IsNoticeBulletObjectAilve(GameObject noticeObject) {
		return noticeObject != null;
	}
}
