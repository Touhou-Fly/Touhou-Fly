using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineManager : MonoBehaviour {

	public const int DIRECTION_LEFT_TOP = 1, DIRECTION_LEFT_BOTTOM = 2, DIRECTION_RIGHT_TOP = 3, DIRECTION_RIGHT_BOTTOM = 4, DIRECTION_CENTER = 5, 
				DIRECTION_FAILED = -1,

				ZERO = 0,

				CREATE_ENEMY_NUM = 5,

				ITEM_POWER = 0, ITEM_SCORE = 1, ITEM_BOOST = 2, 

				BOSS_CREATE_STAGE_BUFFER = 3,

				MAXIMUM_EVENT_SAVE_MEMORY_SIZE = 7,

				NOT_AVAILABLE = -1,

				EVENT_BONUS_FAILED = 0, EVENT_CHALLENGE_NEXT_STAGE = 1
		;

	public const float END_OF_TOP_SCREEN = 1.0f, END_OF_BOTTOM_SCREEN = -1.0f, END_OF_BOTTOM_SCREEN_WIDTH_GAP = -1.5f, END_OF_TOP_SCREEN_TOP_GAP = 3f,

				BOOST_SPEED = 5f,

				ENEMY_NORMAL_CREATE_TIME_GAP = 2.5f, ENEMY_BOOST_CREATE_TIME_GAP = 0.5f, ENEMY_CREATE_WIDTH_SCALE = 1.2f,

				SWAP_ACTIVE_TIME = 15,

				ANIME_SPEED = 10,

				MINIMMAL_GUIDED_BULLET_SPEED = 1.5f, MAXIMMAL_GUIDED_BULLET_SPEED = 2.5f,

				BULLET_ACCURACY = 0.2f,

				MAXIMMAL_PLAYER_DAMAGE_SCALE = 4.0f,

				EACH_POWER_ITEM_GIVE_POWER_SCALE = 0.1f,

				MAXIMMAL_PLAYER_BOOST_TIME = 5,

				END_OF_RIGHT_SCREEN = 1.0f, END_OF_LEFT_SCREEN = -1.0f;

	public static float SHAKE_CAMERA_RANGE = 0.0f, BOOST_TIME = 0, GAME_SCORE = 0, PLAYER_SHOOTING_DAMAGE = 0;

	public static bool AM_I_STILL_AILVE = true;

	public static Vector3 MY_PLAYER_POSITION = Vector3.zero, BOSS_CREATE_POSITION = new Vector3(0, 0.4f, 0);

	public static int NOW_STAGE = 1, EVENT_QUEUE_REAR = 0, EVENT_QUEUE_FRONT = 0;

	public static int[] EVENT_QEUEUE = new int[MAXIMUM_EVENT_SAVE_MEMORY_SIZE];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
