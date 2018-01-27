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
            waitingText.text = "Waiting for Lovers.";
            x++;
            Debug.Log("x = 0");
        }
        if (x == 1)
        {
            waitingText.text = "Waiting for Lovers..";
            x++;
            Debug.Log("x = 1");
        }
        if (x == 2)
        { 
            waitingText.text = "Waiting for Lovers...";
            x++;
            Debug.Log("x = 2");
        }
        if (x == 3)
        {
            waitingText.text = "Waiting for Lovers...";
            x = 0;
            Debug.Log("x = 3");
        }
    }

}
