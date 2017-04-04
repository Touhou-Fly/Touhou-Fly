using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : ObjectHealthControl {

	public GameObject deadParticleEffect;
	public GameObject itemPrefab;

	//const float END_OF_TOP_SCREEN = 1.0f, END_OF_BOTTOM_SCREEN = -1.0f;

	GameObject enemyObject;
	Vector3 enemyPosition;

	float enemyFallingSpeed;

	// Use this for initialization
	void Start () {
		enemyFallingSpeed = 1;
		enemyObject = gameObject;
		enemyPosition = new Vector3 ();

		SetDeadParticleEffect (deadParticleEffect);
		SetObjectWhichIsHasHealth (gameObject);
		SetHitDamageScale (0.25f);
		SetMaxHealth (0.50f);
		SetItemPrefab (itemPrefab);
		SetKillScore (500);
	}
	
	// Update is called once per frame
	void Update () {

		SetHitDamageScale (0.25f + PLAYER_SHOOTING_DAMAGE);
		enemyPosition = enemyObject.transform.position;

		AutoDestroy (enemyPosition, enemyObject);

		enemyObject.transform.Translate(Vector3.forward * Time.deltaTime);
		enemyObject.transform.Translate(Vector3.down * Time.deltaTime * enemyFallingSpeed, Space.World);

		if (BOOST_TIME > ZERO) {
			SetEnemyFallingSpeed (BOOST_SPEED);
			SetMaxHealth (0);
		}
	}

	/*void OnGUI() { 
		DrawMyHealthTest ();
	}*/

	void AutoDestroy(Vector3 myPosition, GameObject myObject) {
		if (myPosition.y < END_OF_BOTTOM_SCREEN) {
			Destroy (myObject);
		}
	}

	public void SetEnemyFallingSpeed(float enemyFallingSpeed) {
		this.enemyFallingSpeed = enemyFallingSpeed;
	}
}
