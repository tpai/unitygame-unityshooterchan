using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCounter : MonoBehaviour {
	
	public Text timeText;

	private bool m_stop = false;
	private float m_nowTime = 200f;

	public bool Stop { set { m_stop = value; } }
	public int TimeLeft { get { return int.Parse(timeText.text); } }
	
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
			if (m_nowTime <= 0)
				m_nowTime = 0;
			timeText.text = m_nowTime.ToString ("000");
		}
	}
}
