using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MOVE : MonoBehaviour {
	public Button but;
	public GameObject obj;

	void Start () {
		Button btn = but.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	void OnClick() {
		obj.transform.position = new Vector3(-1,0,0);
	}
}
