using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCounter : MonoBehaviour {

	public Text coinText;

	private static CoinCounter m_instance;
	public static CoinCounter instance
	{
		get
		{
			if (m_instance == false)
			{
				m_instance = FindObjectOfType<CoinCounter>();
			}
			return m_instance;
		}
	}

	public bool AddCoin (int amt) {
		int coin = Convert.ToInt32(coinText.text) + amt;
		if (coin >= 0) {
			coinText.text = coin.ToString("00");
			return true;
		}
		else {
			coinText.text = "00";
			return false;
		}
	}
}
