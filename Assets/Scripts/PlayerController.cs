using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {

	public int xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float speed;
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public float fireRate;

	private float myTime;

	void start() {
		
		myTime = 0.0f;

		rb = this.GetComponent <Rigidbody> ();

	}

	void Update() {
		
		myTime = myTime + Time.deltaTime;

		if (Input.GetKey (KeyCode.Space) && myTime > fireRate) {
			
			this.GetComponent <AudioSource>().Play ();
			Instantiate (shot, this.transform);
			myTime = 0.0f;

		}

	}

	void FixedUpdate() {

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		Vector3 moving = new Vector3(horizontal, 0.0f, vertical * 1.1f); 

		rb.velocity = moving * speed; 
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, -tilt * rb.velocity.x);

		// 이동 가능한 범위 정해주고 밖으로 못 나가게
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

	}

}