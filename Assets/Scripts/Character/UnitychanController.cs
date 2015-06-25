using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(BoxCollider2D), typeof(Rigidbody2D))]

public class UnitychanController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float maxHeight = 4f;
	public float jumpPower = 1600f;
	
	public Transform groundCheckA;
	public Transform groundCheckB;
	public LayerMask whatIsGround;
	
	private Animator m_animator;
	private Rigidbody2D m_rigidbody2D;
	private BoxCollider2D m_boxcollider2D;
	private float m_jumpStartY;
	private bool m_isJumping;
	private bool m_isGround;
	private bool m_isDead;

	public bool IsJumping { get { return m_isJumping; } }

	void Reset () {

		// 
		m_isDead = false;
		m_isJumping = false;

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
		if (!m_isDead) {
			float x = Input.GetAxis ("Horizontal");
			bool jump = Input.GetButtonDown ("Jump");
			Move (x, jump);

			bool holdJump = Input.GetButton ("Jump");
			if (holdJump && m_isJumping)
				m_rigidbody2D.AddForce (Vector2.up * 30f);

			if (
				transform.position.y - m_jumpStartY > maxHeight ||
				m_rigidbody2D.velocity.y < 0
			)
				m_isJumping = false;
		}
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
		m_animator.SetFloat ("Vertical", m_rigidbody2D.velocity.y);
		m_animator.SetBool ("IsGround", m_isGround);
		
		// When press jump
		if (jump && m_isGround) {
			m_isJumping = true;
			m_jumpStartY = transform.localPosition.y;
			m_rigidbody2D.AddForce (Vector2.up * jumpPower);
			m_animator.SetTrigger ("Jump");
		}
	}
	
	void FixedUpdate () {
		// Set a rectangle area to detect collision with ground
		m_isGround = Physics2D.OverlapArea(groundCheckA.position, groundCheckB.position, whatIsGround);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.tag == "DamageObject") {
			m_isDead = true;
			m_animator.SetTrigger("Dead");
			m_boxcollider2D.enabled = false;
			m_rigidbody2D.velocity = Vector2.zero; // Fix jump when die

			Vector2 dropForce;

			if (coll.collider.transform.position.x - transform.position.x > 0)
				dropForce = new Vector2 (-200f, 500f);
			else
				dropForce = new Vector2 (200f, 500f);

			m_rigidbody2D.AddForce(dropForce);

			// ------

			if (LiveCounter.instance.AddLive (-1))
				PlayerSpawner.instance.Respawn (1f);
			else
				PlayerSpawner.instance.Nospawn ();
			Destroy (gameObject, 1.1f);
		}
	}
}
