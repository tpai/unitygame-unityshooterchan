using UnityEngine;
using System.Collections;

public class UnitychanAttack : MonoBehaviour {

	public float timeOffset = .5f;
	public float shootForce = 1600f;

	[SerializeField] GameObject coin;
	bool holdFire = false;

	void Update () {
		Debug.DrawRay(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.green);

		if (!holdFire && Input.GetButtonDown ("Fire1")) {

			if (!CoinCounter.instance.AddCoin(-1))return ;

			Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			StartCoroutine ( Shoot ( Vector3.Normalize(direction) ) );
		}
	}

	IEnumerator Shoot (Vector3 direction) {

		SendMessage ("PlaySound", "Shoot");

		holdFire = true;
		GameObject bullet = (GameObject)Instantiate (
			coin,
			transform.position,
			Quaternion.identity
		);
		bullet.GetComponent<Rigidbody2D> ().AddForce (
			new Vector2 (
				Mathf.Clamp(direction.x * shootForce, -1000f, 1000f),
				Mathf.Clamp(direction.y * shootForce, -1000f, 1000f)
			)
		);
		yield return new WaitForSeconds (timeOffset);
		holdFire = false;
	}
}
