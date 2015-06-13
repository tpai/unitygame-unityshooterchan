using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(BoxCollider2D), typeof(Rigidbody2D))]

public class UnitychanController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jumpPower = 1000f;
	
	public Transform groundCheckA;
	public Transform groundCheckB;
	
	public LayerMask whatIsGround;

	private Animator m_animator;
	private Rigidbody2D m_rigidbody2D;
	private BoxCollider2D m_boxcollider2D;
	private bool m_isGround;

	void Reset () {
		// Rigidbody2D
		m_rigidbody2D.gravityScale = 3.5f;
		m_rigidbody2D.fixedAngle = true;

		// BoxCollider2D
		m_boxcollider2D.size = new Vector2(1, 2.5f);
		m_boxcollider2D.offset = new Vector2(0, -0.25f);
	}

	void Awake () {
		m_animator = GetComponent <Animator>();
		m_rigidbody2D = GetComponent <Rigidbody2D>();
		m_boxcollider2D = GetComponent <BoxCollider2D>();
	}
	
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		bool jump = Input.GetButtonDown ("Jump");
		Move (x, jump);
	}
	
	void Move (float x, bool jump) {
		if (Mathf.Abs (x) > 0) { // It means now character is moving
			// face to two-side
			Quaternion rot = transform.rotation;
			transform.rotation = Quaternion.Euler (rot.x, Mathf.Sign (x) == 1?0:180, rot.z);
		}
		
		// Assign forward speed and gravity speed
		m_rigidbody2D.velocity = new Vector2 (x * maxSpeed, m_rigidbody2D.velocity.y);

		m_animator.SetFloat ("Horizontal", x);
		
		// When press jump
		if (jump && m_isGround) {
			m_rigidbody2D.AddForce (Vector2.up * jumpPower);
		}
	}
	
	void FixedUpdate () {
		// Set a rectangle area to detect collision with ground
		m_isGround = Physics2D.OverlapArea(groundCheckA.position, groundCheckB.position, whatIsGround);
	}
}
