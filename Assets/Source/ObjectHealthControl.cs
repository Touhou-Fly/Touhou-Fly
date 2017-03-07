using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealthControl : MonoBehaviour {

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
			Debug.Log ("Triggered"); 
		} 
	} 
}
