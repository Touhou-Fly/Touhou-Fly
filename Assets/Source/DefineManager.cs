using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineManager : MonoBehaviour {

	public const int DIRECTION_LEFT_TOP = 1, DIRECTION_LEFT_BOTTOM = 2, DIRECTION_RIGHT_TOP = 3, DIRECTION_RIGHT_BOTTOM = 4, DIRECTION_CENTER = 5, 
				DIRECTION_FAILED = -1,

				ZERO = 0,

				CREATE_ENEMY_NUM = 5;

	public const float END_OF_TOP_SCREEN = 1.0f, END_OF_BOTTOM_SCREEN = -1.0f, END_OF_BOTTOM_SCREEN_WIDTH_GAP = -1.5f, END_OF_TOP_SCREEN_TOP_GAP = 3f;

	public static float SHAKE_CAMERA_RANGE = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
