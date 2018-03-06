using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
	public Button button;
	public GameObject Hide;
	public GameObject Enable;
    //public GameObject bgCol;
    public static int HighScore;
	public static int HighScoreNew;
    BackgroundColor bgCol;

    public void Start() {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
		Score.score = 0;
		if(!PlayerPrefs.HasKey("HighScore")){
			PlayerPrefs.SetInt ("HighScore", 0);
		}
        bgCol = GameObject.Find("Plane").GetComponent<BackgroundColor>();
    }

	public static int ScoreReset(){ 
		HighScore = PlayerPrefs.GetInt ("HighScore");
		if (HighScore < Score.score) {
			PlayerPrefs.SetInt ("HighScore", Score.score);
		}
		HighScoreNew = PlayerPrefs.GetInt ("HighScore");
		Debug.Log (HighScoreNew.ToString());
		Score.score = 0;
		return HighScoreNew;
	}

	void OnClick() {
		Hide.SetActive (false);
		Enable.SetActive (true);
        bgCol.resetColor();
        BackgroundColor.BgColor = 0;
    }
}
