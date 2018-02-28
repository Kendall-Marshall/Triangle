using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text scoreText;
	public Text FinalScoreText;
	public static int  score;

	void Start () {
		score = 0;
	}

	void Update () {
		scoreText.text = score.ToString();
		FinalScoreText.text = score.ToString();
	}
}
