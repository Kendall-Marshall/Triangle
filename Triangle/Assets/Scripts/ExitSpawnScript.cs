using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitSpawnScript : MonoBehaviour {
	public GameObject ExitPanel;
	public Button exitBtn;

	void Start () {
		Button exBtn = exitBtn.GetComponent<Button>();
		exBtn.onClick.AddListener(exitButtonClick);
	}

	void Update () {
		if(Input.GetKeyDown("escape")){
			ExitPanel.SetActive(true);
		}
	}

	void exitButtonClick(){
		ExitPanel.SetActive(true);
	}
}

