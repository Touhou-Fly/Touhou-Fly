using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealthControl : DefineManager {

	float hitDamageScale, maxHealth, nowHealth;
	int revolutionStage;

	GameObject objectWhichIsHasHealth;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	/*void OnCollisionEnter2D(Collision2D col) {
		Debug.Log ("can u see me?");
		if (col.gameObject.tag == "Bullet") {
			Debug.Log ("collision");
		}
	}*/

	void OnTriggerEnter2D(Collider2D other){ 
		if (other.gameObject.tag == "Bullet") { 
			//Debug.Log ("Triggered " + nowHealth); 
			nowHealth -= hitDamageScale;
			DeadProcess ();
		} 
	} 

	void DeadProcess() {
		if (nowHealth < ZERO) {
			nowHealth = maxHealth;
			revolutionStage -= 1;
			if (revolutionStage % 2 == 1) {
				//revolution
			}
		}
		if (revolutionStage < ZERO) {
			Destroy (objectWhichIsHasHealth);
		}
	}

	public void SetMaxHealth(float maxHealth) {
		this.maxHealth = maxHealth;
	}

	public void SetHitDamageScale(float hitDamageScale) {
		this.hitDamageScale = hitDamageScale;
		this.nowHealth = hitDamageScale;
	}

	public void SetRevolutionStage(int revolutionStage) {
		this.revolutionStage = revolutionStage;
	}

	public void SetObjectWhichIsHasHealth(GameObject objectWhichIsHasHealth) {
		this.objectWhichIsHasHealth = objectWhichIsHasHealth;
	}
}
