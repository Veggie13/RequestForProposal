using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HostScript : NetworkBehaviour {

    public
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartServer()
    {
        this.GetComponent<NetworkManager>().StartServer();
        this.GetComponent<NetworkManager>().ServerChangeScene("LobbyScene");

    }

    public void StopServer()
    {
        this.GetComponent<NetworkManager>().ServerChangeScene("TitleScene");
        this.GetComponent<NetworkManager>().StopServer();
        Destroy(gameObject);
    }

    public void StartClient()
    {
        //Debug.Log(this.GetComponent<NetworkManager>().networkAddress);
        //Debug.Log(this.GetComponent<NetworkManager>().networkPort);
        this.GetComponent<NetworkManager>().StartClient();
    }

    public void setIP(string netAddress)
    {
        this.GetComponent<NetworkManager>().networkAddress = netAddress;
    }

    public void setPort(string netPort)
    {
        this.GetComponent<NetworkManager>().networkPort =  int.Parse(netPort);
    }

    public void StartGame()
    {
        this.GetComponent<NetworkManager>().ServerChangeScene("EverythingScene");
    }

}
