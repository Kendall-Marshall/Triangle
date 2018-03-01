using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombMvmt : MonoBehaviour {
	public GameObject Player;
	public Sprite LossSprite;
	public static bool check = false;
	public static bool BombClickCheck = false;

	private SpriteRenderer spr;

	void Start () {
		spr = GetComponent<SpriteRenderer>();
		if (check == true) {
			StartCoroutine (BombScale ());
		}
	}
	
	// Update is called once per frame
	IEnumerator BombScale(){
		float currentTime = 0.0f;

		do
		{

			if(MainScript.runCheck == true){
				Destroy(Player);
				break;
			}

			if(BombClickCheck == true){
				
				StartCoroutine(BombDeath());
				break;
			}

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
		do
		{
			Debug.Log ("1234");


			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= 5);

		//MainScript.runCheck = true;
		Player.SetActive (false);
		Destroy(Player);
	}
}
