using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.UI;

public class fadebut : MonoBehaviour {

	void Update ()
	{
		//var material = GetComponent<Renderer> ().material;
		//var color = material.color;
		if(Input.GetKeyDown(KeyCode.T))
		{
			StartCoroutine(FadeTo(0.0f, 2.0f));
		}
		if(Input.GetKeyDown(KeyCode.F))
		{
			StartCoroutine(FadeTo(1.0f, 2.0f));
		}
	}

	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = transform.GetComponent<Renderer>().material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			transform.GetComponent<Renderer>().material.color = newColor;
			yield return null;
		}
	}
}