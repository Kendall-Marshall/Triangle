using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombMvmt : MonoBehaviour {
	public GameObject Player;
	public static bool check = false;
	// Use this for initialization
	void Start () {

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

			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= 2);

		Player.SetActive (false);
		Destroy(Player);
	}
}
