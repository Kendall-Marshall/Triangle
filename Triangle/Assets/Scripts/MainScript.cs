using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {
	public GameObject obj;
	public GameObject bomb;
	public Button but;
	public GameObject Hide;
	public GameObject Enable;
	public static bool runCheck;
	public Text HighScoreText;
	Renderer rend;
    public Material Yellow;

    void Start () {
        
        Button btn = but.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
		HighScoreText.text = PlayerPrefs.GetInt ("HighScore").ToString();
    }

	void OnClick() {
		runCheck = false;
		StartCoroutine(Scale());
		Hide.SetActive (false);
		Enable.SetActive (true);
	}

	IEnumerator Scale()
	{
        float level = 1;
		int count = 0;
		while(runCheck == false){
			yield return new WaitForSeconds (level);
			Vector3 position = new Vector3 (Random.Range (-2.2f, 2.2f), Random.Range (-4.5f, 2.7f), 0);
			Vector3 bombPos = new Vector3 (Random.Range (-2.2f, 2.2f), Random.Range (-4.5f, 2.7f), 0);
			MovementControl.check = true;
			BombMvmt.check = true;
			BombMvmt.BombClickCheck = false;
			int Rand = Random.Range (0, 6);
			if (Rand > 1) {
				Instantiate (obj, position, Quaternion.identity);
			} else {
				Instantiate (bomb, bombPos, Quaternion.identity);
			}

			count++;
			if (count == 5) {
				level -= 0.025f;
				count = 0;
			}
		}
	}
}