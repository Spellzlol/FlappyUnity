using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject bird;
	public GameObject tutorialImage;
	public GameObject scoreLabel;
	public GameObject deathImage;

	private int lastScore = 0;

	// Use this for initialization
	void Start () {
		bird.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length > 0) {
			handleTouch();
			return;
		}

		if (Input.anyKey) {
			handleMouse();
			return;
		}
	}

	void LateUpdate() {
		var birdController = bird.GetComponent<BirdController>();
		if (birdController.isDead) {
			handleDeath();
		} 
		if (birdController.score > lastScore) {
			updateScore(birdController.score);
		}
	}

	private void handleMouse() {
		dispatchTouchEvent();
	}

	private void handleTouch() {
		var touch = Input.touches [0];
		if (touch.phase == TouchPhase.Ended) {
			dispatchTouchEvent();
		}
	}

	private void dispatchTouchEvent() {
		if (deathImage.activeSelf) {
			SceneManager.LoadScene (1);
			return;
		}

		if (tutorialImage.activeSelf) {
			tutorialImage.SetActive (false);
			bird.SetActive (true);
			return;
		}

		var body = bird.GetComponent<Rigidbody2D> ();
		body.AddForce (Vector2.up, ForceMode2D.Impulse);
	}

	void updateScore(int newScore) {
		lastScore = newScore;
		scoreLabel.GetComponent<Text> ().text = "Score: " + newScore.ToString();
	}

	void handleDeath() {
		bird.SetActive (false);
		deathImage.SetActive (true);
	}
}
