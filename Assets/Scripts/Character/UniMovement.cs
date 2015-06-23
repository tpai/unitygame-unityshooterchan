using UnityEngine;
using System.Collections;

public class UniMovement : MonoBehaviour {

	public bool jump = false;
	public float moveSpeed = -5f;

	private bool m_isDead = false;

	void Start () {
		if (jump)GetComponent<Animator>().SetBool("Jump", true);
	}

	void UniKill () {
		m_isDead = true;
		GetComponent<Animator>().enabled = false;
	}

	void FixedUpdate () {
		if (!m_isDead) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (
				transform.right.x * moveSpeed,
				GetComponent<Rigidbody2D>().velocity.y
			);
		}
	}
}
