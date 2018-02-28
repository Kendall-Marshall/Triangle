using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombMouseClick : MonoBehaviour {

	public GameObject Player;
	public Sprite LossSprite;
	public float finalSize;
	public float finalSizeLoss;
	public static bool check = false;
	public GameObject enable;
	public GameObject disable;


	private SpriteRenderer spr;

	void Start () {
		spr = GetComponent<SpriteRenderer>();

	}

	void OnMouseDown(){
		if (MainScript.runCheck == false) {
			

			BombMovementControl.clickCheck = true;
			Score.score-=1000;
			//StartCoroutine (ScaleAgainTime (1));

		}
	}


	IEnumerator ScaleAgainTime(float time)
	{
		//Player.SetActive (true);


		//Vector3 originalScale = Player.transform.localScale;
		//Vector3 destinationScale = new Vector3(0.3f, 0.3f, 0.3f);
		//Vector3 destinationScale1 = new Vector3(0.1f, 0.1f, 0.1f);

		float currentTime = 0.0f;
		//for (int i = 0; i < 2; i++) {
			do {
				if (MainScript.runCheck == true) {
					Destroy (Player);
					break;
				}
				//Player.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
				currentTime += Time.deltaTime;
				yield return null;
			} while (currentTime <= 1f);
			currentTime = 0.0f;
			MainScript.runCheck = true;
			//originalScale = Player.transform.localScale;
			do {
				//Player.transform.localScale = Vector3.Lerp (originalScale, destinationScale1, currentTime / time);
				currentTime += Time.deltaTime;
				yield return null;
			} while (currentTime <= 1f);
			currentTime = 0.0f;
			//originalScale = Player.transform.localScale;
		//}
		//yield return new WaitForSeconds(0f);

		Player.SetActive (false);
		Destroy(Player);

		enable.SetActive (true);
		disable.SetActive (false);

		Destroy (gameObject);

	}
}
