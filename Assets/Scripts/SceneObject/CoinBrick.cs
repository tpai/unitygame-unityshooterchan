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
		CoinCounter.instance.AddCoin (1);

		GameObject coinObj = (GameObject)Instantiate(coinPrefab, transform.position, Quaternion.identity);
		coinObj.GetComponent<Rigidbody2D>().AddForce (Vector2.up * 500f);
		Destroy (coinObj, .5f);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coin != 0 && coll.collider.tag == "Player") {

			if (!coll.collider.GetComponent<UnitychanController>().IsJumping)return ;
			if (transform.position.y - coll.collider.transform.position.y < 1)return ;

			PopCoin ();
			m_animator.SetTrigger ("Hit");
		}
	}
}
