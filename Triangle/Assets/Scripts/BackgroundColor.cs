﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour {
    public static int BgColor = 0;
    public static int BgColorCount = 0;
    public GameObject panel;
    Renderer rend;

    public Color[] levels = new Color[3];

    private float lerpCheck = 0;

    void Start()
    {
        rend = panel.GetComponent<Renderer>();
        rend.material.color = levels[0];
    }

    public void resetColor()
    {
        rend.material.color = levels[0];
    }

    public void loseColor()
    {
        rend.material.color = Color.red;
    }

    void Update ()
    {
        if (BgColorCount == 3)
        {
            BgColor++;
            BgColorCount = 0;
            lerpCheck = 0;
        }

        switch (BgColor)
        {
            case 1:
                lerper(levels[BgColor-1], levels[BgColor]);
                break;
            case 2:
                lerper(levels[BgColor - 1], levels[BgColor]);
                break;
            case 3:
                lerper(levels[BgColor - 1], levels[BgColor]);
                break;
            default:
                break;
        }
    }

    void lerper(Color oldCol, Color newCol)
    {
        if(lerpCheck <= 1)
        {
            lerpCheck += Time.deltaTime / 2.5f;
            rend.material.color = Color.Lerp(oldCol, newCol, lerpCheck);
        }
    }
}
