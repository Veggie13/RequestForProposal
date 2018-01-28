using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

    [SerializeField]
    private GameObject MainPanel;
    [SerializeField]
    private GameObject HostPanel;
    [SerializeField]
    private GameObject ConfigPanel;

    // Use this for initialization
    void Start () {
        MainPanel.SetActive(true);
        HostPanel.SetActive(false);
        ConfigPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
