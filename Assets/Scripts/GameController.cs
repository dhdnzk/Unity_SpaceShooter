using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	/* variables about Canvas, UI, gameManagement */
	public Text scoreText;
	public Text restartGameText;
	public Text gameOverText;
	private int score;
	private bool isGameOvered;

	/* variables for game balance */
	public GameObject hazard;
	public float spawnWait;
	public float startWait;

	/****************************************************************/

	void Start() {
		score = 0;
		gameOverText.text = "";
		restartGameText.text = "";
		StartCoroutine (SpawnWaves ());
		isGameOvered = false;
	}

	void Update() {

		if(isGameOvered && Input.GetKeyDown (KeyCode.R)) {

			SceneManager.LoadSceneAsync ("Main");

		}
	}
		
	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		while(true) {
			float x = Random.Range (-9.4f, 9.4f);
			float z = 17f;
			Vector3 spawnPosition = new Vector3 (x, 0, z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazard, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
			if (isGameOvered) {
				break;
			}
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore (); 
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score.ToString ();
	}

	public void EndGame() {
				
		isGameOvered = true;
		gameOverText.text = "Game Over.";
		restartGameText.text = "Press 'R' to start game";

	}



}
