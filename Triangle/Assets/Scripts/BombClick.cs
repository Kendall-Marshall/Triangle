using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombClick : MonoBehaviour {
	void OnMouseDown() {
		if (MainScript.runCheck == false) {
			BombMvmt.BombClickCheck = true;
		}
	}
}
