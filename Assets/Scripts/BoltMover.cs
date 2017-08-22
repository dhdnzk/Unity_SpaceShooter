using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour {
	
	public float speed;

	public Rigidbody rb;

	void Start() {
		
		this.GetComponent <Rigidbody>().velocity = new Vector3(0.0f, 0.0f, speed);

	}


}
