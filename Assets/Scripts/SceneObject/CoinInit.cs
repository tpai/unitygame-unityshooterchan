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
			coll.collider.GetComponent<Animator>().enabled = false;
			coll.collider.GetComponent<UniMovement>().enabled = false;
			coll.collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			coll.collider.GetComponent<Rigidbody2D>().isKinematic = false;

			Vector2 dropForce;

			if (coll.collider.transform.position.x - transform.position.x > 0)
				dropForce = new Vector2 (500f, 700f);
			else
				dropForce = new Vector2 (-500f, 700f);

			coll.collider.GetComponent<Rigidbody2D>().AddForce (dropForce);
			coll.collider.GetComponent<CircleCollider2D>().enabled = false;
			Destroy (coll.collider.gameObject, 2f);
		}
	}
}
