using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScore : MonoBehaviour {

	public Text finalScoreText;
	private int finalScore = 0;
	public int GetFinalScore { get { return finalScore; } }

	private bool allowRestart = false;

	private static FinalScore m_instance;
	public static FinalScore instance
	{
		get
		{
			if (m_instance == false)
			{
				m_instance = FindObjectOfType<FinalScore>();
			}
			return m_instance;
		}
	}

	public void Display (bool b) {
		allowRestart = true;

		int time = TimeCounter.instance.TimeLeft;
		int live = LiveCounter.instance.LiveLeft;
		int coin = CoinCounter.instance.CoinLeft;

		finalScore = 1000 * live + 500 * coin + 10 * time;

		if (b)
			finalScoreText.text = "Final Score\n" + finalScore.ToString("000000") + "\n\nPress 'R' to restart";
		else
			finalScoreText.text = "You failed\n\nPress 'R' to restart";
		finalScoreText.enabled = true;
	}

	void Update () {
		if (allowRestart && Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ("Main");
		}
	}
}
