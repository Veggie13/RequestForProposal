using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

    [SerializeField]
    private GameObject ServerCanvas;
    [SerializeField]
    private GameObject ServerMainPanel;
    [SerializeField]
    private GameObject ServerConfigPanel;
    [SerializeField]
    private GameObject ClientCanvas;
    [SerializeField]
    private GameObject ClientMainPanel;
    [SerializeField]
    private GameObject ClientConfigPanel;



    // Use this for initialization
    void Start () {
        ServerCanvas.SetActive(false);
        ServerMainPanel.SetActive(true);
        ServerConfigPanel.SetActive(false);
        ClientCanvas.SetActive(false);
        ClientMainPanel.SetActive(true);
        ClientConfigPanel.SetActive(false);

        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        if(Screen.width < Screen.height)
        {
            ClientCanvas.SetActive(true);
        }
        else if(Screen.width == 1600)
        {
            ClientCanvas.SetActive(true);
        }
        else
        {
            ServerCanvas.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
