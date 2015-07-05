using UnityEngine;
using System.Collections;

public class ItemBrick : MonoBehaviour {

	public enum Item { coin, live };
	public Item itemType;

	public int item;
	public GameObject itemPrefab;

	public AudioClip coinSound;
	public AudioClip liveSound;
	public AudioClip emptySound;

	private Animator m_animator;
	
	void Start () {
		m_animator = GetComponent<Animator>();
	}

	void PopItem () {
		item --;
		if (item <= 0)item = 0;
		m_animator.SetInteger ("Item", item);

		GameObject obj = (GameObject)Instantiate (itemPrefab, transform.position, Quaternion.identity);
		obj.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 500f);
		Destroy (obj, .5f);

		if (itemType == Item.coin) {
			CoinCounter.instance.AddCoin (1);
			AudioCtrler.instance.PlayOneShot (coinSound);
		} else if (itemType == Item.live) {
			LiveCounter.instance.AddLive (1);
			AudioCtrler.instance.PlayOneShot (liveSound);
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.tag == "Player") {

			if (!coll.collider.GetComponent<UnitychanController>().IsJumping)return ;
			if (transform.position.y - coll.collider.transform.position.y < 1)return ;

			if (item != 0) {
				PopItem ();
				m_animator.SetTrigger ("Hit");
			}
			else {
				AudioCtrler.instance.PlayOneShot (emptySound);
			}
		}
	}
}
