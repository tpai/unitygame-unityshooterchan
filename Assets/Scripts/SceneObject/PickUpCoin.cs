using UnityEngine;
using System.Collections;

public class PickUpCoin : MonoBehaviour {
	
	public AudioClip getCoin;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			CoinCounter.instance.AddCoin(1);
			Destroy(gameObject);
		}
	}
}
