using UnityEngine;
using System.Collections;

public class CoinBrick : MonoBehaviour {

	public int coin;
	public GameObject coinPrefab;

	private Animator m_animator;
	
	void Start () {
		m_animator = GetComponent<Animator>();
	}

	void PopCoin () {
		coin --;
		if (coin <= 0)coin = 0;
		m_animator.SetInteger ("Coin", coin);

		GameObject coinObj = (GameObject)Instantiate(
			coinPrefab,
			transform.position,
			Quaternion.identity
		);
		coinObj.GetComponent<Rigidbody2D>().AddForce (Vector2.up * 500f);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coin != 0 && coll.collider.tag == "Player") {

			float vRange = transform.position.y - coll.collider.transform.position.y;
			float hRange = transform.position.x - coll.collider.transform.position.x;
			if (hRange > .8f || hRange < -.8f)return ;
			if (vRange <= 1.4f)return ;

			PopCoin ();
			m_animator.SetTrigger ("Hit");
		}
	}
}
