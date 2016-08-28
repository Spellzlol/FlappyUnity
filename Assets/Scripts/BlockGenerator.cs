using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {

	public GameObject block;
	public GameObject gameController;
	public float spawnInterval = 2.0f;

	private float timeElapsed = 0.0f;

	void Update () {
		if (!gameController.GetComponent<GameController>().bird.activeSelf) {
			return;
		}

		timeElapsed += Time.deltaTime;
		if (timeElapsed >= spawnInterval) {
			timeElapsed = 0.0f;
			var newBlock = Instantiate (block);

			var position = newBlock.transform.position;
			position.y += Random.Range (-2.0f, 2.0f);
			position.x = 4;
			newBlock.transform.position = position;
		}
	}
}
