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
		Destroy (coinObj, .5f);
		CoinCounter.instance.AddCoin (1);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coin != 0 && coll.collider.tag == "Player") {

			if (!coll.collider.GetComponent<UnitychanController>().IsJumping)return ;
			float vForce = transform.position.y - coll.collider.transform.position.y;
			if (vForce < 2)return ;

			PopCoin ();
			m_animator.SetTrigger ("Hit");
		}
	}
}
