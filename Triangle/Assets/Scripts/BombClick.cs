using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombClick : MonoBehaviour {


	
	// Update is called once per frame
	void OnMouseDown() {
		if (MainScript.runCheck == false) {
			//MainScript.runCheck = true;
			BombMvmt.BombClickCheck = true;
			//Destroy (gameObject);
		}
	}
}
