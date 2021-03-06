﻿using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;

	private static PlayerSpawner m_instance;
	public static PlayerSpawner instance {
		get {
			if (m_instance == null) {
				m_instance = FindObjectOfType <PlayerSpawner>();
			}
			return m_instance;
		}
	}

	public void Respawn (float wait) {
		transform.position = new Vector2 (
			GameObject.Find ("Player").transform.position.x,
			transform.position.y
		);
		StartCoroutine ( Spawn (wait) );
	}

	public void Nospawn () {
		Camera.main.GetComponent<CameraFollow>().AssignTarget (Camera.main.transform);
	}

	IEnumerator Spawn (float wait) {
		yield return new WaitForSeconds (wait);
		GameObject player = (GameObject)Instantiate (
			playerPrefab,
			transform.position,
			Quaternion.identity
		);
		player.name = "Player";
		Camera.main.GetComponent<CameraFollow>().AssignTarget (player.transform);
	}
}
