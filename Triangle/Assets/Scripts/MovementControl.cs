using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementControl : MonoBehaviour {

	public GameObject Player;
	public Sprite LossSprite;
	public float finalSize;
	public float finalSizeLoss;
	public static bool check = false;
	public GameObject enable;
	public GameObject disable;
	public Material Yellow;
	public Material Red;
	public FinalScore myInstance;
	public Text HighScoreText;

	private SpriteRenderer spr;

	void Start () {
		//myInstance = FinalScoreScreen.GetComponent<FinalScore> ();
		spr = GetComponent<SpriteRenderer>();
		if (check == true) {
			StartCoroutine(ScaleOverTime (2));
		}
	}
		
	IEnumerator ScaleOverTime(float time)
	{
		Player.SetActive (true);

		Vector3 originalScale = Player.transform.localScale;
		Vector3 destinationScale = new Vector3(finalSize, finalSize, finalSize);
		float currentTime = 0.0f;

		do
		{

			if(MainScript.runCheck == true){
					Destroy(Player);
					break;
			}

			Player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			Player.transform.Rotate(Vector3.forward * 2);
			yield return null;
		} while (currentTime <= time);
		StartCoroutine(ScaleOutOverTime(2));
	}

	IEnumerator ScaleOutOverTime(float time)
	{
		Vector3 originalScale = Player.transform.localScale;
		Vector3 destinationScale = new Vector3(0.1f, 0.1f, 0.1f);
		float currentTime = 0.0f;

		do
		{
			if(MainScript.runCheck == true){
					Destroy(Player);
					break;
			}
			Player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			Player.transform.Rotate(Vector3.forward * -2);
			if(currentTime > 0.7f){
				Player.GetComponent<SpriteRenderer>().material = Yellow;
			}
			yield return null;
		} while (currentTime <= time);

		MainScript.runCheck = true;
		StartCoroutine (ScaleAgainTime (2));
	}
		
	IEnumerator ScaleAgainTime(float time)
	{
		//Player.SetActive (true);

		spr.sprite = LossSprite;
		Vector3 originalScale = Player.transform.localScale;
		Vector3 destinationScale = new Vector3(finalSizeLoss, finalSizeLoss, finalSizeLoss);
		Vector3 destinationScale1 = new Vector3(0.1f, 0.1f, 0.1f);
		Player.GetComponent<SpriteRenderer>().material = Red;
		float currentTime = 0.0f;
		Debug.Log ("HERE1111");
		for (int i = 0; i < 2; i++) {
			
			do {
				Player.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
				currentTime += Time.deltaTime;
				yield return null;
			} while (currentTime <= 1f);
			currentTime = 0.0f;
			originalScale = Player.transform.localScale;
			do {
				Player.transform.localScale = Vector3.Lerp (originalScale, destinationScale1, currentTime / time);
				currentTime += Time.deltaTime;
				yield return null;
			} while (currentTime <= 1f);
			currentTime = 0.0f;
			originalScale = Player.transform.localScale;
		}
		Player.SetActive (false);
		Destroy(Player);

		int HighScore = FinalScore.ScoreReset();

		HighScoreText.text = HighScore.ToString();

		enable.SetActive (true);
		disable.SetActive (false);

	}
}
