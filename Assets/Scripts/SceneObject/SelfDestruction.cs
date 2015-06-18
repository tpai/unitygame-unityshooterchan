using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {

	public bool auto = false;
	public float duration = 2f;

	void Start () {
		if (auto)
			Destroy (gameObject, duration);
	}

	void Activate () {
		Destroy (gameObject, duration);
	}
}
