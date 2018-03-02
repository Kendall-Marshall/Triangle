using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour {
	public AudioClip pop1;
	public AudioClip pop2;
	public AudioClip pop3;
	public AudioSource src;

	void OnMouseDown(){

		int rand = Random.Range (0, 3);
		if (rand == 0) {
			src.clip = pop1;
		} 
		else if (rand == 1) {
			src.clip = pop2;
		}
		else if (rand == 2) {
			src.clip = pop3;
		}

		if (MainScript.runCheck == false) {
				src.Play ();
				Destroy (gameObject);
				Score.score++;
		}
	}
}
