using UnityEngine;
using System.Collections;

public class CoinInit : MonoBehaviour {

	CircleCollider2D circleCollider2D;

	void Start () {
		circleCollider2D = GetComponent<CircleCollider2D>();
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			circleCollider2D.isTrigger = false;
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {

		if (
			coll.collider.tag == "Player" ||
			coll.collider.tag == "DamageObject"
		) {
			GetComponent<CircleCollider2D>().enabled = false;
		}

		if (coll.collider.tag == "DamageObject") {
			coll.collider.GetComponent<Rigidbody2D>().isKinematic = false;
			coll.collider.GetComponent<Rigidbody2D>().AddForce (new Vector2 (500f, 700f));
			coll.collider.GetComponent<CircleCollider2D>().enabled = false;
			coll.collider.GetComponent<Animator>().SetTrigger ("Dead");
		}
	}
}
