using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundPlayer : DefineManager {

	AudioSource soundEffectSource;
	GameObject objectThatCanPlayAudio;

	// Use this for initialization
	void Start () {
		objectThatCanPlayAudio = gameObject;
		soundEffectSource = objectThatCanPlayAudio.GetComponent<AudioSource> ();
		soundEffectSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
