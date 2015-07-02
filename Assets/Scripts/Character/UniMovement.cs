using UnityEngine;
using System.Collections;

public class UniMovement : MonoBehaviour {

	public bool jump = false;
	public float moveSpeed = -5f;

	private bool m_stop = false;

	public bool Stop { set { m_stop = value; } }

	void Start () {
		if (jump)GetComponent<Animator>().SetBool("Jump", true);
	}

	void FixedUpdate () {
		if (!m_stop) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (
				transform.right.x * moveSpeed,
				GetComponent<Rigidbody2D>().velocity.y
			);
		}
	}
}
