using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	public GameObject bird;

	void Update () {
		var birdController = bird.GetComponent<BirdController> ();
		if (birdController.isDead || !bird.activeSelf)
			return;
		
		var position = transform.position;
		position.x -= 1 * Time.deltaTime;
		transform.position = position;
	}
}
