using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LiveCounter : MonoBehaviour {
	
	public Text liveText;
	public int LiveLeft { get { return int.Parse (liveText.text); } }

	private static LiveCounter m_instance;
	public static LiveCounter instance
	{
		get
		{
			if (m_instance == false)
			{
				m_instance = FindObjectOfType<LiveCounter>();
			}
			return m_instance;
		}
	}
	
	public bool AddLive (int amt) {
		int live = Convert.ToInt32(liveText.text) + amt;
		if (live >= 0) {
			liveText.text = live.ToString("00");
			return true;
		}
		else {
			liveText.text = "00";
			return false;
		}
	}
}
