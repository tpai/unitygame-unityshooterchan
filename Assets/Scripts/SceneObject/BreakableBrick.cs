using UnityEngine;
using System.Collections;

public class BreakableBrick : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.tag == "Player") {

			if (!coll.collider.GetComponent<UnitychanController>().IsJumping)return ;

			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;

			foreach (Transform child in transform) {
				child.GetComponent<Rigidbody2D>().isKinematic = false;
				child.GetComponent<Rigidbody2D>().AddForce(child.transform.localPosition * 300f);
			}
		}
	}
}
