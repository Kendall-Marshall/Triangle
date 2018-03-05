using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour {
    public int BgColor = 0;
    public static int BgColorCount = 0;
    public GameObject panel;
    Renderer rend;

    void Start()
    {
        rend = panel.GetComponent<Renderer>();
        rend.material.color = Color.grey;
    }

    void Update ()
    {
        if (BgColorCount == 5)
        {
            BgColor++;
            BgColorCount = 0;
        }

        if(BgColor == 1)
        {
            rend.material.color = Color.cyan;
        }
        else if(BgColor == 2)
        {
            rend.material.color = Color.green;
        }
	}
}
