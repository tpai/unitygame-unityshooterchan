using UnityEngine;
using System.Collections;

public class ScreenCollider : MonoBehaviour {

	void Start () {
		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;

		GetComponent<BoxCollider2D> ().size = new Vector2 (
			width, height
		);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "DamageObject") {
			other.GetComponent<UniMovement>().enabled = true;
		}
	}
}
