using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarView : MonoBehaviour {

	GameObject healthBarObject;
	float maxHealth, nowHealth;

	// Use this for initialization
	void Start () {
		healthBarObject = gameObject.transform.FindChild ("healthBarFront").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetHealthStatus(float maxHealth, float nowHealth) {
		healthBarObject.transform.localScale = new Vector3(nowHealth / maxHealth * healthBarObject.transform.localScale.y, 
															healthBarObject.transform.localScale.y, 1);
	}
}
