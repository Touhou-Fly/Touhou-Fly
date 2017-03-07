using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

	ParticleSystem particleSystemPrefab;
	// Use this for initialization
	void Start () {
		particleSystemPrefab = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!particleSystemPrefab.IsAlive ()) {
			Destroy (gameObject);
		}
	}
}
