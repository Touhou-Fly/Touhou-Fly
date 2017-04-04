using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

	ParticleSystem particleSystemPrefab;
	AudioSource effectSoundSource;
	// Use this for initialization
	void Start () {
		particleSystemPrefab = GetComponent<ParticleSystem> ();
		effectSoundSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!particleSystemPrefab.IsAlive ()) {
			if (effectSoundSource != null) {
				if (!effectSoundSource.isPlaying) {
					Destroy (gameObject);
				}
			}
			else {
				Destroy (gameObject);
			}
		}
	}
}
