using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineManager : MonoBehaviour {

	public const int DIRECTION_LEFT_TOP = 1, DIRECTION_LEFT_BOTTOM = 2, DIRECTION_RIGHT_TOP = 3, DIRECTION_RIGHT_BOTTOM = 4, DIRECTION_CENTER = 5, 
				DIRECTION_FAILED = -1,

				ZERO = 0,

				CREATE_ENEMY_NUM = 5,

				ITEM_POWER = 0, ITEM_SCORE = 1, ITEM_BOOST = 2;

	public const float END_OF_TOP_SCREEN = 1.0f, END_OF_BOTTOM_SCREEN = -1.0f, END_OF_BOTTOM_SCREEN_WIDTH_GAP = -1.5f, END_OF_TOP_SCREEN_TOP_GAP = 3f,

				BOOST_SPEED = 5f,

				ENEMY_NORMAL_CREATE_TIME_GAP = 2.5f, ENEMY_BOOST_CREATE_TIME_GAP = 0.5f, ENEMY_CREATE_WIDTH_SCALE = 1.2f,

				SWAP_ACTIVE_TIME = 15,

				ANIME_SPEED = 10,

				MINIMMAL_GUIDED_BULLET_SPEED = 1.0f, MAXIMMAL_GUIDED_BULLET_SPEED = 2.0f,

				BULLET_ACCURACY = 0.2f;

	public static float SHAKE_CAMERA_RANGE = 0.0f, BOOST_TIME = 0, GAME_SCORE = 0, PLAYER_SHOOTING_DAMAGE = 0;

	public static bool AM_I_STILL_AILVE = true;

	public static Vector3 MY_PLAYER_POSITION = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
