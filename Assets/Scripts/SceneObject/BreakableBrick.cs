using UnityEngine;
using System.Collections;

public class BreakableBrick : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.tag == "Player") {

			float vRange = transform.position.y - coll.collider.transform.position.y;
			float hRange = transform.position.x - coll.collider.transform.position.x;
			if (hRange > .8f || hRange < -.8f)return ;
			if (vRange <= 1.4f)return ;

			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;

			foreach (Transform child in transform) {
				child.GetComponent<Rigidbody2D>().isKinematic = false;
				child.GetComponent<Rigidbody2D>().AddForce(child.transform.localPosition * 300f);
			}
		}
	}
}
