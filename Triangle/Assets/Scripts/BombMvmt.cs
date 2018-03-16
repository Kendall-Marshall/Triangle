using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombMvmt : MonoBehaviour {
	public GameObject Player;
	public Sprite LossSprite;
	public Material Red;
	public float finalSize;
	public static bool check = false;
	public static bool BombClickCheck = false;
	public Text HighScoreText;
	public GameObject enable;
	public GameObject disable;
    BackgroundColor bgCol;

    private SpriteRenderer spr;

	void Start () {
        bgCol = GameObject.Find("Plane").GetComponent<BackgroundColor>();
        spr = GetComponent<SpriteRenderer>();
		if (check == true) {
			StartCoroutine (BombScaleIn ());
		}
	}

	IEnumerator BombScaleIn(){
		float currentTime = 0.0f;
		Vector3 originalScale = Player.transform.localScale;
		Vector3 destinationScale = new Vector3(finalSize, finalSize, finalSize);

		do {
			if (MainScript.runCheck == true) {
				Destroy (Player);
				break;
			}

			if (BombClickCheck == true) {
				StartCoroutine (BombDeath ());
				break;
			}

			Player.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / 2);
			Player.transform.Rotate (Vector3.forward * 2);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= 2);
			
		if (BombClickCheck == false) {
			StartCoroutine (BombScaleOut());
		}

	}

	IEnumerator BombScaleOut(){
		float currentTime = 0.0f;
		finalSize = 0.1f;
		Vector3 originalScale = Player.transform.localScale;
		Vector3 destinationScale = new Vector3(finalSize, finalSize, finalSize);

		do {
			if (MainScript.runCheck == true) {
				Destroy (Player);
				break;
			}

			if (BombClickCheck == true) {
				StartCoroutine (BombDeath ());
				break;
			}

			Player.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / 2);
			Player.transform.Rotate (Vector3.forward * -2);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= 2);

		if (BombClickCheck == false) {
			Player.SetActive (false);
			Destroy (Player);
		}
	}

	IEnumerator BombDeath(){
		MainScript.runCheck = true;
		float currentTime = 0.0f;
		spr.sprite = LossSprite;
        //bgCol.loseColor();
        Player.GetComponent<SpriteRenderer>().material = Red;

		Vector3 originalScale = new Vector3(0.1f, 0.1f, 0.1f);
		Vector3 destinationScale = new Vector3(0.3f, 0.3f, 0.3f);
		Vector3 destinationScale1 = new Vector3(0.1f, 0.1f, 0.1f);

		for (int i = 0; i < 2; i++) {
			do {
				Player.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / 2);
				currentTime += Time.deltaTime;
				yield return null;
			} while (currentTime <= 1f);

			currentTime = 0.0f;
			originalScale = Player.transform.localScale;
			do {
				Player.transform.localScale = Vector3.Lerp (originalScale, destinationScale1, currentTime / 2);
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
