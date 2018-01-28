using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextDots : MonoBehaviour {

    public Text waitingText;
    public int x = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateText", 1.0f, 1.0f);
	}
	

    void UpdateText()
    {
        if (x == 0)
        {
            waitingText.text = "WAITING FOR LOVERS.";
            x++;
            return;
        }
        else if (x == 1)
        {
            waitingText.text = "WAITING FOR LOVERS..";
            x++;
            return;
        }
        else if (x == 2)
        {
            waitingText.text = "WAITING FOR LOVERS...";
            x++;
            return;
        }
        else if (x == 3)
        {
            waitingText.text = "WAITING FOR LOVERS";
            x = 0;
            return;
        }
        else
            return;
    }

}
