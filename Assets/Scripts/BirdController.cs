using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	[HideInInspector]
	public bool isDead = false;

	[HideInInspector]
	public int score = 0;

	void OnCollisionEnter2D(Collision2D coll)
	{
		isDead = true;
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		++score;
	}
}

