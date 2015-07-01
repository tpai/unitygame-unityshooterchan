using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCounter : MonoBehaviour {
	
	public Text timeText;

	private bool m_stop = false;
	public bool Stop { set { m_stop = value; } }
	private float m_nowTime = 200f;
	
	private static TimeCounter m_instance;
	public static TimeCounter instance
	{
		get
		{
			if (m_instance == false)
			{
				m_instance = FindObjectOfType<TimeCounter>();
			}
			return m_instance;
		}
	}

	void FixedUpdate () {
		if (!m_stop) {
			m_nowTime -= Time.deltaTime;
			timeText.text = m_nowTime.ToString ("000");
		}
	}
}
