using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour {

	public Button yesBtn;
	public Button noBtn;
	public GameObject ExitPanel;

	void Start () {
		Button yBtn = yesBtn.GetComponent<Button>();
		yBtn.onClick.AddListener(yesButtonClick);
		Button nBtn = noBtn.GetComponent<Button>();
		nBtn.onClick.AddListener(noButtonClick);
	}

	void yesButtonClick() {
		Application.Quit ();
	}

	void noButtonClick() {
		ExitPanel.SetActive(false);
	}

	void Update () {
		if(Input.GetKeyDown("escape")){
			ExitPanel.SetActive(false);
		}
	}
}
