using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
	
	public Button button;
	public GameObject Hide;
	public GameObject Enable;
	public static int HighScore;
	public static int HighScoreNew;


	public void Start() {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
		Score.score = 0;
		if(!PlayerPrefs.HasKey("HighScore")){
			PlayerPrefs.SetInt ("HighScore", 0);
		}

	}

	public static int ScoreReset(){ 
		Debug.Log ("check1212");

		HighScore = PlayerPrefs.GetInt ("HighScore");
		if (HighScore < Score.score) {
			PlayerPrefs.SetInt ("HighScore", Score.score);
		}
		HighScoreNew = PlayerPrefs.GetInt ("HighScore");
		Debug.Log (HighScoreNew.ToString());
		Score.score = 0;
		return HighScoreNew;
	}

	//void SaveScore(){
	//	HighScoreText.text = HighScoreNew.ToString();
	//}

	void OnClick() {
		Hide.SetActive (false);
		Enable.SetActive (true);
	}
}
