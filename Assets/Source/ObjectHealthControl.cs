using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealthControl : DefineManager {

	float hitDamageScale, maxHealth, nowHealth;
	int revolutionStage;

	GameObject objectWhichIsHasHealth, deadEffect, healthBarObject;

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
			SetHealthStatus (maxHealth, nowHealth);
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
			if(deadEffect != null)
				Instantiate (deadEffect, objectWhichIsHasHealth.transform.position, Quaternion.identity);
			Destroy (objectWhichIsHasHealth);
		}
	}

	public void SetMaxHealth(float maxHealth) {
		this.maxHealth = maxHealth;
		nowHealth = maxHealth;
		SetHealthStatus (maxHealth, nowHealth);
	}

	public void SetHitDamageScale(float hitDamageScale) {
		this.hitDamageScale = hitDamageScale;
	}

	public void SetRevolutionStage(int revolutionStage) {
		this.revolutionStage = revolutionStage;
	}

	public void SetObjectWhichIsHasHealth(GameObject objectWhichIsHasHealth) {
		this.objectWhichIsHasHealth = objectWhichIsHasHealth;
		healthBarObject = objectWhichIsHasHealth.transform.FindChild ("healthBarFront").gameObject;
	}

	public void SetDeadParticleEffect(GameObject deadEffect) {
		this.deadEffect = deadEffect;
	}

	public void DrawMyHealthTest() {
		Vector3 myPosition = objectWhichIsHasHealth.transform.position;
		myPosition = ConvertSmallToBig (myPosition);
		GUI.Label (new Rect (myPosition.x, myPosition.y, 100, 20), "" + nowHealth + " / " + maxHealth);
	}

	Vector3 ConvertSmallToBig(Vector3 originPosition) {
		return new Vector3 (originPosition.x * Screen.width, -originPosition.y * Screen.height, 0);
	}

	public void SetHealthStatus(float maxHealth, float nowHealth) {
		if (maxHealth == 0) {
			healthBarObject.transform.localScale = new Vector3 (maxHealth, 
				healthBarObject.transform.localScale.y, 1);
		}
		else {
			healthBarObject.transform.localScale = new Vector3(nowHealth / maxHealth * healthBarObject.transform.localScale.y, 
				healthBarObject.transform.localScale.y, 1);
		}
	}
}
