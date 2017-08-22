using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float lifetime;

//	public float delayDestroyTime;
//	private float delayedTime;

	void Start() {
		
		Destroy (gameObject, lifetime);

	}

}
