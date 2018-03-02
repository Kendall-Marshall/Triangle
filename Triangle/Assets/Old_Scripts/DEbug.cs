using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEbug : MonoBehaviour {
	public Button but;

	void Start () {
		Button btn = but.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	void OnClick() {
		MainScript.runCheck = true;
	}
}
