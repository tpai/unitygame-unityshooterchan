using UnityEngine;
using System.Collections;

public class UnitychanAudio : MonoBehaviour {

	public AudioClip jumpSound;
	public AudioClip damageSound;
	public AudioClip shootSound;
	public AudioClip successSound;
	public AudioSource audioSource;

	void PlaySound (string sfx) {
		switch (sfx) {
		case "Jump": audioSource.clip = jumpSound; break;
		case "Damage": audioSource.clip = damageSound; break;
		case "Shoot": audioSource.clip = shootSound; break;
		case "Success": audioSource.clip = successSound; break;
		}
		audioSource.Play ();
	}
}
