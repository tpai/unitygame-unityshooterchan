using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;

	void FixedUpdate () {
		transform.position = Vector3.Lerp (
			transform.position,
			new Vector3 (
				Mathf.Clamp (target.position.x, -1f, 100f),
				transform.position.y,
				transform.position.z
			),
			Time.deltaTime * 10f
		);
	}
}
