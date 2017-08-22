using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour {
	
	private float rotationSpeed;
	private float movingSpeed;

	void Start() {

		rotationSpeed = 0.1f + Random.value * 5;
		movingSpeed = 3 + Random.value * 2;

	}

	void FixedUpdate() {

		this.GetComponent <Transform> ().Rotate (new Vector3(0.5f, 0.5f, 0.5f) * rotationSpeed);
		this.GetComponent <Rigidbody> ().AddForce (0.0f, 0.0f, (-1) * movingSpeed);

	}

}
