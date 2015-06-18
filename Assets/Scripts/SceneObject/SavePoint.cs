using UnityEngine;
using System.Collections;

public class SavePoint : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Vector2 spawnPointPos = GameObject.Find ("SpawnPoint").transform.position;
			GameObject.Find ("SpawnPoint").transform.position = new Vector2 (
				transform.position.x,
				spawnPointPos.y
			);
		}
	}
}
