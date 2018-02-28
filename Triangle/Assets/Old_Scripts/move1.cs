using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move1 : MonoBehaviour {
	public Button but;
	public GameObject obj;
	// Use this for initialization
	void Start () {
		Button btn = but.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	// Update is called once per frame
	void OnClick() {
		obj.transform.position = new Vector3(1,0,0);
	}
}
