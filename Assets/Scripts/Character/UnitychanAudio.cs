using UnityEngine;
using System.Collections;

public class UnitychanAudio : MonoBehaviour {

	public AudioClip jumpSound;
	public AudioClip damageSound;
	public AudioSource audioSource;

	void PlaySound (string sfx) {
		switch (sfx) {
		case "Jump": audioSource.clip = jumpSound; break;
		case "Damage": audioSource.clip = damageSound; break;
		}
		audioSource.Play ();
	}
}
