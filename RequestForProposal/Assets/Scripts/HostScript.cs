using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HostScript : NetworkBehaviour {

    private float offset = -1;
    public GameObject Player1Prefab;
    public GameObject TitleMusic;
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
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.Stop();
        this.GetComponent<NetworkManager>().ServerChangeScene("SuitorScene");
    }

    public void SpawnPlayer()
    {
        Debug.Log("In Spawn Player");
        CmdSpawn();
    }

    [Command]
    public void CmdSpawn()
    {

        var Canvas = (GameObject)GameObject.Find("ServerCanvas");
        var Player = (GameObject)Instantiate(Player1Prefab, Canvas.transform.position, Canvas.transform.rotation);
        NetworkServer.Spawn(Player);
        Debug.Log("Am I getting here?");
        Player.transform.position = GameObject.Find("ServerCanvas").transform.position;
        //Player.transform.position = new Vector3(960, 540, 0);
        Debug.Log("What about here?");
    }


}
