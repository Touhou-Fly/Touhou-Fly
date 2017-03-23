using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : DefineManager {

	public Sprite[] itemSpriteImages;

	GameObject thisItemObject;
	SpriteRenderer itemSpriteRenderer;
	Rigidbody2D itemRigidbody2D;
	float gravityScale, animeSpeed, gravityReachScale;

	// Use this for initialization
	void Start () {
		thisItemObject = gameObject;
		gravityScale = -0.2f - Random.Range(0.0f, 0.15f);
		gravityReachScale = 0.1f + Random.Range (0.0f, 0.1f);
		animeSpeed = 10;

		itemSpriteRenderer = thisItemObject.GetComponent<SpriteRenderer> ();
		itemRigidbody2D = thisItemObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 itemObjectPosition = thisItemObject.transform.position;
		AutoDestroy (itemObjectPosition);
		SetGravity ();
	}

	void OnTriggerEnter2D(Collider2D other){ 
		if (other.gameObject.tag == "Player") { 
			Debug.Log ("hit");
			UpdateScore ();
			DestroyItem ();
		} 
	}

	public void AutoDestroy(Vector3 myPosition) {
		if (myPosition.y < END_OF_BOTTOM_SCREEN) {
			DestroyItem ();
		}
	}

	void SetGravity() {
		gravityScale += (gravityReachScale - gravityScale) / animeSpeed;
		itemRigidbody2D.gravityScale = gravityScale;
	}

	void ChangeSpriteImage(int indexNumber) {
		itemSpriteRenderer.sprite = itemSpriteImages [indexNumber];
	}

	void UpdateScore() {
	}

	void DestroyItem() {
		Destroy (thisItemObject);
	}
}
