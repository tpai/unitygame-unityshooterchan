﻿using UnityEngine;
using System.Collections;

public class UniFlap : MonoBehaviour {

	int faceTo;

	void Start () {
		faceTo = 0;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Wall") {

			if (faceTo == 0)faceTo = 180;
			else faceTo = 0;

			Quaternion rot = transform.rotation;
			transform.parent.transform.rotation = Quaternion.Euler (rot.x, faceTo, rot.z);
		}
	}
}