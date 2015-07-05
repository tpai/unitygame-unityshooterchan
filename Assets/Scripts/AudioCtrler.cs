using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioCtrler : MonoBehaviour {

	private static AudioCtrler m_instance;
	public static AudioCtrler instance {
		get {
			if (m_instance == null) {
				m_instance = FindObjectOfType<AudioCtrler> ();
					
				if (m_instance == null) {
					m_instance = new GameObject ("AudioSourceController").AddComponent<AudioCtrler> ();
				}
			}
			return m_instance;
		}
	}
		
	public void PlayOneShot (AudioClip clip)
	{
		GetComponent<AudioSource> ().PlayOneShot (clip);
	}
}
