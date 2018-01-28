using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HostScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartServer()
    {
        Debug.Log("Got Here");
        this.GetComponent<NetworkManager>().StartServer();
        this.GetComponent<NetworkManager>().ServerChangeScene("LobbyScene");

    }

    public void StopServer()
    {
        Debug.Log("Got Here Too");
        this.GetComponent<NetworkManager>().ServerChangeScene("TitleScene");
        this.GetComponent<NetworkManager>().StopServer();
        Destroy(gameObject);
    }

}
