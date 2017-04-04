using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : DefineManager {

	public GameObject deadEffectPrefab;

	GameObject playerObject;
	// Use this for initialization
	void Start () {
		playerObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		GAME_SCORE += 1;
		MY_PLAYER_POSITION = playerObject.transform.position;
	}

	void OnTriggerEnter2D(Collider2D other){ 
		if (BOOST_TIME <= 0) {
			if (other.gameObject.tag == "Enemy") { 
				Debug.Log ("hit");
				DestroyProcess ();
			} 
			if (other.gameObject.tag == "Boss") {
				DestroyProcess ();
			}
			if (other.gameObject.tag == "Bullet") {
				Debug.Log ("hit");
				DestroyProcess ();
			}
		}
	}

	void DestroyProcess() {
		Instantiate (deadEffectPrefab, playerObject.transform.position, Quaternion.identity);
		AM_I_STILL_AILVE = false;
		Destroy (playerObject);
	}
}
