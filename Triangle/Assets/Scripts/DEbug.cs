using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEbug : MonoBehaviour {

	public Button but;
	// Use this for initialization
	void Start () {
		Button btn = but.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void OnClick() {
		MainScript.runCheck = true;
	}
}
