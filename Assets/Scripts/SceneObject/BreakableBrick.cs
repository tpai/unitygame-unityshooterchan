using UnityEngine;
using System.Collections;

public class BreakableBrick : MonoBehaviour {

	public AudioClip breakSound;

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.tag == "Player") {

			if (!coll.collider.GetComponent<UnitychanController>().IsJumping)return ;
			if (transform.position.y - coll.collider.transform.position.y < 1)return ;

			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;

			AudioCtrler.instance.PlayOneShot(breakSound);

			foreach (Transform child in transform) {
				child.GetComponent<Rigidbody2D>().isKinematic = false;
				child.GetComponent<Rigidbody2D>().AddForce(child.transform.localPosition * 300f);
			}
		}
	}
}
