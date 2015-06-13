using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {

	public float duration = 2f;

	void Start () {
		Destroy (gameObject, duration);
	}
}
