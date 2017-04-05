using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : DefineManager {

	public GameObject deadEffectPrefab, boostEffectParticleSystem;

	GameObject playerObject;
	// Use this for initialization
	void Start () {
		playerObject = gameObject;
		boostEffectParticleSystem.SetActive (false);
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
			boostEffectParticleSystem.SetActive (false);
		} 
		else {
			boostEffectParticleSystem.SetActive (true);
		}
	}

	void DestroyProcess() {
		Instantiate (deadEffectPrefab, playerObject.transform.position, Quaternion.identity);
		AM_I_STILL_AILVE = false;
		Destroy (playerObject);
	}
}
