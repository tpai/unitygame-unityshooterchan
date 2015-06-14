﻿using UnityEngine;
using System.Collections;

public class UnitychanAttack : MonoBehaviour {

	public float timeOffset = .5f;
	public float shootForce = 200f;

	[SerializeField] GameObject coin;
	bool holdFire = false;

	void Update () {
		Debug.DrawRay(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.green);

		if (!holdFire && Input.GetButtonDown ("Fire1")) {
			Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			StartCoroutine ( Shoot ( Vector3.Normalize(direction) ) );
		}
	}

	IEnumerator Shoot (Vector3 direction) {
		holdFire = true;
		GameObject bullet = (GameObject)Instantiate (
			coin,
			transform.position,
			Quaternion.identity
		);
		bullet.GetComponent<Rigidbody2D> ().AddForce (direction * shootForce);
		yield return new WaitForSeconds (timeOffset);
		holdFire = false;
	}
}