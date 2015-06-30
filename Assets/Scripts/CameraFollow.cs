using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;

	public void AssignTarget (Transform newTarget) {
		target = newTarget;
	}

	void FixedUpdate () {

		if (target != null) {
			transform.position = Vector3.Lerp (
				transform.position,
				new Vector3 (
					Mathf.Clamp (target.position.x, .9f, 500f),
					transform.position.y,
					transform.position.z
				),
				Time.deltaTime * 10f
			);
		}
	}
}
