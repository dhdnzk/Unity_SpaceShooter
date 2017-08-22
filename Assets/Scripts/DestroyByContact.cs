using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosionAnimation;
	public GameObject playerExplosionAnimation;
	public GameObject enemeyExplosionAnimation;
	private GameController gameController;

	public int scoreValue;

	void Start() {
		scoreValue = 10;

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
	}

	void OnTriggerEnter(Collider other) {

		if(other.CompareTag ("Boundary")) {
			
			return;

		}

		if(other.CompareTag ("Player")) {
		
			Instantiate (playerExplosionAnimation, this.transform.position, this.transform.rotation);
			gameController.EndGame();

		}
		else if(other.CompareTag ("Bolt")){
			
			Instantiate (explosionAnimation, this.transform.position, this.transform.rotation);
			gameController.AddScore (scoreValue);

		}
			
		Destroy(other.gameObject);
		Destroy(this.gameObject);

	}
}
