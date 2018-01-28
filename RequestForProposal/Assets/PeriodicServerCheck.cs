using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicServerCheck : MonoBehaviour {

    // Use this for initialization
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("ServerCheck", 1.0f, 3.0f);
    }


    void UpdateText()
    {

    }

    }
