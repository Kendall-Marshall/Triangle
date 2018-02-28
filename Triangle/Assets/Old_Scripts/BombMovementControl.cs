using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombMovementControl : MonoBehaviour {
	public GameObject Player;
	public static bool check = false;
	public static bool clickCheck = false;


	//public static MovementControl Instance;

	void Start() {
		//myInstance = FinalScoreScreen.GetComponent<FinalScore> ();

		if (check == true) {
			StartCoroutine (ScaleOutOverTime (2));
		}
	}

	IEnumerator ScaleOverTime(float time)
	{
		Player.SetActive (true);

		Vector3 originalScale = Player.transform.localScale;
		Vector3 destinationScale = new Vector3(1, 1, 1);
		float currentTime = 0.0f;

		do
		{

			//Debug.Log (gameObject.name);
			if(MainScript.runCheck == true){
				Destroy(Player);
				break;
			}
			Player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			Player.transform.Rotate(Vector3.forward * 2);
			yield return null;
		} while (currentTime <= time);
		if (clickCheck == false) {
			Destroy(Player);
		}
		StartCoroutine(ScaleOutOverTime(2));
	}

	IEnumerator ScaleOutOverTime(float time)
	{

		//yield return new WaitForSeconds(1f);
	
		Vector3 originalScale = Player.transform.localScale;
		Vector3 destinationScale = new Vector3(0.1f, 0.1f, 0.1f);

		float currentTime = 0.0f;
		do
		{

			//Debug.Log (gameObject.name);
			if(MainScript.runCheck == true){
				Destroy(Player);
				break;
			}
			Player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			Player.transform.Rotate(Vector3.forward * -2);
			//currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time && clickCheck == false);

		if (clickCheck == false) {
			Destroy(Player);
		}

	}



}
