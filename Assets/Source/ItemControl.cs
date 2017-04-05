using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : DefineManager {

	public Sprite[] itemSpriteImages;

	GameObject thisItemObject;
	SpriteRenderer itemSpriteRenderer;
	Rigidbody2D itemRigidbody2D;
	float gravityScale, animeSpeed, gravityReachScale;
	int selectedItemVarious;

	// Use this for initialization
	void Start () {
		thisItemObject = gameObject;
		gravityScale = -0.2f - Random.Range(0.0f, 0.15f);
		gravityReachScale = 0.1f + Random.Range (0.0f, 0.1f);
		animeSpeed = 10;
		selectedItemVarious = ConvertRandomToItemNumber (Random.Range (0.0f, 1.0f));

		itemSpriteRenderer = thisItemObject.GetComponent<SpriteRenderer> ();
		itemRigidbody2D = thisItemObject.GetComponent<Rigidbody2D> ();

		ChangeSpriteImage (selectedItemVarious);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 itemObjectPosition = thisItemObject.transform.position;
		AutoDestroy (itemObjectPosition);
		SetGravity ();
	}

	void OnTriggerEnter2D(Collider2D other){ 
		if (other.gameObject.tag == "Player") { 
			//Debug.Log ("hit");
			switch (selectedItemVarious) {
				case ITEM_POWER:
					GAME_SCORE += 100;
					if (PLAYER_SHOOTING_DAMAGE < MAXIMMAL_PLAYER_DAMAGE_SCALE) {
						PLAYER_SHOOTING_DAMAGE += EACH_POWER_ITEM_GIVE_POWER_SCALE;
					}
					break;
				case ITEM_SCORE:
					GAME_SCORE += 200;
					break;
				case ITEM_BOOST:
					if (BOOST_TIME <= ZERO) {
						BOOST_TIME = MAXIMMAL_PLAYER_BOOST_TIME;
						GAME_SCORE += 50;
					}
					break;
				default:
					break;
			}
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

	int ConvertRandomToItemNumber(float randomStatus) {
		if (0 <= randomStatus && randomStatus < 0.4f) {
			return ITEM_POWER;
		}
		else if (0.4f <= randomStatus && randomStatus < 0.97f) {
			return ITEM_SCORE;
		}
		else if (0.97f <= randomStatus && randomStatus < 1) {
			return ITEM_BOOST;
		}
		return ITEM_POWER;
	}
}
